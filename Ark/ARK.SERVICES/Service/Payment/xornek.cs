using System;
using System.Collections.Generic;
using System.Text;

namespace ARK.SERVICES.Service.Payment
{
    //public class ornek
    //{
    //}
}


//using Armut.Iyzipay;
//using Armut.Iyzipay.Model;
//using Armut.Iyzipay.Request;
//using DP.DAL.Models;
//using DP.DAL.Repositories.BillRepository;
//using DP.DAL.Repositories.CheckinRepository;
//using DP.DAL.Repositories.IyzicoLogRepository;
//using DP.DAL.Repositories.PaymentCardRepository;
//using DP.DAL.Repositories.PaymentRepository;
//using DP.DAL.Repositories.ReservationRepository;
//using DP.DAL.Repositories.ServicePlaceRepository;
//using DP.DAL.Repositories.UserLocationRepository;
//using DP.DAL.Repositories.UserRepository;
//using DP.Helpers.Classes;
//using DP.Services.Classes;
//using DP.Services.Services.BillService;
//using DP.Services.Services.BillService.Models.Bill;
////using DP.Services.Services.IyzicoService.Classes;
//using DP.Services.Services.IyzicoService.Models;
//using DP.Services.Services.PushNotificationService;
//using DP.Services.Services.PushNotificationService.Models;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Dynamic;
//using System.Globalization;
//using System.Linq;
//using DP.Core.Resources;
//using Microsoft.Extensions.Configuration;
//using DP.Services.Services.MerchantService;
//using DP.Services.Services.ServicePlaceMerchantService;
//using Microsoft.Extensions.Localization;

//namespace DP.Services.Services.IyzicoService
//{
//    public class IyzicoService : IIyzicoService
//    {
//        private IIyzicoLogRepository _iyzicoLogRepository;
//        private IUserRepository _userRepository;
//        private IUserLocationRepository _userLocationRepository;
//        private IPaymentCardRepository _paymentCardRepository;
//        private IPaymentRepository _paymentRepository;
//        private IPushNotificationService _pushNotificationService;
//        private IServicePlaceMerchantService _merchantService;
//        private IBillService _billService;
//        private IReservationRepository _reservationRepository;
//        private IBillRepository _billRepository;
//        private IServicePlaceRepository _servicePlaceRepository;
//        private ICheckinRepository _checkinRepository;
//        private IConfiguration _configuration;
//        //private IIyzicoHelper _iyzicoHelper;

//        //private IIyzicoLogRepository _iyzicoLogRepository;
//        private string CallBackURL;
//        private Options options;
//        public decimal SubMerchantPercentage { get; set; }

//        private readonly IStringLocalizer<SharedResource> _localizer;

//        public IyzicoService(
//            IIyzicoLogRepository iyzicoLogRepository,
//            IUserRepository userRepository,
//            IUserLocationRepository userLocationRepository,
//            IPaymentCardRepository paymentCardRepository,
//            IPushNotificationService pushNotificationService,
//            IPaymentRepository paymentRepository,
//            IServicePlaceMerchantService merchantService,
//            IBillService billService,
//            IReservationRepository reservationRepository,
//            IBillRepository billRepository,
//            IServicePlaceRepository servicePlaceRepository,
//            ICheckinRepository checkinRepository,
//            IConfiguration Configuration,
//            //IIyzicoHelper iyzicoHelper,
//            IStringLocalizer<SharedResource> localizer
//            )
//        {
//            _iyzicoLogRepository = iyzicoLogRepository;
//            _userRepository = userRepository;
//            _userLocationRepository = userLocationRepository;
//            _paymentCardRepository = paymentCardRepository;
//            _paymentRepository = paymentRepository;
//            _pushNotificationService = pushNotificationService;
//            _merchantService = merchantService;
//            _billService = billService;
//            _billRepository = billRepository;
//            _servicePlaceRepository = servicePlaceRepository;
//            _reservationRepository = reservationRepository;
//            _checkinRepository = checkinRepository;
//            _configuration = Configuration;
//            //_iyzicoHelper = iyzicoHelper;
//            options = new Options();
//            options.ApiKey = "5aR2839fHT57LuEolTNK1PRIgV8jXmkw";
//            options.SecretKey = "Sg8vsP4nUE1spReMSbaMZCAEDWIOElmv";
//            options.BaseUrl = "https://api.iyzipay.com";
//            SubMerchantPercentage = 5;
//            CallBackURL = _configuration["IyzicoParameters:IyzicoCallBackURL"];
//            _localizer = localizer;
//        }


//        public ServiceResult<DAL.Models.PaymentCard> SaveCreditCard(string cardAlias, string cardHolderName, string cardNumber, string expireMonth, string expireYear, string cvc, string userId)
//        {
//            var result = new ServiceResult<DP.DAL.Models.PaymentCard>();
//            var user = _userRepository.GetSingle(Convert.ToInt32(userId));
//            CreateCardRequest request = new CreateCardRequest();
//            request.Locale = Locale.TR.ToString();
//            request.Email = user.Email;
//            CardInformation cardInformation = new CardInformation();
//            cardInformation.CardAlias = cardAlias;
//            cardInformation.CardHolderName = cardHolderName;
//            cardInformation.CardNumber = cardNumber;
//            cardInformation.ExpireMonth = expireMonth;
//            cardInformation.ExpireYear = expireYear;
//            request.Card = cardInformation;

