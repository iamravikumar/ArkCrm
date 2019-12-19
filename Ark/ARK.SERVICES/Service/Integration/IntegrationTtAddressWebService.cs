using ARK.CORE.Common;
using ARK.CORE.Data;
using ARK.CORE.Response;
using ARK.DATA.Models;
using ARK.MODEL.V1.Integration.TtAddressWebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TtAdresWebService;

namespace ARK.SERVICES.Service.Integration
{
    public class IntegrationTtAddressWebService : IIntegrationTtAddressWebService
    {
        private IRepository<AddressNationality> _nationalityRepository;
        private IRepository<AddressCity> _cityRepository;
        private IRepository<AddressDistrict> _districtRepository;
        private IRepository<AddressMunicipality> _municipalityRepository;
        private IRepository<AddressTownship> _townshipRepository;
        private IRepository<AddressVillage> _villageRepository;
        private IRepository<AddressQuarter> _quarterRepository;
        private IRepository<AddressCsbm> _csbmRepository;
        private IRepository<AddressSite> _siteRepository;
        private readonly IRepository<AddressBuilding> _buildingRepository;

        public IntegrationTtAddressWebService(
            IRepository<AddressNationality> nationalityRepository,
            IRepository<AddressCity> cityRepository,
            IRepository<AddressDistrict> districtRepository,
            IRepository<AddressMunicipality> municipalityRepository,
            IRepository<AddressTownship> townshipRepository,
            IRepository<AddressVillage> villageRepository,
            IRepository<AddressQuarter> quarterRepository,
            IRepository<AddressCsbm> csbmRepository,
            IRepository<AddressSite> siteRepository,
            IRepository<AddressBuilding> buildingRepository
            )
        {
            var context = new ArkDatabaseContext();
            _nationalityRepository = nationalityRepository;
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _municipalityRepository = municipalityRepository;
            _townshipRepository = townshipRepository;
            _villageRepository = villageRepository;
            _quarterRepository = quarterRepository;
            _csbmRepository = csbmRepository;
            _siteRepository = siteRepository;
            _buildingRepository = buildingRepository;
        }
        
        public async Task<ServiceResponse<TTAUlkeType>> InsertNationalitiesAsync()
        {
            try
            {
               //ULKELER
               var head = new RequestHeaderType
               {
                   BusinessID = "1",
                   ConversationID = "1",
                   MessageID = null,
                   RequestID = "1"
               };
                var req = new UlkeListesiGetirRequestBodyType
                {
                    GirdiParametreleri = new EkParametreType[]
                    {
                        new EkParametreType
                        {
                            Deger = null,
                            Ad = null
                        }
                    }
                };

                TtAdresServiceSOAPClient asd = new TtAdresServiceSOAPClient();
                var request = await asd.UlkeListesiGetirAsync(head, req);

                var response = request.UlkeListesiGetirResponseBody.Item as UlkeListesiGetirResponseBodySuccessType;

                var items = response.UlkeListesi.ToList();

                List<AddressNationality> ooo = new List<AddressNationality>();
                foreach (var item in items)
                {
                    ooo.Add(new AddressNationality
                    {
                        Code = (int)item.Kod,
                        CreateDate = TimeStamp.ToUnixTimestamp(DateTime.Now),
                        CreateUser = 1,
                        Name = item.Ad,
                        ServiceUpdateDate = item.GuncellemeZamani
                    });
                }
                
                _nationalityRepository.Insert(ooo);

                return new ServiceResponse<TTAUlkeType>();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TTAUlkeType>(ex);
            }            
        }

