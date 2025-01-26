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
プロパティというのは、クラスのデータ（属性）にアクセスするための仕組みのこと。
オブジェクトがもっているデータのことを属性という。
BankAccountクラスの属性は、Number(口座番号)、Owner(所有者名)、Balance(残高)の3つ。
プロパティは、クラスの属性（データ）へのアクセスを安全に管理するための仕組みのこと。
残りの2つはメソッドという。
メソッドは1つの機能を実行するコードブロックのこと。または、オブジェクトの振る舞いを定義するもの
各メンバを確認すると、開発者がそのクラスの作用を把握するための十分な情報が得られるような構成・名前にする。
*/

/*
BankAccount 型の新しいオブジェクトを作成する＝BankAccount 型のクラスのメンバに初期値を設定して、個々の口座を作成すること。
田中さんの口座（残高1000円） <- 「田中さんの口座」オブジェクトは、BankAccount 型のクラスの性質を持っている。
山本さんの口座（残高3500円） <- 「山本さんの口座」オブジェクトは、BankAccount 型のクラスの性質を持っている。
2つの口座は、BankAccount 型のクラスの性質を持っているけど、それぞれ別のオブジェクトである。
*/
public class BankAccount
{
	
	private static int s_accountNumberSeed = 1234567890;
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance { get; }

	/*
	コンストラクタ：BankAccountオブジェクト作成時に呼び出され、Owner(所有者名)とBalance(初期残高)を初期化する
	初期化とは、オブジェクトのメンバに値を設定すること。
	コンストラクタは、オブジェクトの作成時に呼び出される。
	新しい山田さんのオブジェクトを作成するときに、コンストラクタを呼び出して、そのオブジェクトには名前と残高が存在することを保証する。
	コンストラクタの名前は、クラス名と同じである。
	コンストラクタに引数を渡すことで、オブジェクトのメンバに値を設定することができる
	*/
	public BankAccount(string name, decimal initialBalance)
	{
		this.Owner = name;
		this.Balance = initialBalance;
	}
    // 預金をするためのクラス
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
    }
}