//            DP.DAL.Models.PaymentCard CardInfo = new DP.DAL.Models.PaymentCard
//            {
//                CardAlias = cardAlias,
//                LastFourDigit = cardNumber.Substring(cardNumber.Length - 4, 4),
//                UserId = user.Id,
//                UserIdentification = user.UserIdentification,
//                Provider = (int)Enums.PaymentProvider.Iyzico,
//                IsDefault = false
//            };
//            try
//            {
//                var exist = _paymentCardRepository.GetSingleByLastFourDigitAndUserId(user.Id, cardNumber.Substring(cardNumber.Length - 4, 4));
//                if (exist == null)
//                {
//                    request.ConversationId = CardInfo.Id.ToString();
//                    request.ExternalId = CardInfo.Id.ToString();
//                    Card card = Card.Create(request, options);
//                    CardInfo.UserKey = card.CardUserKey;
//                    CardInfo.Token = card.CardToken;
//                    _paymentCardRepository.Add(CardInfo);
//                    _paymentCardRepository.Save();

//                    result.IsSuccessful = true;
//                    result.Message = _localizer["New Card Successfully Added."].ToString(); // check localization
//                    result.Data = CardInfo;
//                }
//                else
//                {
//                    result.IsSuccessful = false;
//                    result.Message = _localizer["Card is already added."].ToString(); // check localization
//                    result.Data = exist;
//                }
//            }
//            catch (Exception e)
//            {
//                result.IsSuccessful = false;
//                result.Message = _localizer["Unknown error"].ToString(); // check localization
//            }
//            return result;
//        }
//        public ServiceResult<bool> DeleteCreditCard(string cardId, string userId)
//        {
//            var result = new ServiceResult<bool>();
//            try
//            {
//                var creditCard = _paymentCardRepository.GetSingle(Convert.ToInt32(cardId), Convert.ToInt64(userId));
//                if (creditCard != null)
//                {
//                    DeleteCardRequest request = new DeleteCardRequest();
//                    request.Locale = Locale.TR.ToString();
//                    request.CardToken = creditCard.Token;
//                    request.CardUserKey = creditCard.UserKey;
//                    Card card = Card.Delete(request, options);
//                    creditCard.IsDeleted = true;
//                    creditCard.DeleterUserId = Convert.ToInt32(userId);
//                    _paymentCardRepository.Edit(creditCard);
//                    _paymentCardRepository.Save();
//                    result.Data = true;
//                    result.Message = _localizer["Credit Card successfully deleted."].ToString(); // check localization
//                    result.IsSuccessful = true;
//                }
//                else
//                {
//                    result.Data = false;
//                    result.Message = _localizer["This card does not belong to you."].ToString(); // check localization
//                    result.IsSuccessful = false;
//                }
//            }
//            catch (Exception e)
//            {
//                result.Data = false;
//                result.Message = _localizer["An error occured while deleting credit card."].ToString(); // check localization
//                result.IsSuccessful = false;
//            }
//            return result;
//        }

//        public ServiceResult<BinNumber> RetrieveBinInfo(string cardnumber)
//        {
//            var result = new ServiceResult<BinNumber>();
//            RetrieveBinNumberRequest request = new RetrieveBinNumberRequest();
//            request.Locale = Locale.TR.ToString();
//            request.ConversationId = "123456789";
//            request.BinNumber = cardnumber;
//            BinNumber binnumber = new BinNumber();
//            try
//            {
//                binnumber = BinNumber.Retrieve(request, options);
//            }
//            catch (Exception ex)
//            {
//                result.IsSuccessful = false;
//                result.Exception = ex;
//            }
//            result.Data = binnumber;
//            result.IsSuccessful = true;
//            return result;
//        }

//        public string GetSubMerchantPrice(string price)
//        {
//            var pd = Convert.ToDecimal(price, CultureInfo.GetCultureInfo("en-US"));
//            var p = pd - ((pd * SubMerchantPercentage) / 100);
//            return p.ToString(CultureInfo.GetCultureInfo("en-US"));
//        }

//        public ServiceResult<SubMerchant> AddSubmerchant(ServicePlaceMerchantModel submerchant)
//        {
//            CreateSubMerchantRequest request = new CreateSubMerchantRequest();
//            request.Locale = Locale.TR.ToString();
//            request.SubMerchantExternalId = submerchant.SubMerchantExternalId;
//            request.SubMerchantType = submerchant.SubMerchantType;
//            request.Address = submerchant.Address;
//            request.ContactName = submerchant.ContactName;
//            request.ContactSurname = submerchant.ContactSurname;
//            request.Email = submerchant.Email;
//            request.GsmNumber = submerchant.GsmNumber;
//            request.Name = submerchant.Name;
//            request.Iban = submerchant.Iban;
//            request.IdentityNumber = submerchant.IdentityNumber;
//            request.LegalCompanyTitle = submerchant.LegalCompanyTitle;
//            request.TaxNumber = submerchant.TaxNumber;
//            request.TaxOffice = submerchant.TaxOffice;
//            request.Currency = submerchant.Currency.ToString();

//            //request.Currency = Currency.TRY.ToString();
//            SubMerchant subMerchant = SubMerchant.Create(request, options);
//            var result = new ServiceResult<SubMerchant>();
//            if (subMerchant.Status == "success")
//            {
//                result.IsSuccessful = true;
//            }
//            result.Data = subMerchant;
//            return result;
//        }

//        public ServiceResult<SubMerchant> UpdateSubmerchant(ServicePlaceMerchantModel submerchant)
//        {
//            UpdateSubMerchantRequest request = new UpdateSubMerchantRequest();
//            request.Locale = Locale.TR.ToString();
//            request.SubMerchantKey = submerchant.SubMerchantKey;
//            request.Address = submerchant.Address;
//            request.ContactName = submerchant.ContactName;
//            request.ContactSurname = submerchant.ContactSurname;
//            request.Email = submerchant.Email;
//            request.GsmNumber = submerchant.GsmNumber;
//            request.Name = submerchant.Name;
//            request.Iban = submerchant.Iban;
//            request.IdentityNumber = submerchant.IdentityNumber;
//            request.LegalCompanyTitle = submerchant.LegalCompanyTitle;
//            request.TaxNumber = submerchant.TaxNumber;
//            request.TaxOffice = submerchant.TaxOffice;
//            request.Currency = submerchant.Currency.ToString();

