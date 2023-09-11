﻿using System.Text.Json;

using System.Text;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Mvc;

namespace VGR_WebAPI
{
    public class DTO : IDTO
    {
        
        public List_of_Data? list = new List_of_Data();
        
        public List<string> list_of_names = new List<string>();
        public DTO()
        {
            
        }

        public void insert(List_of_Data data)
        {
            insert_buyer(data);
            insert_status(data);
            insert_project(data);
            insert_files(data);
            insert_datacollection(data);
            
            //get_mailadress(data);

        }

        private void insert_buyer(List_of_Data data)
        {
            Bestallning_av_data bestallning_Av_Data = new Bestallning_av_data()
            {
                Bestallare_Namn = data.Bestallare_Namn,
                Bestallare_Adress = data.Bestallare_Adress,
                Bestallare_Epostadress = data.Bestallare_Epostadress,
                Bestallare_Mobiltelefon = data.Bestallare_Mobiltelefon,
                Bestallare_Organisation = data.Bestallare_Organisation,
                Bestallare_Titel_och_Roll = data.Bestallare_Titel_och_Roll,
                Bestallare_Fak_Adress = data.Bestallare_Fak_Adress,
                Bestallare_Fak_Org = data.Bestallare_Fak_Org,
                Bestallare_Fak_Referens = data.Bestallare_Fak_Referens,
                Bestallare_Postnummer = data.Bestallare_Postnummer,
                Bestallare_Postort = data.Bestallare_Postort,
                Huvudans_Epostadress = data.Huvudans_Epostadress,
                Huvudans_Mobiltelefon = data.Huvudans_Mobiltelefon,
                Huvudans_Namn = data.Huvudans_Namn,
                Huvudans_Organisation = data.Huvudans_Organisation,
                Insertdatetime = DateTime.Now,
                Updatedatetime = DateTime.Now,
            };

            //get_mailadress(data);

            Database database = new Database();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            database.bestallning_Av_Data.Add(bestallning_Av_Data);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            database.SaveChanges();

            var select_user_id = (from user in database.bestallning_Av_Data
                                  select user.ID).Max();
            if (select_user_id > 1)
            {
                data.ID = select_user_id;
            }
            else
                data.ID = 1;
        }

        private void insert_status(List_of_Data data)
        {
            Database database = new Database();
            
            Status status = new Status();

            status.Bestallare_id = data.ID;
            status.Status_ = "Inkommande";
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            database.status.Add(status);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            database.SaveChanges();   
        }

        private void insert_project(List_of_Data data)
        {
            Forskningsprojekt forskningsprojekt = new Forskningsprojekt();


            forskningsprojekt.Projektbeskrivning = data.Projektbeskrivning;
            forskningsprojekt.Projekttitel = data.Projekttitel;
            forskningsprojekt.Lakemedelstudier = data.Lakemedelstudier;
            forskningsprojekt.Samarbete_Med_Industrin = data.Samarbete_Med_Industrin;
            forskningsprojekt.User_ID = data.ID;
            forskningsprojekt.Diarienummer = data.Diarienummer;
            forskningsprojekt.Andringansökan_Diarienummer = data.Andringansokan_Diarienummer;
            //if (data.Avtal_Industri != null)
            //{
            //    forskningsprojekt.Avtal_Industri = get_file(data);
            //}

            Database database = new Database();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            database.forskningsprojekts.Add(forskningsprojekt);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            database.SaveChanges();



        }

        private void insert_datacollection(List_of_Data data)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            foreach(var d in data.Array.ToList())
            {
                Datauttag datauttag =new Datauttag();
                Database database= new Database();
                
                string json =JsonSerializer.Serialize(d);
                datauttag.data = json;
                datauttag.User_ID = data.ID;
                database.datauttag.Add(datauttag);
                database.SaveChanges();
            }
#pragma warning restore CS8604 // Possible null reference argument.

        }