        public async Task<ServiceResponse<TTAIlType>> InsertCitiesAsync()
        {
            try
            {
                // ILLER
                var head = new RequestHeaderType
                {
                    BusinessID = "1",
                    ConversationID = "1",
                    MessageID = null,
                    RequestID = "1"
                };
                var req = new IlListesiGetirRequestBodyType
                {
                    GirdiParametreleri = new EkParametreType[]
                    {
                        new EkParametreType
                        {
                            Deger = null,
                            Ad = null
                        }
                    }
                };

                TtAdresServiceSOAPClient asd = new TtAdresServiceSOAPClient();
                var request = await asd.IlListesiGetirAsync(head, req);

                var response = request.IlListesiGetirResponseBody.Item as IlListesiGetirResponseBodySuccessType;

                var items = response.IlListesi.ToList();

                List<AddressCity> ooo = new List<AddressCity>();
                var noww = DateTime.Now;
                foreach (var item in items)
                {
                    ooo.Add(new AddressCity
                    {
                        Code = (int)item.Kod,
                        CreateDate = TimeStamp.ToUnixTimestamp(noww),
                        CreateUser = 1,
                        Name = item.Ad,
                        ServiceUpdateDate = item.GuncellemeZamani,
                        NationalityCode = (int)item.UlkeKodu,
                        NationalityId = 25,
                        StatusId = (int)item.Durum
                    });
                }
                
                _cityRepository.Insert(ooo);


                return new ServiceResponse<TTAIlType>();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TTAIlType>(ex);
            }
        }

        public async Task<ServiceResponse<TTAIlceType>> InsertDistrictsAsync()
        {
            try
            {

                var city = _cityRepository.TableNoTracking;
                var cities = city.ToList();

                // ILLER
                var head = new RequestHeaderType
                {
                    BusinessID = "1",
                    ConversationID = "1",
                    MessageID = null,
                    RequestID = "1"
                };

                List<AddressDistrict> ooo = new List<AddressDistrict>();

                foreach (var item in cities)
                {
                    if (item.Code > 0)
                    {
                        var req = new IleBagliIlceListesiGetirRequestBodyType
                        {
                            GirdiParametreleri = new EkParametreType[]
                            {

                                new EkParametreType
                                {
                                    Deger = null,
                                    Ad = null
                                }
                            },
                            IlKodu = (long)item.Code
                        };

                        TtAdresServiceSOAPClient asd = new TtAdresServiceSOAPClient();
                        var request = await asd.IleBagliIlceListesiGetirAsync(head, req);

                        var response = request.IleBagliIlceListesiGetirResponseBody.Item as IleBagliIlceListesiGetirResponseBodySuccessType;

                        var items = response.IleBagliIlceListesi.ToList();

                        var noww = DateTime.Now;
                        foreach (var item2 in items)
                        {
                            ooo.Add(new AddressDistrict
                            {
                                Code = (int)item2.Kod,
                                CreateDate = TimeStamp.ToUnixTimestamp(noww),
                                CreateUser = 1,
                                Name = item2.Ad,
                                ServiceUpdateDate = item2.GuncellemeZamani,
                                CityCode = (int)item2.IlKodu,
                                StatusId = (int)item2.Durum,
                                CityId = item.ID
                            });
                        }
                    }
                }               
                
                _districtRepository.Insert(ooo);

                return new ServiceResponse<TTAIlceType>();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TTAIlceType>(ex);
            }
        }

        public async Task<ServiceResponse<TTABelediyeTTType>> InsertMunicipalitiesAsync()
        {
            try
            {

                var city = _cityRepository.TableNoTracking;
                var cities = city.ToList();

                // ILLER
                var head = new RequestHeaderType
                {
                    BusinessID = "1",
                    ConversationID = "1",
                    MessageID = null,
                    RequestID = "1"
                };

                List<AddressMunicipality> ooo = new List<AddressMunicipality>();

                foreach (var item in cities)
                {
                    if (item.Code > 0)
                    {
                        var req = new IleBagliBelediyeListesiGetirRequestBodyType
                        {
                            GirdiParametreleri = new EkParametreType[]
                            {

                                new EkParametreType
                                {
                                    Deger = null,
                                    Ad = null
                                }
                            },
                            IlKodu = (long)item.Code
                        };

                        TtAdresServiceSOAPClient asd = new TtAdresServiceSOAPClient();
                        var request = await asd.IleBagliBelediyeListesiGetirAsync(head, req);

                        var response = request.IleBagliBelediyeListesiGetirResponseBody.Item as IleBagliBelediyeListesiGetirResponseBodySuccessType;

                        var items = response.BelediyeListesi.ToList();

                        var noww = DateTime.Now;
                        foreach (var item2 in items)
                        {
                            ooo.Add(new AddressMunicipality
                            {
                                Code = (int)item2.Kod,
                                CreateDate = TimeStamp.ToUnixTimestamp(noww),
                                CreateUser = 1,
                                Name = item2.Ad,
                                ServiceUpdateDate = item2.GuncellemeZamani,
                                CityCode = (int)item2.IlKodu,
                                StatusId = (int)item2.Durum,
                                CityId = item.ID
                            });
                        }
                    }
                }

                _municipalityRepository.Insert(ooo);

                return new ServiceResponse<TTABelediyeTTType>();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TTABelediyeTTType>(ex);
            }
        }