//            //request.Currency = Currency.TRY.ToString();
//            SubMerchant subMerchant = SubMerchant.Update(request, options);
//            var result = new ServiceResult<SubMerchant>();
//            if (subMerchant.Status == "success")
//            {
//                result.IsSuccessful = true;
//            }
//            result.Data = subMerchant;
//            return result;
//        }

//        public ServiceResult<Object> MakeNormalPayment(string paymentId, string cardId, string price, string userId, string userIdentification, string billId, decimal totalPrice, decimal tip = 0)
//        {
//            //JsonConvert.SerializeObject(Images, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
//            var model = new PushNotificationModel()
//            {
//                title = _localizer["paymentresult"].ToString(),
//                body = ""
//            };
//            dynamic innerData = new ExpandoObject();
//            dynamic data = new ExpandoObject();
//            data.Action = "Checkout";
//            data.Route = "Checkout";
//            var g = Guid.NewGuid();
//            data.Id = g.ToString();
//            var payment_ = _paymentRepository.GetSingle(Convert.ToInt32(paymentId));

//            var result = new ServiceResult<Object>();
//            Armut.Iyzipay.Model.Payment payment = null;
//            var user = new User();
//            var creatorUser = new User();

//            var creditCard = _paymentCardRepository.GetSingle(Convert.ToInt32(cardId), Convert.ToInt64(userId));

//            ConsoleLogWithData("PaymentCard model", creditCard);

//            var log = new IyzicoLog()
//            {
//                CardNumber = creditCard.LastFourDigit,
//                ConversationTime = TimeStamp.ToUnixTimestamp(DateTime.Now),
//                CreatorUserId = Convert.ToInt64(userId),
//                Tip = tip,
//                LastModificationTime = (int)DateTime.UtcNow.Ticks,
//                Price = Convert.ToDecimal(price, CultureInfo.GetCultureInfo("en-US")),
//                IsDeleted = false,
//                BillId = Convert.ToInt32(billId)
//            };
//            _iyzicoLogRepository.Add(log);
//            _iyzicoLogRepository.Save();
//            List<string> toList = new List<string>();
//            List<string> toListSubPayment = new List<string>();
//            List<string> toListSubPaymentServicePlace = new List<string>();
//            List<string> toListDirectPayment = new List<string>();
//            List<string> toListServicePlacePayment = new List<string>();



//            //var percantage = _iyzicoHelper.GetSubmerchantPercantage(Convert.ToInt64(billId));
//            //_billService.SetBillMerchantPercentage(Convert.ToInt32(billId), percantage);

//            if (creditCard != null)
//            {
//                try
//                {
//                    var bill = _billRepository.GetSingle(payment_.BillId);
//                    var merchant = _merchantService.GetMerchant(bill.ServicePlaceId);
//                    if (merchant == null || merchant.Data.MerchantKey == null)
//                    {
//                        throw new Exception("This serviceplace is not ready for getting payment.");
//                    }
//                    var priceDecimal = Convert.ToDecimal(price, CultureInfo.GetCultureInfo("en-US"));
//                    if (priceDecimal > 0)
//                    {
//                        var request = new CreatePaymentRequest();
//                        request.Locale = Locale.TR.ToString();
//                        request.ConversationId = log.Id.ToString();
//                        request.Price = price;
//                        request.PaidPrice = price;
//                        //request.Currency = Enums.Currency // Open When Multi Currency Support
//                        request.Currency = Currency.TRY.ToString();
//                        request.Installment = 1;
//                        request.BasketId = billId;
//                        request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
//                        request.PaymentChannel = PaymentChannel.WEB.ToString();
//                        Armut.Iyzipay.Model.PaymentCard paymentCard = new Armut.Iyzipay.Model.PaymentCard();

//                        paymentCard.CardToken = creditCard.Token;
//                        paymentCard.CardUserKey = creditCard.UserKey;
//                        request.PaymentCard = paymentCard;

//                        user = _userRepository.GetSingle(Convert.ToInt32(userId));
//                        request.Buyer = new Buyer()
//                        {
//                            Id = user.Id.ToString(),
//                            Name = user.Name,
//                            Surname = user.Surname,
//                            Email = user.Email,
//                            IdentityNumber = user.IdentityNumber ?? "11111111111",
//                            City = "İstanbul",
//                            Country = "Turkey",
//                            RegistrationAddress = "Deneme mah.",
//                            Ip = "172.25.2.5",
//                        };
//                        request.BillingAddress = new Address()
//                        {
//                            Description = "deneme adresi",
//                            City = "istanbul",
//                            Country = "Turkey",
//                            ContactName = user.Name + " " + user.Surname
//                        };



//                        request.BasketItems = new List<BasketItem>()
//                        {
//                        new BasketItem()
//                        {
//                            Id ="1",
//                            Name = billId + " id'li Adisyon",
//                            Price = price,
//                            Category1 = "1",
//                            ItemType = BasketItemType.VIRTUAL.ToString(),
//                            SubMerchantKey = merchant.Data.MerchantKey,
//                            SubMerchantPrice =GetSubMerchantPrice(price),
//                        }
//                            };
//                        Console.WriteLine(JsonConvert.SerializeObject(request));
//                        Console.WriteLine(JsonConvert.SerializeObject(options));
//                        Console.WriteLine("[NORMAL ODEME OBJESI");
//                        Console.WriteLine(JsonConvert.SerializeObject(request));
//                        Console.WriteLine(JsonConvert.SerializeObject(payment));
//                        Console.WriteLine("[NORMAL ODEME OBJESI");
//                        payment = Armut.Iyzipay.Model.Payment.Create(request, options);
//                    }
//                    else
//                    {

