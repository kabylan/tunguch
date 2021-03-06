﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AisMKIT.Models
{

    public class ListOfCinematographyDocuments
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string NameRus { get; set; }

        [Display(Name = "Дата регистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? RegistrationDate { get; set; }
 

        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
    public class ListOfCinematographyCertificates
    {
        public int Id { get; set; }

        [Display(Name = "Название фильма")]
        public string NameRus { get; set; }

        [Display(Name = "Название фильма (кырг.)")]
        public string NameKyrg { get; set; }

        
        // промежуточные таблицы для Стран и Режиссёров
        //public int? ListOfCinematographyCertificatesId { get; set; }
        [Display(Name = "Страна")]
        public List<CinemaCountries> CinemaCountries { get; set; }

        [Display(Name = "Режиссёр")]
        public List<CinemaRegisers> CinemaRegisers { get; set; }


        [Display(Name = "Год выпуска")]
        public string Years { get; set; }

        [Display(Name = "Продолжительность")]
        public int? DictCinemaDurationId { get; set; }

        [Display(Name = "Продолжительность")]
        public DictCinemaDuration DictCinemaDuration { get; set; }

        [Display(Name = "Возрастное ограничение")]
        public int? DictCinemaAgeRestrictionsId { get; set; }

        [Display(Name = "Возрастное ограничение")]
        public DictCinemaAgeRestrictions DictCinemaAgeRestrictions { get; set; }

         
        [Display(Name = "Дата выдачи удостоверения")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RegistrationDate { get; set; }
 
        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }

    public class ListOfCinematography
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string NameRus { get; set; }

        [Display(Name = "Наименование (кырг.)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Организационно-правовая форма")]
        public int? DictLegalFormId { get; set; }

        [Display(Name = "Организационно-правовая форма")]
        public DictLegalForm DictLegalForm { get; set; }

        [Display(Name = "ИНН")]
        public string INN { get; set; }

        [Display(Name = "Фамилия директора")]
        public string LastNameDirector { get; set; }

        [Display(Name = "Имя директора")]
        public string FirstNameDirector { get; set; }

        [Display(Name = "Отчество директора")]
        public string PatronicNameDirector { get; set; }
        [Display(Name = "Источник финансирования")]
        public int? DictFinSourceId { get; set; }

        [Display(Name = "Источник финансирования")]
        public DictFinSource DictFinSource { get; set; }

        [Display(Name = "Район")]
        public int? DictDistrictId { get; set; }

        [Display(Name = "Район")]
        public DictDistrict DictDistrict { get; set; }

        [Display(Name = "Юридический адрес")]
        public string LegalAddress { get; set; }
               
        [Display(Name = "Фактический район")]
        public string FactDistrictId { get; set; }

        [Display(Name = "Юридический адрес фактически")]
        public string LegalFactAddress { get; set; }
        
        [Display(Name = "Дата регистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? RegistrationDate { get; set; }

        [Display(Name = "Дата перерегистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? ReregistrationDate { get; set; }

        [Display(Name = "Дата ликвидации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DeactiveDate { get; set; }

        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }

    public class ListOfCinematographyHistory
    {
        public int Id { get; set; }
        public int ListOfCinematographyId { get; set; }
        public ListOfCinematography ListOfCinematography { get; set; }

        [Display(Name = "Наименование")]
        public string NameRus { get; set; }

        [Display(Name = "Наименование (кырг.)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Организационно-правовая форма")]
        public int? DictLegalFormId { get; set; }

        [Display(Name = "Организационно-правовая форма")]
        public DictLegalForm DictLegalForm { get; set; }

        [Display(Name = "ИНН")]
        public string INN { get; set; }

        [Display(Name = "Фамилия директора")]
        public string LastNameDirector { get; set; }

        [Display(Name = "Имя директора")]
        public string FirstNameDirector { get; set; }

        [Display(Name = "Отчество директора")]
        public string PatronicNameDirector { get; set; }
        [Display(Name = "Источник финансирования")]
        public int? DictFinSourceId { get; set; }

        [Display(Name = "Источник финансирования")]
        public DictFinSource DictFinSource { get; set; }

        [Display(Name = "Район")]
        public int? DictDistrictId { get; set; }

        [Display(Name = "Район")]
        public DictDistrict DictDistrict { get; set; }

        [Display(Name = "Юридический адрес")]
        public string LegalAddress { get; set; }

        [Display(Name = "Фактический район")]
        public string FactDistrictId { get; set; }

        [Display(Name = "Юридический адрес фактически")]
        public string LegalFactAddress { get; set; }

        [Display(Name = "Дата регистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? RegistrationDate { get; set; }

        [Display(Name = "Дата перерегистрации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? ReregistrationDate { get; set; }

        [Display(Name = "Дата ликвидации")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DeactiveDate { get; set; }

        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
    
    public class ListOfCinematographyServices
    {
        public int Id { get; set; }
        [Display(Name = "Услуги")]
        public int DictCinematographyServicesId { get; set; }
        [Display(Name = "Услуги")]
        public DictCinematographyServices DictCinematographyServices { get; set; }

        public int ListOfCinematographyId { get; set; }
        public ListOfCinematography ListOfCinematography { get; set; }
        [Display(Name = "Статус")]

        public int DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }
        [Display(Name = "Дата прекарщения услуги")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DeactivateStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }

    public class DictCinematographyServices
    {
        public int Id { get; set; }

        [Display(Name = "Наименование (Кырг)")]
        public string NameKyrg { get; set; }

        [Display(Name = "Наименование")]
        public string NameRus { get; set; }
        [Display(Name = "Статус")]
        public int? DictStatusId { get; set; }
        [Display(Name = "Статус")]
        public DictStatus DictStatus { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class DictCinemaAgeRestrictions
    {
        public int Id { get; set; }

        [Display(Name = "Возрастное ограничение")]
        public string Name { get; set; }

    }

    public class DictCinemaRegiser
    {
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string Patronic { get; set; }

        public string FullName { get { return LastName + " " + FirstName; } set { } }
    }

    public class DictCinemaDuration
    {
        public int Id { get; set; }

        [Display(Name = "Продолжительность")]
        public string Name { get; set; }

    }
    
    public class CinemaCountries
    {
        public int Id { get; set; }

        [Display(Name = "Фильм")]
        public int? ListOfCinematographyCertificatesId { get; set; }
        
        [Display(Name = "Фильм")]
        public ListOfCinematographyCertificates ListOfCinematographyCertificates { get; set; }

        [Display(Name = "Страна")]
        public int? DictCountryId { get; set; }

        [Display(Name = "Страна")]
        public DictCountry DictCountry { get; set; }
    }

    public class CinemaRegisers
    {
        public int Id { get; set; }

        [Display(Name = "Фильм")]
        public int? ListOfCinematographyCertificatesId { get; set; }

        [Display(Name = "Фильм")]
        public ListOfCinematographyCertificates ListOfCinematographyCertificates { get; set; }

        [Display(Name = "Режиссер")]
        public int? DictCinemaRegiserId { get; set; }

        [Display(Name = "Режиссер")]
        public DictCinemaRegiser DictCinemaRegiser { get; set; }
    }


    public class JsonData
    {
        public int[] countries { get; set; }
        public int[] regisers { get; set; }

    }
}