        public async Task<ServiceResponse<TTABucakType>> InsertTownshipAsync() //bucak
        {
            try
            {

                var parent = _districtRepository.TableNoTracking;
                var parents = parent.ToList();

                // ILLER
                var head = new RequestHeaderType
                {
                    BusinessID = "1",
                    ConversationID = "1",
                    MessageID = null,
                    RequestID = "1"
                };

                List<AddressTownship> ooo = new List<AddressTownship>();

                foreach (var item in parents)
                {
                    if (item.Code > 0 && item.StatusId == 1)
                    {
                        var req = new IlceyeBagliBucakListesiGetirRequestBodyType
                        {
                            GirdiParametreleri = new EkParametreType[]
                            {

                                new EkParametreType
                                {
                                    Deger = null,
                                    Ad = null
                                }
                            },
                            IlceKodu = (long)item.Code
                        };

                        TtAdresServiceSOAPClient soap = new TtAdresServiceSOAPClient();
                        var request = await soap.IlceyeBagliBucakListesiGetirAsync(head, req);

                        var response = request.IlceyeBagliBucakListesiGetirResponseBody.Item as IlceyeBagliBucakListesiGetirResponseBodySuccessType;

                        var items = response.IlceyeBagliBucakListesi.ToList();

                        var noww = DateTime.Now;
                        foreach (var item2 in items)
                        {
                            ooo.Add(new AddressTownship
                            {
                                Code = (int)item2.Kod,
                                CreateDate = TimeStamp.ToUnixTimestamp(noww),
                                CreateUser = 1,
                                Name = item2.Ad,
                                ServiceUpdateDate = item2.GuncellemeZamani,
                                StatusId = (int)item2.Durum,
                                DistrictId = item.ID,
                                DistrictCode = (int)item2.IlceKodu,
                                QueueNo = (int)item2.SiraNo
                            });
                        }
                    }
                }

                _townshipRepository.Insert(ooo);

                return new ServiceResponse<TTABucakType>();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TTABucakType>(ex);
            }
        }

        public async Task<ServiceResponse<TTAKoyType>> InsertVillageAsync()
        {
            try
            {

                var parent = _townshipRepository.TableNoTracking;
                var parents = parent.ToList();

                // ILLER
                var head = new RequestHeaderType
                {
                    BusinessID = "1",
                    ConversationID = "1",
                    MessageID = null,
                    RequestID = "1"
                };

                List<AddressVillage> ooo = new List<AddressVillage>();

                foreach (var item in parents)
                {
                    if (item.Code > 0 && item.StatusId == 1)
                    {
                        var req = new BucagaBagliKoyListesiGetirRequestBodyType
                        {
                            GirdiParametreleri = new EkParametreType[]
                            {

                                new EkParametreType
                                {
                                    Deger = null,
                                    Ad = null
                                }
                            },
                            BucakKodu = (long)item.Code
                        };

                        TtAdresServiceSOAPClient soap = new TtAdresServiceSOAPClient();
                        var request = await soap.BucagaBagliKoyListesiGetirAsync(head, req);

                        var response = request.BucagaBagliKoyListesiGetirResponseBody.Item as BucagaBagliKoyListesiGetirResponseBodySuccessType;

                        var items = response.BucagaBagliKoyListesi.ToList();

                        var noww = DateTime.Now;
                        foreach (var item2 in items)
                        {
                            ooo.Add(new AddressVillage
                            {
                                Code = (int)item2.Kod,
                                CreateDate = TimeStamp.ToUnixTimestamp(noww),
                                CreateUser = 1,
                                Name = item2.Ad,
                                ServiceUpdateDate = item2.GuncellemeZamani,
                                StatusId = (int)item2.Durum,
                                TownshipId = item.ID,
                                TownshipCode = item.Code,
                                QueueNo = (int)item2.SiraNo
                            });
                        }
                    }
                }

                _villageRepository.Insert(ooo);

                return new ServiceResponse<TTAKoyType>();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TTAKoyType>(ex);
            }
        }

