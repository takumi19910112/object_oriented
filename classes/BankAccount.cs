/* 
銀行口座の定義

銀行口座を一意に特定する 10 桁の数字をサポートしています。
口座の名前、または所有者の名前を格納する文字列をサポートしています。
残高を取得できます。
預金を許可します。
引き出しを許可します。
初期残高は正の値である必要があります。
引き出しによって残高が負の値になることはありません。
*/
namespace Classes;

/*
クラス、または型の宣言。この場合は銀行口座のクラスを宣言した。
{}の内側は全てクラス状態と動作を定義している。
このクラスには、5つのメンバがある。
最初の3つはプロパティという。
プロパティというのは、データを格納するための要素（メンバ）。
残りの2つはメソッドという。
メソッドは1つの機能を実行するコードブロックのこと。
各メンバを確認すると、開発者がそのクラスの作用を把握するための十分な情報が得られるような構成・名前にする。
*/
public class BankAccount
{
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance { get; }

    // 預金をするためのクラス
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
    }
}
