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
