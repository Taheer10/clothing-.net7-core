using Mapster;
using System;
using System.Collections.Generic;
using ClothingPro.BusinessLayer.DTO;
using ClothingPro.BusinessLayer.Interface;
using ClothingPro.BusinessLayer.Mapper;
using ClothingPro.BusinessLayer.Repository;
using ClothingPro.BusinessLayer.Helper;
using ClothingPro.DataAccessLayer.DbAccess;
using Microsoft.Data.SqlClient;
using System.Data;
using ClothingPro.Models;

namespace ClothingPro.BusinessLayer.BusinessService
{
    public class BannerService : IBannerService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly BannerRepository _bannerRepository;

        public BannerService(UnitOfWork unitOfWork, BannerRepository bannerRepository)
        {
            _unitOfWork = unitOfWork;
            _bannerRepository = bannerRepository;
        }

        public List<BannerDTO> GetAllBanner()
        {
            try
            {
                
                    var BannerDAOList = _bannerRepository.BannerList();

                    var BannerDTOList = BannerMapper.GetAllBannerDTO(BannerDAOList).OrderBy(x=>x.BannerSortOrder).ToList();
                    return BannerDTOList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     

        public BannerDTO GetBannerByIdd(int MnId)
        {
            try
            {
                var Banner = _bannerRepository.GetBannerByIdd(MnId);
                if (MnId > 0)
                {
                    return BannerMapper.GetBannerDTO(Banner);
                }
                else
                {
                    return new BannerDTO();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BannerDTO GetBannerById(string BannerName)
        {
            try
            {
                
                    var BannerDAO = _bannerRepository.GetBannerById(BannerName);
                    var BannerDTOMOdel = BannerMapper.GetBannerDTO(BannerDAO);

                    return BannerDTOMOdel;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int CreateBanner(BannerDTO BannerUI)
        {
            try
            {
                
                    var BannerModel = BannerMapper.GetBannerDAO(BannerUI);
                    if (BannerModel.BannerId > 0)
                    {
                        var stockDAO = _bannerRepository.GetBannerByIdd(BannerUI.BannerId);
                        BannerModel.BannerId = stockDAO.BannerId;

                        BannerModel = BannerModel.Adapt(stockDAO);
                        var result = _bannerRepository.UpdateBanner(BannerModel);
                        return BannerUI.BannerId;
                    }
                    else
                    {
                        return _bannerRepository.CreateBanner(BannerModel);
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string GetValueByName(string BannerName)
        {
            try
            {
               
                    return _bannerRepository.GetBannerById(BannerName).BannerImg;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public bool DeleteBanner(int mnId)
        {
            try
            {

              

                    var result = _bannerRepository.DeleteBanner(mnId);
                    return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      

    }

}