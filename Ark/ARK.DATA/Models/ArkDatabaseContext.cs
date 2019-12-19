using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ARK.DATA.Models
{
    public class ArkDatabaseContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {

        public ArkDatabaseContext()
        {

        }

        public ArkDatabaseContext(DbContextOptions<ArkDatabaseContext> options) : base(options)
        {
        }

        //view
        public virtual DbSet<CustomerView> CustomerView { get; set; }
        public virtual DbSet<AccountView> AccountView { get; set; }

        // table
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountAddressType> AccountAddressType { get; set; }
        public virtual DbSet<AccountCampaign> AccountCampaign { get; set; }
        public virtual DbSet<AccountType> AccountType { get; set; }
        public virtual DbSet<AccountAddress> AccountAddress { get; set; }
        public virtual DbSet<AccountCompanyType> AccountCompanyType { get; set; }
        public virtual DbSet<AccountCommunication> AccountCommunication { get; set; }
        public virtual DbSet<AccountCommunicationType> AccountCommunicationType { get; set; }
        public virtual DbSet<AccountProfile> AccountProfile { get; set; }
        public virtual DbSet<AddressBB> AddressBB { get; set; }
        public virtual DbSet<AddressBBType> AddressBBType { get; set; }        
        public virtual DbSet<AddressBuilding> AddressBuilding { get; set; }
        public virtual DbSet<AddressBuildingType> AddressBuildingType { get; set; }        
        public virtual DbSet<AddressCity> AddressCity { get; set; }
        public virtual DbSet<AddressCsbm> AddressCsbm { get; set; }
        public virtual DbSet<AddressCsbmType> AddressCsbmType { get; set; }
        public virtual DbSet<AddressMunicipality> AddressMunicipality { get; set; }
        public virtual DbSet<AddressQuarterType> AddressQuarterType { get; set; }
        public virtual DbSet<AddressSite> AddressSite { get; set; }
        public virtual DbSet<AddressTownship> AddressTownship { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<AddressVillage> AddressVillage { get; set; }
        public virtual DbSet<AddressDistrict> AddressDistrict { get; set; }
        public virtual DbSet<AddressNationality> AddressNationality { get; set; }
        public virtual DbSet<AddressQuarter> AddressQuarter { get; set; }
        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<CampaignSpeed> CampaignSpeed { get; set; }
        public virtual DbSet<CampaignParameterList> CampaignParameterList { get; set; }
        public virtual DbSet<PaymentCardDetail> PaymentCardDetail { get; set; }
        public virtual DbSet<Commitment> Commitment { get; set; }
        public virtual DbSet<CommitmentPeriod> CommitmentPeriod { get; set; }
        public virtual DbSet<CommitmentPromotion> CommitmentPromotion { get; set; }
        public virtual DbSet<CommitmentStatus> CommitmentStatus { get; set; }
        public virtual DbSet<CommitmentType> CommitmentType { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerSource> CustomerSource { get; set; }
        public virtual DbSet<IdentityType> IdentityType { get; set; }
        public virtual DbSet<Infrastructure> Infrastructure { get; set; }
        public virtual DbSet<Insurance> Insurance { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceType> InvoiceType { get; set; }
        public virtual DbSet<InvoiceHistory> InvoiceHistory { get; set; }
        public virtual DbSet<InvoiceRevision> InvoiceRevision { get; set; }
        public virtual DbSet<InvoiceService> InvoiceService { get; set; }
        public virtual DbSet<InvoiceServiceTax> InvoiceServiceTax { get; set; }
        public virtual DbSet<InvoiceStatus> InvoiceStatus { get; set; }
        public virtual DbSet<InvoiceTaxType> InvoiceTaxType { get; set; }
        public virtual DbSet<LogMongoException> LogMongoException { get; set; }
        public virtual DbSet<LogWeb> LogWeb { get; set; }
        public virtual DbSet<Mikrotik> Mikrotik { get; set; }
        public virtual DbSet<MikrotikIP> MikrotikIP { get; set; }
        public virtual DbSet<MikrotikLine> MikrotikLine { get; set; }
        public virtual DbSet<MikrotikLineType> MikrotikLineType { get; set; }
        public virtual DbSet<RetailerMikrotik> RetailerMikrotik { get; set; }
        public virtual DbSet<RetailerPaymentType> RetailerPaymentType { get; set; }
        public virtual DbSet<RetailerPrice> RetailerPrice { get; set; }
        public virtual DbSet<RetailerType> RetailerType { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Parameter> Parameter { get; set; }
        public virtual DbSet<ParameterList> ParameterList { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductBrand> ProductBrand { get; set; }
        public virtual DbSet<ProductModel> ProductModel { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Receiver> Receiver { get; set; }
        public virtual DbSet<Retailer> Retailer { get; set; }
        public virtual DbSet<SpeedLimitType> SpeedLimitType { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<TaxAdministrationCity> TaxAdministrationCity { get; set; }
        public virtual DbSet<TaxAdministrationDistrict> TaxAdministrationDistrict { get; set; }
        public virtual DbSet<PaymentSetting> PaymentSetting { get; set; }
        public virtual DbSet<SmsCorporate> SmsCorporate { get; set; }
        public virtual DbSet<SmsSetting> SmsSetting { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=37.230.108.251;Database=ARK_DEV;User Id=saa2;Password=0qB-4#pY;");
            }
        }

        /// <summary>
        /// Further configuration the model
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            ////dynamically load all entity and query type configurations
            //var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
            //    (type.BaseType?.IsGenericType ?? false)
            //        && (type.BaseType.GetGenericTypeDefinition() == typeof(NopEntityTypeConfiguration<>)
            //            || type.BaseType.GetGenericTypeDefinition() == typeof(NopQueryTypeConfiguration<>)));

            //foreach (var typeConfiguration in typeConfigurations)
            //{
            //    var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
            //    configuration.ApplyConfiguration(modelBuilder);
            //}

            //base.OnModelCreating(modelBuilder);


            
            modelBuilder.Ignore<CustomerView>();
            modelBuilder.Entity<CustomerView>().ToView("CustomerView");
            modelBuilder.Ignore<AccountView>();
            modelBuilder.Entity<AccountView>().ToView("AccountView");
            base.OnModelCreating(modelBuilder);
        }


        /// <summary>
        /// Modify the input SQL query by adding passed parameters
        /// </summary>
        /// <param name="sql">The raw SQL query</param>
        /// <param name="parameters">The values to be assigned to parameters</param>
        /// <returns>Modified raw SQL query</returns>
        protected virtual string CreateSqlWithParameters(string sql, params object[] parameters)
        {
            //add parameters to sql
            for (var i = 0; i <= (parameters?.Length ?? 0) - 1; i++)
            {
                if (!(parameters[i] is DbParameter parameter))
                    continue;

                sql = $"{sql}{(i > 0 ? "," : string.Empty)} @{parameter.ParameterName}";

                //whether parameter is output
                if (parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Output)
                    sql = $"{sql} output";
            }

            return sql;
        }

        #region Methods

        ///// <summary>
        ///// Creates a DbSet that can be used to query and save instances of entity
        ///// </summary>
        ///// <typeparam name="TEntity">Entity type</typeparam>
        ///// <returns>A set for the given entity type</returns>
        //public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        //{
        //    return base.Set<TEntity>();
        //}

        ///// <summary>
        ///// Generate a script to create all tables for the current model
        ///// </summary>
        ///// <returns>A SQL script</returns>
        //public virtual string GenerateCreateScript()
        //{
        //    return Database.GenerateCreateScript();
        //}

        ///// <summary>
        ///// Creates a LINQ query for the query type based on a raw SQL query
        ///// </summary>
        ///// <typeparam name="TQuery">Query type</typeparam>
        ///// <param name="sql">The raw SQL query</param>
        ///// <param name="parameters">The values to be assigned to parameters</param>
        ///// <returns>An IQueryable representing the raw SQL query</returns>
        //public virtual IQueryable<TQuery> QueryFromSql<TQuery>(string sql, params object[] parameters) where TQuery : class
        //{
        //    return Query<TQuery>().FromSql(CreateSqlWithParameters(sql, parameters), parameters);
        //}

        ///// <summary>
        ///// Creates a LINQ query for the entity based on a raw SQL query
        ///// </summary>
        ///// <typeparam name="TEntity">Entity type</typeparam>
        ///// <param name="sql">The raw SQL query</param>
        ///// <param name="parameters">The values to be assigned to parameters</param>
        ///// <returns>An IQueryable representing the raw SQL query</returns>
        //public virtual IQueryable<TEntity> EntityFromSql<TEntity>(string sql, params object[] parameters) where TEntity : BaseEntity
        //{
        //    return Set<TEntity>().FromSql(CreateSqlWithParameters(sql, parameters), parameters);
        //}

        ///// <summary>
        ///// Executes the given SQL against the database
        ///// </summary>
        ///// <param name="sql">The SQL to execute</param>
        ///// <param name="doNotEnsureTransaction">true - the transaction creation is not ensured; false - the transaction creation is ensured.</param>
        ///// <param name="timeout">The timeout to use for command. Note that the command timeout is distinct from the connection timeout, which is commonly set on the database connection string</param>
        ///// <param name="parameters">Parameters to use with the SQL</param>
        ///// <returns>The number of rows affected</returns>
        //public virtual int ExecuteSqlCommand(RawSqlString sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        //{
        //    //set specific command timeout
        //    var previousTimeout = Database.GetCommandTimeout();
        //    Database.SetCommandTimeout(timeout);

        //    var result = 0;
        //    if (!doNotEnsureTransaction)
        //    {
        //        //use with transaction
        //        using (var transaction = Database.BeginTransaction())
        //        {
        //            result = Database.ExecuteSqlCommand(sql, parameters);
        //            transaction.Commit();
        //        }
        //    }
        //    else
        //        result = Database.ExecuteSqlCommand(sql, parameters);

        //    //return previous timeout back
        //    Database.SetCommandTimeout(previousTimeout);

        //    return result;
        //}

        ///// <summary>
        ///// Detach an entity from the context
        ///// </summary>
        ///// <typeparam name="TEntity">Entity type</typeparam>
        ///// <param name="entity">Entity</param>
        //public virtual void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));

        //    var entityEntry = Entry(entity);
        //    if (entityEntry == null)
        //        return;

        //    //set the entity is not being tracked by the context
        //    entityEntry.State = EntityState.Detached;
        //}

        

        #endregion
    }
}
