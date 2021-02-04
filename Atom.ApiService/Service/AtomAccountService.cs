using Atom.ApiService.IService;
using Atom.ApiService.Models;
using Atom.Domain.Entities;
using Atom.Repository.Interface;
using System;
using System.Threading.Tasks;

namespace Atom.ApiService.Service
{
    public class AtomAccountService : IAtomAccountService
    {
        private IUnitOfWork<Account> unitOfWork { get; set; }
        public AtomAccountService(IUnitOfWork<Account> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<AccountResponseDto> Balance(long id)
        {
            AccountResponseDto accountResponse = new AccountResponseDto();
            Account account;
            try
            {
                account = await unitOfWork.Repository.GetById(id);
                accountResponse.AccountNumber = account.Id;
                accountResponse.Successful = true;
                accountResponse.Balance = account.Balance;
                accountResponse.Currency = account.Currency;
                accountResponse.Message = "transaction successful";
                return accountResponse;
            }
            catch(Exception ex)
            {
                accountResponse.AccountNumber = id;
                accountResponse.Successful = false;
                accountResponse.Message = "unable to process your request now. Please try again after sometime";
            }
            return accountResponse;
        }
        public async Task<AccountResponseDto> Deposit(AccountDto accountDto)
        {
            AccountResponseDto accountResponse = new AccountResponseDto();
            Account account;
            try
            {
                if(accountDto.Amount<=0)
                {
                    accountResponse.AccountNumber = accountDto.AccountNumber;
                    accountResponse.Successful = false;
                    accountResponse.Message = "please enter a valid amount";
                    return accountResponse;
                }
                account = await unitOfWork.Repository.GetById(accountDto.AccountNumber);
                var balanceAmount = account.Balance + accountDto.Amount;

                accountResponse.AccountNumber = accountDto.AccountNumber;
                accountResponse.Successful = true;
                accountResponse.Balance = balanceAmount;
                accountResponse.Currency = account.Currency;
                accountResponse.Message = "transaction successful";

                account.Balance = balanceAmount;

                unitOfWork.Repository.Update(account);
                await unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                accountResponse.AccountNumber = accountDto.AccountNumber;
                accountResponse.Successful = false;                
                accountResponse.Message = $"invalid account {ex.Message}";
            }
            return accountResponse;
        }
        public async Task<AccountResponseDto> Widthdraw(AccountDto accountDto)
        {
            AccountResponseDto accountResponse = new AccountResponseDto();
            try
            {
                if (accountDto.Amount <= 0)
                {
                    accountResponse.AccountNumber = accountDto.AccountNumber;
                    accountResponse.Successful = false;
                    accountResponse.Message = "please enter a valid amount";
                    return accountResponse;
                }
                var accountRecord = await unitOfWork.Repository.GetById(accountDto.AccountNumber).ConfigureAwait(false);
                if (accountDto.Amount>accountRecord.Balance)
                {
                    accountResponse.AccountNumber = accountDto.AccountNumber;
                    accountResponse.Successful = false;
                    accountResponse.Balance = accountRecord.Balance;
                    accountResponse.Currency = accountRecord.Currency;
                    accountResponse.Message = "transaction failed due to insufficient balance";
                    return accountResponse;
                }
                accountRecord.Balance -= accountDto.Amount;

                accountResponse.AccountNumber = accountDto.AccountNumber;
                accountResponse.Successful = true;
                accountResponse.Balance = accountRecord.Balance;
                accountResponse.Currency = accountRecord.Currency;
                accountResponse.Message = "transaction successful";
               
                unitOfWork.Repository.Update(accountRecord);
                await unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                accountResponse.AccountNumber = accountDto.AccountNumber;
                accountResponse.Successful = true;
                accountResponse.Message = "unable to process your request now. Please try again after sometime";
            }
            return accountResponse;
        }
    }
}