//                    }


//                    if (payment.Status == "success")
//                    {
//                        Console.WriteLine("Ödeme Success Başlangıcı");
//                        data.IsSuccessful = true;
//                        data.Message = _localizer["Payment Successful"].ToString(); // check localization
//                        Console.WriteLine("Bill Kapatma Başlangıcı");
//                        var resultBillClosed = _billService.UpdateBillPayment(payment_.BillId, priceDecimal);
//                        var resultBillClosed_ = JsonConvert.SerializeObject(resultBillClosed);
//                        Console.WriteLine(resultBillClosed_);
//                        Console.WriteLine("Bill Kapatma Bitişi");
//                        Console.WriteLine("Bill Çekme Başlangıcı");

//                        Console.WriteLine("Bill Çekme Bitişi");
//                        //innerData.Reservation = null;
//                        if (resultBillClosed.IsSuccessful && bill.IsOriginalBill == true)
//                        {
//                            if (bill.ReservationId != null)
//                            {
//                                Console.WriteLine("Rezervasyon Kapatma Başlangıcı");
//                                var reservation = _reservationRepository.GetSingle((long)bill.ReservationId);
//                                reservation.ReservationStatus = (int)Enums.ReservationStatus.Completed;
//                                _reservationRepository.Edit(reservation);
//                                _reservationRepository.Save();
//                                //innerData.Reservation = reservation;
//                                Console.WriteLine("Rezervasyon Kapatma Bitişi");
//                            }
//                            if (bill.CheckinId != null)
//                            {
//                                Console.WriteLine("Checkin Kapatma Başlangıcı");
//                                var checkin = _checkinRepository.GetSingle((long)bill.CheckinId);
//                                checkin.CheckinStatus = (int)Enums.CheckinStatus.Completed;
//                                _checkinRepository.Edit(checkin);
//                                _checkinRepository.Save();
//                                //innerData.Checkin = checkin;
//                                Console.WriteLine("Checkin Kapatma Bitişi");
//                            }
//                        }
//                        var servicePlace = _servicePlaceRepository.GetSingle(bill.ServicePlaceId);

//                        var servicePlaceUser = _userRepository.GetSingle(servicePlace.UserId);

//                        var waiterUser = new User();
//                        if (bill.WaiterUserId != null)
//                        {
//                            waiterUser = _userRepository.GetSingle((long)bill.WaiterUserId);
//                        }
//                        if (servicePlaceUser != null && servicePlaceUser.PushToken != null && bill.IsOriginalBill == false)
//                        {
//                            toListSubPaymentServicePlace.Add(servicePlaceUser.PushToken);
//                        }
//                        if (waiterUser != null && waiterUser.PushToken != null)
//                        {
//                            toListSubPaymentServicePlace.Add(waiterUser.PushToken);
//                        }
//                        if (bill.IsOriginalBill != true)
//                        {
//                            Bill b = _billRepository.GetSingle(Convert.ToInt32(bill.OriginalBillId));
//                            User u = _userRepository.GetSingle(Convert.ToInt32(b.CreatorUserId));
//                            //Console.WriteLine("Group get ");
//                            //Console.WriteLine(JsonConvert.SerializeObject(u));
//                            ConsoleLogWithData("Group get ", u);
//                            if (u != null && u.PushToken != null)
//                            {
//                                if (b.BillStatus == (int)Enums.BillStatus.ClosedPaid)
//                                {
//                                    toList.Add(u.PushToken);
//                                }
//                                toListSubPayment.Add(u.PushToken);
//                            }
//                        }
//                        if (bill.CreatorUserId != null && bill.CreatorUserId != 0)
//                        {
//                            creatorUser = _userRepository.GetSingle(Convert.ToInt32(bill.CreatorUserId));
//                        }
//                        if (bill.CheckinId == null && bill.ReservationId == null)
//                        {
//                            User u = _userRepository.GetSingle(Convert.ToInt32(bill.CreatorUserId));
//                            toListDirectPayment.Add(u.PushToken);
//                        }

//                        if (bill.CreatorUserId != bill.PayerUserId && (bill.PayerUserId != null && bill.PayerUserId != 0))
//                        {
//                            var userPayer = _userRepository.GetSingle(Convert.ToInt32(bill.PayerUserId));
//                            if (userPayer != null && userPayer.PushToken != null)
//                            {
//                                toList.Add(userPayer.PushToken);
//                            }
//                        }
//                        BillModel originalbill = new BillModel();
//                        if (bill.IsOriginalBill == false)
//                        {
//                            originalbill = new BillModel().ToSubBillsDTO(_billRepository.GetSingle(Convert.ToInt32(bill.OriginalBillId)));
//                            var childs = _billRepository.GetAll().Where(x => x.OriginalBillId == originalbill.Id).Select(new BillModel().ToSubBillsDTO).ToList();
//                            //result.ChildBills =_billRepository.GetAll().Where(x => x.OriginalBillId == billId).ToList();
//                            if (childs != null && childs.Count > 0)
//                            {
//                                foreach (var item in childs)
//                                {
//                                    User u = _userRepository.GetSingle(Convert.ToInt32(item.CreatorUserId));
//                                    if (u != null && u.PushToken != null)
//                                    {
//                                        toListSubPayment.Add(u.PushToken);
//                                    }
//                                }
//                                originalbill.ChildBills = childs;
//                            }
//                        }
//                        //innerData.Bill = originalbill;
//                        //if (innerData.Reservation != null)
//                        //{
//                        //    innerData.Reservation.Bill = null;
//                        //    innerData.Reservation.User = null;
//                        //}
//                        innerData.Payment = payment_;
//                        result.IsSuccessful = true;
//                        Console.WriteLine("Ödeme Success Bitişi");
//                    }
//                    else
//                    {
//                        data.IsSuccessful = false;
//                        data.Message = payment.ErrorMessage;
//                        result.IsSuccessful = false;
//                    }
//                    //result.IsSuccessful = true;

