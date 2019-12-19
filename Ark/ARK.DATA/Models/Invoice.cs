using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARK.DATA.Models
{
    public class Invoice : BaseModel.BaseData
    {
        public int ID { get; set; }


        //Fatura Bilgileri
        [MaxLength(8)]
        public string InvoiceSerial { get; set; } //fatura seri no
        public int? InvoiceNo { get; set; } //fatura sıra no

        public int? LastPaymentDate { get; set; } //son ödeme tarihi
        [MaxLength(8)]
        public string PeriodMonth { get; set; } // hizmet verilen ay
        [MaxLength(8)]
        public string PeriodDay { get; set; }// hizmet verilen gün
        [MaxLength(8)]
        public string PeriodYear { get; set; }// hizmet verilen yıl

        public int? NextInvoiceDate { get; set; } //bir sonraki fatura tarihi
        public int? NextLastPaymentDate { get; set; } // bir sonraki fatura son ödeme

        [MaxLength(512)]
        public string AmountByLetter { get; set; } // harf ile fiyat bilgisi

        [MaxLength(1024)]
        public string Description { get; set; } // gizli not , faturada gösterilmez

        public bool IsVatExempt { get; set; } // kdv den muaf mı
        public int? PrintDate { get; set; } // yazdırma tarihi

        [Column(TypeName = "decimal(18,4)")]
        public decimal? Amount { get; set; } // net tutar

        [Column(TypeName = "decimal(18,4)")]
        public decimal? TotalAmount { get; set; } // brüt tutar

        [Column(TypeName = "decimal(18,4)")]
        public decimal? PayedAmount { get; set; } // ödenen tutar

        [Column(TypeName = "decimal(18,4)")]
        public decimal? VatAmount { get; set; } //kdv tutarı

        public string VatRate { get; set; } // kdv oranı

        [Column(TypeName = "decimal(18,4)")]
        public decimal? TaxAmount { get; set; } // vergi tutarı

        public string TaxRate { get; set; } // vergi oranı

        [Column(TypeName = "decimal(18,4)")]
        public decimal? TaxOivAmount { get; set; } //oiv tutarı

        public string TaxOivRate { get; set; } // oiv oranı

        [Column(TypeName = "decimal(18,4)")]
        public decimal? OtherTaxAmount { get; set; } //diğer vergiler

        [Column(TypeName = "decimal(18,4)")]
        public decimal? TotalAmountWithoutTax { get; set; } //vergisiz tutar

        [Column(TypeName = "decimal(18,4)")]
        public decimal? RoundedAmount { get; set; } //yuvarlanmış tutar

        [Column(TypeName = "decimal(18,4)")]
        public decimal? OpenAmount { get; set; } // kalan ödeme



        // Müşteri Bilgileri
        public int? CustomerId { get; set; }
        public long TTCustomerNo { get; set; } //tt customer no
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256)]
        public string MiddleName { get; set; }
        [MaxLength(256)]
        public string LastName { get; set; }
        [MaxLength(768)]
        public string FullName { get; set; }
        [MaxLength(32)]
        public string CitizenNumber { get; set; } // tc kimlik

        [MaxLength(64)]
        public string TaxNumber { get; set; }
        [MaxLength(64)]
        public string MersisNumber { get; set; }
        [MaxLength(512)]
        public string CompanyName { get; set; }
        [MaxLength(128)]
        public string TaxAdministrationName { get; set; }
        public int CustomerType { get; set; }
        public Customer Customer { get; set; }

        [MaxLength(1024)]
        public string InvoiceAddress { get; set; }


        // Hesap Bilgileri

        public int? AccountId { get; set; }
        [MaxLength(50)]
        public string XdslNo { get; set; } // tt hizmet no
        [MaxLength(50)]
        public string PstnNo { get; set; } //telefon no
        public Account Account { get; set; }

        public int? CurrencyID { get; set; }
        [MaxLength(10)]
        public string CurrencyName { get; set; }
        public Currency Currency { get; set; }

        public int? AddressId { get; set; }
        public AccountAddress Address { get; set; }
        public int? StatusId { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public int? RetailerId { get; set; }
        public string RetailerName { get; set; }
        public Retailer Retailer { get; set; }


        //OpenAmount
        //PPaymentAmount
        //PGsmAmount
        //PIcAmount
        //PInAmount
        //PAmountWithoutVAT


        //ID
        //AutoId
        //Description
        //IsVatExempt
        //BillAccountId
        //CustomerId
        //BillDate
        //BillStatusId
        //ResponsiblePositionId
        //PaymentDueDay
        //Remarks
        //ErpBillNumber
        //ErpBillDate
        //PrintDate

        //CurrencyId
        //CurrencyTypeId
        //PaymentStatusId
        //DunningStatusId
        //DunningDate
        //BillSourceId
        //CancellationReasonId

        //CreateUserId
        //CreateUserPositionId
        //CreateUserTime
        //UpdateUserId
        //UpdateUserPositionId
        //UpdateUserTime

        //GcRecordId
        //AddressId
        //BillId

        //PShowPayWithCCButton
        //PBillPeriod
        //PTotalOIV

        //PIsPaid
        //PBillOriginId
        //PPaymentDate
        //PBillFile

        //PTotalKDV

        //PPaymentDetail
        //PPayWithCC
        //PRemark
        //PGrandTotal

        //PPaymentDueDate
        //PCallDetail
        //PYTSOperationTime
        //YTSStatusId
        //IsInYTS
        //UpdateUserIP
        //CreateUserIP
    }
}