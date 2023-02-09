// <auto-generated> to shut up linter
using ArcCreate.Gameplay.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ArcCreate.Gameplay.Skin
{
    [CreateAssetMenu(fileName = "GamemodeNoteSkin", menuName = "Skin Option/NoteGamemode/Joycon")]
    public class JoyconNoteSkinOption : GamemodeNoteSkinOption
    {
        [SerializeField] private Sprite tapSkinLeft;
        [SerializeField] private Sprite tapSkinRight;
        [SerializeField] private Sprite holdSkinLeft;
        [SerializeField] private Sprite holdSkinRight;
        [SerializeField] private Sprite holdHighlightSkinLeft;
        [SerializeField] private Sprite holdHighlightSkinRight;
        [SerializeField] private Sprite[] arcCapSprites;
        [SerializeField] private Material arcTapSkinLeft;
        [SerializeField] private Material arcTapSkinMiddle;
        [SerializeField] private Material arcTapSkinRight;

        public Material ArcTapSkinLeft { get; private set; }
        public Material ArcTapSkinMiddle { get; private set; }
        public Material ArcTapSkinRight { get; private set; }

        public ExternalSprite TapSkinLeft { get; private set; }
        public ExternalSprite TapSkinRight { get; private set; }
        public ExternalSprite HoldSkinLeft { get; private set; }
        public ExternalSprite HoldSkinRight { get; private set; }
        public ExternalSprite HoldHighlightSkinLeft { get; private set; }
        public ExternalSprite HoldHighlightSkinRight { get; private set; }
        public ExternalSprite[] ArcCapSprites { get; private set; }
        public ExternalTexture ArcTapSkinLeftTexture { get; private set; }
        public ExternalTexture ArcTapSkinMiddleTexture { get; private set; }
        public ExternalTexture ArcTapSkinRightTexture { get; private set; }

        public override (Mesh mesh, Material material) GetArcTapSkin(ArcTap note)
        {
            if (note.Sfx != "none")
            {
                return (ArcTapSfxMesh, ArcTapSfxSkin);
            }

            if (Mathf.Abs(note.WorldX) <= Values.ArcTapMiddleWorldXRange)
            {
                return (ArcTapMesh, ArcTapSkinMiddle);
            }

            if (ArcFormula.WorldXToArc(note.WorldX) > 0f)
            {
                return (ArcTapMesh, ArcTapSkinLeft);
            }

            return (ArcTapMesh, ArcTapSkinRight);
        }

        public override (Sprite normal, Sprite highlight) GetHoldSkin(Hold note)
            => (note.Lane <= 2) ? (HoldSkinLeft.Value, HoldHighlightSkinLeft.Value) : (HoldSkinRight.Value, HoldHighlightSkinRight.Value);

        public override Sprite GetTapSkin(Tap note)
            => (note.Lane <= 2) ? TapSkinLeft.Value : TapSkinRight.Value;

        public override Sprite GetArcCapSprite(Arc arc)
        {
            if (arc.Color < 0 || arc.Color > ArcCapSprites.Length)
            {
                return ArcCapSprites[ArcCapSprites.Length - 1].Value;
            }
            return ArcCapSprites[arc.Color].Value;
        }

        internal override void RegisterExternalSkin()
        {
            base.RegisterExternalSkin();
            ArcTapSkinLeft = Instantiate(arcTapSkinLeft);
            ArcTapSkinRight = Instantiate(arcTapSkinRight);
            ArcTapSkinMiddle = Instantiate(arcTapSkinMiddle);

            string subdir = System.IO.Path.Combine("Note", "Joycon");
            TapSkinLeft = new ExternalSprite(tapSkinLeft, subdir);
            TapSkinRight = new ExternalSprite(tapSkinRight, subdir);
            HoldSkinLeft = new ExternalSprite(holdSkinLeft, subdir);
            HoldSkinRight = new ExternalSprite(holdSkinRight, subdir);
            HoldHighlightSkinLeft = new ExternalSprite(holdHighlightSkinLeft, subdir);
            HoldHighlightSkinRight = new ExternalSprite(holdHighlightSkinRight, subdir);
            ArcCapSprites = new ExternalSprite[arcCapSprites.Length];
            for (int i = 0; i < ArcCapSprites.Length; i++)
            {
                ArcCapSprites[i] = new ExternalSprite(arcCapSprites[i], subdir);
            }

            ArcTapSkinLeftTexture = new ExternalTexture(ArcTapSkinLeft.mainTexture, subdir);
            ArcTapSkinMiddleTexture = new ExternalTexture(ArcTapSkinMiddle.mainTexture, subdir);
            ArcTapSkinRightTexture = new ExternalTexture(ArcTapSkinRight.mainTexture, subdir);
        }

        internal override async UniTask LoadExternalSkin()
        {
            await base.LoadExternalSkin();
            await TapSkinLeft.Load();
            await TapSkinRight.Load();
            await HoldSkinLeft.Load();
            await HoldSkinRight.Load();
            await HoldHighlightSkinLeft.Load();
            await HoldHighlightSkinRight.Load();

            for (int i = 0; i < ArcCapSprites.Length; i++)
            {
                await ArcCapSprites[i].Load();
            }

            await ArcTapSkinLeftTexture.Load();
            await ArcTapSkinMiddleTexture.Load();
            await ArcTapSkinRightTexture.Load();

            ArcTapSkinLeft.mainTexture = ArcTapSkinLeftTexture.Value;
            ArcTapSkinRight.mainTexture = ArcTapSkinRightTexture.Value;
            ArcTapSkinMiddle.mainTexture = ArcTapSkinMiddleTexture.Value;
        }

        internal override void UnloadExternalSkin()
        {
            base.UnloadExternalSkin();
            TapSkinLeft.Unload();
            TapSkinRight.Unload();
            HoldSkinLeft.Unload();
            HoldSkinRight.Unload();
            HoldHighlightSkinLeft.Unload();
            HoldHighlightSkinRight.Unload();

            for (int i = 0; i < ArcCapSprites.Length; i++)
            {
                ArcCapSprites[i].Unload();
            }

            ArcTapSkinLeftTexture.Unload();
            ArcTapSkinMiddleTexture.Unload();
            ArcTapSkinRightTexture.Unload();

            Destroy(ArcTapSkinLeft);
            Destroy(ArcTapSkinRight);
            Destroy(ArcTapSkinMiddle);
        }
    }
}