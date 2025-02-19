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
・オブジェクト: 山田さんの口座 (具体的な BankAccount クラスのインスタンス)
・属性: 山田さんの口座が持っている各値 (口座番号、所有者名、残高などのデータ)
・プロパティ: 属性の定義づけ、属性そのものの性質を決定するもの (データへのアクセス方法やルールを定める。残高はマイナスになってはいけないとか)
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
	/*
	private staticとは
	private -> private アクセス修飾子
	役割：アクセスレベルを制限し、s_accountNumberSeedというメンバは、BankAccountクラスの中からしかアクセスできないようにする。
	なぜそうするのか？：クラスの内部実装を隠蔽することで、外部から不正に・誤ってアクセスされることを防ぐため。
	こう書くと、s_accountNumberSeedはBankAccountクラスの中からしかアクセスできず、例えばProgram.csからアクセスすることはできない。

	static -> static 修飾子
	s_accountNumberSeedというメンバが、クラスのインスタンス（オブジェクト）ごとではなく、クラス自体に紐づくことを示す。
	つまり、s_accountNumberSeedは、BankAccountクラスのすべてのインスタンス（オブジェクト）で共有される。
	例えば、田中さんの口座と山本さんの口座では、s_accountNumberSeedは同じ値をもつことになる。
	*/
	private static int s_accountNumberSeed = 1234567890;
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance
	/*
	元々はBalance プロパティは、単純に値を保持するだけのプロパティだった
	*/
	{
		get
		{
			decimal balance = 0;
			foreach (var item in _allTransactions)
			{
				balance += item.Amount;
			}

			return balance;
		}
	}

	/*
	コンストラクタ：BankAccountオブジェクト作成時に呼び出され、Owner(所有者名)とBalance(初期残高)を初期化する
	初期化とは、オブジェクトのメンバに値を設定すること。
	コンストラクタは、オブジェクトの作成時に呼び出される。
	新しい山田さんのオブジェクトを作成するときに、コンストラクタを呼び出して、そのオブジェクトには名前と残高が存在することを保証する。
	コンストラクタの名前は、クラス名と同じである。
	コンストラクタに引数を渡すことで、オブジェクトのメンバに値を設定することができる
	「this」は、オブジェクト自身を参照するためのキーワード
	つまり、this.Owner = name; は、オブジェクト自身のOwnerにnameを設定するという意味。
	「このオブジェクトの Owner プロパティに、引数 name の値を設定する」という意味
	this は名前の衝突を避けたり、明示的にオブジェクトのプロパティであることを示すために使用される
	例：
	BankAccount account = new BankAccount("yamasaka", 1000);
	この場合、コンストラクタの引数 name は "yamasaka" であり、Owner は "yamasaka" に設定される。
	プロパティに値を設定するということは、そのプロパティの set アクセサーを呼び出すことと同じ
	*/
	public BankAccount(string name, decimal initialBalance)
	{
		Number = s_accountNumberSeed.ToString();
		s_accountNumberSeed++;

		Owner = name;
		MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
	}
	// List<Transaction> は 「Transaction オブジェクト」のリスト
	// _ で始まる名前は、慣習的にプライベートなフィールドであることを示すためによく使われる
	private List<Transaction> _allTransactions = new List<Transaction>();
    // 預金をするためのメソッド
    public void MakeDeposit(decimal amount, DateTime date, string note)
	{
		if (amount <= 0)
		{
			// 引数が0以下の場合、例外をスローする
			throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
		}
		// デポジット、つまり預金をするためのTransactionオブジェクトを作成する
		// 引数はコンストラクタで定義したもの
		var deposit = new Transaction(amount, date, note);
		// 作成したTransactionオブジェクトを_allTransactionsに追加する
		_allTransactions.Add(deposit);
	}

	/*
	引き出しをするためのメソッド
	*/
	public void MakeWithdrawal(decimal amount, DateTime date, string note)
	{
		/*
		引数が0以下の場合、例外をスローする
		*/
		if (amount <= 0)
		{
			throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
		}
		/*
		残高が引き出し額より少ない場合、例外をスローする
		*/
		if (Balance - amount < 0)
		{
			throw new InvalidOperationException("Not sufficient funds for this withdrawal");
		}
		/*
		引き出しをするためのTransactionオブジェクトを作成する
		*/
		var withdrawal = new Transaction(-amount, date, note);
		/*
		作成したTransactionオブジェクトを_allTransactionsに追加する
		*/
		_allTransactions.Add(withdrawal);
	}
}

