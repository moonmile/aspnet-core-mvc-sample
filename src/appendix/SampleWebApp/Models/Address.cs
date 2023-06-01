using Microsoft.EntityFrameworkCore;

namespace SampleWebApp.Models;

public class Address
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    // 初回のみ都道府県のデータを作る
    public static void Initialize(DbContext context)
    {
        var t = context.Set<Address>();
        if (t.Any() == false)
        {
            // データを作る
            t.AddRange(
                new Address() { Name = "北海道" },
                new Address() { Name = "青森県" },
                new Address() { Name = "岩手県" },
                new Address() { Name = "宮城県" },
                new Address() { Name = "秋田県" },
                new Address() { Name = "山形県" },
                new Address() { Name = "福島県" },
                new Address() { Name = "茨城県" },
                new Address() { Name = "栃木県" },
                new Address() { Name = "群馬県" },
                new Address() { Name = "埼玉県" },
                new Address() { Name = "千葉県" },
                new Address() { Name = "東京都" },
                new Address() { Name = "神奈川県" },
                new Address() { Name = "新潟県" },
                new Address() { Name = "富山県" },
                new Address() { Name = "石川県" },
                new Address() { Name = "福井県" },
                new Address() { Name = "山梨県" },
                new Address() { Name = "長野県" },
                new Address() { Name = "岐阜県" },
                new Address() { Name = "静岡県" },
                new Address() { Name = "愛知県" },
                new Address() { Name = "三重県" },
                new Address() { Name = "滋賀県" },
                new Address() { Name = "京都府" },
                new Address() { Name = "大阪府" },
                new Address() { Name = "兵庫県" },
                new Address() { Name = "奈良県" },
                new Address() { Name = "和歌山県" },
                new Address() { Name = "鳥取県" },
                new Address() { Name = "島根県" },
                new Address() { Name = "岡山県" },
                new Address() { Name = "広島県" },
                new Address() { Name = "山口県" },
                new Address() { Name = "徳島県" },
                new Address() { Name = "香川県" },
                new Address() { Name = "愛媛県" },
                new Address() { Name = "高知県" },
                new Address() { Name = "福岡県" },
                new Address() { Name = "佐賀県" },
                new Address() { Name = "長崎県" },
                new Address() { Name = "熊本県" },
                new Address() { Name = "大分県" },
                new Address() { Name = "宮崎県" },
                new Address() { Name = "鹿児島県" },
                new Address() { Name = "沖縄県" });
            context.SaveChanges();
        }
    }
}
