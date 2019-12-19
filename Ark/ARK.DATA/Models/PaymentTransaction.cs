namespace ARK.DATA.Models
{
    public class PaymentTransaction
    {
    }
}

//Transaction
            //ret.Transaction = new GVPSTransaction();
            //ret.Transaction.Amount = ulong.Parse(formDataDic.Get("txnamount"));
            //ret.Transaction.AuthCode = formDataDic.Get("cavv");
            ////TODO ret.Transaction.BatchNum = formDataDic.Get("");
            //ret.Transaction.CardholderPresentCode = GVPSCardholderPresentCodeEnum.Secure3D;
            //ret.Transaction.CurrencyCode = formDataDic.Get("txncurrencycode").GetValueFromXmlEnumName<GVPSCurrencyCodeEnum>();
            //ret.Transaction.DelayDayCount = formDataDic.Get("txndelaydaycnt");
            //ret.Transaction.DownPaymentRate = formDataDic.Get("txndownpayrate");
            //ret.Transaction.InstallmentCnt = formDataDic.Get("txninstallmentcount");
            //ret.Transaction.MotoInd = formDataDic.Get("txnmotoind").GetValueFromXmlEnumName<GVPSMotoIndEnum>();
            //ret.Transaction.OriginalRetrefNum = formDataDic.Get("");
            ////TODO ret.Transaction.ProvDate = formDataDic.Get("");
            ////TODO ret.Transaction.RetrefNum = formDataDic.Get("");
            ////TODO ret.Transaction.SequenceNum = formDataDic.Get("");
            //ret.Transaction.Type = formDataDic.Get("txntype").GetValueFromXmlEnumName<GVPSTransactionTypeEnum>();

            ////TODO Transaction CepBank
            ////ret.Transaction.CepBank = new GVPSCepBank();
            ////ret.Transaction.CepBank.GSMNumber = formDataDic.Get("");
            ////ret.Transaction.CepBank.PaymentType = GVPSPaymentTypeEnum.Unspecified;

            ////TODO Transaction CepBankInq
            ////ret.Transaction.CepBankInq = new GVPSCepBankIng();
            ////ret.Transaction.CepBankInq.GSMNumber = formDataDic.Get("");

            ////TODO Transaction ChequeList
            ////ret.Transaction.ChequeList = new GVPSChequeList();

            ////TODO Transaction Commercial Card Extended Credit
            ////ret.Transaction.CommercialCardExtendedCredit = new GVPSCommercialCardExtendedCredit();
            ////ret.Transaction.CommercialCardExtendedCredit.PaymentList = new GVPSTransactionPaymentList();
            ////var TransactionPaymentList = new List<GVPSTransactionPayment>();
            ////TransactionPaymentList.Add(new GVPSTransactionPayment());
            ////TransactionPaymentList.Last().Amount = formDataDic.Get("");
            ////TransactionPaymentList.Last().DueDate = formDataDic.Get("");
            ////TransactionPaymentList.Last().Number = ushort.Parse(formDataDic.Get(""));
            ////ret.Transaction.CommercialCardExtendedCredit.PaymentList.Payment = TransactionPaymentList.ToArray();

            ////TODO Transaction GSMUnitInq
            ////ret.Transaction.GSMUnitInq = new GVPSGSMUnitInq();
            ////ret.Transaction.GSMUnitInq.InstitutionCode = ushort.Parse(formDataDic.Get(""));
            ////ret.Transaction.GSMUnitInq.Quantity = formDataDic.Get("gsmquantity");
            ////ret.Transaction.GSMUnitInq.SubscriberCode = formDataDic.Get("utilitypaysubscode");
            ////ret.Transaction.GSMUnitSales = new GVPSGSMUnitSales();

            ////TODO Transaction GSMUnitSales
            ////ret.Transaction.GSMUnitSales.InstitutionCode = ushort.Parse(formDataDic.Get(""));
            ////ret.Transaction.GSMUnitSales.Quantity = formDataDic.Get("gsmquantity");
            ////ret.Transaction.GSMUnitSales.SubscriberCode = formDataDic.Get("utilitypaysubscode");
            ////ret.Transaction.GSMUnitSales.UnitID = formDataDic.Get("");

            ////TODO Transaction HostMsgList
            //ret.Transaction.HostMsgList = new GVPSHostMsgList();
            //var HostMsgList = new List<string>();
            //ret.Transaction.HostMsgList.HostMsg = HostMsgList.ToArray();

            ////TODO Transaction MoneyCard
            ////ret.Transaction.MoneyCard = new GVPSMoneyCard();

            ////TODO Transaction Response
            ////ret.Transaction.Response = new GVPSTransactionResponse();
            ////ret.Transaction.Response.Code = formDataDic.Get("");
            ////ret.Transaction.Response.ErrorMsg = formDataDic.Get("");
            ////ret.Transaction.Response.Message = formDataDic.Get("");
            ////ret.Transaction.Response.ReasonCode = formDataDic.Get("");
            ////ret.Transaction.Response.Source = formDataDic.Get("");
            ////ret.Transaction.Response.SysErrMsg = formDataDic.Get("");

            ////TODO Transaction RewardInqResult 
            ////ret.Transaction.RewardInqResult = new GVPSRewardInqResult();
            ////ret.Transaction.RewardInqResult.ChequeList = new GVPSChequeList();
            
            ////TODO ret.Transaction.RewardInqResult.ChequeList.

            ////TODO Transaction RewardList 
            ////ret.Transaction.RewardList = new GVPSRewardList();
            ////ret.Transaction.RewardList.Reward = new GVPSReward[] { new GVPSReward() { } }; //TODO fill GVPSResponseReward properties

            ////Transaction Secure3D 
            //ret.Transaction.Secure3D = new GVPSSecure3D();
            //ret.Transaction.Secure3D.AuthenticationCode = formDataDic.Get("secure3dauthenticationcode"); 
            //ret.Transaction.Secure3D.Md = formDataDic.Get("mdstatus").GetValueFromXmlEnumName<GVPSMdStatusEnum>();
            //ushort securityLevel;
            //if (ushort.TryParse(formDataDic.Get("eci"), out securityLevel)) //secure3dsecuritylevel
            //    ret.Transaction.Secure3D.SecurityLevel = securityLevel;
            //ret.Transaction.Secure3D.TxnID = formDataDic.Get("secure3dtxnid");
            //ret.Transaction.Secure3D.TxnID = formDataDic.Get("xid");
