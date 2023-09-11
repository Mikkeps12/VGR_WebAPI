using Microsoft.Win32;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Configuration;
using System.ComponentModel.DataAnnotations.Schema;

namespace VGR_WebAPI
{
    public class Database : DbContext
    {

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Database() : base(System.Configuration.ConfigurationManager.ConnectionStrings["VGRT"].ConnectionString)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            
        }
        public DbSet<Register>? Register { get; set; }
        public DbSet<Logg>? Logg { get; set; }
        public DbSet<Bestallare>? bestallare { get; set; }
        public DbSet<Bestallning_av_data>? bestallning_Av_Data { get; set; }
        public DbSet<Status>? status { get; set; }
        public DbSet<Diarie>? diarie { get; set; }
        public DbSet<Beslut>? beslut { get; set; }
        public DbSet<Avgift>? avgift { get; set; }
        public DbSet<Uttagsformat>? uttagsformat { get; set; }
        public DbSet<Sprak>? sprak { get; set; }
        public DbSet<Inloggningsuppgifter>? inloggningsuppgifter { get; set; }

        public DbSet<Forskningsprojekt>? forskningsprojekts { get; set; }

        public DbSet<Filer>? filers { get; set; }
        public DbSet<Datauttag> datauttag { get; set; }
        public DbSet<Omraden> omraden { get; set; }

