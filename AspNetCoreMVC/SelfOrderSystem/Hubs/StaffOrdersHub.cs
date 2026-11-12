using Microsoft.AspNetCore.SignalR; // Hub の基本機能 
namespace SelfOrderSystem.Hubs;
// 店舗画面と注文状況画面が接続するHub 
public class StaffOrdersHub : Hub {
    // 指定した注文だけの通知を受けるグループへ参加 
    public async Task JoinOrder(string publicId) {
        if (!Guid.TryParse(publicId, out var id))
            throw new HubException("注文 ID が正しくありません");
    }
}