//                }
//                catch (Exception e)
//                {
//                    result.Exception = e;
//                    result.IsSuccessful = false;
//                }
//            }
//            else
//            {
//                result.IsSuccessful = false;
//            }

//            //string[] to = new string[] { user.PushToken };
//            toList.Add(creatorUser.PushToken);
//            result.Data = payment;
//            data.Data = innerData;
//            model.data = data;
//            Console.WriteLine("PushNotification Oncesi");
//            string[] to = toList.ToArray();
//            string[] toSubPayment = toListSubPayment.ToArray();
//            string[] toSubPaymentServicePlace = toListSubPaymentServicePlace.ToArray();
//            string[] toServicePlacePayment = toListServicePlacePayment.ToArray();
//            string[] toDirectPayment = toListDirectPayment.ToArray();

//            ConsoleLogWithData("Checkout model", model);
//            ConsoleLogWithData("Checkout to", to);

//            var pushResponse = _pushNotificationService.SendMessageToDevice(to, model).Data;
//            ConsoleLogWithData("Checkout to push response", pushResponse);
//            Object pushResponseSub = null;
//            Object pushResponseSubServicePlace = null;
//            if (toSubPayment != null && toSubPayment.Length > 0)
//            {
//                dynamic subPaymentData = new ExpandoObject();
//                subPaymentData.Action = "someonemadepayment";
//                subPaymentData.Route = "billupdate";
//                g = Guid.NewGuid();
//                subPaymentData.Id = g.ToString();
//                //model.data = new Bill();
//                model.data = subPaymentData;
//                model.title = _localizer["somebodyjoinedthepayment"].ToString();
//                //_pushNotificationService.SendMessageToDevice(toSubPayment, model);

//                //dynamic subPaymentServicePlaceData = new ExpandoObject();
//                //subPaymentServicePlaceData.Action = "someonemadepayment";
//                //subPaymentServicePlaceData.Route = "billupdate";
//                ////model.data = new Bill();
//                //model.data = subPaymentData;
//                //model.title= _localizer["somebodyjoinedthepayment"].ToString(),
//                pushResponseSub = _pushNotificationService.SendMessageToDevice(toSubPayment, model).Data;
//                if (toSubPaymentServicePlace != null && toSubPaymentServicePlace.Length > 0)
//                {
//                    pushResponseSubServicePlace = _pushNotificationService.SendMessageToDevice(toSubPaymentServicePlace, model).Data;
//                }
//            }


//            ConsoleLogWithData("Someonemakepayment model", model);
//            ConsoleLogWithData("Someonemakepayment to", toSubPayment);
//            ConsoleLogWithData("Someonemakepayment push response", pushResponseSub);

//            ConsoleLogWithData("SomeonemakepaymentservicePlace model", model);
//            ConsoleLogWithData("SomeonemakepaymentservicePlace to", toSubPayment);
//            ConsoleLogWithData("SomeonemakepaymentservicePlace push response", pushResponseSubServicePlace);

//            if (toDirectPayment.Length > 0)
//            {
//                dynamic directPaymentData = new ExpandoObject();
//                directPaymentData.Action = "ShowMessage";
//                directPaymentData.Route = "Modal";
//                g = Guid.NewGuid();
//                directPaymentData.Id = g.ToString();
//                dynamic directPaymenInnertData = new ExpandoObject();
//                directPaymenInnertData.modalText = "Doğrudan bir ödeme gerçekleşti";
//                directPaymenInnertData.BillId = billId;

//                directPaymentData.Data = directPaymenInnertData;
//                //Route: Modal
//                //Action : ShowMessage
//                //Data: modalText
//                //model.data = new Bill();
//                model.data = directPaymentData;
//                model.title = "Doğrudan bir ödeme gerçekleşti";
//                _pushNotificationService.SendMessageToDevice(toDirectPayment, model);
//            }

//            Console.WriteLine("PushNotification Sonrası");

//            return result;
//        }

