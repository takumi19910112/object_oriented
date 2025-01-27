# オブジェクト指向プログラミング学習

オブジェクト指向プログラミングの基本概念を学習・実践するためのもの

参考：[Microsoft C# チュートリアル - クラス](https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/tutorials/classes)

## 主要な概念

### クラス
- オブジェクトの設計図
- オブジェクトの構造とふるまいを定義する

```csharp
public class BankAccount
{
    // クラスの定義
}
```

#### クラスのメンバ
クラスの構成要素として以下がある：

1. **属性**
   - オブジェクトが持っているデータ
   - オブジェクトの状態を表現する

```csharp
public class BankAccount
{
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance { get; }
}
var account = new BankAccount("yamasaka", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
// ↑newをしたらできるのがオブジェクト（インスタンス）
// このときのyamasakaとか、1000とかが属性
// 属性は、コンストラクタの引数で設定する
```

2. **プロパティ**
   - クラスのデータ（属性）にアクセスするための仕組み
   - データの読み書きを制御する
   - プロパティは、属性にアクセスするためのgetterとsetterがある
   - getterは、属性の値を取得するためのメソッド
   - setterは、属性の値を設定するためのメソッド
```csharp
public class BankAccount
{
    public string Number { get; } // 読み取り専用
    public string Owner { get; set; } // 読み取りと書き込みが可能
    public decimal Balance { get; private set; } // 読み取りは可能、書き込みはクラス内からのみ
}
```

3. **メソッド**
   - 1つの機能を実行するコードブロック
   - オブジェクトの振る舞いを定義する

```csharp
public class BankAccount
{
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        // 預金をするためのメソッド
    }
}
```

### インスタンス
- クラスを元に作られた実際のオブジェクト
- クラスの設計図から生成された具体的なもの

```csharp
var account = new BankAccount("yamasaka", 1000);
```