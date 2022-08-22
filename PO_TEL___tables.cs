﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfToyDataForms
{


    [Table("TEL_VID_CONNECT")]
    public class PO_TEL_VID_CONNECT
    {
        [Required]
        [Key]
        [Column("ID_CONNECT")]
        public int IDConnect
        { // ID_CONNECT   - идентификатор вида связи
            get;
            set;
        }

        [Column("KOD_CONNECT")]
        [MaxLength(1)]
        public string KodOfConnect
        { // KOD_CONNECT  - код вида связи
            get;
            set;
        }

        [Column("NAME_CONNECT")]
        [MaxLength(50)]
        public string NameOfConnect
        { // MAME_CONNECT - наименование связи
            get;
            set;
        }

        //public ICollection<PO_TEL_OPERATOR> TelefonOperators { get; set; }
        public virtual ObservableCollection<PO_TEL_OPERATOR>? TelefonOperators { get; set; }


        public PO_TEL_VID_CONNECT()
        {
            this.IDConnect = 0;
            this.KodOfConnect = string.Empty;
            this.NameOfConnect = string.Empty;
            //this.TelefonOperators = new List<PO_TEL_OPERATOR>();
            this.TelefonOperators = new ObservableCollection<PO_TEL_OPERATOR>();
        }

    }

    [Table("TEL_OPERATOR")]
    public class PO_TEL_OPERATOR
    { //
        [Required]
        [Key]
        [Column("ID_OPERATOR")]
        public int IDOperator
        { // ID_OPERATOR  - идентификатор операторв связи
            get;
            set;
        }

        [Column("KOD_OPERATOR")]
        [MaxLength(2)]
        public string? KodOfOperator
        { // KOD_OPERATOR - код оператора связи
            get;
            set;
        }

        [Column("NAME_OPERATOR")]
        [MaxLength(50)]
        public string? NameOfOperator
        { // NAME_OPERATOR - наименование оператора связи
            get;
            set;
        }

        public int? ID_BK
        { // ID_BK - идентификатор бюджет кода
            get;
            set;
        }

        [Column("ID_CONNECT")]
        public int? IDConnect
        {
            get;
            set;
        }


        [Column("ID_KAGENT")]
        public int? IDKagent
        { // ID_KAGENT  - идентификатор контрагента
            get;
            set;
        }

        [Column("NOM_DOG")]
        [MaxLength(22)]
        public string? NumberOfContract
        { // NOM_DOG  - номер договора
            get;
            set;
        }

        [Column("DATE_DOG")]
        public DateTime DateOfContract
        { // DATE_DOG - дата договора,  преобразование типов ...
            get;
            set;
        }

        public PO_TEL_VID_CONNECT? ParentIDConnect
        { // ID_CONNECT  ссылка на вид связи
            get;
            set;
        }
    }

    [Table("TEL_MOB_SPR___OLD")]
    public class PO_TEL_MOB_SPR
    {
        [Required]
        [Key]
        [Column("ID_MOB_TEL")]
        public int IDOfCellPhone
        {   //  ID_MOB_TEL  integer
            get;
            set;
        }
        [Column("NOM_TEL")]
        [MaxLength(12)]
        public string Phone
        {  //   NOM_TEL  char(12)
            get;
            set;
        }
        [Column("FIO")]
        [MaxLength(100)]
        public string Fio
        {   //   FIO  varchar(100)
            get;
            set;
        }
        [Column("TARIF")]
        [MaxLength(50)]
        public string Tarif
        {   //  TARIF  varchar(50)
            get;
            set;
        }
        [Column("LIMIT")]
        public decimal Limit
        {   //  LIMIT  double precision
            get;
            set;
        }
        [Column("PR_ROUMING")]
        [MaxLength(1)]
        public string RoumingSet
        {   //  PR_ROUMING  char(1)
            get;
            set;
        }
        [Column("DATE_BEGIN")]
        public DateTime BeginOf
        {   //  DATE_BEGIN  timestamp
            get;
            set;
        }
        [Column("DATE_END")]
        public DateTime EndOf
        {   //  DATE_END   timestamp
            get;
            set;
        }
        [Column("ID_OPERATOR")]
        public int IDOperator
        {  //  ID_OPERATOR  integer
            get;
            set;
        }
        [Column("ID_PODR")]
        public int IDDepartment
        {   //  ID__PODR  integer
            get;
            set;
        }
        [Column("VID_TEL")]
        [MaxLength(1)]
        public string PhoneType
        {   //  VID_TEL  char(1)
            get;
            set;
        }
        [Column("DATE_INS")]
        public DateTime WhenInserted
        {   //  DATE_INS  timestamp
            get;
            set;
        }
        [Column("DATE_IZM")]
        public DateTime WhenEdited
        {   //  DATE_IZM  timestamp
            get;
            set;
        }
        [Column("ID_USER_INS")]
        public int IDWhoInserted
        {   //  ID_USER_INS  integer
            get;
            set;
        }
        [Column("ID_USER_IZM")]
        public int IDWhoEdited
        {   //  ID_USER_IZM  integer
            get;
            set;
        }
        [Column("DOLGNOST")]
        [MaxLength(200)]
        public string JobTitle
        {   //  DOLGNOST  varchar(200)
            get;
            set;
        }
        [Column("PRIMECH")]
        [MaxLength(150)]
        public string NoteComment
        {   //  PRIMECH  varchar(150)
            get;
            set;
        }
        [Column("NAIM")]
        [MaxLength(1)]
        public string PhoneTypeTogle
        {   //  NAIM  char(1)
            get;
            set;
        }
        [Column("NDS")]
        [MaxLength(1)]
        public string Nds
        {   //  NDS  char(1)
            get;
            set;
        }
        [Column("PF")]
        [MaxLength(1)]
        public string Pf
        {   //  PF  char(1)
            get;
            set;
        }
        [Column("TAB_NOM")]
        [MaxLength(4)]
        public string TabelNumber
        {   //  TAB_NOM  char(4)
            get;
            set;
        }
        [Column("PR_UVOL")]
        [MaxLength(1)]
        public string FiredSign
        {   //  PR_UVOL  char(1)
            get;
            set;
        }
        [Column("CEX_MVZ")]
        [MaxLength(3)]
        public string Mvz
        {   //  CEX_MVZ  char(3)
            get;
            set;
        }
        [Column("PR")]
        [MaxLength(1)]
        public string Pr
        {   //  PR  char(1)
            get;
            set;
        }
        [Column("NOM_KART")]
        [MaxLength(8)]
        public string CardNumber
        {   //  NOM_KART  varchar(8)
            get;
            set;
        }
        [Column("PERNR")]
        public int Pernr
        {   //  PERNR  integer
            get;
            set;
        }
        [Column("DATE_PEREM")]
        public DateTime Perem
        {   //  DATE_PEREM  date
            get;
            set;
        }
    }

}
