// See https://aka.ms/new-console-template for more information
using Classes;

/*
newをするとオブジェクトの作成をすることができる
出力結果：Account  was created for yamasaka with 1000 initial balance.
ただ、今の状態だと口座番号がない。
なのでオブジェクトが作成される時に口座番号を設定する必要がある。
だけど、これは呼び出し元（つまりnewしたこのプログラム）に負わせる責任ではない。
*/
var account = new BankAccount("yamasaka", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine(account.Balance);
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.Balance);

// Test that the initial balances must be positive.
BankAccount invalidAccount;
try
{
    invalidAccount = new BankAccount("invalid", -55);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
    return;
}
// Test for a negative balance.
try
{
    account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}
