using Spine.Unity;

using System.Collections;

using UnityEngine;

/// <summary>
/// ���Գ���
/// </summary>
public class DemoScene : MonoBehaviour
{
    /** ��ҽڵ� */
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
    /// ��ʼ��ʾ
    /// </summary>
    /// <returns>ö�ٵ�����</returns>
    IEnumerator StartDemo_XC()
    {
        yield return new WaitForEndOfFrame();

        // ����Ԥ������Ϊ����, �����ؽڵ�.
        // ���´�������޸ĳ�ͨ�� HTTP ��ʽ������Դ...
        GameObject prefab = Resources.Load<GameObject>("Playerz/Player_CatGirl_/Prefab/Player_CatGirl_");
        GameObject playerCatGirl = GameObject.Instantiate<GameObject>(prefab);
        playerCatGirl.SetActive(false);

        // �ȴ� 2 ��
        yield return new WaitForSeconds(2f);

        // ��� CatGirl �� MissDie �� Spine �����������
        SkeletonAnimation spineCatGirl =  playerCatGirl.GetComponent<SkeletonAnimation>();
        SkeletonAnimation spineMissDie = _playerMissDie.GetComponent<SkeletonAnimation>();
        // 
        // ������, ������ MissDie ΪĿ��, 
        // �� CatGirl Ƥ���滻�� MissDie ����...
        // XXX �ر�ע��: MissDie �� CatGirl ���˳�������ȫһ��,  ����
        // ����ֻ�װ��ͼƬλ�ò���ȷ������!

        // Demo1, �� CatGirl ��ͷ��Ƥ���滻�� MissDie
        {
            // ��ȡ MissDie Ĭ��Ƥ��
            Spine.Skin skinDefault = spineMissDie.Skeleton.Data.FindSkin("_Default");
            // ��ȡ CatGirl ͷ��Ƥ��
            Spine.Skin skinHead = spineCatGirl.Skeleton.Data.FindSkin("Head");

            // ����һ���µ�Ƥ������, ����Ϊ Mix.
            // ������������, ����ò�Ҫ������Ƥ��������ͬ...
            Spine.Skin skinMix = new Spine.Skin("Mix");
            // ���� MissDie Ĭ��Ƥ��
            skinMix.CopySkin(skinDefault);
            // ���� CatGirl ͷ��Ƥ��
            skinMix.AddSkin(skinHead);

            // ����Ƥ�����õ� MissDie ����
            spineMissDie.Skeleton.SetSkin(skinMix);
            spineMissDie.skeleton.UpdateCache();
            spineMissDie.skeleton.SetSlotsToSetupPose();
        }

        // �ȴ� 2 ��
        yield return new WaitForSeconds(2f);

        // Demo2, �� CatGirl ��ͷ���ͷ���Ƥ���滻�� MissDie.
        // ��һ�� MissDie ����ȫ����� CatGirl
        {
            // ��ȡ CatGirl ͷ��Ƥ��
            Spine.Skin skinHead = spineCatGirl.Skeleton.Data.FindSkin("Head");
            // ��ȡ CatGirl ����Ƥ��
            Spine.Skin skinHair = spineCatGirl.Skeleton.Data.FindSkin("Hair");

            // ����һ���µ�Ƥ������
            Spine.Skin skinMix = new Spine.Skin("Mix");
            // ���� CatGirl ͷ��Ƥ���ͷ���Ƥ��
            skinMix.AddSkin(skinHead);
            skinMix.AddSkin(skinHair);

            // ����Ƥ�����õ� MissDie ����
            spineMissDie.Skeleton.SetSkin(skinMix);
            spineMissDie.skeleton.UpdateCache();
            spineMissDie.skeleton.SetSlotsToSetupPose();
        }

        // �ȴ� 2 ��
        yield return new WaitForSeconds(2f);

        // Demo3, �� CatGirl �ķ���Ƥ���滻�� MissDie
        {
            // ��ȡ MissDie Ĭ��Ƥ��
            Spine.Skin skinDefault = spineMissDie.Skeleton.Data.FindSkin("_Default");
            // ��ȡ CatGirl ����Ƥ��
            Spine.Skin skinHair = spineCatGirl.Skeleton.Data.FindSkin("Hair");

            // ����һ���µ�Ƥ������
            Spine.Skin skinMix = new Spine.Skin("Mix");
            // ���� MissDie Ĭ��Ƥ��
            skinMix.CopySkin(skinDefault);
            // ���� CatGirl ����Ƥ��
            skinMix.AddSkin(skinHair);

            // ����Ƥ�����õ� MissDie ����
            spineMissDie.Skeleton.SetSkin(skinMix);
            spineMissDie.skeleton.UpdateCache();
            spineMissDie.skeleton.SetSlotsToSetupPose();
        }

        yield return 1;
    }
}
