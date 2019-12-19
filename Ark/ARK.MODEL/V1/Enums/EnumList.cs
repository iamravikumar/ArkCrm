using System.ComponentModel;

namespace ARK.MODEL.V1.Enums
{
    public enum ParameterListEnum
    {
        [Description("Üyelik Tipi")]
        MembershipType = 1,
        [Description("Kimlik Tipi")]
        IdentificationType = 2,
        [Description("Cinsiyet Tipi")]
        Gender = 3,
        [Description("Medeni Hali")]
        MaritalStatus = 4,
        [Description("TT Müşteri Numarası")]
        TTCustomerNumber = 5,
    }

    public enum CampaignParameterListEnum
    {
        [Description("Bayi Satış Kanalı")] //AL-SAT, VAE, WIFI, YAPA
        RetailerSaleChannel = 1,
        [Description("Kampanya Türü")] // adsl, vdsl vs.
        CampaignType = 2,
        [Description("Kampanya Ödeme Türü")] // kampanya tipi ör: ön ödemeli, faturalı, taahhütlü, kart tarifesi, adsl, ön ödemeli aylık, vdsl, fiber, metro
        CampaignPaymentType = 3,
        [Description("Kampanya Taksit Süresi")]
        CampaignInstallmentPeriod = 4,
        [Description("İş Türü")]
        BusinessType = 5,
        [Description("Alt İş Türü")]
        BusinessSubType = 6,
        [Description("Güvenli İnternet Profili")]
        SecureInternetProfile = 7,
        [Description("XDSL Alınacak Yer")]
        XdslPlacementLocation = 8,
        [Description("Statik IP İsteniyor mu")]
        StatikIPRequest = 9,
        [Description("Domain İsim")]
        Domain = 10,
        [Description("Meslekler")]
        Jobs = 11,
    }

    public enum RetailerSaleChannel
    {
        ALSAT = 1,
        WIFI = 2,
        VAE = 3,
        YAPA = 4
    }
}
