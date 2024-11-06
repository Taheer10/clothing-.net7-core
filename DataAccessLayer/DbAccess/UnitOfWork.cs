using ClothingPro.Areas.Identity.Data;
using ClothingPro.DataAccessLayer.DataContext;
using ClothingPro.DataAccessLayer.Model;
using System;

namespace ClothingPro.DataAccessLayer.DbAccess
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        // Repository fields for lazy initialization
        private IRepository<Stock>? _stockRepository;
        private IRepository<Setting>? _settingRepository;
        private IRepository<MenuHeader>? _menuHeaderRepository;
        private IRepository<Company>? _companyRepository;
        private IRepository<Banner>? _bannerRepository;
        private IRepository<ColorImages>? _colorImagesRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #region Repository Properties

        public IRepository<Stock> StockRepository =>
            _stockRepository ??= new GenericRepository<Stock>(_dbContext);

        public IRepository<Setting> SettingRepository =>
            _settingRepository ??= new GenericRepository<Setting>(_dbContext);

        public IRepository<MenuHeader> MenuHeaderRepository =>
            _menuHeaderRepository ??= new GenericRepository<MenuHeader>(_dbContext);

        public IRepository<Company> CompanyRepository =>
            _companyRepository ??= new GenericRepository<Company>(_dbContext);

        public IRepository<Banner> BannerRepository =>
            _bannerRepository ??= new GenericRepository<Banner>(_dbContext);

        public IRepository<ColorImages> ColorImagesRepository =>
            _colorImagesRepository ??= new GenericRepository<ColorImages>(_dbContext);

        #endregion

        #region Public Methods

        /// <summary>
        /// Commits all changes to the database.
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Starts a new database transaction.
        /// </summary>
        public EntityDatabaseTransaction BeginTransaction()
        {
            return new EntityDatabaseTransaction(_dbContext);
        }

        #endregion

        #region IDisposable Implementation

        private bool _disposed = false;

        /// <summary>
        /// Disposes the database context and other managed resources.
        /// </summary>
        /// <param name="disposing">True to dispose managed resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// Disposes the unit of work instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