//        public ServiceResult<Object> StartThreeDPayment(bool registerCard, string paymentId, string cardAlias, string cardHolderName, string cardNumber, string expireMonth, string expireYear, string cvc, bool IsFavourite, string price, string userId, string billId, decimal tip = 0)
//        {
//            var result = new ServiceResult<Object>();
//            var bill = _billRepository.GetSingle(Convert.ToInt64(billId));
//            var merchant = _merchantService.GetMerchant(bill.ServicePlaceId);
//            if (merchant == null || merchant.Data.MerchantKey == null)
//            {
//                result.Message = _localizer["This serviceplace is not ready for getting payment."].ToString(); // check localization
//            }
//            else
//            {
//                var log = new IyzicoLog()
//                {
//                    RegisterCard = registerCard,
//                    CardNumber = cardNumber,
//                    CardAlias = cardAlias,
//                    ConversationTime = (int)DateTime.UtcNow.Ticks,
//                    CreationTime = (int)DateTime.UtcNow.Ticks,
//                    CreatorUserId = Convert.ToInt64(userId),
//                    Tip = tip,
//                    LastModificationTime = (int)DateTime.UtcNow.Ticks,
//                    Price = Convert.ToDecimal(price, CultureInfo.GetCultureInfo("en-US")),
//                    IsDeleted = false,
//                    BillId = Convert.ToInt32(billId)
//                };
//                //var bill = _billRepository.GetSingle(Convert.ToInt32(billId));
//                //bill.Tip = tip;
//                //bill.Total = Convert.ToDecimal(price);
//                //_billRepository.Edit(bill);
//                //_billRepository.Save();
//                //var percantage = _iyzicoHelper.GetSubmerchantPercantage(Convert.ToInt64(billId));
//                //_billService.SetBillMerchantPercentage(Convert.ToInt32(billId), percantage);
//                _iyzicoLogRepository.Add(log);
//                _iyzicoLogRepository.Save();
//                var payment = _paymentRepository.GetSingle(Convert.ToInt64(paymentId));
//                payment.ConversationId = log.Id.ToString();
//                var priceDecimal = Convert.ToDecimal(price, CultureInfo.GetCultureInfo("en-US"));
//                ThreedsInitialize paymentAuth = new ThreedsInitialize();
//                if (priceDecimal > 0)
//                {
//                    var request = new CreatePaymentRequest();
//                    request.Locale = Locale.TR.ToString();
//                    request.ConversationId = log.Id.ToString();
//                    request.Price = price;
//                    request.PaidPrice = price;
//                    //request.Currency = Enums.Currency // Open When Multi Currency Support
//                    request.Currency = Currency.TRY.ToString();
//                    request.Installment = 1;
//                    request.BasketId = billId;
//                    request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
//                    request.PaymentChannel = PaymentChannel.WEB.ToString();
//                    request.CallbackUrl = CallBackURL;
//                    Armut.Iyzipay.Model.PaymentCard paymentCard = new Armut.Iyzipay.Model.PaymentCard();
//                    paymentCard.CardHolderName = cardHolderName;
//                    paymentCard.CardNumber = cardNumber;
//                    paymentCard.ExpireMonth = expireMonth;
//                    paymentCard.ExpireYear = expireYear;
//                    paymentCard.CardAlias = cardAlias;
//                    paymentCard.RegisterCard = 1;
//                    paymentCard.Cvc = cvc;
//                    request.PaymentCard = paymentCard;
//                    var user = _userRepository.GetSingle(Convert.ToInt32(userId));
//                    request.Buyer = new Buyer()
//                    {
//                        Id = user.Id.ToString(),
//                        Name = user.Name,
//                        Surname = user.Surname,
//                        Email = user.Email,
//                        IdentityNumber = user.IdentityNumber ?? "11111111111",
//                        City = "İstanbul",
//                        Country = "Turkey",
//                        RegistrationAddress = "Deneme mah.",
//                        Ip = "172.25.2.5",
//                    };
//                    request.BillingAddress = new Address()
//                    {
//                        Description = "deneme adresi",
//                        City = "istanbul",
//                        Country = "Turkey",
//                        ContactName = cardHolderName
//                    };

//                    request.BasketItems = new List<BasketItem>()
//                {
//                    new BasketItem()
//                    {
//                        Id ="1",
//                        Name = billId + " id'li Adisyon",
//                        Price = price,
//                        Category1 = "1",
//                        ItemType = BasketItemType.VIRTUAL.ToString(),
//                        SubMerchantKey = merchant.Data.MerchantKey,
//                        SubMerchantPrice =GetSubMerchantPrice(price),
//                    }
//                };
//                    paymentAuth = ThreedsInitialize.Create(request, options);
//                    result.IsSuccessful = true;
//                    if (paymentAuth.ErrorMessage != null && paymentAuth.ErrorMessage != "")
//                    {
//                        payment.PaymentStatus = false;
//                        result.IsSuccessful = false;
//                        result.Message = paymentAuth.ErrorMessage;
//                    }
//                }

//                else
//                {
//                    payment.PaymentStatus = false;
//                    paymentAuth.Status = Status.FAILURE.ToString();
//                    result.Message = _localizer["Price must be bigger than 0."].ToString(); // check localization
//                }
//                _paymentRepository.Edit(payment);
//                _paymentRepository.Save();
//                result.Data = paymentAuth;
//            }
//            return result;
//        }

//        public PushNotificationModel SetNotificationData(string title, string body, string action, string route, ExpandoObject extraData)
//        {
//            var model = new PushNotificationModel()
//            {
//                title = title,
//                body = body,
//            };
//            dynamic data = new ExpandoObject();
//            dynamic inData = new ExpandoObject();

//            return model;
//        }

//        public ServiceResult<Object> MakeThreeDPayment(string conversationId, string paymentId, string conversationData)
//        {


//            Console.WriteLine("PaymentCallback Başlangıcı");
//            var log = _iyzicoLogRepository.GetSingle(Convert.ToInt32(conversationId));
//            var payment = _paymentRepository.GetSingleByConversationId(conversationId);
//            var user = _userRepository.GetSingle(Convert.ToInt32(log.CreatorUserId));
//            var creatorUser = new User();

//            user.Bill = null;
//            List<string> toList = new List<string>();
//            List<string> toListSubPayment = new List<string>();
//            List<string> toListSubPaymentServicePlace = new List<string>();

//            //string[] to = new string[] { user.PushToken };
//            var model = new PushNotificationModel()
//            {
//                title = _localizer["paymentresult"].ToString(),
//                body = ""
//            };
//            dynamic innerData = new ExpandoObject();
//            dynamic data = new ExpandoObject();
//            innerData.CardSaved = true;
//            data.Action = "Checkout";
//            data.Route = "Checkout";
//            var g = Guid.NewGuid();
//            data.Id = g.ToString();

