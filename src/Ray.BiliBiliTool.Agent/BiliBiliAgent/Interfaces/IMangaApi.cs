﻿using Ray.BiliBiliTool.Agent.Attributes;
using Ray.BiliBiliTool.Agent.BiliBiliAgent.Dtos;
using WebApiClientCore.Attributes;

namespace Ray.BiliBiliTool.Agent.BiliBiliAgent.Interfaces;

/// <summary>
/// 漫画相关接口
/// </summary>
[Header("Origin", "https://manga.bilibili.com")]
[Header("Host", "manga.bilibili.com")]
public interface IMangaApi : IBiliBiliApi
{
    /// <summary>
    /// 漫画签到
    /// </summary>
    /// <param name="platform"></param>
    /// <returns></returns>
    [LogFilter(false)]
    [HttpPost("/twirp/activity.v1.Activity/ClockIn?platform={platform}")]
    Task<BiliApiResponse> ClockIn(string platform, [Header("Cookie")] string ck);

    /// <summary>
    /// 漫画阅读
    /// </summary>
    /// <param name="platform"></param>
    /// <returns></returns>
    [HttpPost(
        "/twirp/bookshelf.v1.Bookshelf/AddHistory?platform={platform}&comic_id={comic_id}&ep_id={ep_id}"
    )]
    Task<BiliApiResponse> ReadManga(
        string platform,
        long comic_id,
        long ep_id,
        [Header("Cookie")] string ck
    );

    /// <summary>
    /// 获取会员漫画奖励
    /// </summary>
    /// <param name="reason_id"></param>
    /// <returns></returns>
    [HttpPost("/twirp/user.v1.User/GetVipReward?reason_id={reason_id}")]
    Task<BiliApiResponse<MangaVipRewardResponse>> ReceiveMangaVipReward(
        int reason_id,
        [Header("Cookie")] string ck
    );
}