        private void insert_files(List_of_Data data)
        {
            list_of_names = get_file_names();

            
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", data.PUB_Avtal[0].FileName);
            if (data.PUB_Avtal != null)
            {
                MemoryStream stream = new MemoryStream();
                data.PUB_Avtal.CopyTo(stream);
                string filename = data.PUB_Avtal.FileName;
                long Id = data.ID;

                get_file(stream, filename, Id);
                stream.Close();
                stream.Flush();
            }

            if (data.Kompletta_handlingar_Fil != null)
            {
                MemoryStream stream = new MemoryStream();
                data.Kompletta_handlingar_Fil.CopyTo(stream);
                string filename = data.Kompletta_handlingar_Fil.FileName;
                long Id = data.ID;

                get_file(stream, filename, Id);
                stream.Close();
                stream.Flush();
            }

            if (data.Ansokan_Fil != null)
            {
                MemoryStream stream = new MemoryStream();
                data.Ansokan_Fil.CopyTo(stream);
                string filenameWithExtension = Path.GetExtension(data.Ansokan_Fil.FileName);


                string filename = list_of_names[12] + filenameWithExtension;
                long Id = data.ID;

                get_file(stream, filename, Id);
                stream.Close();
                stream.Flush();
            }

            if (data.Beslut_Fil != null)
            {
                MemoryStream stream = new MemoryStream();
                data.Beslut_Fil.CopyTo(stream);
                string filenameWithExtension = Path.GetExtension(data.Beslut_Fil.FileName);


                string filename = list_of_names[18] + filenameWithExtension;
                long Id = data.ID;

                get_file(stream, filename, Id);
                stream.Close();
                stream.Flush();
            }

            if (data.Komplettering_Fil != null)
            {
                foreach (var files in data.Komplettering_Fil)
                {
                    MemoryStream stream = new MemoryStream();
                    files.CopyTo(stream);
                    string filenameWithExtension = Path.GetExtension(files.FileName);


                    string filename = list_of_names[14] + filenameWithExtension;

                    long Id = data.ID;

                    get_file(stream, filename, Id);
                    stream.Close();
                    stream.Flush();
                }
            }

            if (data.Andringansokan_Fil != null)
            {
                MemoryStream stream = new MemoryStream();
                data.Andringansokan_Fil.CopyTo(stream);
                string filenameWithExtension = Path.GetExtension(data.Andringansokan_Fil.FileName);


                string filename = list_of_names[13] + filenameWithExtension;
                long Id = data.ID;

                get_file(stream, filename, Id);
                stream.Close();
                stream.Flush();
            }

            if (data.Beslut_Andringansokan != null)
            {
                MemoryStream stream = new MemoryStream();
                data.Beslut_Andringansokan.CopyTo(stream);
                string filenameWithExtension = Path.GetExtension(data.Beslut_Andringansokan.FileName);


                string filename = list_of_names[19] + filenameWithExtension;
                long Id = data.ID;

                get_file(stream, filename, Id);
                stream.Close();
                stream.Flush();
            }

            if (data.Projektbeskrivning_fil != null)
            {
                MemoryStream stream = new MemoryStream();
                data.Projektbeskrivning_fil.CopyTo(stream);
                string filename = data.Projektbeskrivning_fil.FileName;
                long Id = data.ID;

                get_file(stream, filename, Id);
                stream.Close();
                stream.Flush();
            }

            if (data.Avtal_Industri != null)
                {
                    MemoryStream stream = new MemoryStream();
                    data.Avtal_Industri.CopyTo(stream);
                    string filename= data.Avtal_Industri.FileName;
                    long Id = data.ID;
                    
                    get_file(stream, filename, Id);
                    stream.Close();
                    stream.Flush();
                }

            if(data.Variabellista!=null)
            {
                foreach (var v in data.Variabellista)
                {
                    MemoryStream stream = new MemoryStream();
                    v.CopyTo(stream);
                    string filename = v.FileName;
                    long Id = data.ID;

                    get_file(stream, filename, Id);
                    stream.Close();
                    stream.Flush();
                }
            }
        }

        private void get_mailadress(List_of_Data data) => Mail.mail(data);


        public byte[] get_file(List_of_Data data)
        {
            MemoryStream stream = new MemoryStream();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            data.Projektbeskrivning_fil.CopyTo(stream);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            byte[] imageData;

            imageData = stream.GetBuffer();

            return imageData;
        }

        public void mail(string mailaddress)
        {
           
            
            //Mail.mail("mikael.jonsson@vgregion.se");
        }

        private void get_file(MemoryStream stream, string filename, long id)
        {
            byte[] imageData;

            imageData = stream.GetBuffer();
            Filer filer = new Filer()
            {
                FormFile = imageData,
                FileName = filename,
                User_ID = id
            };

            Database database = new Database();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            database.filers.Add(filer);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            database.SaveChanges();
        }

        public string get_requests()
        {
            
            try
            {
                Database database = new Database();

                
                var request = from request_ in database.bestallning_Av_Data
                              from beslut_ in database.beslut
                              from status_ in database.status
                              where request_.ID == beslut_.Bestallare_id
                              select new
                              {
                                  Ststus = status_.Status_,
                                  Beslut = beslut_.Beslut_,
                                  request_.ID,
                                  request_.Bestallare_Namn,
                                  request_.Insertdatetime
                              };
                              
                
                
                System.IO.File.AppendAllText("D:\\Check.txt", "Test3");

                return JsonSerializer.Serialize(request);

            }
            catch(Exception e) 
            {
                System.IO.File.AppendAllText("D:\\Check.txt", e.Message.ToString()+"   "+e.ToString());
            }
            return "Failure";
        }

