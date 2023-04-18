using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Test.Contracts.Charity.ContractDefinition;

namespace Test.Contracts.Charity
{
    public partial class CharityService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, CharityDeployment charityDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<CharityDeployment>().SendRequestAndWaitForReceiptAsync(charityDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, CharityDeployment charityDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<CharityDeployment>().SendRequestAsync(charityDeployment);
        }

        public static async Task<CharityService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, CharityDeployment charityDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, charityDeployment, cancellationTokenSource);
            return new CharityService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public CharityService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ApproveOrganisationRequestAsync(ApproveOrganisationFunction approveOrganisationFunction)
        {
             return ContractHandler.SendRequestAsync(approveOrganisationFunction);
        }

        public Task<TransactionReceipt> ApproveOrganisationRequestAndWaitForReceiptAsync(ApproveOrganisationFunction approveOrganisationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveOrganisationFunction, cancellationToken);
        }

        public Task<string> ApproveOrganisationRequestAsync(byte[] id)
        {
            var approveOrganisationFunction = new ApproveOrganisationFunction();
                approveOrganisationFunction.Id = id;
            
             return ContractHandler.SendRequestAsync(approveOrganisationFunction);
        }

        public Task<TransactionReceipt> ApproveOrganisationRequestAndWaitForReceiptAsync(byte[] id, CancellationTokenSource cancellationToken = null)
        {
            var approveOrganisationFunction = new ApproveOrganisationFunction();
                approveOrganisationFunction.Id = id;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveOrganisationFunction, cancellationToken);
        }

        public Task<string> CreateDonorRequestAsync(CreateDonorFunction createDonorFunction)
        {
             return ContractHandler.SendRequestAsync(createDonorFunction);
        }

        public Task<TransactionReceipt> CreateDonorRequestAndWaitForReceiptAsync(CreateDonorFunction createDonorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createDonorFunction, cancellationToken);
        }

        public Task<string> CreateDonorRequestAsync(string name, string desc, string email)
        {
            var createDonorFunction = new CreateDonorFunction();
                createDonorFunction.Name = name;
                createDonorFunction.Desc = desc;
                createDonorFunction.Email = email;
            
             return ContractHandler.SendRequestAsync(createDonorFunction);
        }

        public Task<TransactionReceipt> CreateDonorRequestAndWaitForReceiptAsync(string name, string desc, string email, CancellationTokenSource cancellationToken = null)
        {
            var createDonorFunction = new CreateDonorFunction();
                createDonorFunction.Name = name;
                createDonorFunction.Desc = desc;
                createDonorFunction.Email = email;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createDonorFunction, cancellationToken);
        }

        public Task<string> CreateOrganizationRequestAsync(CreateOrganizationFunction createOrganizationFunction)
        {
             return ContractHandler.SendRequestAsync(createOrganizationFunction);
        }

        public Task<TransactionReceipt> CreateOrganizationRequestAndWaitForReceiptAsync(CreateOrganizationFunction createOrganizationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createOrganizationFunction, cancellationToken);
        }

        public Task<string> CreateOrganizationRequestAsync(string name, string desc, string email, string registrationId)
        {
            var createOrganizationFunction = new CreateOrganizationFunction();
                createOrganizationFunction.Name = name;
                createOrganizationFunction.Desc = desc;
                createOrganizationFunction.Email = email;
                createOrganizationFunction.RegistrationId = registrationId;
            
             return ContractHandler.SendRequestAsync(createOrganizationFunction);
        }

        public Task<TransactionReceipt> CreateOrganizationRequestAndWaitForReceiptAsync(string name, string desc, string email, string registrationId, CancellationTokenSource cancellationToken = null)
        {
            var createOrganizationFunction = new CreateOrganizationFunction();
                createOrganizationFunction.Name = name;
                createOrganizationFunction.Desc = desc;
                createOrganizationFunction.Email = email;
                createOrganizationFunction.RegistrationId = registrationId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createOrganizationFunction, cancellationToken);
        }

        public Task<string> DonateRequestAsync(DonateFunction donateFunction)
        {
             return ContractHandler.SendRequestAsync(donateFunction);
        }

        public Task<TransactionReceipt> DonateRequestAndWaitForReceiptAsync(DonateFunction donateFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(donateFunction, cancellationToken);
        }

        public Task<string> DonateRequestAsync(string orgAddress, BigInteger amount, byte[] dsa)
        {
            var donateFunction = new DonateFunction();
                donateFunction.OrgAddress = orgAddress;
                donateFunction.Amount = amount;
                donateFunction.Dsa = dsa;
            
             return ContractHandler.SendRequestAsync(donateFunction);
        }

        public Task<TransactionReceipt> DonateRequestAndWaitForReceiptAsync(string orgAddress, BigInteger amount, byte[] dsa, CancellationTokenSource cancellationToken = null)
        {
            var donateFunction = new DonateFunction();
                donateFunction.OrgAddress = orgAddress;
                donateFunction.Amount = amount;
                donateFunction.Dsa = dsa;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(donateFunction, cancellationToken);
        }

        public Task<GetOrganisationOutputDTO> GetOrganisationQueryAsync(GetOrganisationFunction getOrganisationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetOrganisationFunction, GetOrganisationOutputDTO>(getOrganisationFunction, blockParameter);
        }

        public Task<GetOrganisationOutputDTO> GetOrganisationQueryAsync(byte[] id, BlockParameter blockParameter = null)
        {
            var getOrganisationFunction = new GetOrganisationFunction();
                getOrganisationFunction.Id = id;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetOrganisationFunction, GetOrganisationOutputDTO>(getOrganisationFunction, blockParameter);
        }

        public Task<byte[]> GetStatusQueryAsync(GetStatusFunction getStatusFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStatusFunction, byte[]>(getStatusFunction, blockParameter);
        }

        
        public Task<byte[]> GetStatusQueryAsync(byte[] donationStatusId, BlockParameter blockParameter = null)
        {
            var getStatusFunction = new GetStatusFunction();
                getStatusFunction.DonationStatusId = donationStatusId;
            
            return ContractHandler.QueryAsync<GetStatusFunction, byte[]>(getStatusFunction, blockParameter);
        }
    }
}
