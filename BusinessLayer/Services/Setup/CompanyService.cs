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
    public class CompanyService : ICompanyService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly CompanyRepository _companyRepository;

        public CompanyService(UnitOfWork unitOfWork, CompanyRepository companyRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
        }

        public List<CompanyDTO> GetAllCompany()
        {
            try
            {

                var CompanyDAOList = _companyRepository.CompanyList();

                var CompanyDTOList = CompanyMapper.GetAllCompanyDTO(CompanyDAOList);
                return CompanyDTOList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public CompanyDTO GetCompanyByIdd(int MnId)
        {
            try
            {
                var Company = _companyRepository.GetCompanyByIdd(MnId);
                if (Company == null)
                {
                    return null;
                }
                if (MnId > 0)
                {
                    return CompanyMapper.GetCompanyDTO(Company);
                }
                else
                {
                    return new CompanyDTO();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CompanyDTO GetCompanyById(string CompanyName)
        {
            try
            {

                var CompanyDAO = _companyRepository.GetCompanyById(CompanyName);
                var CompanyDTOMOdel = CompanyMapper.GetCompanyDTO(CompanyDAO);

                return CompanyDTOMOdel;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int CreateCompany(CompanyDTO CompanyUI)
        {
            try
            {

                var CompanyModel = CompanyMapper.GetCompanyDAO(CompanyUI);
                if (CompanyModel.CompanyId > 0)
                {
                    var stockDAO = _companyRepository.GetCompanyByIdd(CompanyUI.CompanyId);
                    CompanyModel.CompanyId = stockDAO.CompanyId;

                    CompanyModel = CompanyModel.Adapt(stockDAO);
                    var result = _companyRepository.UpdateCompany(CompanyModel);
                    return CompanyUI.CompanyId;
                }
                else
                {
                    return _companyRepository.CreateCompany(CompanyModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string GetValueByName(string CompanyName)
        {
            try
            {

                return _companyRepository.GetCompanyById(CompanyName).CompanyName;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public bool DeleteCompany(int mnId)
        {
            try
            {


                var result = _companyRepository.DeleteCompany(mnId);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCompany(CompanyDTO CompanyDTO)
        {
            try
            {

                var CompanyDAOModel = _companyRepository.GetCompanyById(CompanyDTO.CompanyName);

                var CompanyModel = CompanyMapper.GetCompanyDAO(CompanyDTO);

                CompanyModel.CompanyName = CompanyDAOModel.CompanyName;

                CompanyModel = CompanyModel.Adapt(CompanyDAOModel);

                _companyRepository.UpdateCompany(CompanyModel);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}