//            ThreedsPayment threedsPayment = null;
//            var result = new ServiceResult<Object>();
//            try
//            {
//                CreateThreedsPaymentRequest request = new CreateThreedsPaymentRequest();
//                request.Locale = Locale.TR.ToString();
//                request.ConversationId = conversationId;
//                request.PaymentId = paymentId;
//                if (conversationData != null)
//                {
//                    request.ConversationData = conversationData;
//                }
//                threedsPayment = ThreedsPayment.Create(request, this.options);

//                Console.WriteLine("[ODEME OBJESI");
//                Console.WriteLine(JsonConvert.SerializeObject(request));
//                Console.WriteLine(JsonConvert.SerializeObject(threedsPayment));
//                Console.WriteLine("[ODEME OBJESI");

//                #region kartı saklama
//                try
//                {
//                    if (log.RegisterCard)
//                    {
//                        var cardInfo = RetrieveBinInfo(log.CardNumber.Substring(0, 6)).Data;
//                        Console.WriteLine("Kart BIN Bilgileri");
//                        Console.WriteLine(JsonConvert.SerializeObject(cardInfo));
//                        if (cardInfo != null && cardInfo.CardType != "DEBIT_CARD")
//                        {
//                            //innerData.CardInfo = cardInfo;
//                            DP.DAL.Models.PaymentCard CardInfo = new DP.DAL.Models.PaymentCard
//                            {
//                                Token = threedsPayment.CardToken,
//                                CardAlias = log.CardAlias,
//                                UserKey = threedsPayment.CardUserKey,
//                                LastFourDigit = log.CardNumber.Substring(log.CardNumber.Length - 4, 4),
//                                UserId = user.Id,
//                                UserIdentification = user.UserIdentification,
//                                Provider = (int)Enums.PaymentProvider.Iyzico,
//                                IsDefault = false
//                            };
//                            var exist = _paymentCardRepository.GetSingleByLastFourDigitAndUserId(user.Id, log.CardNumber.Substring(log.CardNumber.Length - 4, 4));
//                            if (exist == null)
//                            {
//                                CardInfo.IsDefault = true;
//                                _paymentCardRepository.Add(CardInfo);
//                                _paymentCardRepository.Save();
//                            }
//                            else
//                            {
//                                exist.Token = threedsPayment.CardToken;
//                                exist.UserKey = threedsPayment.CardUserKey;
//                                exist.CardAlias = log.CardAlias;
//                                _paymentCardRepository.Edit(exist);
//                                _paymentCardRepository.Save();
//                            }
//                        }
//                        else
//                        {
//                            innerData.CardSaved = false;
//                            innerData.CardSaveMessage = "DEBIT Cards can not be saved.";
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine(JsonConvert.SerializeObject(ex));
//                    innerData.CardSaved = false;
//                    innerData.CardSaveMessage = "Unknown error occured on saving card.";
//                }

//                #endregion

//                if (log.CardAlias.Length > 4)
//                {
//                    log.CardAlias = log.CardNumber.Substring(log.CardNumber.Length - 4, 4);
//                    _iyzicoLogRepository.BeginTransaction();
//                    _iyzicoLogRepository.Edit(log);
//                    _iyzicoLogRepository.Save();
//                    _iyzicoLogRepository.CommitTransaction();
//                }
//                if (threedsPayment.Status == "success")
//                {
//                    Console.WriteLine("Ödeme Success Başlangıcı");

//                    data.IsSuccessful = true;
//                    data.Message = _localizer["Payment Successful"].ToString(); // check localization
//                    Console.WriteLine("Bill Kapatma Başlangıcı");
//                    bool billClosed = _billService.UpdateBillPayment(payment.BillId, payment.Charge).IsSuccessful;
//                    Console.WriteLine("Bill Kapatma Bitişi");

//                    Console.WriteLine("Bill Çekme Başlangıcı");
//                    var bill = _billRepository.GetSingle(payment.BillId);


//                    Console.WriteLine("Bill Çekme Bitişi");
//                    //innerData.Reservation = null;

//                    if (billClosed && bill.IsOriginalBill == true)
//                    {
//                        if (bill.ReservationId != null)
//                        {
//                            Console.WriteLine("Rezervasyon Kapatma Başlangıcı");
//                            var reservation = _reservationRepository.GetSingle((long)bill.ReservationId);
//                            reservation.ReservationStatus = (int)Enums.ReservationStatus.Completed;
//                            _reservationRepository.Edit(reservation);
//                            _reservationRepository.Save();
//                            //innerData.Reservation = reservation;
//                            Console.WriteLine("Rezervasyon Kapatma Bitişi");
//                        }
//                        if (bill.CheckinId != null)
//                        {
//                            Console.WriteLine("Checkin Kapatma Başlangıcı");
//                            var checkin = _checkinRepository.GetSingle((long)bill.CheckinId);
//                            checkin.CheckinStatus = (int)Enums.CheckinStatus.Completed;
//                            _checkinRepository.Edit(checkin);
//                            _checkinRepository.Save();
//                            //innerData.Checkin = checkin;
//                            Console.WriteLine("Checkin Kapatma Bitişi");
//                        }
//                    }
//                    var servicePlace = _servicePlaceRepository.GetSingle(bill.ServicePlaceId);
//                    var servicePlaceUser = _userRepository.GetSingle(servicePlace.UserId);
//                    var waiterUser = new User();
//                    if (bill.WaiterUserId != null)
//                    {
//                        waiterUser = _userRepository.GetSingle((long)bill.WaiterUserId);
//                    }
//                    if (servicePlaceUser != null && servicePlaceUser.PushToken != null)
//                    {
//                        toListSubPaymentServicePlace.Add(servicePlaceUser.PushToken);
//                    }
//                    if (waiterUser != null && waiterUser.PushToken != null)
//                    {
//                        toListSubPaymentServicePlace.Add(waiterUser.PushToken);
//                    }
//                    if (bill.IsOriginalBill != true)
//                    {
//                        Bill b = _billRepository.GetSingle(Convert.ToInt32(bill.OriginalBillId));
//                        User u = _userRepository.GetSingle(Convert.ToInt32(b.CreatorUserId));