        public DbSet<Filnamn> filnamn { get; set; }
        public DbSet<Mailmall> mailmall { get; set; }

    }

    public class Filnamn
    {
        public long ID { get; set; }
        public string? Namn { get; set; }
    }

    public class Mailmall
    {
        public long ID { get; set; }
        public string? Amne { get; set; }
        public string? Meddelande { get; set; }
    }


    public class Datauttag
    {
        public Datauttag()
        {
            
        }
        [Key]
        public long ID { get; set; }
        public string? data { get; set; }
        public long User_ID { get; set; }
    }

    public class Omraden
    {
        public Omraden()
        {
            
        }

        [Key]
        public long ID { get; set; }
        public string? Omrade { get; set; }
        public long Place_ID { get; set; }
    }

    public class Register
    {
        public Register() { }
        
        [Key]
        public long ID { get; set; }
        public string? Datauttagsnamn { get; set; }
        public long Place_ID { get; set; }
        public string? Fullstandigt_Namn { get; set; }
    }

    public class Filer
    {
        public Filer() { }
        
        [Key]
        public long ID { get; set; }
        public string? FileName{ get; set; }
        public byte[]? FormFile { get; set; }

        public long User_ID { get; set; }



        //public long Dokument_ID { get; set; }
    }

    public class Logg
    {
        [Key]
        public long ID { get; set; } = 0;
        public int Logg_Personnr { get; set; }
        public DateTime Logg_nowdate { get; set; }
        public string? Logg_Page { get; set; }
        public long Logg_Bestallar_id { get; set; }
    }

    public class Bestallare
    {
        [Key]
        public long ID { get; set; }
        public string? Bestallare_Epostadress { get; set; }
        public string? Diarie { get; set; }
        public DateTime Date { get; set; }
        public DateTime Insertdatetime { get; set; }
        public DateTime Updatedatetime { get; set; }
    }

    public class Bestallning_av_data
    {
        [Key]
        public long ID { get; set; }
        public long Bestallar_id { get; set; }
        //public long Register_id { get; set; }
        public DateTime Insertdatetime { get; set; }
        public DateTime Updatedatetime { get; set; }
        public string? Bestallare_Namn { get; set; }
        public string? Bestallare_Titel_och_Roll { get; set; }
        public string? Bestallare_Organisation { get; set; }
        public string? Bestallare_Adress { get; set; }
        public string? Bestallare_Mobiltelefon { get; set; }
        public string? Bestallare_Epostadress { get; set; }
        
        public string? Bestallare_Fak_Adress { get; set; }
        public string? Bestallare_Fak_Org { get; set; }
        public string? Bestallare_Fak_Referens { get; set; }
        public string? Bestallare_Postnummer { get; set; }
        public string? Bestallare_Postort { get; set; }
        public string? Huvudans_Namn { get; set; }

        public string? Huvudans_Epostadress { get; set; }
        public string? Huvudans_Mobiltelefon { get; set; }
        public string? Huvudans_Organisation { get; set; }
        [NotMapped]
        public Beslut? Beslut { get; set; }
        [NotMapped]
        public Status? Status { get; set; }
        //public IFormFile? PUB_Avtal { get; set; }
        //public string? Mottagare_mobiltelefon { get; set; }
        //public string? Mottagare_Epostadress { get; set; }

        //public string? Avgiftsalternativ { get; set; }
        //public int FilformatID { get; set; }
        //public string? Filformat_annat { get; set; }
        //public string? Mottagare_Organisation { get; set; }
        //public string? Mottagare_mobiltelefon2 { get; set; }
        //public string? Mottagare_Epostadress2 { get; set; }


    }

    public class Forskningsprojekt
    {
        public long ID { get; set; }
        public string? Projekttitel { get; set; }
        public string? Projektbeskrivning { get; set; }
        //public byte[]? Projektbeskrivning_Fil { get; set; }
        public string? Diarienummer { get; set; }
        public string? Andringansökan_Diarienummer { get; set; }
        //public byte Andringansökan_Fil { get; set; }
        //public byte Beslut_Andringansokan { get; set; }

        public string? Lakemedelstudier { get; set; }
        public string? Samarbete_Med_Industrin { get; set; }
        //public byte[]? Avtal_Industri { get; set; }
        public long User_ID { get;set; }

    }
    public class Status
    {
        [Key]
        public long ID { get; set; }
        public string? Status_ { get; set; }

        public long Bestallare_id { get; set; }
    }

    public class Diarie
    {
        [Key]
        public long ID { get; set; }
        public string? DiarieStatus { get; set; }

        public long Bestallare_id { get; set; }
    }

    public class Beslut
    {
        [Key]
        public long ID { get; set; }
        public string? Beslut_ { get; set; }

        public long Bestallare_id { get; set; }
    }

    public class Avgift
    {
        [Key]
        public long ID { get; set; }
        public string? Avgiftsalternativ { get; set; }

        public long Bestallare_id { get; set; }

    }

    public class Uttagsformat
    {
        [Key]
        public long ID { get; set; }
        public string? Uttagsformat_ { get; set; }

        public long Bestallare_id { get; set; }

    }

    public class Sprak
    {
        [Key]
        public long ID { get; set; }
        public string? Sprak_ { get; set; }
        public string? options { get; set; }
    }

    public class Inloggningsuppgifter
    {
        [Key]
        public long ID { get; set; }
        public string? Epostadress { get; set; }
        public string? Losenord { get; set; }
        public DateTime Insertdatetime { get; set; }
        public DateTime Updatedatetime { get; set; }


    }

    public class List_of_Data
    {

        public long ID { get; set; }
        //public long Bestallar_id { get; set; }
        //public long Register_id { get; set; }
        //public DateTime Insertdatetime { get; set; }
        //public DateTime Updatedatetime { get; set; }
        public string? Bestallare_Namn { get; set; }
        public string? Bestallare_Titel_och_Roll { get; set; }
        public string? Bestallare_Organisation { get; set; }
        public string? Bestallare_Adress { get; set; }
        public string? Bestallare_Mobiltelefon { get; set; }
        public string? Bestallare_Epostadress { get; set; }
        public string? Bestallare_Fak_Adress { get; set; }
        public string? Bestallare_Fak_Org { get; set; }
        public string? Bestallare_Fak_Referens { get; set; }
        public string? Bestallare_Postnummer { get; set; }
        public string? Bestallare_Postort { get; set; }
        public string? Huvudans_Namn { get; set; }

        public string? Huvudans_Epostadress { get; set; }
        public string? Huvudans_Mobiltelefon { get; set; }
        public string? Huvudans_Organisation { get; set; }

        public IFormFile? PUB_Avtal { get; set; }
        //public string? Mottagare_mobiltelefon { get; set; }
        //public string? Mottagare_Epostadress { get; set; }

        //public string? Avgiftsalternativ { get; set; }
        //public int FilformatID { get; set; }
        public string? Filformat_annat { get; set; }
        //public string? Mottagare_Organisation { get; set; }
        //public string? Mottagare_mobiltelefon2 { get; set; }
        //public string? Mottagare_Epostadress2 { get; set; }
        public string? Diarienummer { get; set; }
        public string? Andringansokan_Diarienummer { get; set; }
        public string? Projekttitel { get; set; }
        public string? Projektbeskrivning { get; set; }

        public IFormFile? Projektbeskrivning_fil { get; set; }

        public string? Lakemedelstudier { get; set; }

        public string? Samarbete_Med_Industrin { get; set; }
        public IFormFile? Avtal_Industri { get; set; }

        public IFormFile? Ansokan_Fil { get; set; }

        public IFormFile? Beslut_Fil { get; set; }

        public IFormFile? Kompletta_handlingar_Fil { get; set; }

        public IFormFile? Andringansokan_Fil { get; set; }

        public IFormFile? Beslut_Andringansokan { get; set; }

        public List<IFormFile>? Komplettering_Fil { get; set; }

        
        public List<IFormFile>? Variabellista { get; set; }
    
        //public string? Datakalla { get; set; }

        //public DateTime? Fran_Datum { get; set; }
        //public DateTime? Till_Datum { get; set;}

        // public string? Kon { get; set;}

        //public DateTime? Fran_Alder { get; set; }
        //public DateTime? Till_Alder { get; set;}

        //public string? Variabelista { get; set;}


        //public List<IFormFile> A { get; set; }
        public string[]? Array { get; set; }
    }

    public class Arra
    {
        public Arra()
        {
            
        }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? Goverment { get; set; }
        public string? Register { get; set; }
        public string? DateInterval { get; set; }

        public string? Gender { get; set; }

        public string? SelectSelection { get; set; }
        public string? Additional { get; set; }
        public string? DataDelivered { get; set; }
        public string? AgeFrom { get; set; }
        public string? AgeTo { get; set; }
        public string? DescriptionOfVariables { get; set; }
        public string? FileFormat { get; set; }
        public string? AgeInterval { get; set; }
        public string? NameDatasources { get; set; }
        public string? Name { get; set; }
        public string? Organization { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string? ProcessOfSync { get; set; }
        public string? SyncRegisterFromOtherSources { get; set; }

        public string? SyncRegistersWithFile { get; set; }

        public string? WhichVariables { get; set; }
        //public IFormFile? V { get; set; }

    }

    public class RenameFileData
    {
        public string? newFilename { get; set; }
        public string? oldFilename { get; set; }
    }

    public class Data
    {
        public List<IFormFile>? fIles { get; set; }
        public string[]? CustomData { get; set; }
    }
}