        public async Task<ServiceResponse<TTAMahalleType>> InsertQuarterAsync()
        {
            try
            {
                var parent = _villageRepository.TableNoTracking;
                var parents = parent.ToList();

                var head = new RequestHeaderType
                {
                    BusinessID = "1",
                    ConversationID = "1",
                    MessageID = null,
                    RequestID = "1"
                };

                List<AddressQuarter> ooo = new List<AddressQuarter>();

                foreach (var item in parents)
                {
                    if (item.Code > 0 && item.StatusId == 1)
                    {
                        var req = new KoyeBagliMahalleListesiGetirRequestBodyType
                        {
                            GirdiParametreleri = new EkParametreType[]
                            {

                                new EkParametreType
                                {
                                    Deger = null,
                                    Ad = null
                                }
                            },
                            KoyKodu = (long)item.Code
                        };

                        TtAdresServiceSOAPClient soap = new TtAdresServiceSOAPClient();
                        var request = await soap.KoyeBagliMahalleListesiGetirAsync(head, req);

                        var response = request.KoyeBagliMahalleListesiGetirResponseBody.Item as KoyeBagliMahalleListesiGetirResponseBodySuccessType;

                        var items = response.KoyeBagliMahalleListesi.ToList();

                        var noww = DateTime.Now;
                        foreach (var item2 in items)
                        {
                            int typeId = 0;
                            switch (item2.Tipi)
                            {
                                case 0:
                                    typeId = 1;
                                    break;
                                case 1:
                                    typeId = 2;
                                    break;
                                case 3:
                                    typeId = 3;
                                    break;
                                case 4:
                                    typeId = 4;
                                    break;
                                case 5:
                                    typeId = 5;
                                    break;
                                case 6:
                                    typeId = 6;
                                    break;
                                default:
                                    break;
                            }


                            ooo.Add(new AddressQuarter
                            {
                                Code = (int)item2.Kod,
                                CreateDate = TimeStamp.ToUnixTimestamp(noww),
                                CreateUser = 1,
                                Name = item2.Ad,
                                Name2 = item2.Ad2,
                                OldName = item2.EskiAd,
                                ServiceUpdateDate = item2.GuncellemeZamani,
                                StatusId = (int)item2.Durum,
                                VillageId = item.ID,
                                VillageCode = item.Code,
                                AuthorizedAdminCode = item2.YetkiliIdareKodu != null ? (int)item2.YetkiliIdareKodu : new Nullable<int>(),
                                MunicipalityCode = item2.BelediyeKodu != null ? (int)item2.BelediyeKodu : new Nullable<int>(),
                                QuarterTypeId = typeId
                            });
                        }
                    }
                }

                _quarterRepository.Insert(ooo);

                return new ServiceResponse<TTAMahalleType>();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TTAMahalleType>(ex);
            }
        }

