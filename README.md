# Bank Application


This is a bank application that allows a user to view and manage their bank accounts. The system is built using C#, and the console.
Features is 
    
    1. View bank accounts and balance.
    2. Transfer money between bank accounts.
    3. Withdraw money.
    4. Log out.
    
    

## Getting Started With The Bank Application


    Clone the repository to your local machine.
    
    Open the solution file in Visual Studio.
    
    Build and run the application.




## Code Structure

The code is structured in the following way:

    Account.cs:
    
    Account class which represents a bank account. It has properties for the account owner's name,
    account type, and balance.
    
    Program.cs: 
    
    This file contains the main program logic.
    It has methods for viewing bank accounts and balance,
    transferring money between bank account and withdrawing money.
    
    
    

## Functionality Explanation

   
    ViewAccounts: 
    
    This method is used to view the existing bank accounts. 
    It loops through the list of accounts and prints the account type and 
    balance for each account that belongs to the user.
    
    TransferBetweenAccounts: 
    
    This method is used to transfer money between two accounts. 
    It prompts the user for the source account, 
    target account, and amount to transfer. 
    The balance of the source account is decreased by the transfer amount and 
    the balance of the target account is increased by the same amount.
    
    WithdrawMoney: 
    
    This method is used to withdraw money from an account. 
    It prompts the user to select the account they wish to withdraw from,
    enter their pin code and the amount they wish to withdraw. 
    The balance of the selected account is decreased by the withdrawal amount if the pin code is correct.
