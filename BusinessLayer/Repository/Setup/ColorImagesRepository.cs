﻿using System;
using System.Collections.Generic;
using System.Linq;
using ClothingPro.DataAccessLayer.DbAccess;
using ClothingPro.DataAccessLayer.Model;

namespace ClothingPro.BusinessLayer.Repository
{
    public class ColorImagesRepository : IDisposable
    {
        private readonly UnitOfWork _unitOfWork;

        public ColorImagesRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<ColorImages> ColorImagesList()
        {
            try
            {

                var result = _unitOfWork.ColorImagesRepository.GetAll().ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ColorImages> ColorImagesListBYStockId(int stockId)
        {
            try
            {

                var result = _unitOfWork.ColorImagesRepository.GetAll().Where(x=> x.StockId == stockId).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ColorImages GetColorImagesById(string ColorImagesName)
        {
            try
            {
                if (ColorImagesName != null)
                {
                    var result = _unitOfWork.ColorImagesRepository.GetBy(x => x.ColorImagesName == ColorImagesName).FirstOrDefault();
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CreateColorImages(ColorImages model)
        {
            try
            {

                var result = _unitOfWork.ColorImagesRepository.Add(model).ColorImagesId;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ColorImages> AddColorImagesRange(List<ColorImages> model)
        {
            try
            {
                _unitOfWork.ColorImagesRepository.AddRange(model);
                return model.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ColorImages> UpdateColorImagesRange(List<ColorImages> model)
        {
            try
            {
                _unitOfWork.ColorImagesRepository.UpdateRange(model);
                return model.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ColorImages GetColorImagesByIdd(int ClrId)
        {
            try
            {
                if (ClrId != 0)
                {
                    var result = _unitOfWork.ColorImagesRepository.FindBy(x => x.ColorImagesId == ClrId);
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteColorImages(int ClrId)
        {
            try
            {
                var colorModel = _unitOfWork.ColorImagesRepository.FindBy(x => x.ColorImagesId == ClrId);

                _unitOfWork.ColorImagesRepository.Delete(colorModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateColorImages(ColorImages model)
        {
            try
            {
                 _unitOfWork.ColorImagesRepository.Update(model);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