        public async Task<ServiceResponse<TTACSBMType>> InsertCsbmAsync()
        {
            try
            {
                var parent = _quarterRepository.TableNoTracking;
                var parents = parent.ToList();

                var head = new RequestHeaderType
                {
                    BusinessID = "1",
                    ConversationID = "1",
                    MessageID = null,
                    RequestID = "1"
                };

                List<AddressCsbm> ooo = new List<AddressCsbm>();

                foreach (var item in parents)
                {
                    if (item.Code > 0 && item.StatusId == 1)
                    {
                        var req = new MahalleyeBagliCsbmListesiGetirRequestBodyType
                        {
                            GirdiParametreleri = new EkParametreType[]
                            {

                                new EkParametreType
                                {
                                    Deger = null,
                                    Ad = null
                                }
                            },
                            MahalleKodu = (long)item.Code
                        };

                        TtAdresServiceSOAPClient soap = new TtAdresServiceSOAPClient();
                        var request = await soap.MahalleyeBagliCsbmListesiGetirAsync(head, req);

                        var response = request.MahalleyeBagliCsbmListesiGetirResponseBody.Item as MahalleyeBagliCsbmListesiGetirResponseBodySuccessType;

                        var items = response.MahalleyeBagliCsbmListesi.ToList();

                        var noww = DateTime.Now;
                        foreach (var item2 in items)
                        {
                            int typeId = 0;
                            switch (item2.Tipi)
                            {
                                case 0:
                                    typeId = 1;
                                    break;
                                case 1:
                                    typeId = 2;
                                    break;
                                case 2:
                                    typeId = 3;
                                    break;
                                case 3:
                                    typeId = 4;
                                    break;
                                case 4:
                                    typeId = 5;
                                    break;
                                case 5:
                                    typeId = 6;
                                    break;
                                default:
                                    break;
                            }

                            Console.WriteLine(item2.Kod);

                            ooo.Add(new AddressCsbm
                            {
                                Code = (int)item2.Kod,
                                CreateDate = TimeStamp.ToUnixTimestamp(noww),
                                CreateUser = 1,
                                Name = item2.Ad,
                                Name2 = item2.Ad2,
                                OldName = item2.EskiAd,
                                ServiceUpdateDate = item2.GuncellemeZamani,
                                StatusId = (int)item2.Durum,
                                CsbmTypeId = typeId,
                                QuarterCode = (int)item2.MahalleKodu,
                                QuarterId = item.ID
                            });
                        }
                    }
                }

                _csbmRepository.Insert(ooo);

                return new ServiceResponse<TTACSBMType>();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TTACSBMType>(ex);
            }
        }

        public async Task<ServiceResponse<TTASiteType>> InsertSitesAsync()
        {
            try
            {
                var parent = _quarterRepository.TableNoTracking;
                var parents = parent.ToList();

                var head = new RequestHeaderType
                {
                    BusinessID = "1",
                    ConversationID = "1",
                    MessageID = null,
                    RequestID = "1"
                };

                List<AddressSite> ooo = new List<AddressSite>();

                foreach (var item in parents)
                {
                    if (item.Code > 0 && item.StatusId == 1)
                    {
                        var req = new MahalledekiSiteListesiRequestBodyType
                        {
                            GirdiParametreleri = new EkParametreType[]
                            {

                                new EkParametreType
                                {
                                    Deger = null,
                                    Ad = null
                                }
                            },
                            MahalleKodu = (long)item.Code
                        };                        

                        TtAdresServiceSOAPClient soap = new TtAdresServiceSOAPClient();
                        var request = await soap.MahalledekiSiteListesiAsync(head, req);
                        var response = request.MahalledekiSiteListesiResponseBody.Item as MahalledekiSiteListesiResponseBodySuccessType;
                        if (response.TTASiteListesi.Count() > 0)
                        {
                            var items = response.TTASiteListesi;
                            var noww = DateTime.Now;
                            foreach (var item2 in items)
                            {
                                Console.WriteLine("Mahalle ID: "+ item.ID + " Site Kodu:" +item2.Kod);
                                ooo.Add(new AddressSite
                                {
                                    Code = (int)item2.Kod,
                                    CreateDate = TimeStamp.ToUnixTimestamp(noww),
                                    CreateUser = 1,
                                    Name = item2.Ad,
                                    ServiceUpdateDate = item2.GuncellemeZamani,
                                    QuarterCode = (int)item2.MahalleKodu,
                                    QuarterId = item.ID
                                });
                            }
                        }

                        
                    }
                }

                if (ooo.Count > 0)
                {
                    _siteRepository.Insert(ooo);
                }                

                return new ServiceResponse<TTASiteType>();
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TTASiteType>(ex);
            }
        }

