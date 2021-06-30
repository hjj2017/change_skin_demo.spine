using Spine.Unity;

using System.Collections;

using UnityEngine;

/// <summary>
/// 测试场景
/// </summary>
public class DemoScene : MonoBehaviour
{
    /** 玩家节点 */
    private GameObject _playerMissDie;

    /// <summary>
    /// Awake
    /// </summary>
    void Awake()
    {
        _playerMissDie = GameObject.Find("/Player_MissDie_");
    }

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        StartCoroutine(StartDemo_XC());
    }

    /// <summary>
    /// Update
    /// </summary>
    void Update()
    {
    }

    /// <summary>
    /// 开始演示
    /// </summary>
    /// <returns>枚举迭代器</returns>
    IEnumerator StartDemo_XC()
    {
        yield return new WaitForEndOfFrame();

        // 加载预制体作为备用, 并隐藏节点.
        // 以下代码可以修改成通过 HTTP 方式加载资源...
        GameObject prefab = Resources.Load<GameObject>("Playerz/Player_CatGirl_/Prefab/Player_CatGirl_");
        GameObject playerCatGirl = GameObject.Instantiate<GameObject>(prefab);
        playerCatGirl.SetActive(false);

        // 等待 2 秒
        yield return new WaitForSeconds(2f);

        // 获得 CatGirl 和 MissDie 的 Spine 骨骼动画组件
        SkeletonAnimation spineCatGirl =  playerCatGirl.GetComponent<SkeletonAnimation>();
        SkeletonAnimation spineMissDie = _playerMissDie.GetComponent<SkeletonAnimation>();
        // 
        // 接下来, 我们以 MissDie 为目标, 
        // 将 CatGirl 皮肤替换到 MissDie 身上...
        // XXX 特别注意: MissDie 和 CatGirl 插槽顺序必须完全一致,  否则
        // 会出现换装后图片位置不正确的问题!

        // Demo1, 将 CatGirl 的头部皮肤替换到 MissDie
        {
            // 获取 MissDie 默认皮肤
            Spine.Skin skinDefault = spineMissDie.Skeleton.Data.FindSkin("_Default");
            // 获取 CatGirl 头部皮肤
            Spine.Skin skinHead = spineCatGirl.Skeleton.Data.FindSkin("Head");

            // 创建一个新的皮肤对象, 名字为 Mix.
            // 命名可以随意, 但最好不要与已有皮肤名称相同...
            Spine.Skin skinMix = new Spine.Skin("Mix");
            // 复制 MissDie 默认皮肤
            skinMix.CopySkin(skinDefault);
            // 设置 CatGirl 头部皮肤
            skinMix.AddSkin(skinHead);

            // 将新皮肤设置到 MissDie 身上
            spineMissDie.Skeleton.SetSkin(skinMix);
            spineMissDie.skeleton.UpdateCache();
            spineMissDie.skeleton.SetSlotsToSetupPose();
        }

        // 等待 2 秒
        yield return new WaitForSeconds(2f);

        // Demo2, 将 CatGirl 的头部和发型皮肤替换到 MissDie.
        // 这一步 MissDie 就完全变成了 CatGirl
        {
            // 获取 CatGirl 头部皮肤
            Spine.Skin skinHead = spineCatGirl.Skeleton.Data.FindSkin("Head");
            // 获取 CatGirl 发型皮肤
            Spine.Skin skinHair = spineCatGirl.Skeleton.Data.FindSkin("Hair");

            // 创建一个新的皮肤对象
            Spine.Skin skinMix = new Spine.Skin("Mix");
            // 设置 CatGirl 头部皮肤和发型皮肤
            skinMix.AddSkin(skinHead);
            skinMix.AddSkin(skinHair);

            // 将新皮肤设置到 MissDie 身上
            spineMissDie.Skeleton.SetSkin(skinMix);
            spineMissDie.skeleton.UpdateCache();
            spineMissDie.skeleton.SetSlotsToSetupPose();
        }

        // 等待 2 秒
        yield return new WaitForSeconds(2f);

        // Demo3, 将 CatGirl 的发型皮肤替换到 MissDie
        {
            // 获取 MissDie 默认皮肤
            Spine.Skin skinDefault = spineMissDie.Skeleton.Data.FindSkin("_Default");
            // 获取 CatGirl 发型皮肤
            Spine.Skin skinHair = spineCatGirl.Skeleton.Data.FindSkin("Hair");

            // 创建一个新的皮肤对象
            Spine.Skin skinMix = new Spine.Skin("Mix");
            // 复制 MissDie 默认皮肤
            skinMix.CopySkin(skinDefault);
            // 设置 CatGirl 发型皮肤
            skinMix.AddSkin(skinHair);

            // 将新皮肤设置到 MissDie 身上
            spineMissDie.Skeleton.SetSkin(skinMix);
            spineMissDie.skeleton.UpdateCache();
            spineMissDie.skeleton.SetSlotsToSetupPose();
        }

        yield return 1;
    }
}