        public string get_request_id(int id)
        {

            Database db = new Database();

            var beställningData = db.bestallning_Av_Data;
            var beslut = db.beslut;
            var status = db.status;


            
#pragma warning disable CS8604 // Possible null reference argument.
            var resultBestallning = beställningData.FirstOrDefault(x => x.ID == id);
#pragma warning restore CS8604 // Possible null reference argument.
   
#pragma warning disable CS8604 // Possible null reference argument.
            var resultBeslut = beslut.FirstOrDefault(x => x.Bestallare_id == id);
#pragma warning restore CS8604 // Possible null reference argument.
            
#pragma warning disable CS8604 // Possible null reference argument.
            var resultStatus = status.FirstOrDefault(x=>x.Bestallare_id == id);
#pragma warning restore CS8604 // Possible null reference argument.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            resultBestallning.Beslut = resultBeslut;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            resultBestallning.Status = resultStatus;


            return JsonSerializer.Serialize(resultBestallning).ToString();
        }

        public string get_filename(int id)
        {
            Database db = new Database();

#pragma warning disable CS8604 // Possible null reference argument.
            var request = (from files in db.filers
                           join request_ in db.bestallning_Av_Data on files.User_ID equals request_.ID
                           where request_.ID == id

                           select new
                           {

                               files.FileName,
                               files.User_ID
                           });
#pragma warning restore CS8604 // Possible null reference argument.


            return JsonSerializer.Serialize(request).ToString();
        }

        public string get_datacollection(int id)
        {
            Database db = new Database();

#pragma warning disable CS8604 // Possible null reference argument.
            var request = (from datauttag in db.datauttag
                           join request_ in db.bestallning_Av_Data on datauttag.User_ID equals request_.ID
                           where request_.ID == id

                           select new
                           {
                               datauttag.data
                               
                           });
#pragma warning restore CS8604 // Possible null reference argument.


            return JsonSerializer.Serialize(request).ToString();
        }

        public string get_register(int id)
        {
            Database db = new Database();

            var request = from register in db.Register
                          where register.Place_ID == id
                          select register;

            return JsonSerializer.Serialize(request).ToString();
        }

        public string get_goverment()
        {
            Database db = new Database();

            var request = from omrade in db.omraden
                          select omrade;

            return JsonSerializer.Serialize(request).ToString();
        }

        public Stream get_file(string filename, int user_id)
        {
            Database db = new Database();

            var request = (from file in db.filers
                           where file.FileName == filename && 
                           file.User_ID == user_id
                           select new
                           {
                               file.FormFile
                           }).Single();

            //dynamic json = JsonSerializer.Serialize(request.FormFile);

            var stream = new MemoryStream();
            var g = request.FormFile;
            File.WriteAllBytes("D:\\gg.txt", g);
            //byte[] read = File.ReadAllBytes("D:\\gg.txt");
            stream = new MemoryStream(g);
            return stream;
        }

        public string get_names()
        {
            Database db = new Database();

            var request = from names in db.filnamn

                          select new
                          {
                              names.Namn
                          };

             string json = JsonSerializer.Serialize(request);

            
            return json;
        }

        public string get_mail_templates()
        {
            Database db = new Database();

            var request = from get_mail_templates in db.mailmall

                          select new
                          {
                              get_mail_templates.Amne,
                              get_mail_templates.Meddelande
                          };

            //dynamic json = JsonSerializer.Serialize(request.FormFile);

            
            string json = JsonSerializer.Serialize(request);
            return json;
        }

        public string get_project(int user_id)
        {
            Database db = new Database();

            var request = from project in db.forskningsprojekts
                          where project.User_ID == user_id
                          select new
                          {

                              project.Projektbeskrivning,
                              project.Lakemedelstudier,
                              project.Diarienummer,
                              project.Samarbete_Med_Industrin
                          };

            string json = JsonSerializer.Serialize(request); return json;
        }

        public void rename_file(string oldFilename, string newFilename, int user_id)
        {
            Database db = new Database();

            var request = (from file in db.filers
                           where file.FileName == oldFilename &&
                           file.User_ID == user_id
                           select file).SingleOrDefault();

            if (request != null)
            {
                request.User_ID = user_id;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string filenamewithExtension = Path.GetExtension(request.FileName);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                request.FileName = newFilename + filenamewithExtension;
                db.SaveChanges();
            }
        }

        private List<string> get_file_names()
        {
            Database db = new Database();
            List<string> name = new List<string>();
            var request = from filnamn_ in db.filnamn
                          select new
                          {
                              names = filnamn_.Namn
                          };

            foreach(var n in request) 
            {
                name.Add(n.names);
            }

            return name;
        }

        
    }
}