        //public async Task<ServiceResponse<TTABinaType, TTABinaModel>> InsertBuildingsAsync()
        //{
        //    try
        //    {
        //        var parent = _csbmRepository.TableNoTracking;
        //        var parents = parent.Where(z => z.ID < 50001).OrderBy(x => x.ID).ToList();

        //        var head = new RequestHeaderType
        //        {
        //            BusinessID = "1",
        //            ConversationID = "1",
        //            MessageID = null,
        //            RequestID = "1"
        //        };

        //        List<AddressBuilding> ooo = new List<AddressBuilding>();

        //        foreach (var item in parents)
        //        {
        //            if (item.Code > 0 && item.StatusId == 1)
        //            {
        //                var req = new CsbmyeBagliBinaListesiGetirRequestBodyType
        //                {
        //                    GirdiParametreleri = new EkParametreType[]
        //                    {

        //                        new EkParametreType
        //                        {
        //                            Deger = null,
        //                            Ad = null
        //                        }
        //                    },
        //                    CSBMKodu = (long)item.Code
        //                };

                        

        //                TtAdresServiceSOAPClient soap = new TtAdresServiceSOAPClient();
        //                var request = await soap.CsbmyeBagliBinaListesiGetirAsync(head, req);
        //                var response = request.CsbmyeBagliBinaListesiGetirResponseBody.Item as CsbmyeBagliBinaListesiGetirResponseBodySuccessType;
        //                if (response.CsbmyeBagliBinaListesi.Count() > 0)
        //                {
        //                    var items = response.CsbmyeBagliBinaListesi;
        //                    var noww = DateTime.Now;
        //                    Console.WriteLine("CSBM ID: " + item.ID);
        //                    foreach (var item2 in items)
        //                    {

        //                        int typeId = 0;
        //                        switch (item2.Nitelik)
        //                        {
        //                            case -99:
        //                                typeId = 1;
        //                                break;
        //                            case 1:
        //                                typeId = 2;
        //                                break;
        //                            case 2:
        //                                typeId = 3;
        //                                break;
        //                            case 3:
        //                                typeId = 4;
        //                                break;
        //                            case 4:
        //                                typeId = 5;
        //                                break;
        //                            case 5:
        //                                typeId = 6;
        //                                break;
        //                            case 6:
        //                                typeId = 7;
        //                                break;
        //                            case 7:
        //                                typeId = 8;
        //                                break;
        //                            case 8:
        //                                typeId = 9;
        //                                break;
        //                            case 9:
        //                                typeId = 10;
        //                                break;
        //                            case 10:
        //                                typeId = 11;
        //                                break;
        //                            default:
        //                                break;
        //                        }

                                
        //                        ooo.Add(new AddressBuilding
        //                        {
        //                            Code = (int)item2.Kod,
        //                            CreateDate = TimeStamp.ToUnixTimestamp(noww),
        //                            CreateUser = 1,
        //                            Name = item2.BlokAdi,
        //                            ServiceUpdateDate = item2.GuncellemeZamani,
        //                            CsbmCode = (int)item2.CSBMKodu,
        //                            CsbmId= item.ID,
        //                            BuildingTypeId = typeId,
        //                            BlockName = item2.BlokAdi,
        //                            BlockName2 = item2.BlokAdi2,
        //                            OldBlockName = item2.BlokEskiAdi,
        //                            OldBuildingCode = item2.EsBinaKodu != null ? (int)item2.EsBinaKodu : new Nullable<int>(),
        //                            PostCode = item2.PostaKodu,
        //                            SiteName = item2.SiteAdi,
        //                            SiteName2 = item2.SiteAdi2,
        //                            SiteOldName = item2.SiteEskiAdi,                                    
        //                            StatusId = (int)item2.Durum                                    
        //                        });
        //                    }
        //                }
        //            }
        //        }

        //        if (ooo.Count > 0)
        //        {
        //            _buildingRepository.Insert(ooo);
        //        }

        //        return new ServiceResponse<TTABinaType, TTABinaModel>();
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ServiceResponse<TTABinaType, TTABinaModel>(ex);
        //    }
        //}
    }
}