//                        if (u != null && u.PushToken != null)
//                        {
//                            if (b.BillStatus == (int)Enums.BillStatus.ClosedPaid)
//                            {
//                                toList.Add(u.PushToken);
//                            }
//                            toListSubPayment.Add(u.PushToken);
//                        }
//                    }
//                    if (bill.CreatorUserId != null && bill.CreatorUserId != 0)
//                    {
//                        creatorUser = _userRepository.GetSingle(Convert.ToInt32(bill.CreatorUserId));
//                    }
//                    if (bill.CreatorUserId != bill.PayerUserId && (bill.PayerUserId != null && bill.PayerUserId != 0))
//                    {
//                        var userPayer = _userRepository.GetSingle(Convert.ToInt32(bill.PayerUserId));
//                        userPayer.Bill = null;
//                        if (userPayer != null && userPayer.PushToken != null)
//                        {
//                            toList.Add(userPayer.PushToken);
//                        }
//                    }
//                    BillModel originalbill = new BillModel();
//                    if (bill.IsOriginalBill == false)
//                    {
//                        originalbill = new BillModel().ToSubBillsDTO(_billRepository.GetSingle(Convert.ToInt32(bill.OriginalBillId)));
//                        var childs = _billRepository.GetAll().Where(x => x.OriginalBillId == originalbill.Id).Select(new BillModel().ToSubBillsDTO).ToList();
//                        //result.ChildBills =_billRepository.GetAll().Where(x => x.OriginalBillId == billId).ToList();
//                        if (childs != null && childs.Count > 0)
//                        {
//                            foreach (var item in childs)
//                            {
//                                User u = _userRepository.GetSingle(Convert.ToInt32(item.CreatorUserId));
//                                if (u != null && u.PushToken != null)
//                                {
//                                    toListSubPayment.Add(u.PushToken);
//                                }
//                            }
//                            originalbill.ChildBills = childs;
//                        }
//                    }
//                    //innerData.Bill = originalbill;
//                    //originalbill.User = null;
//                    //originalbill.Payment = null;
//                    //if (innerData.Reservation != null)
//                    //{
//                    //    innerData.Reservation.Bill = null;
//                    //    innerData.Reservation.User = null;
//                    //}
//                    innerData.Payment = payment;
//                    result.IsSuccessful = true;
//                    Console.WriteLine("Ödeme Success Bitişi");
//                }
//                else
//                {
//                    data.IsSuccessful = false;
//                    data.Message = threedsPayment.ErrorMessage;
//                    result.IsSuccessful = false;
//                }

//            }
//            catch (Exception e)
//            {
//                result.IsSuccessful = false;
//                result.Exception = e;
//                data.IsSuccessful = false;
//                data.Message = "Son" + e.Message;
//            }
//            finally
//            {
//                toList.Add(creatorUser.PushToken);
//                data.Data = innerData;
//                model.data = data;
//                Console.WriteLine("PushNotification Oncesi");
//                string[] to = toList.ToArray();
//                string[] toSubPayment = toListSubPayment.ToArray();
//                string[] toSubPaymentServicePlace = toListSubPaymentServicePlace.ToArray();


//                _pushNotificationService.SendMessageToDevice(to, model);

//                ConsoleLogWithData("Checkout model", model);
//                ConsoleLogWithData("Checkout to", to);

//                Object pushResponseSub = null;
//                Object pushResponseSubServicePlace = null;

//                if (toSubPayment != null && toSubPayment.Length > 0)
//                {
//                    dynamic subPaymentData = new ExpandoObject();
//                    subPaymentData.Action = "someonemadepayment";
//                    subPaymentData.Route = "billupdate";
//                    g = Guid.NewGuid();
//                    subPaymentData.Id = g.ToString();

//                    //model.data = new Bill();
//                    model.data = subPaymentData;
//                    model.title = _localizer["somebodyjoinedthepayment"].ToString();

//                    pushResponseSub = _pushNotificationService.SendMessageToDevice(toSubPayment, model).Data;
//                    if (toSubPaymentServicePlace != null && toSubPaymentServicePlace.Length > 0)
//                    {
//                        pushResponseSubServicePlace = _pushNotificationService.SendMessageToDevice(toSubPaymentServicePlace, model).Data;
//                    }
//                }


//                ConsoleLogWithData("Someonemakepayment model", model);
//                ConsoleLogWithData("Someonemakepayment to", toSubPayment);
//                ConsoleLogWithData("Someonemakepayment push response", pushResponseSub);

//                ConsoleLogWithData("SomeonemakepaymentservicePlace model", model);
//                ConsoleLogWithData("SomeonemakepaymentservicePlace to", toSubPayment);
//                ConsoleLogWithData("SomeonemakepaymentservicePlace push response", pushResponseSubServicePlace);

//                Console.WriteLine("PushNotification Sonrası");
//                result.Data = threedsPayment;
//            }
//            Console.WriteLine("PaymentCallback Bitişi");

//            return result;
//        }

//        public void ConsoleLogWithData(string title, Object data)
//        {
//            var jsonmodel = JsonConvert.SerializeObject(data, new JsonSerializerSettings
//            {
//                MaxDepth = 1,
//                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
//                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
//            });
//            Console.WriteLine(title);
//            Console.WriteLine(jsonmodel);
//        }
//    }
//}