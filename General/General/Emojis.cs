using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Linq ;
using System . Reflection ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class Emojis
	{

		public static ReadOnlyDictionary <string , string> EmojisList { get ; }

		static Emojis ( )
		{
			Dictionary <string , string> emojis =
				typeof ( Emojis ) . GetFields (
												BindingFlags . Static
												| BindingFlags . Public
												| BindingFlags . DeclaredOnly ) .
									ToDictionary (
												fieldInfo => fieldInfo . Name ,
												fieldInfo => ( string ) fieldInfo . GetValue ( null ) ) ;

			EmojisList = new ReadOnlyDictionary <string , string> ( emojis ) ;
		}

		public const string GrinningFace = "😀" ;

		public const string GrinningFaceWithBigEyes = "😃" ;

		public const string GrinningFaceWithSmilingEyes = "😄" ;

		public const string BeamingFaceWithSmilingEyes = "😁" ;

		public const string GrinningSquintingFace = "😆" ;

		public const string GrinningFaceWithSweat = "😅" ;

		public const string RollingOnTheFloorLaughing = "🤣" ;

		public const string FaceWithTearsOfJoy = "😂" ;

		public const string SlightlySmilingFace = "🙂" ;

		public const string UpsideDownFace = "🙃" ;

		public const string WinkingFace = "😉" ;

		public const string SmilingFaceWithSmilingEyes = "😊" ;

		public const string SmilingFaceWithHalo = "😇" ;

		public const string SmilingFaceWith3Hearts = "🥰" ;

		public const string SmilingFaceWithHeartEyes = "😍" ;

		public const string StarStruck = "🤩" ;

		public const string FaceBlowingAKiss = "😘" ;

		public const string KissingFace = "😗" ;

		public const string SmilingFace = "☺️" ;

		public const string SmilingFace2 = "☺" ;

		public const string KissingFaceWithClosedEyes = "😚" ;

		public const string KissingFaceWithSmilingEyes = "😙" ;

		public const string FaceSavoringFood = "😋" ;

		public const string FaceWithTongue = "😛" ;

		public const string WinkingFaceWithTongue = "😜" ;

		public const string ZanyFace = "🤪" ;

		public const string SquintingFaceWithTongue = "😝" ;

		public const string MoneyMouthFace = "🤑" ;

		public const string HuggingFace = "🤗" ;

		public const string FaceWithHandOverMouth = "🤭" ;

		public const string ShushingFace = "🤫" ;

		public const string ThinkingFace = "🤔" ;

		public const string ZipperMouthFace = "🤐" ;

		public const string FaceWithRaisedEyebrow = "🤨" ;

		public const string NeutralFace = "😐" ;

		public const string ExpressionlessFace = "😑" ;

		public const string FaceWithoutMouth = "😶" ;

		public const string SmirkingFace = "😏" ;

		public const string UnamusedFace = "😒" ;

		public const string FaceWithRollingEyes = "🙄" ;

		public const string GrimacingFace = "😬" ;

		public const string LyingFace = "🤥" ;

		public const string RelievedFace = "😌" ;

		public const string PensiveFace = "😔" ;

		public const string SleepyFace = "😪" ;

		public const string DroolingFace = "🤤" ;

		public const string SleepingFace = "😴" ;

		public const string FaceWithMedicalMask = "😷" ;

		public const string FaceWithThermometer = "🤒" ;

		public const string FaceWithHeadBandage = "🤕" ;

		public const string NauseatedFace = "🤢" ;

		public const string FaceVomiting = "🤮" ;

		public const string SneezingFace = "🤧" ;

		public const string HotFace = "🥵" ;

		public const string ColdFace = "🥶" ;

		public const string WoozyFace = "🥴" ;

		public const string DizzyFace = "😵" ;

		public const string ExplodingHead = "🤯" ;

		public const string CowboyHatFace = "🤠" ;

		public const string PartyingFace = "🥳" ;

		public const string SmilingFaceWithSunglasses = "😎" ;

		public const string NerdFace = "🤓" ;

		public const string FaceWithMonocle = "🧐" ;

		public const string ConfusedFace = "😕" ;

		public const string WorriedFace = "😟" ;

		public const string SlightlyFrowningFace = "🙁" ;

		public const string FrowningFace = "☹️" ;

		public const string FrowningFace2 = "☹" ;

		public const string FaceWithOpenMouth = "😮" ;

		public const string HushedFace = "😯" ;

		public const string AstonishedFace = "😲" ;

		public const string FlushedFace = "😳" ;

		public const string PleadingFace = "🥺" ;

		public const string FrowningFaceWithOpenMouth = "😦" ;

		public const string AnguishedFace = "😧" ;

		public const string FearfulFace = "😨" ;

		public const string AnxiousFaceWithSweat = "😰" ;

		public const string SadButRelievedFace = "😥" ;

		public const string CryingFace = "😢" ;

		public const string LoudlyCryingFace = "😭" ;

		public const string FaceScreamingInFear = "😱" ;

		public const string ConfoundedFace = "😖" ;

		public const string PerseveringFace = "😣" ;

		public const string DisappointedFace = "😞" ;

		public const string DowncastFaceWithSweat = "😓" ;

		public const string WearyFace = "😩" ;

		public const string TiredFace = "😫" ;

		public const string YawningFace = "🥱" ;

		public const string FaceWithSteamFromNose = "😤" ;

		public const string PoutingFace = "😡" ;

		public const string AngryFace = "😠" ;

		public const string FaceWithSymbolsOnMouth = "🤬" ;

		public const string SmilingFaceWithHorns = "😈" ;

		public const string AngryFaceWithHorns = "👿" ;

		public const string Skull = "💀" ;

		public const string SkullAndCrossbones = "☠️" ;

		public const string SkullAndCrossbones2 = "☠" ;

		public const string PileOfPoo = "💩" ;

		public const string ClownFace = "🤡" ;

		public const string Ogre = "👹" ;

		public const string Goblin = "👺" ;

		public const string Ghost = "👻" ;

		public const string Alien = "👽" ;

		public const string AlienMonster = "👾" ;

		public const string RobotFace = "🤖" ;

		public const string GrinningCatFace = "😺" ;

		public const string GrinningCatFaceWithSmilingEyes = "😸" ;

		public const string CatFaceWithTearsOfJoy = "😹" ;

		public const string SmilingCatFaceWithHeartEyes = "😻" ;

		public const string CatFaceWithWrySmile = "😼" ;

		public const string KissingCatFace = "😽" ;

		public const string WearyCatFace = "🙀" ;

		public const string CryingCatFace = "😿" ;

		public const string PoutingCatFace = "😾" ;

		public const string SeeNoEvilMonkey = "🙈" ;

		public const string HearNoEvilMonkey = "🙉" ;

		public const string SpeakNoEvilMonkey = "🙊" ;

		public const string KissMark = "💋" ;

		public const string LoveLetter = "💌" ;

		public const string HeartWithArrow = "💘" ;

		public const string HeartWithRibbon = "💝" ;

		public const string SparklingHeart = "💖" ;

		public const string GrowingHeart = "💗" ;

		public const string BeatingHeart = "💓" ;

		public const string RevolvingHearts = "💞" ;

		public const string TwoHearts = "💕" ;

		public const string HeartDecoration = "💟" ;

		public const string HeavyHeartExclamation = "❣️" ;

		public const string HeavyHeartExclamation2 = "❣" ;

		public const string BrokenHeart = "💔" ;

		public const string RedHeart = "❤️" ;

		public const string RedHeart2 = "❤" ;

		public const string OrangeHeart = "🧡" ;

		public const string YellowHeart = "💛" ;

		public const string GreenHeart = "💚" ;

		public const string BlueHeart = "💙" ;

		public const string PurpleHeart = "💜" ;

		public const string BlackHeart = "🖤" ;

		public const string WhiteHeart = "🤍" ;

		public const string BrownHeart = "🤎" ;

		public const string HundredPoints = "💯" ;

		public const string AngerSymbol = "💢" ;

		public const string Collision = "💥" ;

		public const string Dizzy = "💫" ;

		public const string SweatDroplets = "💦" ;

		public const string DashingAway = "💨" ;

		public const string Hole = "🕳️" ;

		public const string Hole2 = "🕳" ;

		public const string Bomb = "💣" ;

		public const string SpeechBalloon = "💬" ;

		public const string EyeInSpeechBubble = "👁️‍🗨️" ;

		public const string EyeInSpeechBubble2 = "👁‍🗨️" ;

		public const string EyeInSpeechBubble3 = "👁️‍🗨" ;

		public const string EyeInSpeechBubble4 = "👁‍🗨" ;

		public const string LeftSpeechBubble = "🗨️" ;

		public const string LeftSpeechBubble2 = "🗨" ;

		public const string RightAngerBubble = "🗯️" ;

		public const string RightAngerBubble2 = "🗯" ;

		public const string ThoughtBalloon = "💭" ;

		public const string Zzz = "💤" ;

		public const string WavingHand = "👋" ;

		public const string WavingHandLightSkinTone = "👋🏻" ;

		public const string WavingHandMediumLightSkinTone = "👋🏼" ;

		public const string WavingHandMediumSkinTone = "👋🏽" ;

		public const string WavingHandMediumDarkSkinTone = "👋🏾" ;

		public const string WavingHandDarkSkinTone = "👋🏿" ;

		public const string RaisedBackOfHand = "🤚" ;

		public const string RaisedBackOfHandLightSkinTone = "🤚🏻" ;

		public const string RaisedBackOfHandMediumLightSkinTone = "🤚🏼" ;

		public const string RaisedBackOfHandMediumSkinTone = "🤚🏽" ;

		public const string RaisedBackOfHandMediumDarkSkinTone = "🤚🏾" ;

		public const string RaisedBackOfHandDarkSkinTone = "🤚🏿" ;

		public const string HandWithFingersSplayed = "🖐️" ;

		public const string HandWithFingersSplayed2 = "🖐" ;

		public const string HandWithFingersSplayedLightSkinTone = "🖐🏻" ;

		public const string HandWithFingersSplayedMediumLightSkinTone = "🖐🏼" ;

		public const string HandWithFingersSplayedMediumSkinTone = "🖐🏽" ;

		public const string HandWithFingersSplayedMediumDarkSkinTone = "🖐🏾" ;

		public const string HandWithFingersSplayedDarkSkinTone = "🖐🏿" ;

		public const string RaisedHand = "✋" ;

		public const string RaisedHandLightSkinTone = "✋🏻" ;

		public const string RaisedHandMediumLightSkinTone = "✋🏼" ;

		public const string RaisedHandMediumSkinTone = "✋🏽" ;

		public const string RaisedHandMediumDarkSkinTone = "✋🏾" ;

		public const string RaisedHandDarkSkinTone = "✋🏿" ;

		public const string VulcanSalute = "🖖" ;

		public const string VulcanSaluteLightSkinTone = "🖖🏻" ;

		public const string VulcanSaluteMediumLightSkinTone = "🖖🏼" ;

		public const string VulcanSaluteMediumSkinTone = "🖖🏽" ;

		public const string VulcanSaluteMediumDarkSkinTone = "🖖🏾" ;

		public const string VulcanSaluteDarkSkinTone = "🖖🏿" ;

		public const string OkHand = "👌" ;

		public const string OkHandLightSkinTone = "👌🏻" ;

		public const string OkHandMediumLightSkinTone = "👌🏼" ;

		public const string OkHandMediumSkinTone = "👌🏽" ;

		public const string OkHandMediumDarkSkinTone = "👌🏾" ;

		public const string OkHandDarkSkinTone = "👌🏿" ;

		public const string PinchingHand = "🤏" ;

		public const string PinchingHandLightSkinTone = "🤏🏻" ;

		public const string PinchingHandMediumLightSkinTone = "🤏🏼" ;

		public const string PinchingHandMediumSkinTone = "🤏🏽" ;

		public const string PinchingHandMediumDarkSkinTone = "🤏🏾" ;

		public const string PinchingHandDarkSkinTone = "🤏🏿" ;

		public const string VictoryHand = "✌️" ;

		public const string VictoryHand2 = "✌" ;

		public const string VictoryHandLightSkinTone = "✌🏻" ;

		public const string VictoryHandMediumLightSkinTone = "✌🏼" ;

		public const string VictoryHandMediumSkinTone = "✌🏽" ;

		public const string VictoryHandMediumDarkSkinTone = "✌🏾" ;

		public const string VictoryHandDarkSkinTone = "✌🏿" ;

		public const string CrossedFingers = "🤞" ;

		public const string CrossedFingersLightSkinTone = "🤞🏻" ;

		public const string CrossedFingersMediumLightSkinTone = "🤞🏼" ;

		public const string CrossedFingersMediumSkinTone = "🤞🏽" ;

		public const string CrossedFingersMediumDarkSkinTone = "🤞🏾" ;

		public const string CrossedFingersDarkSkinTone = "🤞🏿" ;

		public const string LoveYouGesture = "🤟" ;

		public const string LoveYouGestureLightSkinTone = "🤟🏻" ;

		public const string LoveYouGestureMediumLightSkinTone = "🤟🏼" ;

		public const string LoveYouGestureMediumSkinTone = "🤟🏽" ;

		public const string LoveYouGestureMediumDarkSkinTone = "🤟🏾" ;

		public const string LoveYouGestureDarkSkinTone = "🤟🏿" ;

		public const string SignOfTheHorns = "🤘" ;

		public const string SignOfTheHornsLightSkinTone = "🤘🏻" ;

		public const string SignOfTheHornsMediumLightSkinTone = "🤘🏼" ;

		public const string SignOfTheHornsMediumSkinTone = "🤘🏽" ;

		public const string SignOfTheHornsMediumDarkSkinTone = "🤘🏾" ;

		public const string SignOfTheHornsDarkSkinTone = "🤘🏿" ;

		public const string CallMeHand = "🤙" ;

		public const string CallMeHandLightSkinTone = "🤙🏻" ;

		public const string CallMeHandMediumLightSkinTone = "🤙🏼" ;

		public const string CallMeHandMediumSkinTone = "🤙🏽" ;

		public const string CallMeHandMediumDarkSkinTone = "🤙🏾" ;

		public const string CallMeHandDarkSkinTone = "🤙🏿" ;

		public const string BackhandIndexPointingLeft = "👈" ;

		public const string BackhandIndexPointingLeftLightSkinTone = "👈🏻" ;

		public const string BackhandIndexPointingLeftMediumLightSkinTone = "👈🏼" ;

		public const string BackhandIndexPointingLeftMediumSkinTone = "👈🏽" ;

		public const string BackhandIndexPointingLeftMediumDarkSkinTone = "👈🏾" ;

		public const string BackhandIndexPointingLeftDarkSkinTone = "👈🏿" ;

		public const string BackhandIndexPointingRight = "👉" ;

		public const string BackhandIndexPointingRightLightSkinTone = "👉🏻" ;

		public const string BackhandIndexPointingRightMediumLightSkinTone = "👉🏼" ;

		public const string BackhandIndexPointingRightMediumSkinTone = "👉🏽" ;

		public const string BackhandIndexPointingRightMediumDarkSkinTone = "👉🏾" ;

		public const string BackhandIndexPointingRightDarkSkinTone = "👉🏿" ;

		public const string BackhandIndexPointingUp = "👆" ;

		public const string BackhandIndexPointingUpLightSkinTone = "👆🏻" ;

		public const string BackhandIndexPointingUpMediumLightSkinTone = "👆🏼" ;

		public const string BackhandIndexPointingUpMediumSkinTone = "👆🏽" ;

		public const string BackhandIndexPointingUpMediumDarkSkinTone = "👆🏾" ;

		public const string BackhandIndexPointingUpDarkSkinTone = "👆🏿" ;

		public const string MiddleFinger = "🖕" ;

		public const string MiddleFingerLightSkinTone = "🖕🏻" ;

		public const string MiddleFingerMediumLightSkinTone = "🖕🏼" ;

		public const string MiddleFingerMediumSkinTone = "🖕🏽" ;

		public const string MiddleFingerMediumDarkSkinTone = "🖕🏾" ;

		public const string MiddleFingerDarkSkinTone = "🖕🏿" ;

		public const string BackhandIndexPointingDown = "👇" ;

		public const string BackhandIndexPointingDownLightSkinTone = "👇🏻" ;

		public const string BackhandIndexPointingDownMediumLightSkinTone = "👇🏼" ;

		public const string BackhandIndexPointingDownMediumSkinTone = "👇🏽" ;

		public const string BackhandIndexPointingDownMediumDarkSkinTone = "👇🏾" ;

		public const string BackhandIndexPointingDownDarkSkinTone = "👇🏿" ;

		public const string IndexPointingUp = "☝️" ;

		public const string IndexPointingUp2 = "☝" ;

		public const string IndexPointingUpLightSkinTone = "☝🏻" ;

		public const string IndexPointingUpMediumLightSkinTone = "☝🏼" ;

		public const string IndexPointingUpMediumSkinTone = "☝🏽" ;

		public const string IndexPointingUpMediumDarkSkinTone = "☝🏾" ;

		public const string IndexPointingUpDarkSkinTone = "☝🏿" ;

		public const string ThumbsUp = "👍" ;

		public const string ThumbsUpLightSkinTone = "👍🏻" ;

		public const string ThumbsUpMediumLightSkinTone = "👍🏼" ;

		public const string ThumbsUpMediumSkinTone = "👍🏽" ;

		public const string ThumbsUpMediumDarkSkinTone = "👍🏾" ;

		public const string ThumbsUpDarkSkinTone = "👍🏿" ;

		public const string ThumbsDown = "👎" ;

		public const string ThumbsDownLightSkinTone = "👎🏻" ;

		public const string ThumbsDownMediumLightSkinTone = "👎🏼" ;

		public const string ThumbsDownMediumSkinTone = "👎🏽" ;

		public const string ThumbsDownMediumDarkSkinTone = "👎🏾" ;

		public const string ThumbsDownDarkSkinTone = "👎🏿" ;

		public const string RaisedFist = "✊" ;

		public const string RaisedFistLightSkinTone = "✊🏻" ;

		public const string RaisedFistMediumLightSkinTone = "✊🏼" ;

		public const string RaisedFistMediumSkinTone = "✊🏽" ;

		public const string RaisedFistMediumDarkSkinTone = "✊🏾" ;

		public const string RaisedFistDarkSkinTone = "✊🏿" ;

		public const string OncomingFist = "👊" ;

		public const string OncomingFistLightSkinTone = "👊🏻" ;

		public const string OncomingFistMediumLightSkinTone = "👊🏼" ;

		public const string OncomingFistMediumSkinTone = "👊🏽" ;

		public const string OncomingFistMediumDarkSkinTone = "👊🏾" ;

		public const string OncomingFistDarkSkinTone = "👊🏿" ;

		public const string LeftFacingFist = "🤛" ;

		public const string LeftFacingFistLightSkinTone = "🤛🏻" ;

		public const string LeftFacingFistMediumLightSkinTone = "🤛🏼" ;

		public const string LeftFacingFistMediumSkinTone = "🤛🏽" ;

		public const string LeftFacingFistMediumDarkSkinTone = "🤛🏾" ;

		public const string LeftFacingFistDarkSkinTone = "🤛🏿" ;

		public const string RightFacingFist = "🤜" ;

		public const string RightFacingFistLightSkinTone = "🤜🏻" ;

		public const string RightFacingFistMediumLightSkinTone = "🤜🏼" ;

		public const string RightFacingFistMediumSkinTone = "🤜🏽" ;

		public const string RightFacingFistMediumDarkSkinTone = "🤜🏾" ;

		public const string RightFacingFistDarkSkinTone = "🤜🏿" ;

		public const string ClappingHands = "👏" ;

		public const string ClappingHandsLightSkinTone = "👏🏻" ;

		public const string ClappingHandsMediumLightSkinTone = "👏🏼" ;

		public const string ClappingHandsMediumSkinTone = "👏🏽" ;

		public const string ClappingHandsMediumDarkSkinTone = "👏🏾" ;

		public const string ClappingHandsDarkSkinTone = "👏🏿" ;

		public const string RaisingHands = "🙌" ;

		public const string RaisingHandsLightSkinTone = "🙌🏻" ;

		public const string RaisingHandsMediumLightSkinTone = "🙌🏼" ;

		public const string RaisingHandsMediumSkinTone = "🙌🏽" ;

		public const string RaisingHandsMediumDarkSkinTone = "🙌🏾" ;

		public const string RaisingHandsDarkSkinTone = "🙌🏿" ;

		public const string OpenHands = "👐" ;

		public const string OpenHandsLightSkinTone = "👐🏻" ;

		public const string OpenHandsMediumLightSkinTone = "👐🏼" ;

		public const string OpenHandsMediumSkinTone = "👐🏽" ;

		public const string OpenHandsMediumDarkSkinTone = "👐🏾" ;

		public const string OpenHandsDarkSkinTone = "👐🏿" ;

		public const string PalmsUpTogether = "🤲" ;

		public const string PalmsUpTogetherLightSkinTone = "🤲🏻" ;

		public const string PalmsUpTogetherMediumLightSkinTone = "🤲🏼" ;

		public const string PalmsUpTogetherMediumSkinTone = "🤲🏽" ;

		public const string PalmsUpTogetherMediumDarkSkinTone = "🤲🏾" ;

		public const string PalmsUpTogetherDarkSkinTone = "🤲🏿" ;

		public const string Handshake = "🤝" ;

		public const string HandshakeLightSkinTone = "🤝🏻" ;

		public const string HandshakeMediumLightSkinTone = "🤝🏼" ;

		public const string HandshakeMediumSkinTone = "🤝🏽" ;

		public const string HandshakeMediumDarkSkinTone = "🤝🏾" ;

		public const string HandshakeDarkSkinTone = "🤝🏿" ;

		public const string FoldedHands = "🙏" ;

		public const string FoldedHandsLightSkinTone = "🙏🏻" ;

		public const string FoldedHandsMediumLightSkinTone = "🙏🏼" ;

		public const string FoldedHandsMediumSkinTone = "🙏🏽" ;

		public const string FoldedHandsMediumDarkSkinTone = "🙏🏾" ;

		public const string FoldedHandsDarkSkinTone = "🙏🏿" ;

		public const string WritingHand = "✍️" ;

		public const string WritingHand2 = "✍" ;

		public const string WritingHandLightSkinTone = "✍🏻" ;

		public const string WritingHandMediumLightSkinTone = "✍🏼" ;

		public const string WritingHandMediumSkinTone = "✍🏽" ;

		public const string WritingHandMediumDarkSkinTone = "✍🏾" ;

		public const string WritingHandDarkSkinTone = "✍🏿" ;

		public const string NailPolish = "💅" ;

		public const string NailPolishLightSkinTone = "💅🏻" ;

		public const string NailPolishMediumLightSkinTone = "💅🏼" ;

		public const string NailPolishMediumSkinTone = "💅🏽" ;

		public const string NailPolishMediumDarkSkinTone = "💅🏾" ;

		public const string NailPolishDarkSkinTone = "💅🏿" ;

		public const string Selfie = "🤳" ;

		public const string SelfieLightSkinTone = "🤳🏻" ;

		public const string SelfieMediumLightSkinTone = "🤳🏼" ;

		public const string SelfieMediumSkinTone = "🤳🏽" ;

		public const string SelfieMediumDarkSkinTone = "🤳🏾" ;

		public const string SelfieDarkSkinTone = "🤳🏿" ;

		public const string FlexedBiceps = "💪" ;

		public const string FlexedBicepsLightSkinTone = "💪🏻" ;

		public const string FlexedBicepsMediumLightSkinTone = "💪🏼" ;

		public const string FlexedBicepsMediumSkinTone = "💪🏽" ;

		public const string FlexedBicepsMediumDarkSkinTone = "💪🏾" ;

		public const string FlexedBicepsDarkSkinTone = "💪🏿" ;

		public const string MechanicalArm = "🦾" ;

		public const string MechanicalLeg = "🦿" ;

		public const string Leg = "🦵" ;

		public const string LegLightSkinTone = "🦵🏻" ;

		public const string LegMediumLightSkinTone = "🦵🏼" ;

		public const string LegMediumSkinTone = "🦵🏽" ;

		public const string LegMediumDarkSkinTone = "🦵🏾" ;

		public const string LegDarkSkinTone = "🦵🏿" ;

		public const string Foot = "🦶" ;

		public const string FootLightSkinTone = "🦶🏻" ;

		public const string FootMediumLightSkinTone = "🦶🏼" ;

		public const string FootMediumSkinTone = "🦶🏽" ;

		public const string FootMediumDarkSkinTone = "🦶🏾" ;

		public const string FootDarkSkinTone = "🦶🏿" ;

		public const string Ear = "👂" ;

		public const string EarLightSkinTone = "👂🏻" ;

		public const string EarMediumLightSkinTone = "👂🏼" ;

		public const string EarMediumSkinTone = "👂🏽" ;

		public const string EarMediumDarkSkinTone = "👂🏾" ;

		public const string EarDarkSkinTone = "👂🏿" ;

		public const string EarWithHearingAid = "🦻" ;

		public const string EarWithHearingAidLightSkinTone = "🦻🏻" ;

		public const string EarWithHearingAidMediumLightSkinTone = "🦻🏼" ;

		public const string EarWithHearingAidMediumSkinTone = "🦻🏽" ;

		public const string EarWithHearingAidMediumDarkSkinTone = "🦻🏾" ;

		public const string EarWithHearingAidDarkSkinTone = "🦻🏿" ;

		public const string Nose = "👃" ;

		public const string NoseLightSkinTone = "👃🏻" ;

		public const string NoseMediumLightSkinTone = "👃🏼" ;

		public const string NoseMediumSkinTone = "👃🏽" ;

		public const string NoseMediumDarkSkinTone = "👃🏾" ;

		public const string NoseDarkSkinTone = "👃🏿" ;

		public const string Brain = "🧠" ;

		public const string Tooth = "🦷" ;

		public const string Bone = "🦴" ;

		public const string Eyes = "👀" ;

		public const string Eye = "👁️" ;

		public const string Eye2 = "👁" ;

		public const string Tongue = "👅" ;

		public const string Mouth = "👄" ;

		public const string Baby = "👶" ;

		public const string BabyLightSkinTone = "👶🏻" ;

		public const string BabyMediumLightSkinTone = "👶🏼" ;

		public const string BabyMediumSkinTone = "👶🏽" ;

		public const string BabyMediumDarkSkinTone = "👶🏾" ;

		public const string BabyDarkSkinTone = "👶🏿" ;

		public const string Child = "🧒" ;

		public const string ChildLightSkinTone = "🧒🏻" ;

		public const string ChildMediumLightSkinTone = "🧒🏼" ;

		public const string ChildMediumSkinTone = "🧒🏽" ;

		public const string ChildMediumDarkSkinTone = "🧒🏾" ;

		public const string ChildDarkSkinTone = "🧒🏿" ;

		public const string Boy = "👦" ;

		public const string BoyLightSkinTone = "👦🏻" ;

		public const string BoyMediumLightSkinTone = "👦🏼" ;

		public const string BoyMediumSkinTone = "👦🏽" ;

		public const string BoyMediumDarkSkinTone = "👦🏾" ;

		public const string BoyDarkSkinTone = "👦🏿" ;

		public const string Girl = "👧" ;

		public const string GirlLightSkinTone = "👧🏻" ;

		public const string GirlMediumLightSkinTone = "👧🏼" ;

		public const string GirlMediumSkinTone = "👧🏽" ;

		public const string GirlMediumDarkSkinTone = "👧🏾" ;

		public const string GirlDarkSkinTone = "👧🏿" ;

		public const string Person = "🧑" ;

		public const string PersonLightSkinTone = "🧑🏻" ;

		public const string PersonMediumLightSkinTone = "🧑🏼" ;

		public const string PersonMediumSkinTone = "🧑🏽" ;

		public const string PersonMediumDarkSkinTone = "🧑🏾" ;

		public const string PersonDarkSkinTone = "🧑🏿" ;

		public const string PersonBlondHair = "👱" ;

		public const string PersonLightSkinToneBlondHair = "👱🏻" ;

		public const string PersonMediumLightSkinToneBlondHair = "👱🏼" ;

		public const string PersonMediumSkinToneBlondHair = "👱🏽" ;

		public const string PersonMediumDarkSkinToneBlondHair = "👱🏾" ;

		public const string PersonDarkSkinToneBlondHair = "👱🏿" ;

		public const string Man = "👨" ;

		public const string ManLightSkinTone = "👨🏻" ;

		public const string ManMediumLightSkinTone = "👨🏼" ;

		public const string ManMediumSkinTone = "👨🏽" ;

		public const string ManMediumDarkSkinTone = "👨🏾" ;

		public const string ManDarkSkinTone = "👨🏿" ;

		public const string ManBlondHair = "👱‍♂️" ;

		public const string ManBlondHair2 = "👱‍♂" ;

		public const string ManLightSkinToneBlondHair = "👱🏻‍♂️" ;

		public const string ManLightSkinToneBlondHair2 = "👱🏻‍♂" ;

		public const string ManMediumLightSkinToneBlondHair = "👱🏼‍♂️" ;

		public const string ManMediumLightSkinToneBlondHair2 = "👱🏼‍♂" ;

		public const string ManMediumSkinToneBlondHair = "👱🏽‍♂️" ;

		public const string ManMediumSkinToneBlondHair2 = "👱🏽‍♂" ;

		public const string ManMediumDarkSkinToneBlondHair = "👱🏾‍♂️" ;

		public const string ManMediumDarkSkinToneBlondHair2 = "👱🏾‍♂" ;

		public const string ManDarkSkinToneBlondHair = "👱🏿‍♂️" ;

		public const string ManDarkSkinToneBlondHair2 = "👱🏿‍♂" ;

		public const string ManRedHair = "👨‍🦰" ;

		public const string ManLightSkinToneRedHair = "👨🏻‍🦰" ;

		public const string ManMediumLightSkinToneRedHair = "👨🏼‍🦰" ;

		public const string ManMediumSkinToneRedHair = "👨🏽‍🦰" ;

		public const string ManMediumDarkSkinToneRedHair = "👨🏾‍🦰" ;

		public const string ManDarkSkinToneRedHair = "👨🏿‍🦰" ;

		public const string ManCurlyHair = "👨‍🦱" ;

		public const string ManLightSkinToneCurlyHair = "👨🏻‍🦱" ;

		public const string ManMediumLightSkinToneCurlyHair = "👨🏼‍🦱" ;

		public const string ManMediumSkinToneCurlyHair = "👨🏽‍🦱" ;

		public const string ManMediumDarkSkinToneCurlyHair = "👨🏾‍🦱" ;

		public const string ManDarkSkinToneCurlyHair = "👨🏿‍🦱" ;

		public const string ManWhiteHair = "👨‍🦳" ;

		public const string ManLightSkinToneWhiteHair = "👨🏻‍🦳" ;

		public const string ManMediumLightSkinToneWhiteHair = "👨🏼‍🦳" ;

		public const string ManMediumSkinToneWhiteHair = "👨🏽‍🦳" ;

		public const string ManMediumDarkSkinToneWhiteHair = "👨🏾‍🦳" ;

		public const string ManDarkSkinToneWhiteHair = "👨🏿‍🦳" ;

		public const string ManBald = "👨‍🦲" ;

		public const string ManLightSkinToneBald = "👨🏻‍🦲" ;

		public const string ManMediumLightSkinToneBald = "👨🏼‍🦲" ;

		public const string ManMediumSkinToneBald = "👨🏽‍🦲" ;

		public const string ManMediumDarkSkinToneBald = "👨🏾‍🦲" ;

		public const string ManDarkSkinToneBald = "👨🏿‍🦲" ;

		public const string ManBeard = "🧔" ;

		public const string ManLightSkinToneBeard = "🧔🏻" ;

		public const string ManMediumLightSkinToneBeard = "🧔🏼" ;

		public const string ManMediumSkinToneBeard = "🧔🏽" ;

		public const string ManMediumDarkSkinToneBeard = "🧔🏾" ;

		public const string ManDarkSkinToneBeard = "🧔🏿" ;

		public const string Woman = "👩" ;

		public const string WomanLightSkinTone = "👩🏻" ;

		public const string WomanMediumLightSkinTone = "👩🏼" ;

		public const string WomanMediumSkinTone = "👩🏽" ;

		public const string WomanMediumDarkSkinTone = "👩🏾" ;

		public const string WomanDarkSkinTone = "👩🏿" ;

		public const string WomanBlondHair = "👱‍♀️" ;

		public const string WomanBlondHair2 = "👱‍♀" ;

		public const string WomanLightSkinToneBlondHair = "👱🏻‍♀️" ;

		public const string WomanLightSkinToneBlondHair2 = "👱🏻‍♀" ;

		public const string WomanMediumLightSkinToneBlondHair = "👱🏼‍♀️" ;

		public const string WomanMediumLightSkinToneBlondHair2 = "👱🏼‍♀" ;

		public const string WomanMediumSkinToneBlondHair = "👱🏽‍♀️" ;

		public const string WomanMediumSkinToneBlondHair2 = "👱🏽‍♀" ;

		public const string WomanMediumDarkSkinToneBlondHair = "👱🏾‍♀️" ;

		public const string WomanMediumDarkSkinToneBlondHair2 = "👱🏾‍♀" ;

		public const string WomanDarkSkinToneBlondHair = "👱🏿‍♀️" ;

		public const string WomanDarkSkinToneBlondHair2 = "👱🏿‍♀" ;

		public const string WomanRedHair = "👩‍🦰" ;

		public const string WomanLightSkinToneRedHair = "👩🏻‍🦰" ;

		public const string WomanMediumLightSkinToneRedHair = "👩🏼‍🦰" ;

		public const string WomanMediumSkinToneRedHair = "👩🏽‍🦰" ;

		public const string WomanMediumDarkSkinToneRedHair = "👩🏾‍🦰" ;

		public const string WomanDarkSkinToneRedHair = "👩🏿‍🦰" ;

		public const string WomanCurlyHair = "👩‍🦱" ;

		public const string WomanLightSkinToneCurlyHair = "👩🏻‍🦱" ;

		public const string WomanMediumLightSkinToneCurlyHair = "👩🏼‍🦱" ;

		public const string WomanMediumSkinToneCurlyHair = "👩🏽‍🦱" ;

		public const string WomanMediumDarkSkinToneCurlyHair = "👩🏾‍🦱" ;

		public const string WomanDarkSkinToneCurlyHair = "👩🏿‍🦱" ;

		public const string WomanWhiteHair = "👩‍🦳" ;

		public const string WomanLightSkinToneWhiteHair = "👩🏻‍🦳" ;

		public const string WomanMediumLightSkinToneWhiteHair = "👩🏼‍🦳" ;

		public const string WomanMediumSkinToneWhiteHair = "👩🏽‍🦳" ;

		public const string WomanMediumDarkSkinToneWhiteHair = "👩🏾‍🦳" ;

		public const string WomanDarkSkinToneWhiteHair = "👩🏿‍🦳" ;

		public const string WomanBald = "👩‍🦲" ;

		public const string WomanLightSkinToneBald = "👩🏻‍🦲" ;

		public const string WomanMediumLightSkinToneBald = "👩🏼‍🦲" ;

		public const string WomanMediumSkinToneBald = "👩🏽‍🦲" ;

		public const string WomanMediumDarkSkinToneBald = "👩🏾‍🦲" ;

		public const string WomanDarkSkinToneBald = "👩🏿‍🦲" ;

		public const string OlderPerson = "🧓" ;

		public const string OlderPersonLightSkinTone = "🧓🏻" ;

		public const string OlderPersonMediumLightSkinTone = "🧓🏼" ;

		public const string OlderPersonMediumSkinTone = "🧓🏽" ;

		public const string OlderPersonMediumDarkSkinTone = "🧓🏾" ;

		public const string OlderPersonDarkSkinTone = "🧓🏿" ;

		public const string OldMan = "👴" ;

		public const string OldManLightSkinTone = "👴🏻" ;

		public const string OldManMediumLightSkinTone = "👴🏼" ;

		public const string OldManMediumSkinTone = "👴🏽" ;

		public const string OldManMediumDarkSkinTone = "👴🏾" ;

		public const string OldManDarkSkinTone = "👴🏿" ;

		public const string OldWoman = "👵" ;

		public const string OldWomanLightSkinTone = "👵🏻" ;

		public const string OldWomanMediumLightSkinTone = "👵🏼" ;

		public const string OldWomanMediumSkinTone = "👵🏽" ;

		public const string OldWomanMediumDarkSkinTone = "👵🏾" ;

		public const string OldWomanDarkSkinTone = "👵🏿" ;

		public const string PersonFrowning = "🙍" ;

		public const string PersonFrowningLightSkinTone = "🙍🏻" ;

		public const string PersonFrowningMediumLightSkinTone = "🙍🏼" ;

		public const string PersonFrowningMediumSkinTone = "🙍🏽" ;

		public const string PersonFrowningMediumDarkSkinTone = "🙍🏾" ;

		public const string PersonFrowningDarkSkinTone = "🙍🏿" ;

		public const string ManFrowning = "🙍‍♂️" ;

		public const string ManFrowning2 = "🙍‍♂" ;

		public const string ManFrowningLightSkinTone = "🙍🏻‍♂️" ;

		public const string ManFrowningLightSkinTone2 = "🙍🏻‍♂" ;

		public const string ManFrowningMediumLightSkinTone = "🙍🏼‍♂️" ;

		public const string ManFrowningMediumLightSkinTone2 = "🙍🏼‍♂" ;

		public const string ManFrowningMediumSkinTone = "🙍🏽‍♂️" ;

		public const string ManFrowningMediumSkinTone2 = "🙍🏽‍♂" ;

		public const string ManFrowningMediumDarkSkinTone = "🙍🏾‍♂️" ;

		public const string ManFrowningMediumDarkSkinTone2 = "🙍🏾‍♂" ;

		public const string ManFrowningDarkSkinTone = "🙍🏿‍♂️" ;

		public const string ManFrowningDarkSkinTone2 = "🙍🏿‍♂" ;

		public const string WomanFrowning = "🙍‍♀️" ;

		public const string WomanFrowning2 = "🙍‍♀" ;

		public const string WomanFrowningLightSkinTone = "🙍🏻‍♀️" ;

		public const string WomanFrowningLightSkinTone2 = "🙍🏻‍♀" ;

		public const string WomanFrowningMediumLightSkinTone = "🙍🏼‍♀️" ;

		public const string WomanFrowningMediumLightSkinTone2 = "🙍🏼‍♀" ;

		public const string WomanFrowningMediumSkinTone = "🙍🏽‍♀️" ;

		public const string WomanFrowningMediumSkinTone2 = "🙍🏽‍♀" ;

		public const string WomanFrowningMediumDarkSkinTone = "🙍🏾‍♀️" ;

		public const string WomanFrowningMediumDarkSkinTone2 = "🙍🏾‍♀" ;

		public const string WomanFrowningDarkSkinTone = "🙍🏿‍♀️" ;

		public const string WomanFrowningDarkSkinTone2 = "🙍🏿‍♀" ;

		public const string PersonPouting = "🙎" ;

		public const string PersonPoutingLightSkinTone = "🙎🏻" ;

		public const string PersonPoutingMediumLightSkinTone = "🙎🏼" ;

		public const string PersonPoutingMediumSkinTone = "🙎🏽" ;

		public const string PersonPoutingMediumDarkSkinTone = "🙎🏾" ;

		public const string PersonPoutingDarkSkinTone = "🙎🏿" ;

		public const string ManPouting = "🙎‍♂️" ;

		public const string ManPouting2 = "🙎‍♂" ;

		public const string ManPoutingLightSkinTone = "🙎🏻‍♂️" ;

		public const string ManPoutingLightSkinTone2 = "🙎🏻‍♂" ;

		public const string ManPoutingMediumLightSkinTone = "🙎🏼‍♂️" ;

		public const string ManPoutingMediumLightSkinTone2 = "🙎🏼‍♂" ;

		public const string ManPoutingMediumSkinTone = "🙎🏽‍♂️" ;

		public const string ManPoutingMediumSkinTone2 = "🙎🏽‍♂" ;

		public const string ManPoutingMediumDarkSkinTone = "🙎🏾‍♂️" ;

		public const string ManPoutingMediumDarkSkinTone2 = "🙎🏾‍♂" ;

		public const string ManPoutingDarkSkinTone = "🙎🏿‍♂️" ;

		public const string ManPoutingDarkSkinTone2 = "🙎🏿‍♂" ;

		public const string WomanPouting = "🙎‍♀️" ;

		public const string WomanPouting2 = "🙎‍♀" ;

		public const string WomanPoutingLightSkinTone = "🙎🏻‍♀️" ;

		public const string WomanPoutingLightSkinTone2 = "🙎🏻‍♀" ;

		public const string WomanPoutingMediumLightSkinTone = "🙎🏼‍♀️" ;

		public const string WomanPoutingMediumLightSkinTone2 = "🙎🏼‍♀" ;

		public const string WomanPoutingMediumSkinTone = "🙎🏽‍♀️" ;

		public const string WomanPoutingMediumSkinTone2 = "🙎🏽‍♀" ;

		public const string WomanPoutingMediumDarkSkinTone = "🙎🏾‍♀️" ;

		public const string WomanPoutingMediumDarkSkinTone2 = "🙎🏾‍♀" ;

		public const string WomanPoutingDarkSkinTone = "🙎🏿‍♀️" ;

		public const string WomanPoutingDarkSkinTone2 = "🙎🏿‍♀" ;

		public const string PersonGesturingNo = "🙅" ;

		public const string PersonGesturingNoLightSkinTone = "🙅🏻" ;

		public const string PersonGesturingNoMediumLightSkinTone = "🙅🏼" ;

		public const string PersonGesturingNoMediumSkinTone = "🙅🏽" ;

		public const string PersonGesturingNoMediumDarkSkinTone = "🙅🏾" ;

		public const string PersonGesturingNoDarkSkinTone = "🙅🏿" ;

		public const string ManGesturingNo = "🙅‍♂️" ;

		public const string ManGesturingNo2 = "🙅‍♂" ;

		public const string ManGesturingNoLightSkinTone = "🙅🏻‍♂️" ;

		public const string ManGesturingNoLightSkinTone2 = "🙅🏻‍♂" ;

		public const string ManGesturingNoMediumLightSkinTone = "🙅🏼‍♂️" ;

		public const string ManGesturingNoMediumLightSkinTone2 = "🙅🏼‍♂" ;

		public const string ManGesturingNoMediumSkinTone = "🙅🏽‍♂️" ;

		public const string ManGesturingNoMediumSkinTone2 = "🙅🏽‍♂" ;

		public const string ManGesturingNoMediumDarkSkinTone = "🙅🏾‍♂️" ;

		public const string ManGesturingNoMediumDarkSkinTone2 = "🙅🏾‍♂" ;

		public const string ManGesturingNoDarkSkinTone = "🙅🏿‍♂️" ;

		public const string ManGesturingNoDarkSkinTone2 = "🙅🏿‍♂" ;

		public const string WomanGesturingNo = "🙅‍♀️" ;

		public const string WomanGesturingNo2 = "🙅‍♀" ;

		public const string WomanGesturingNoLightSkinTone = "🙅🏻‍♀️" ;

		public const string WomanGesturingNoLightSkinTone2 = "🙅🏻‍♀" ;

		public const string WomanGesturingNoMediumLightSkinTone = "🙅🏼‍♀️" ;

		public const string WomanGesturingNoMediumLightSkinTone2 = "🙅🏼‍♀" ;

		public const string WomanGesturingNoMediumSkinTone = "🙅🏽‍♀️" ;

		public const string WomanGesturingNoMediumSkinTone2 = "🙅🏽‍♀" ;

		public const string WomanGesturingNoMediumDarkSkinTone = "🙅🏾‍♀️" ;

		public const string WomanGesturingNoMediumDarkSkinTone2 = "🙅🏾‍♀" ;

		public const string WomanGesturingNoDarkSkinTone = "🙅🏿‍♀️" ;

		public const string WomanGesturingNoDarkSkinTone2 = "🙅🏿‍♀" ;

		public const string PersonGesturingOk = "🙆" ;

		public const string PersonGesturingOkLightSkinTone = "🙆🏻" ;

		public const string PersonGesturingOkMediumLightSkinTone = "🙆🏼" ;

		public const string PersonGesturingOkMediumSkinTone = "🙆🏽" ;

		public const string PersonGesturingOkMediumDarkSkinTone = "🙆🏾" ;

		public const string PersonGesturingOkDarkSkinTone = "🙆🏿" ;

		public const string ManGesturingOk = "🙆‍♂️" ;

		public const string ManGesturingOk2 = "🙆‍♂" ;

		public const string ManGesturingOkLightSkinTone = "🙆🏻‍♂️" ;

		public const string ManGesturingOkLightSkinTone2 = "🙆🏻‍♂" ;

		public const string ManGesturingOkMediumLightSkinTone = "🙆🏼‍♂️" ;

		public const string ManGesturingOkMediumLightSkinTone2 = "🙆🏼‍♂" ;

		public const string ManGesturingOkMediumSkinTone = "🙆🏽‍♂️" ;

		public const string ManGesturingOkMediumSkinTone2 = "🙆🏽‍♂" ;

		public const string ManGesturingOkMediumDarkSkinTone = "🙆🏾‍♂️" ;

		public const string ManGesturingOkMediumDarkSkinTone2 = "🙆🏾‍♂" ;

		public const string ManGesturingOkDarkSkinTone = "🙆🏿‍♂️" ;

		public const string ManGesturingOkDarkSkinTone2 = "🙆🏿‍♂" ;

		public const string WomanGesturingOk = "🙆‍♀️" ;

		public const string WomanGesturingOk2 = "🙆‍♀" ;

		public const string WomanGesturingOkLightSkinTone = "🙆🏻‍♀️" ;

		public const string WomanGesturingOkLightSkinTone2 = "🙆🏻‍♀" ;

		public const string WomanGesturingOkMediumLightSkinTone = "🙆🏼‍♀️" ;

		public const string WomanGesturingOkMediumLightSkinTone2 = "🙆🏼‍♀" ;

		public const string WomanGesturingOkMediumSkinTone = "🙆🏽‍♀️" ;

		public const string WomanGesturingOkMediumSkinTone2 = "🙆🏽‍♀" ;

		public const string WomanGesturingOkMediumDarkSkinTone = "🙆🏾‍♀️" ;

		public const string WomanGesturingOkMediumDarkSkinTone2 = "🙆🏾‍♀" ;

		public const string WomanGesturingOkDarkSkinTone = "🙆🏿‍♀️" ;

		public const string WomanGesturingOkDarkSkinTone2 = "🙆🏿‍♀" ;

		public const string PersonTippingHand = "💁" ;

		public const string PersonTippingHandLightSkinTone = "💁🏻" ;

		public const string PersonTippingHandMediumLightSkinTone = "💁🏼" ;

		public const string PersonTippingHandMediumSkinTone = "💁🏽" ;

		public const string PersonTippingHandMediumDarkSkinTone = "💁🏾" ;

		public const string PersonTippingHandDarkSkinTone = "💁🏿" ;

		public const string ManTippingHand = "💁‍♂️" ;

		public const string ManTippingHand2 = "💁‍♂" ;

		public const string ManTippingHandLightSkinTone = "💁🏻‍♂️" ;

		public const string ManTippingHandLightSkinTone2 = "💁🏻‍♂" ;

		public const string ManTippingHandMediumLightSkinTone = "💁🏼‍♂️" ;

		public const string ManTippingHandMediumLightSkinTone2 = "💁🏼‍♂" ;

		public const string ManTippingHandMediumSkinTone = "💁🏽‍♂️" ;

		public const string ManTippingHandMediumSkinTone2 = "💁🏽‍♂" ;

		public const string ManTippingHandMediumDarkSkinTone = "💁🏾‍♂️" ;

		public const string ManTippingHandMediumDarkSkinTone2 = "💁🏾‍♂" ;

		public const string ManTippingHandDarkSkinTone = "💁🏿‍♂️" ;

		public const string ManTippingHandDarkSkinTone2 = "💁🏿‍♂" ;

		public const string WomanTippingHand = "💁‍♀️" ;

		public const string WomanTippingHand2 = "💁‍♀" ;

		public const string WomanTippingHandLightSkinTone = "💁🏻‍♀️" ;

		public const string WomanTippingHandLightSkinTone2 = "💁🏻‍♀" ;

		public const string WomanTippingHandMediumLightSkinTone = "💁🏼‍♀️" ;

		public const string WomanTippingHandMediumLightSkinTone2 = "💁🏼‍♀" ;

		public const string WomanTippingHandMediumSkinTone = "💁🏽‍♀️" ;

		public const string WomanTippingHandMediumSkinTone2 = "💁🏽‍♀" ;

		public const string WomanTippingHandMediumDarkSkinTone = "💁🏾‍♀️" ;

		public const string WomanTippingHandMediumDarkSkinTone2 = "💁🏾‍♀" ;

		public const string WomanTippingHandDarkSkinTone = "💁🏿‍♀️" ;

		public const string WomanTippingHandDarkSkinTone2 = "💁🏿‍♀" ;

		public const string PersonRaisingHand = "🙋" ;

		public const string PersonRaisingHandLightSkinTone = "🙋🏻" ;

		public const string PersonRaisingHandMediumLightSkinTone = "🙋🏼" ;

		public const string PersonRaisingHandMediumSkinTone = "🙋🏽" ;

		public const string PersonRaisingHandMediumDarkSkinTone = "🙋🏾" ;

		public const string PersonRaisingHandDarkSkinTone = "🙋🏿" ;

		public const string ManRaisingHand = "🙋‍♂️" ;

		public const string ManRaisingHand2 = "🙋‍♂" ;

		public const string ManRaisingHandLightSkinTone = "🙋🏻‍♂️" ;

		public const string ManRaisingHandLightSkinTone2 = "🙋🏻‍♂" ;

		public const string ManRaisingHandMediumLightSkinTone = "🙋🏼‍♂️" ;

		public const string ManRaisingHandMediumLightSkinTone2 = "🙋🏼‍♂" ;

		public const string ManRaisingHandMediumSkinTone = "🙋🏽‍♂️" ;

		public const string ManRaisingHandMediumSkinTone2 = "🙋🏽‍♂" ;

		public const string ManRaisingHandMediumDarkSkinTone = "🙋🏾‍♂️" ;

		public const string ManRaisingHandMediumDarkSkinTone2 = "🙋🏾‍♂" ;

		public const string ManRaisingHandDarkSkinTone = "🙋🏿‍♂️" ;

		public const string ManRaisingHandDarkSkinTone2 = "🙋🏿‍♂" ;

		public const string WomanRaisingHand = "🙋‍♀️" ;

		public const string WomanRaisingHand2 = "🙋‍♀" ;

		public const string WomanRaisingHandLightSkinTone = "🙋🏻‍♀️" ;

		public const string WomanRaisingHandLightSkinTone2 = "🙋🏻‍♀" ;

		public const string WomanRaisingHandMediumLightSkinTone = "🙋🏼‍♀️" ;

		public const string WomanRaisingHandMediumLightSkinTone2 = "🙋🏼‍♀" ;

		public const string WomanRaisingHandMediumSkinTone = "🙋🏽‍♀️" ;

		public const string WomanRaisingHandMediumSkinTone2 = "🙋🏽‍♀" ;

		public const string WomanRaisingHandMediumDarkSkinTone = "🙋🏾‍♀️" ;

		public const string WomanRaisingHandMediumDarkSkinTone2 = "🙋🏾‍♀" ;

		public const string WomanRaisingHandDarkSkinTone = "🙋🏿‍♀️" ;

		public const string WomanRaisingHandDarkSkinTone2 = "🙋🏿‍♀" ;

		public const string DeafPerson = "🧏" ;

		public const string DeafPersonLightSkinTone = "🧏🏻" ;

		public const string DeafPersonMediumLightSkinTone = "🧏🏼" ;

		public const string DeafPersonMediumSkinTone = "🧏🏽" ;

		public const string DeafPersonMediumDarkSkinTone = "🧏🏾" ;

		public const string DeafPersonDarkSkinTone = "🧏🏿" ;

		public const string DeafMan = "🧏‍♂️" ;

		public const string DeafMan2 = "🧏‍♂" ;

		public const string DeafManLightSkinTone = "🧏🏻‍♂️" ;

		public const string DeafManLightSkinTone2 = "🧏🏻‍♂" ;

		public const string DeafManMediumLightSkinTone = "🧏🏼‍♂️" ;

		public const string DeafManMediumLightSkinTone2 = "🧏🏼‍♂" ;

		public const string DeafManMediumSkinTone = "🧏🏽‍♂️" ;

		public const string DeafManMediumSkinTone2 = "🧏🏽‍♂" ;

		public const string DeafManMediumDarkSkinTone = "🧏🏾‍♂️" ;

		public const string DeafManMediumDarkSkinTone2 = "🧏🏾‍♂" ;

		public const string DeafManDarkSkinTone = "🧏🏿‍♂️" ;

		public const string DeafManDarkSkinTone2 = "🧏🏿‍♂" ;

		public const string DeafWoman = "🧏‍♀️" ;

		public const string DeafWoman2 = "🧏‍♀" ;

		public const string DeafWomanLightSkinTone = "🧏🏻‍♀️" ;

		public const string DeafWomanLightSkinTone2 = "🧏🏻‍♀" ;

		public const string DeafWomanMediumLightSkinTone = "🧏🏼‍♀️" ;

		public const string DeafWomanMediumLightSkinTone2 = "🧏🏼‍♀" ;

		public const string DeafWomanMediumSkinTone = "🧏🏽‍♀️" ;

		public const string DeafWomanMediumSkinTone2 = "🧏🏽‍♀" ;

		public const string DeafWomanMediumDarkSkinTone = "🧏🏾‍♀️" ;

		public const string DeafWomanMediumDarkSkinTone2 = "🧏🏾‍♀" ;

		public const string DeafWomanDarkSkinTone = "🧏🏿‍♀️" ;

		public const string DeafWomanDarkSkinTone2 = "🧏🏿‍♀" ;

		public const string PersonBowing = "🙇" ;

		public const string PersonBowingLightSkinTone = "🙇🏻" ;

		public const string PersonBowingMediumLightSkinTone = "🙇🏼" ;

		public const string PersonBowingMediumSkinTone = "🙇🏽" ;

		public const string PersonBowingMediumDarkSkinTone = "🙇🏾" ;

		public const string PersonBowingDarkSkinTone = "🙇🏿" ;

		public const string ManBowing = "🙇‍♂️" ;

		public const string ManBowing2 = "🙇‍♂" ;

		public const string ManBowingLightSkinTone = "🙇🏻‍♂️" ;

		public const string ManBowingLightSkinTone2 = "🙇🏻‍♂" ;

		public const string ManBowingMediumLightSkinTone = "🙇🏼‍♂️" ;

		public const string ManBowingMediumLightSkinTone2 = "🙇🏼‍♂" ;

		public const string ManBowingMediumSkinTone = "🙇🏽‍♂️" ;

		public const string ManBowingMediumSkinTone2 = "🙇🏽‍♂" ;

		public const string ManBowingMediumDarkSkinTone = "🙇🏾‍♂️" ;

		public const string ManBowingMediumDarkSkinTone2 = "🙇🏾‍♂" ;

		public const string ManBowingDarkSkinTone = "🙇🏿‍♂️" ;

		public const string ManBowingDarkSkinTone2 = "🙇🏿‍♂" ;

		public const string WomanBowing = "🙇‍♀️" ;

		public const string WomanBowing2 = "🙇‍♀" ;

		public const string WomanBowingLightSkinTone = "🙇🏻‍♀️" ;

		public const string WomanBowingLightSkinTone2 = "🙇🏻‍♀" ;

		public const string WomanBowingMediumLightSkinTone = "🙇🏼‍♀️" ;

		public const string WomanBowingMediumLightSkinTone2 = "🙇🏼‍♀" ;

		public const string WomanBowingMediumSkinTone = "🙇🏽‍♀️" ;

		public const string WomanBowingMediumSkinTone2 = "🙇🏽‍♀" ;

		public const string WomanBowingMediumDarkSkinTone = "🙇🏾‍♀️" ;

		public const string WomanBowingMediumDarkSkinTone2 = "🙇🏾‍♀" ;

		public const string WomanBowingDarkSkinTone = "🙇🏿‍♀️" ;

		public const string WomanBowingDarkSkinTone2 = "🙇🏿‍♀" ;

		public const string PersonFacepalming = "🤦" ;

		public const string PersonFacepalmingLightSkinTone = "🤦🏻" ;

		public const string PersonFacepalmingMediumLightSkinTone = "🤦🏼" ;

		public const string PersonFacepalmingMediumSkinTone = "🤦🏽" ;

		public const string PersonFacepalmingMediumDarkSkinTone = "🤦🏾" ;

		public const string PersonFacepalmingDarkSkinTone = "🤦🏿" ;

		public const string ManFacepalming = "🤦‍♂️" ;

		public const string ManFacepalming2 = "🤦‍♂" ;

		public const string ManFacepalmingLightSkinTone = "🤦🏻‍♂️" ;

		public const string ManFacepalmingLightSkinTone2 = "🤦🏻‍♂" ;

		public const string ManFacepalmingMediumLightSkinTone = "🤦🏼‍♂️" ;

		public const string ManFacepalmingMediumLightSkinTone2 = "🤦🏼‍♂" ;

		public const string ManFacepalmingMediumSkinTone = "🤦🏽‍♂️" ;

		public const string ManFacepalmingMediumSkinTone2 = "🤦🏽‍♂" ;

		public const string ManFacepalmingMediumDarkSkinTone = "🤦🏾‍♂️" ;

		public const string ManFacepalmingMediumDarkSkinTone2 = "🤦🏾‍♂" ;

		public const string ManFacepalmingDarkSkinTone = "🤦🏿‍♂️" ;

		public const string ManFacepalmingDarkSkinTone2 = "🤦🏿‍♂" ;

		public const string WomanFacepalming = "🤦‍♀️" ;

		public const string WomanFacepalming2 = "🤦‍♀" ;

		public const string WomanFacepalmingLightSkinTone = "🤦🏻‍♀️" ;

		public const string WomanFacepalmingLightSkinTone2 = "🤦🏻‍♀" ;

		public const string WomanFacepalmingMediumLightSkinTone = "🤦🏼‍♀️" ;

		public const string WomanFacepalmingMediumLightSkinTone2 = "🤦🏼‍♀" ;

		public const string WomanFacepalmingMediumSkinTone = "🤦🏽‍♀️" ;

		public const string WomanFacepalmingMediumSkinTone2 = "🤦🏽‍♀" ;

		public const string WomanFacepalmingMediumDarkSkinTone = "🤦🏾‍♀️" ;

		public const string WomanFacepalmingMediumDarkSkinTone2 = "🤦🏾‍♀" ;

		public const string WomanFacepalmingDarkSkinTone = "🤦🏿‍♀️" ;

		public const string WomanFacepalmingDarkSkinTone2 = "🤦🏿‍♀" ;

		public const string PersonShrugging = "🤷" ;

		public const string PersonShruggingLightSkinTone = "🤷🏻" ;

		public const string PersonShruggingMediumLightSkinTone = "🤷🏼" ;

		public const string PersonShruggingMediumSkinTone = "🤷🏽" ;

		public const string PersonShruggingMediumDarkSkinTone = "🤷🏾" ;

		public const string PersonShruggingDarkSkinTone = "🤷🏿" ;

		public const string ManShrugging = "🤷‍♂️" ;

		public const string ManShrugging2 = "🤷‍♂" ;

		public const string ManShruggingLightSkinTone = "🤷🏻‍♂️" ;

		public const string ManShruggingLightSkinTone2 = "🤷🏻‍♂" ;

		public const string ManShruggingMediumLightSkinTone = "🤷🏼‍♂️" ;

		public const string ManShruggingMediumLightSkinTone2 = "🤷🏼‍♂" ;

		public const string ManShruggingMediumSkinTone = "🤷🏽‍♂️" ;

		public const string ManShruggingMediumSkinTone2 = "🤷🏽‍♂" ;

		public const string ManShruggingMediumDarkSkinTone = "🤷🏾‍♂️" ;

		public const string ManShruggingMediumDarkSkinTone2 = "🤷🏾‍♂" ;

		public const string ManShruggingDarkSkinTone = "🤷🏿‍♂️" ;

		public const string ManShruggingDarkSkinTone2 = "🤷🏿‍♂" ;

		public const string WomanShrugging = "🤷‍♀️" ;

		public const string WomanShrugging2 = "🤷‍♀" ;

		public const string WomanShruggingLightSkinTone = "🤷🏻‍♀️" ;

		public const string WomanShruggingLightSkinTone2 = "🤷🏻‍♀" ;

		public const string WomanShruggingMediumLightSkinTone = "🤷🏼‍♀️" ;

		public const string WomanShruggingMediumLightSkinTone2 = "🤷🏼‍♀" ;

		public const string WomanShruggingMediumSkinTone = "🤷🏽‍♀️" ;

		public const string WomanShruggingMediumSkinTone2 = "🤷🏽‍♀" ;

		public const string WomanShruggingMediumDarkSkinTone = "🤷🏾‍♀️" ;

		public const string WomanShruggingMediumDarkSkinTone2 = "🤷🏾‍♀" ;

		public const string WomanShruggingDarkSkinTone = "🤷🏿‍♀️" ;

		public const string WomanShruggingDarkSkinTone2 = "🤷🏿‍♀" ;

		public const string ManHealthWorker = "👨‍⚕️" ;

		public const string ManHealthWorker2 = "👨‍⚕" ;

		public const string ManHealthWorkerLightSkinTone = "👨🏻‍⚕️" ;

		public const string ManHealthWorkerLightSkinTone2 = "👨🏻‍⚕" ;

		public const string ManHealthWorkerMediumLightSkinTone = "👨🏼‍⚕️" ;

		public const string ManHealthWorkerMediumLightSkinTone2 = "👨🏼‍⚕" ;

		public const string ManHealthWorkerMediumSkinTone = "👨🏽‍⚕️" ;

		public const string ManHealthWorkerMediumSkinTone2 = "👨🏽‍⚕" ;

		public const string ManHealthWorkerMediumDarkSkinTone = "👨🏾‍⚕️" ;

		public const string ManHealthWorkerMediumDarkSkinTone2 = "👨🏾‍⚕" ;

		public const string ManHealthWorkerDarkSkinTone = "👨🏿‍⚕️" ;

		public const string ManHealthWorkerDarkSkinTone2 = "👨🏿‍⚕" ;

		public const string WomanHealthWorker = "👩‍⚕️" ;

		public const string WomanHealthWorker2 = "👩‍⚕" ;

		public const string WomanHealthWorkerLightSkinTone = "👩🏻‍⚕️" ;

		public const string WomanHealthWorkerLightSkinTone2 = "👩🏻‍⚕" ;

		public const string WomanHealthWorkerMediumLightSkinTone = "👩🏼‍⚕️" ;

		public const string WomanHealthWorkerMediumLightSkinTone2 = "👩🏼‍⚕" ;

		public const string WomanHealthWorkerMediumSkinTone = "👩🏽‍⚕️" ;

		public const string WomanHealthWorkerMediumSkinTone2 = "👩🏽‍⚕" ;

		public const string WomanHealthWorkerMediumDarkSkinTone = "👩🏾‍⚕️" ;

		public const string WomanHealthWorkerMediumDarkSkinTone2 = "👩🏾‍⚕" ;

		public const string WomanHealthWorkerDarkSkinTone = "👩🏿‍⚕️" ;

		public const string WomanHealthWorkerDarkSkinTone2 = "👩🏿‍⚕" ;

		public const string ManStudent = "👨‍🎓" ;

		public const string ManStudentLightSkinTone = "👨🏻‍🎓" ;

		public const string ManStudentMediumLightSkinTone = "👨🏼‍🎓" ;

		public const string ManStudentMediumSkinTone = "👨🏽‍🎓" ;

		public const string ManStudentMediumDarkSkinTone = "👨🏾‍🎓" ;

		public const string ManStudentDarkSkinTone = "👨🏿‍🎓" ;

		public const string WomanStudent = "👩‍🎓" ;

		public const string WomanStudentLightSkinTone = "👩🏻‍🎓" ;

		public const string WomanStudentMediumLightSkinTone = "👩🏼‍🎓" ;

		public const string WomanStudentMediumSkinTone = "👩🏽‍🎓" ;

		public const string WomanStudentMediumDarkSkinTone = "👩🏾‍🎓" ;

		public const string WomanStudentDarkSkinTone = "👩🏿‍🎓" ;

		public const string ManTeacher = "👨‍🏫" ;

		public const string ManTeacherLightSkinTone = "👨🏻‍🏫" ;

		public const string ManTeacherMediumLightSkinTone = "👨🏼‍🏫" ;

		public const string ManTeacherMediumSkinTone = "👨🏽‍🏫" ;

		public const string ManTeacherMediumDarkSkinTone = "👨🏾‍🏫" ;

		public const string ManTeacherDarkSkinTone = "👨🏿‍🏫" ;

		public const string WomanTeacher = "👩‍🏫" ;

		public const string WomanTeacherLightSkinTone = "👩🏻‍🏫" ;

		public const string WomanTeacherMediumLightSkinTone = "👩🏼‍🏫" ;

		public const string WomanTeacherMediumSkinTone = "👩🏽‍🏫" ;

		public const string WomanTeacherMediumDarkSkinTone = "👩🏾‍🏫" ;

		public const string WomanTeacherDarkSkinTone = "👩🏿‍🏫" ;

		public const string ManJudge = "👨‍⚖️" ;

		public const string ManJudge2 = "👨‍⚖" ;

		public const string ManJudgeLightSkinTone = "👨🏻‍⚖️" ;

		public const string ManJudgeLightSkinTone2 = "👨🏻‍⚖" ;

		public const string ManJudgeMediumLightSkinTone = "👨🏼‍⚖️" ;

		public const string ManJudgeMediumLightSkinTone2 = "👨🏼‍⚖" ;

		public const string ManJudgeMediumSkinTone = "👨🏽‍⚖️" ;

		public const string ManJudgeMediumSkinTone2 = "👨🏽‍⚖" ;

		public const string ManJudgeMediumDarkSkinTone = "👨🏾‍⚖️" ;

		public const string ManJudgeMediumDarkSkinTone2 = "👨🏾‍⚖" ;

		public const string ManJudgeDarkSkinTone = "👨🏿‍⚖️" ;

		public const string ManJudgeDarkSkinTone2 = "👨🏿‍⚖" ;

		public const string WomanJudge = "👩‍⚖️" ;

		public const string WomanJudge2 = "👩‍⚖" ;

		public const string WomanJudgeLightSkinTone = "👩🏻‍⚖️" ;

		public const string WomanJudgeLightSkinTone2 = "👩🏻‍⚖" ;

		public const string WomanJudgeMediumLightSkinTone = "👩🏼‍⚖️" ;

		public const string WomanJudgeMediumLightSkinTone2 = "👩🏼‍⚖" ;

		public const string WomanJudgeMediumSkinTone = "👩🏽‍⚖️" ;

		public const string WomanJudgeMediumSkinTone2 = "👩🏽‍⚖" ;

		public const string WomanJudgeMediumDarkSkinTone = "👩🏾‍⚖️" ;

		public const string WomanJudgeMediumDarkSkinTone2 = "👩🏾‍⚖" ;

		public const string WomanJudgeDarkSkinTone = "👩🏿‍⚖️" ;

		public const string WomanJudgeDarkSkinTone2 = "👩🏿‍⚖" ;

		public const string ManFarmer = "👨‍🌾" ;

		public const string ManFarmerLightSkinTone = "👨🏻‍🌾" ;

		public const string ManFarmerMediumLightSkinTone = "👨🏼‍🌾" ;

		public const string ManFarmerMediumSkinTone = "👨🏽‍🌾" ;

		public const string ManFarmerMediumDarkSkinTone = "👨🏾‍🌾" ;

		public const string ManFarmerDarkSkinTone = "👨🏿‍🌾" ;

		public const string WomanFarmer = "👩‍🌾" ;

		public const string WomanFarmerLightSkinTone = "👩🏻‍🌾" ;

		public const string WomanFarmerMediumLightSkinTone = "👩🏼‍🌾" ;

		public const string WomanFarmerMediumSkinTone = "👩🏽‍🌾" ;

		public const string WomanFarmerMediumDarkSkinTone = "👩🏾‍🌾" ;

		public const string WomanFarmerDarkSkinTone = "👩🏿‍🌾" ;

		public const string ManCook = "👨‍🍳" ;

		public const string ManCookLightSkinTone = "👨🏻‍🍳" ;

		public const string ManCookMediumLightSkinTone = "👨🏼‍🍳" ;

		public const string ManCookMediumSkinTone = "👨🏽‍🍳" ;

		public const string ManCookMediumDarkSkinTone = "👨🏾‍🍳" ;

		public const string ManCookDarkSkinTone = "👨🏿‍🍳" ;

		public const string WomanCook = "👩‍🍳" ;

		public const string WomanCookLightSkinTone = "👩🏻‍🍳" ;

		public const string WomanCookMediumLightSkinTone = "👩🏼‍🍳" ;

		public const string WomanCookMediumSkinTone = "👩🏽‍🍳" ;

		public const string WomanCookMediumDarkSkinTone = "👩🏾‍🍳" ;

		public const string WomanCookDarkSkinTone = "👩🏿‍🍳" ;

		public const string ManMechanic = "👨‍🔧" ;

		public const string ManMechanicLightSkinTone = "👨🏻‍🔧" ;

		public const string ManMechanicMediumLightSkinTone = "👨🏼‍🔧" ;

		public const string ManMechanicMediumSkinTone = "👨🏽‍🔧" ;

		public const string ManMechanicMediumDarkSkinTone = "👨🏾‍🔧" ;

		public const string ManMechanicDarkSkinTone = "👨🏿‍🔧" ;

		public const string WomanMechanic = "👩‍🔧" ;

		public const string WomanMechanicLightSkinTone = "👩🏻‍🔧" ;

		public const string WomanMechanicMediumLightSkinTone = "👩🏼‍🔧" ;

		public const string WomanMechanicMediumSkinTone = "👩🏽‍🔧" ;

		public const string WomanMechanicMediumDarkSkinTone = "👩🏾‍🔧" ;

		public const string WomanMechanicDarkSkinTone = "👩🏿‍🔧" ;

		public const string ManFactoryWorker = "👨‍🏭" ;

		public const string ManFactoryWorkerLightSkinTone = "👨🏻‍🏭" ;

		public const string ManFactoryWorkerMediumLightSkinTone = "👨🏼‍🏭" ;

		public const string ManFactoryWorkerMediumSkinTone = "👨🏽‍🏭" ;

		public const string ManFactoryWorkerMediumDarkSkinTone = "👨🏾‍🏭" ;

		public const string ManFactoryWorkerDarkSkinTone = "👨🏿‍🏭" ;

		public const string WomanFactoryWorker = "👩‍🏭" ;

		public const string WomanFactoryWorkerLightSkinTone = "👩🏻‍🏭" ;

		public const string WomanFactoryWorkerMediumLightSkinTone = "👩🏼‍🏭" ;

		public const string WomanFactoryWorkerMediumSkinTone = "👩🏽‍🏭" ;

		public const string WomanFactoryWorkerMediumDarkSkinTone = "👩🏾‍🏭" ;

		public const string WomanFactoryWorkerDarkSkinTone = "👩🏿‍🏭" ;

		public const string ManOfficeWorker = "👨‍💼" ;

		public const string ManOfficeWorkerLightSkinTone = "👨🏻‍💼" ;

		public const string ManOfficeWorkerMediumLightSkinTone = "👨🏼‍💼" ;

		public const string ManOfficeWorkerMediumSkinTone = "👨🏽‍💼" ;

		public const string ManOfficeWorkerMediumDarkSkinTone = "👨🏾‍💼" ;

		public const string ManOfficeWorkerDarkSkinTone = "👨🏿‍💼" ;

		public const string WomanOfficeWorker = "👩‍💼" ;

		public const string WomanOfficeWorkerLightSkinTone = "👩🏻‍💼" ;

		public const string WomanOfficeWorkerMediumLightSkinTone = "👩🏼‍💼" ;

		public const string WomanOfficeWorkerMediumSkinTone = "👩🏽‍💼" ;

		public const string WomanOfficeWorkerMediumDarkSkinTone = "👩🏾‍💼" ;

		public const string WomanOfficeWorkerDarkSkinTone = "👩🏿‍💼" ;

		public const string ManScientist = "👨‍🔬" ;

		public const string ManScientistLightSkinTone = "👨🏻‍🔬" ;

		public const string ManScientistMediumLightSkinTone = "👨🏼‍🔬" ;

		public const string ManScientistMediumSkinTone = "👨🏽‍🔬" ;

		public const string ManScientistMediumDarkSkinTone = "👨🏾‍🔬" ;

		public const string ManScientistDarkSkinTone = "👨🏿‍🔬" ;

		public const string WomanScientist = "👩‍🔬" ;

		public const string WomanScientistLightSkinTone = "👩🏻‍🔬" ;

		public const string WomanScientistMediumLightSkinTone = "👩🏼‍🔬" ;

		public const string WomanScientistMediumSkinTone = "👩🏽‍🔬" ;

		public const string WomanScientistMediumDarkSkinTone = "👩🏾‍🔬" ;

		public const string WomanScientistDarkSkinTone = "👩🏿‍🔬" ;

		public const string ManTechnologist = "👨‍💻" ;

		public const string ManTechnologistLightSkinTone = "👨🏻‍💻" ;

		public const string ManTechnologistMediumLightSkinTone = "👨🏼‍💻" ;

		public const string ManTechnologistMediumSkinTone = "👨🏽‍💻" ;

		public const string ManTechnologistMediumDarkSkinTone = "👨🏾‍💻" ;

		public const string ManTechnologistDarkSkinTone = "👨🏿‍💻" ;

		public const string WomanTechnologist = "👩‍💻" ;

		public const string WomanTechnologistLightSkinTone = "👩🏻‍💻" ;

		public const string WomanTechnologistMediumLightSkinTone = "👩🏼‍💻" ;

		public const string WomanTechnologistMediumSkinTone = "👩🏽‍💻" ;

		public const string WomanTechnologistMediumDarkSkinTone = "👩🏾‍💻" ;

		public const string WomanTechnologistDarkSkinTone = "👩🏿‍💻" ;

		public const string ManSinger = "👨‍🎤" ;

		public const string ManSingerLightSkinTone = "👨🏻‍🎤" ;

		public const string ManSingerMediumLightSkinTone = "👨🏼‍🎤" ;

		public const string ManSingerMediumSkinTone = "👨🏽‍🎤" ;

		public const string ManSingerMediumDarkSkinTone = "👨🏾‍🎤" ;

		public const string ManSingerDarkSkinTone = "👨🏿‍🎤" ;

		public const string WomanSinger = "👩‍🎤" ;

		public const string WomanSingerLightSkinTone = "👩🏻‍🎤" ;

		public const string WomanSingerMediumLightSkinTone = "👩🏼‍🎤" ;

		public const string WomanSingerMediumSkinTone = "👩🏽‍🎤" ;

		public const string WomanSingerMediumDarkSkinTone = "👩🏾‍🎤" ;

		public const string WomanSingerDarkSkinTone = "👩🏿‍🎤" ;

		public const string ManArtist = "👨‍🎨" ;

		public const string ManArtistLightSkinTone = "👨🏻‍🎨" ;

		public const string ManArtistMediumLightSkinTone = "👨🏼‍🎨" ;

		public const string ManArtistMediumSkinTone = "👨🏽‍🎨" ;

		public const string ManArtistMediumDarkSkinTone = "👨🏾‍🎨" ;

		public const string ManArtistDarkSkinTone = "👨🏿‍🎨" ;

		public const string WomanArtist = "👩‍🎨" ;

		public const string WomanArtistLightSkinTone = "👩🏻‍🎨" ;

		public const string WomanArtistMediumLightSkinTone = "👩🏼‍🎨" ;

		public const string WomanArtistMediumSkinTone = "👩🏽‍🎨" ;

		public const string WomanArtistMediumDarkSkinTone = "👩🏾‍🎨" ;

		public const string WomanArtistDarkSkinTone = "👩🏿‍🎨" ;

		public const string ManPilot = "👨‍✈️" ;

		public const string ManPilot2 = "👨‍✈" ;

		public const string ManPilotLightSkinTone = "👨🏻‍✈️" ;

		public const string ManPilotLightSkinTone2 = "👨🏻‍✈" ;

		public const string ManPilotMediumLightSkinTone = "👨🏼‍✈️" ;

		public const string ManPilotMediumLightSkinTone2 = "👨🏼‍✈" ;

		public const string ManPilotMediumSkinTone = "👨🏽‍✈️" ;

		public const string ManPilotMediumSkinTone2 = "👨🏽‍✈" ;

		public const string ManPilotMediumDarkSkinTone = "👨🏾‍✈️" ;

		public const string ManPilotMediumDarkSkinTone2 = "👨🏾‍✈" ;

		public const string ManPilotDarkSkinTone = "👨🏿‍✈️" ;

		public const string ManPilotDarkSkinTone2 = "👨🏿‍✈" ;

		public const string WomanPilot = "👩‍✈️" ;

		public const string WomanPilot2 = "👩‍✈" ;

		public const string WomanPilotLightSkinTone = "👩🏻‍✈️" ;

		public const string WomanPilotLightSkinTone2 = "👩🏻‍✈" ;

		public const string WomanPilotMediumLightSkinTone = "👩🏼‍✈️" ;

		public const string WomanPilotMediumLightSkinTone2 = "👩🏼‍✈" ;

		public const string WomanPilotMediumSkinTone = "👩🏽‍✈️" ;

		public const string WomanPilotMediumSkinTone2 = "👩🏽‍✈" ;

		public const string WomanPilotMediumDarkSkinTone = "👩🏾‍✈️" ;

		public const string WomanPilotMediumDarkSkinTone2 = "👩🏾‍✈" ;

		public const string WomanPilotDarkSkinTone = "👩🏿‍✈️" ;

		public const string WomanPilotDarkSkinTone2 = "👩🏿‍✈" ;

		public const string ManAstronaut = "👨‍🚀" ;

		public const string ManAstronautLightSkinTone = "👨🏻‍🚀" ;

		public const string ManAstronautMediumLightSkinTone = "👨🏼‍🚀" ;

		public const string ManAstronautMediumSkinTone = "👨🏽‍🚀" ;

		public const string ManAstronautMediumDarkSkinTone = "👨🏾‍🚀" ;

		public const string ManAstronautDarkSkinTone = "👨🏿‍🚀" ;

		public const string WomanAstronaut = "👩‍🚀" ;

		public const string WomanAstronautLightSkinTone = "👩🏻‍🚀" ;

		public const string WomanAstronautMediumLightSkinTone = "👩🏼‍🚀" ;

		public const string WomanAstronautMediumSkinTone = "👩🏽‍🚀" ;

		public const string WomanAstronautMediumDarkSkinTone = "👩🏾‍🚀" ;

		public const string WomanAstronautDarkSkinTone = "👩🏿‍🚀" ;

		public const string ManFirefighter = "👨‍🚒" ;

		public const string ManFirefighterLightSkinTone = "👨🏻‍🚒" ;

		public const string ManFirefighterMediumLightSkinTone = "👨🏼‍🚒" ;

		public const string ManFirefighterMediumSkinTone = "👨🏽‍🚒" ;

		public const string ManFirefighterMediumDarkSkinTone = "👨🏾‍🚒" ;

		public const string ManFirefighterDarkSkinTone = "👨🏿‍🚒" ;

		public const string WomanFirefighter = "👩‍🚒" ;

		public const string WomanFirefighterLightSkinTone = "👩🏻‍🚒" ;

		public const string WomanFirefighterMediumLightSkinTone = "👩🏼‍🚒" ;

		public const string WomanFirefighterMediumSkinTone = "👩🏽‍🚒" ;

		public const string WomanFirefighterMediumDarkSkinTone = "👩🏾‍🚒" ;

		public const string WomanFirefighterDarkSkinTone = "👩🏿‍🚒" ;

		public const string PoliceOfficer = "👮" ;

		public const string PoliceOfficerLightSkinTone = "👮🏻" ;

		public const string PoliceOfficerMediumLightSkinTone = "👮🏼" ;

		public const string PoliceOfficerMediumSkinTone = "👮🏽" ;

		public const string PoliceOfficerMediumDarkSkinTone = "👮🏾" ;

		public const string PoliceOfficerDarkSkinTone = "👮🏿" ;

		public const string ManPoliceOfficer = "👮‍♂️" ;

		public const string ManPoliceOfficer2 = "👮‍♂" ;

		public const string ManPoliceOfficerLightSkinTone = "👮🏻‍♂️" ;

		public const string ManPoliceOfficerLightSkinTone2 = "👮🏻‍♂" ;

		public const string ManPoliceOfficerMediumLightSkinTone = "👮🏼‍♂️" ;

		public const string ManPoliceOfficerMediumLightSkinTone2 = "👮🏼‍♂" ;

		public const string ManPoliceOfficerMediumSkinTone = "👮🏽‍♂️" ;

		public const string ManPoliceOfficerMediumSkinTone2 = "👮🏽‍♂" ;

		public const string ManPoliceOfficerMediumDarkSkinTone = "👮🏾‍♂️" ;

		public const string ManPoliceOfficerMediumDarkSkinTone2 = "👮🏾‍♂" ;

		public const string ManPoliceOfficerDarkSkinTone = "👮🏿‍♂️" ;

		public const string ManPoliceOfficerDarkSkinTone2 = "👮🏿‍♂" ;

		public const string WomanPoliceOfficer = "👮‍♀️" ;

		public const string WomanPoliceOfficer2 = "👮‍♀" ;

		public const string WomanPoliceOfficerLightSkinTone = "👮🏻‍♀️" ;

		public const string WomanPoliceOfficerLightSkinTone2 = "👮🏻‍♀" ;

		public const string WomanPoliceOfficerMediumLightSkinTone = "👮🏼‍♀️" ;

		public const string WomanPoliceOfficerMediumLightSkinTone2 = "👮🏼‍♀" ;

		public const string WomanPoliceOfficerMediumSkinTone = "👮🏽‍♀️" ;

		public const string WomanPoliceOfficerMediumSkinTone2 = "👮🏽‍♀" ;

		public const string WomanPoliceOfficerMediumDarkSkinTone = "👮🏾‍♀️" ;

		public const string WomanPoliceOfficerMediumDarkSkinTone2 = "👮🏾‍♀" ;

		public const string WomanPoliceOfficerDarkSkinTone = "👮🏿‍♀️" ;

		public const string WomanPoliceOfficerDarkSkinTone2 = "👮🏿‍♀" ;

		public const string Detective = "🕵️" ;

		public const string Detective2 = "🕵" ;

		public const string DetectiveLightSkinTone = "🕵🏻" ;

		public const string DetectiveMediumLightSkinTone = "🕵🏼" ;

		public const string DetectiveMediumSkinTone = "🕵🏽" ;

		public const string DetectiveMediumDarkSkinTone = "🕵🏾" ;

		public const string DetectiveDarkSkinTone = "🕵🏿" ;

		public const string ManDetective = "🕵️‍♂️" ;

		public const string ManDetective2 = "🕵‍♂️" ;

		public const string ManDetective3 = "🕵️‍♂" ;

		public const string ManDetective4 = "🕵‍♂" ;

		public const string ManDetectiveLightSkinTone = "🕵🏻‍♂️" ;

		public const string ManDetectiveLightSkinTone2 = "🕵🏻‍♂" ;

		public const string ManDetectiveMediumLightSkinTone = "🕵🏼‍♂️" ;

		public const string ManDetectiveMediumLightSkinTone2 = "🕵🏼‍♂" ;

		public const string ManDetectiveMediumSkinTone = "🕵🏽‍♂️" ;

		public const string ManDetectiveMediumSkinTone2 = "🕵🏽‍♂" ;

		public const string ManDetectiveMediumDarkSkinTone = "🕵🏾‍♂️" ;

		public const string ManDetectiveMediumDarkSkinTone2 = "🕵🏾‍♂" ;

		public const string ManDetectiveDarkSkinTone = "🕵🏿‍♂️" ;

		public const string ManDetectiveDarkSkinTone2 = "🕵🏿‍♂" ;

		public const string WomanDetective = "🕵️‍♀️" ;

		public const string WomanDetective2 = "🕵‍♀️" ;

		public const string WomanDetective3 = "🕵️‍♀" ;

		public const string WomanDetective4 = "🕵‍♀" ;

		public const string WomanDetectiveLightSkinTone = "🕵🏻‍♀️" ;

		public const string WomanDetectiveLightSkinTone2 = "🕵🏻‍♀" ;

		public const string WomanDetectiveMediumLightSkinTone = "🕵🏼‍♀️" ;

		public const string WomanDetectiveMediumLightSkinTone2 = "🕵🏼‍♀" ;

		public const string WomanDetectiveMediumSkinTone = "🕵🏽‍♀️" ;

		public const string WomanDetectiveMediumSkinTone2 = "🕵🏽‍♀" ;

		public const string WomanDetectiveMediumDarkSkinTone = "🕵🏾‍♀️" ;

		public const string WomanDetectiveMediumDarkSkinTone2 = "🕵🏾‍♀" ;

		public const string WomanDetectiveDarkSkinTone = "🕵🏿‍♀️" ;

		public const string WomanDetectiveDarkSkinTone2 = "🕵🏿‍♀" ;

		public const string Guard = "💂" ;

		public const string GuardLightSkinTone = "💂🏻" ;

		public const string GuardMediumLightSkinTone = "💂🏼" ;

		public const string GuardMediumSkinTone = "💂🏽" ;

		public const string GuardMediumDarkSkinTone = "💂🏾" ;

		public const string GuardDarkSkinTone = "💂🏿" ;

		public const string ManGuard = "💂‍♂️" ;

		public const string ManGuard2 = "💂‍♂" ;

		public const string ManGuardLightSkinTone = "💂🏻‍♂️" ;

		public const string ManGuardLightSkinTone2 = "💂🏻‍♂" ;

		public const string ManGuardMediumLightSkinTone = "💂🏼‍♂️" ;

		public const string ManGuardMediumLightSkinTone2 = "💂🏼‍♂" ;

		public const string ManGuardMediumSkinTone = "💂🏽‍♂️" ;

		public const string ManGuardMediumSkinTone2 = "💂🏽‍♂" ;

		public const string ManGuardMediumDarkSkinTone = "💂🏾‍♂️" ;

		public const string ManGuardMediumDarkSkinTone2 = "💂🏾‍♂" ;

		public const string ManGuardDarkSkinTone = "💂🏿‍♂️" ;

		public const string ManGuardDarkSkinTone2 = "💂🏿‍♂" ;

		public const string WomanGuard = "💂‍♀️" ;

		public const string WomanGuard2 = "💂‍♀" ;

		public const string WomanGuardLightSkinTone = "💂🏻‍♀️" ;

		public const string WomanGuardLightSkinTone2 = "💂🏻‍♀" ;

		public const string WomanGuardMediumLightSkinTone = "💂🏼‍♀️" ;

		public const string WomanGuardMediumLightSkinTone2 = "💂🏼‍♀" ;

		public const string WomanGuardMediumSkinTone = "💂🏽‍♀️" ;

		public const string WomanGuardMediumSkinTone2 = "💂🏽‍♀" ;

		public const string WomanGuardMediumDarkSkinTone = "💂🏾‍♀️" ;

		public const string WomanGuardMediumDarkSkinTone2 = "💂🏾‍♀" ;

		public const string WomanGuardDarkSkinTone = "💂🏿‍♀️" ;

		public const string WomanGuardDarkSkinTone2 = "💂🏿‍♀" ;

		public const string ConstructionWorker = "👷" ;

		public const string ConstructionWorkerLightSkinTone = "👷🏻" ;

		public const string ConstructionWorkerMediumLightSkinTone = "👷🏼" ;

		public const string ConstructionWorkerMediumSkinTone = "👷🏽" ;

		public const string ConstructionWorkerMediumDarkSkinTone = "👷🏾" ;

		public const string ConstructionWorkerDarkSkinTone = "👷🏿" ;

		public const string ManConstructionWorker = "👷‍♂️" ;

		public const string ManConstructionWorker2 = "👷‍♂" ;

		public const string ManConstructionWorkerLightSkinTone = "👷🏻‍♂️" ;

		public const string ManConstructionWorkerLightSkinTone2 = "👷🏻‍♂" ;

		public const string ManConstructionWorkerMediumLightSkinTone = "👷🏼‍♂️" ;

		public const string ManConstructionWorkerMediumLightSkinTone2 = "👷🏼‍♂" ;

		public const string ManConstructionWorkerMediumSkinTone = "👷🏽‍♂️" ;

		public const string ManConstructionWorkerMediumSkinTone2 = "👷🏽‍♂" ;

		public const string ManConstructionWorkerMediumDarkSkinTone = "👷🏾‍♂️" ;

		public const string ManConstructionWorkerMediumDarkSkinTone2 = "👷🏾‍♂" ;

		public const string ManConstructionWorkerDarkSkinTone = "👷🏿‍♂️" ;

		public const string ManConstructionWorkerDarkSkinTone2 = "👷🏿‍♂" ;

		public const string WomanConstructionWorker = "👷‍♀️" ;

		public const string WomanConstructionWorker2 = "👷‍♀" ;

		public const string WomanConstructionWorkerLightSkinTone = "👷🏻‍♀️" ;

		public const string WomanConstructionWorkerLightSkinTone2 = "👷🏻‍♀" ;

		public const string WomanConstructionWorkerMediumLightSkinTone = "👷🏼‍♀️" ;

		public const string WomanConstructionWorkerMediumLightSkinTone2 = "👷🏼‍♀" ;

		public const string WomanConstructionWorkerMediumSkinTone = "👷🏽‍♀️" ;

		public const string WomanConstructionWorkerMediumSkinTone2 = "👷🏽‍♀" ;

		public const string WomanConstructionWorkerMediumDarkSkinTone = "👷🏾‍♀️" ;

		public const string WomanConstructionWorkerMediumDarkSkinTone2 = "👷🏾‍♀" ;

		public const string WomanConstructionWorkerDarkSkinTone = "👷🏿‍♀️" ;

		public const string WomanConstructionWorkerDarkSkinTone2 = "👷🏿‍♀" ;

		public const string Prince = "🤴" ;

		public const string PrinceLightSkinTone = "🤴🏻" ;

		public const string PrinceMediumLightSkinTone = "🤴🏼" ;

		public const string PrinceMediumSkinTone = "🤴🏽" ;

		public const string PrinceMediumDarkSkinTone = "🤴🏾" ;

		public const string PrinceDarkSkinTone = "🤴🏿" ;

		public const string Princess = "👸" ;

		public const string PrincessLightSkinTone = "👸🏻" ;

		public const string PrincessMediumLightSkinTone = "👸🏼" ;

		public const string PrincessMediumSkinTone = "👸🏽" ;

		public const string PrincessMediumDarkSkinTone = "👸🏾" ;

		public const string PrincessDarkSkinTone = "👸🏿" ;

		public const string PersonWearingTurban = "👳" ;

		public const string PersonWearingTurbanLightSkinTone = "👳🏻" ;

		public const string PersonWearingTurbanMediumLightSkinTone = "👳🏼" ;

		public const string PersonWearingTurbanMediumSkinTone = "👳🏽" ;

		public const string PersonWearingTurbanMediumDarkSkinTone = "👳🏾" ;

		public const string PersonWearingTurbanDarkSkinTone = "👳🏿" ;

		public const string ManWearingTurban = "👳‍♂️" ;

		public const string ManWearingTurban2 = "👳‍♂" ;

		public const string ManWearingTurbanLightSkinTone = "👳🏻‍♂️" ;

		public const string ManWearingTurbanLightSkinTone2 = "👳🏻‍♂" ;

		public const string ManWearingTurbanMediumLightSkinTone = "👳🏼‍♂️" ;

		public const string ManWearingTurbanMediumLightSkinTone2 = "👳🏼‍♂" ;

		public const string ManWearingTurbanMediumSkinTone = "👳🏽‍♂️" ;

		public const string ManWearingTurbanMediumSkinTone2 = "👳🏽‍♂" ;

		public const string ManWearingTurbanMediumDarkSkinTone = "👳🏾‍♂️" ;

		public const string ManWearingTurbanMediumDarkSkinTone2 = "👳🏾‍♂" ;

		public const string ManWearingTurbanDarkSkinTone = "👳🏿‍♂️" ;

		public const string ManWearingTurbanDarkSkinTone2 = "👳🏿‍♂" ;

		public const string WomanWearingTurban = "👳‍♀️" ;

		public const string WomanWearingTurban2 = "👳‍♀" ;

		public const string WomanWearingTurbanLightSkinTone = "👳🏻‍♀️" ;

		public const string WomanWearingTurbanLightSkinTone2 = "👳🏻‍♀" ;

		public const string WomanWearingTurbanMediumLightSkinTone = "👳🏼‍♀️" ;

		public const string WomanWearingTurbanMediumLightSkinTone2 = "👳🏼‍♀" ;

		public const string WomanWearingTurbanMediumSkinTone = "👳🏽‍♀️" ;

		public const string WomanWearingTurbanMediumSkinTone2 = "👳🏽‍♀" ;

		public const string WomanWearingTurbanMediumDarkSkinTone = "👳🏾‍♀️" ;

		public const string WomanWearingTurbanMediumDarkSkinTone2 = "👳🏾‍♀" ;

		public const string WomanWearingTurbanDarkSkinTone = "👳🏿‍♀️" ;

		public const string WomanWearingTurbanDarkSkinTone2 = "👳🏿‍♀" ;

		public const string ManWithChineseCap = "👲" ;

		public const string ManWithChineseCapLightSkinTone = "👲🏻" ;

		public const string ManWithChineseCapMediumLightSkinTone = "👲🏼" ;

		public const string ManWithChineseCapMediumSkinTone = "👲🏽" ;

		public const string ManWithChineseCapMediumDarkSkinTone = "👲🏾" ;

		public const string ManWithChineseCapDarkSkinTone = "👲🏿" ;

		public const string WomanWithHeadscarf = "🧕" ;

		public const string WomanWithHeadscarfLightSkinTone = "🧕🏻" ;

		public const string WomanWithHeadscarfMediumLightSkinTone = "🧕🏼" ;

		public const string WomanWithHeadscarfMediumSkinTone = "🧕🏽" ;

		public const string WomanWithHeadscarfMediumDarkSkinTone = "🧕🏾" ;

		public const string WomanWithHeadscarfDarkSkinTone = "🧕🏿" ;

		public const string ManInTuxedo = "🤵" ;

		public const string ManInTuxedoLightSkinTone = "🤵🏻" ;

		public const string ManInTuxedoMediumLightSkinTone = "🤵🏼" ;

		public const string ManInTuxedoMediumSkinTone = "🤵🏽" ;

		public const string ManInTuxedoMediumDarkSkinTone = "🤵🏾" ;

		public const string ManInTuxedoDarkSkinTone = "🤵🏿" ;

		public const string BrideWithVeil = "👰" ;

		public const string BrideWithVeilLightSkinTone = "👰🏻" ;

		public const string BrideWithVeilMediumLightSkinTone = "👰🏼" ;

		public const string BrideWithVeilMediumSkinTone = "👰🏽" ;

		public const string BrideWithVeilMediumDarkSkinTone = "👰🏾" ;

		public const string BrideWithVeilDarkSkinTone = "👰🏿" ;

		public const string PregnantWoman = "🤰" ;

		public const string PregnantWomanLightSkinTone = "🤰🏻" ;

		public const string PregnantWomanMediumLightSkinTone = "🤰🏼" ;

		public const string PregnantWomanMediumSkinTone = "🤰🏽" ;

		public const string PregnantWomanMediumDarkSkinTone = "🤰🏾" ;

		public const string PregnantWomanDarkSkinTone = "🤰🏿" ;

		public const string BreastFeeding = "🤱" ;

		public const string BreastFeedingLightSkinTone = "🤱🏻" ;

		public const string BreastFeedingMediumLightSkinTone = "🤱🏼" ;

		public const string BreastFeedingMediumSkinTone = "🤱🏽" ;

		public const string BreastFeedingMediumDarkSkinTone = "🤱🏾" ;

		public const string BreastFeedingDarkSkinTone = "🤱🏿" ;

		public const string BabyAngel = "👼" ;

		public const string BabyAngelLightSkinTone = "👼🏻" ;

		public const string BabyAngelMediumLightSkinTone = "👼🏼" ;

		public const string BabyAngelMediumSkinTone = "👼🏽" ;

		public const string BabyAngelMediumDarkSkinTone = "👼🏾" ;

		public const string BabyAngelDarkSkinTone = "👼🏿" ;

		public const string SantaClaus = "🎅" ;

		public const string SantaClausLightSkinTone = "🎅🏻" ;

		public const string SantaClausMediumLightSkinTone = "🎅🏼" ;

		public const string SantaClausMediumSkinTone = "🎅🏽" ;

		public const string SantaClausMediumDarkSkinTone = "🎅🏾" ;

		public const string SantaClausDarkSkinTone = "🎅🏿" ;

		public const string MrsClaus = "🤶" ;

		public const string MrsClausLightSkinTone = "🤶🏻" ;

		public const string MrsClausMediumLightSkinTone = "🤶🏼" ;

		public const string MrsClausMediumSkinTone = "🤶🏽" ;

		public const string MrsClausMediumDarkSkinTone = "🤶🏾" ;

		public const string MrsClausDarkSkinTone = "🤶🏿" ;

		public const string Superhero = "🦸" ;

		public const string SuperheroLightSkinTone = "🦸🏻" ;

		public const string SuperheroMediumLightSkinTone = "🦸🏼" ;

		public const string SuperheroMediumSkinTone = "🦸🏽" ;

		public const string SuperheroMediumDarkSkinTone = "🦸🏾" ;

		public const string SuperheroDarkSkinTone = "🦸🏿" ;

		public const string ManSuperhero = "🦸‍♂️" ;

		public const string ManSuperhero2 = "🦸‍♂" ;

		public const string ManSuperheroLightSkinTone = "🦸🏻‍♂️" ;

		public const string ManSuperheroLightSkinTone2 = "🦸🏻‍♂" ;

		public const string ManSuperheroMediumLightSkinTone = "🦸🏼‍♂️" ;

		public const string ManSuperheroMediumLightSkinTone2 = "🦸🏼‍♂" ;

		public const string ManSuperheroMediumSkinTone = "🦸🏽‍♂️" ;

		public const string ManSuperheroMediumSkinTone2 = "🦸🏽‍♂" ;

		public const string ManSuperheroMediumDarkSkinTone = "🦸🏾‍♂️" ;

		public const string ManSuperheroMediumDarkSkinTone2 = "🦸🏾‍♂" ;

		public const string ManSuperheroDarkSkinTone = "🦸🏿‍♂️" ;

		public const string ManSuperheroDarkSkinTone2 = "🦸🏿‍♂" ;

		public const string WomanSuperhero = "🦸‍♀️" ;

		public const string WomanSuperhero2 = "🦸‍♀" ;

		public const string WomanSuperheroLightSkinTone = "🦸🏻‍♀️" ;

		public const string WomanSuperheroLightSkinTone2 = "🦸🏻‍♀" ;

		public const string WomanSuperheroMediumLightSkinTone = "🦸🏼‍♀️" ;

		public const string WomanSuperheroMediumLightSkinTone2 = "🦸🏼‍♀" ;

		public const string WomanSuperheroMediumSkinTone = "🦸🏽‍♀️" ;

		public const string WomanSuperheroMediumSkinTone2 = "🦸🏽‍♀" ;

		public const string WomanSuperheroMediumDarkSkinTone = "🦸🏾‍♀️" ;

		public const string WomanSuperheroMediumDarkSkinTone2 = "🦸🏾‍♀" ;

		public const string WomanSuperheroDarkSkinTone = "🦸🏿‍♀️" ;

		public const string WomanSuperheroDarkSkinTone2 = "🦸🏿‍♀" ;

		public const string Supervillain = "🦹" ;

		public const string SupervillainLightSkinTone = "🦹🏻" ;

		public const string SupervillainMediumLightSkinTone = "🦹🏼" ;

		public const string SupervillainMediumSkinTone = "🦹🏽" ;

		public const string SupervillainMediumDarkSkinTone = "🦹🏾" ;

		public const string SupervillainDarkSkinTone = "🦹🏿" ;

		public const string ManSupervillain = "🦹‍♂️" ;

		public const string ManSupervillain2 = "🦹‍♂" ;

		public const string ManSupervillainLightSkinTone = "🦹🏻‍♂️" ;

		public const string ManSupervillainLightSkinTone2 = "🦹🏻‍♂" ;

		public const string ManSupervillainMediumLightSkinTone = "🦹🏼‍♂️" ;

		public const string ManSupervillainMediumLightSkinTone2 = "🦹🏼‍♂" ;

		public const string ManSupervillainMediumSkinTone = "🦹🏽‍♂️" ;

		public const string ManSupervillainMediumSkinTone2 = "🦹🏽‍♂" ;

		public const string ManSupervillainMediumDarkSkinTone = "🦹🏾‍♂️" ;

		public const string ManSupervillainMediumDarkSkinTone2 = "🦹🏾‍♂" ;

		public const string ManSupervillainDarkSkinTone = "🦹🏿‍♂️" ;

		public const string ManSupervillainDarkSkinTone2 = "🦹🏿‍♂" ;

		public const string WomanSupervillain = "🦹‍♀️" ;

		public const string WomanSupervillain2 = "🦹‍♀" ;

		public const string WomanSupervillainLightSkinTone = "🦹🏻‍♀️" ;

		public const string WomanSupervillainLightSkinTone2 = "🦹🏻‍♀" ;

		public const string WomanSupervillainMediumLightSkinTone = "🦹🏼‍♀️" ;

		public const string WomanSupervillainMediumLightSkinTone2 = "🦹🏼‍♀" ;

		public const string WomanSupervillainMediumSkinTone = "🦹🏽‍♀️" ;

		public const string WomanSupervillainMediumSkinTone2 = "🦹🏽‍♀" ;

		public const string WomanSupervillainMediumDarkSkinTone = "🦹🏾‍♀️" ;

		public const string WomanSupervillainMediumDarkSkinTone2 = "🦹🏾‍♀" ;

		public const string WomanSupervillainDarkSkinTone = "🦹🏿‍♀️" ;

		public const string WomanSupervillainDarkSkinTone2 = "🦹🏿‍♀" ;

		public const string Mage = "🧙" ;

		public const string MageLightSkinTone = "🧙🏻" ;

		public const string MageMediumLightSkinTone = "🧙🏼" ;

		public const string MageMediumSkinTone = "🧙🏽" ;

		public const string MageMediumDarkSkinTone = "🧙🏾" ;

		public const string MageDarkSkinTone = "🧙🏿" ;

		public const string ManMage = "🧙‍♂️" ;

		public const string ManMage2 = "🧙‍♂" ;

		public const string ManMageLightSkinTone = "🧙🏻‍♂️" ;

		public const string ManMageLightSkinTone2 = "🧙🏻‍♂" ;

		public const string ManMageMediumLightSkinTone = "🧙🏼‍♂️" ;

		public const string ManMageMediumLightSkinTone2 = "🧙🏼‍♂" ;

		public const string ManMageMediumSkinTone = "🧙🏽‍♂️" ;

		public const string ManMageMediumSkinTone2 = "🧙🏽‍♂" ;

		public const string ManMageMediumDarkSkinTone = "🧙🏾‍♂️" ;

		public const string ManMageMediumDarkSkinTone2 = "🧙🏾‍♂" ;

		public const string ManMageDarkSkinTone = "🧙🏿‍♂️" ;

		public const string ManMageDarkSkinTone2 = "🧙🏿‍♂" ;

		public const string WomanMage = "🧙‍♀️" ;

		public const string WomanMage2 = "🧙‍♀" ;

		public const string WomanMageLightSkinTone = "🧙🏻‍♀️" ;

		public const string WomanMageLightSkinTone2 = "🧙🏻‍♀" ;

		public const string WomanMageMediumLightSkinTone = "🧙🏼‍♀️" ;

		public const string WomanMageMediumLightSkinTone2 = "🧙🏼‍♀" ;

		public const string WomanMageMediumSkinTone = "🧙🏽‍♀️" ;

		public const string WomanMageMediumSkinTone2 = "🧙🏽‍♀" ;

		public const string WomanMageMediumDarkSkinTone = "🧙🏾‍♀️" ;

		public const string WomanMageMediumDarkSkinTone2 = "🧙🏾‍♀" ;

		public const string WomanMageDarkSkinTone = "🧙🏿‍♀️" ;

		public const string WomanMageDarkSkinTone2 = "🧙🏿‍♀" ;

		public const string Fairy = "🧚" ;

		public const string FairyLightSkinTone = "🧚🏻" ;

		public const string FairyMediumLightSkinTone = "🧚🏼" ;

		public const string FairyMediumSkinTone = "🧚🏽" ;

		public const string FairyMediumDarkSkinTone = "🧚🏾" ;

		public const string FairyDarkSkinTone = "🧚🏿" ;

		public const string ManFairy = "🧚‍♂️" ;

		public const string ManFairy2 = "🧚‍♂" ;

		public const string ManFairyLightSkinTone = "🧚🏻‍♂️" ;

		public const string ManFairyLightSkinTone2 = "🧚🏻‍♂" ;

		public const string ManFairyMediumLightSkinTone = "🧚🏼‍♂️" ;

		public const string ManFairyMediumLightSkinTone2 = "🧚🏼‍♂" ;

		public const string ManFairyMediumSkinTone = "🧚🏽‍♂️" ;

		public const string ManFairyMediumSkinTone2 = "🧚🏽‍♂" ;

		public const string ManFairyMediumDarkSkinTone = "🧚🏾‍♂️" ;

		public const string ManFairyMediumDarkSkinTone2 = "🧚🏾‍♂" ;

		public const string ManFairyDarkSkinTone = "🧚🏿‍♂️" ;

		public const string ManFairyDarkSkinTone2 = "🧚🏿‍♂" ;

		public const string WomanFairy = "🧚‍♀️" ;

		public const string WomanFairy2 = "🧚‍♀" ;

		public const string WomanFairyLightSkinTone = "🧚🏻‍♀️" ;

		public const string WomanFairyLightSkinTone2 = "🧚🏻‍♀" ;

		public const string WomanFairyMediumLightSkinTone = "🧚🏼‍♀️" ;

		public const string WomanFairyMediumLightSkinTone2 = "🧚🏼‍♀" ;

		public const string WomanFairyMediumSkinTone = "🧚🏽‍♀️" ;

		public const string WomanFairyMediumSkinTone2 = "🧚🏽‍♀" ;

		public const string WomanFairyMediumDarkSkinTone = "🧚🏾‍♀️" ;

		public const string WomanFairyMediumDarkSkinTone2 = "🧚🏾‍♀" ;

		public const string WomanFairyDarkSkinTone = "🧚🏿‍♀️" ;

		public const string WomanFairyDarkSkinTone2 = "🧚🏿‍♀" ;

		public const string Vampire = "🧛" ;

		public const string VampireLightSkinTone = "🧛🏻" ;

		public const string VampireMediumLightSkinTone = "🧛🏼" ;

		public const string VampireMediumSkinTone = "🧛🏽" ;

		public const string VampireMediumDarkSkinTone = "🧛🏾" ;

		public const string VampireDarkSkinTone = "🧛🏿" ;

		public const string ManVampire = "🧛‍♂️" ;

		public const string ManVampire2 = "🧛‍♂" ;

		public const string ManVampireLightSkinTone = "🧛🏻‍♂️" ;

		public const string ManVampireLightSkinTone2 = "🧛🏻‍♂" ;

		public const string ManVampireMediumLightSkinTone = "🧛🏼‍♂️" ;

		public const string ManVampireMediumLightSkinTone2 = "🧛🏼‍♂" ;

		public const string ManVampireMediumSkinTone = "🧛🏽‍♂️" ;

		public const string ManVampireMediumSkinTone2 = "🧛🏽‍♂" ;

		public const string ManVampireMediumDarkSkinTone = "🧛🏾‍♂️" ;

		public const string ManVampireMediumDarkSkinTone2 = "🧛🏾‍♂" ;

		public const string ManVampireDarkSkinTone = "🧛🏿‍♂️" ;

		public const string ManVampireDarkSkinTone2 = "🧛🏿‍♂" ;

		public const string WomanVampire = "🧛‍♀️" ;

		public const string WomanVampire2 = "🧛‍♀" ;

		public const string WomanVampireLightSkinTone = "🧛🏻‍♀️" ;

		public const string WomanVampireLightSkinTone2 = "🧛🏻‍♀" ;

		public const string WomanVampireMediumLightSkinTone = "🧛🏼‍♀️" ;

		public const string WomanVampireMediumLightSkinTone2 = "🧛🏼‍♀" ;

		public const string WomanVampireMediumSkinTone = "🧛🏽‍♀️" ;

		public const string WomanVampireMediumSkinTone2 = "🧛🏽‍♀" ;

		public const string WomanVampireMediumDarkSkinTone = "🧛🏾‍♀️" ;

		public const string WomanVampireMediumDarkSkinTone2 = "🧛🏾‍♀" ;

		public const string WomanVampireDarkSkinTone = "🧛🏿‍♀️" ;

		public const string WomanVampireDarkSkinTone2 = "🧛🏿‍♀" ;

		public const string Merperson = "🧜" ;

		public const string MerpersonLightSkinTone = "🧜🏻" ;

		public const string MerpersonMediumLightSkinTone = "🧜🏼" ;

		public const string MerpersonMediumSkinTone = "🧜🏽" ;

		public const string MerpersonMediumDarkSkinTone = "🧜🏾" ;

		public const string MerpersonDarkSkinTone = "🧜🏿" ;

		public const string Merman = "🧜‍♂️" ;

		public const string Merman2 = "🧜‍♂" ;

		public const string MermanLightSkinTone = "🧜🏻‍♂️" ;

		public const string MermanLightSkinTone2 = "🧜🏻‍♂" ;

		public const string MermanMediumLightSkinTone = "🧜🏼‍♂️" ;

		public const string MermanMediumLightSkinTone2 = "🧜🏼‍♂" ;

		public const string MermanMediumSkinTone = "🧜🏽‍♂️" ;

		public const string MermanMediumSkinTone2 = "🧜🏽‍♂" ;

		public const string MermanMediumDarkSkinTone = "🧜🏾‍♂️" ;

		public const string MermanMediumDarkSkinTone2 = "🧜🏾‍♂" ;

		public const string MermanDarkSkinTone = "🧜🏿‍♂️" ;

		public const string MermanDarkSkinTone2 = "🧜🏿‍♂" ;

		public const string Mermaid = "🧜‍♀️" ;

		public const string Mermaid2 = "🧜‍♀" ;

		public const string MermaidLightSkinTone = "🧜🏻‍♀️" ;

		public const string MermaidLightSkinTone2 = "🧜🏻‍♀" ;

		public const string MermaidMediumLightSkinTone = "🧜🏼‍♀️" ;

		public const string MermaidMediumLightSkinTone2 = "🧜🏼‍♀" ;

		public const string MermaidMediumSkinTone = "🧜🏽‍♀️" ;

		public const string MermaidMediumSkinTone2 = "🧜🏽‍♀" ;

		public const string MermaidMediumDarkSkinTone = "🧜🏾‍♀️" ;

		public const string MermaidMediumDarkSkinTone2 = "🧜🏾‍♀" ;

		public const string MermaidDarkSkinTone = "🧜🏿‍♀️" ;

		public const string MermaidDarkSkinTone2 = "🧜🏿‍♀" ;

		public const string Elf = "🧝" ;

		public const string ElfLightSkinTone = "🧝🏻" ;

		public const string ElfMediumLightSkinTone = "🧝🏼" ;

		public const string ElfMediumSkinTone = "🧝🏽" ;

		public const string ElfMediumDarkSkinTone = "🧝🏾" ;

		public const string ElfDarkSkinTone = "🧝🏿" ;

		public const string ManElf = "🧝‍♂️" ;

		public const string ManElf2 = "🧝‍♂" ;

		public const string ManElfLightSkinTone = "🧝🏻‍♂️" ;

		public const string ManElfLightSkinTone2 = "🧝🏻‍♂" ;

		public const string ManElfMediumLightSkinTone = "🧝🏼‍♂️" ;

		public const string ManElfMediumLightSkinTone2 = "🧝🏼‍♂" ;

		public const string ManElfMediumSkinTone = "🧝🏽‍♂️" ;

		public const string ManElfMediumSkinTone2 = "🧝🏽‍♂" ;

		public const string ManElfMediumDarkSkinTone = "🧝🏾‍♂️" ;

		public const string ManElfMediumDarkSkinTone2 = "🧝🏾‍♂" ;

		public const string ManElfDarkSkinTone = "🧝🏿‍♂️" ;

		public const string ManElfDarkSkinTone2 = "🧝🏿‍♂" ;

		public const string WomanElf = "🧝‍♀️" ;

		public const string WomanElf2 = "🧝‍♀" ;

		public const string WomanElfLightSkinTone = "🧝🏻‍♀️" ;

		public const string WomanElfLightSkinTone2 = "🧝🏻‍♀" ;

		public const string WomanElfMediumLightSkinTone = "🧝🏼‍♀️" ;

		public const string WomanElfMediumLightSkinTone2 = "🧝🏼‍♀" ;

		public const string WomanElfMediumSkinTone = "🧝🏽‍♀️" ;

		public const string WomanElfMediumSkinTone2 = "🧝🏽‍♀" ;

		public const string WomanElfMediumDarkSkinTone = "🧝🏾‍♀️" ;

		public const string WomanElfMediumDarkSkinTone2 = "🧝🏾‍♀" ;

		public const string WomanElfDarkSkinTone = "🧝🏿‍♀️" ;

		public const string WomanElfDarkSkinTone2 = "🧝🏿‍♀" ;

		public const string Genie = "🧞" ;

		public const string ManGenie = "🧞‍♂️" ;

		public const string ManGenie2 = "🧞‍♂" ;

		public const string WomanGenie = "🧞‍♀️" ;

		public const string WomanGenie2 = "🧞‍♀" ;

		public const string Zombie = "🧟" ;

		public const string ManZombie = "🧟‍♂️" ;

		public const string ManZombie2 = "🧟‍♂" ;

		public const string WomanZombie = "🧟‍♀️" ;

		public const string WomanZombie2 = "🧟‍♀" ;

		public const string PersonGettingMassage = "💆" ;

		public const string PersonGettingMassageLightSkinTone = "💆🏻" ;

		public const string PersonGettingMassageMediumLightSkinTone = "💆🏼" ;

		public const string PersonGettingMassageMediumSkinTone = "💆🏽" ;

		public const string PersonGettingMassageMediumDarkSkinTone = "💆🏾" ;

		public const string PersonGettingMassageDarkSkinTone = "💆🏿" ;

		public const string ManGettingMassage = "💆‍♂️" ;

		public const string ManGettingMassage2 = "💆‍♂" ;

		public const string ManGettingMassageLightSkinTone = "💆🏻‍♂️" ;

		public const string ManGettingMassageLightSkinTone2 = "💆🏻‍♂" ;

		public const string ManGettingMassageMediumLightSkinTone = "💆🏼‍♂️" ;

		public const string ManGettingMassageMediumLightSkinTone2 = "💆🏼‍♂" ;

		public const string ManGettingMassageMediumSkinTone = "💆🏽‍♂️" ;

		public const string ManGettingMassageMediumSkinTone2 = "💆🏽‍♂" ;

		public const string ManGettingMassageMediumDarkSkinTone = "💆🏾‍♂️" ;

		public const string ManGettingMassageMediumDarkSkinTone2 = "💆🏾‍♂" ;

		public const string ManGettingMassageDarkSkinTone = "💆🏿‍♂️" ;

		public const string ManGettingMassageDarkSkinTone2 = "💆🏿‍♂" ;

		public const string WomanGettingMassage = "💆‍♀️" ;

		public const string WomanGettingMassage2 = "💆‍♀" ;

		public const string WomanGettingMassageLightSkinTone = "💆🏻‍♀️" ;

		public const string WomanGettingMassageLightSkinTone2 = "💆🏻‍♀" ;

		public const string WomanGettingMassageMediumLightSkinTone = "💆🏼‍♀️" ;

		public const string WomanGettingMassageMediumLightSkinTone2 = "💆🏼‍♀" ;

		public const string WomanGettingMassageMediumSkinTone = "💆🏽‍♀️" ;

		public const string WomanGettingMassageMediumSkinTone2 = "💆🏽‍♀" ;

		public const string WomanGettingMassageMediumDarkSkinTone = "💆🏾‍♀️" ;

		public const string WomanGettingMassageMediumDarkSkinTone2 = "💆🏾‍♀" ;

		public const string WomanGettingMassageDarkSkinTone = "💆🏿‍♀️" ;

		public const string WomanGettingMassageDarkSkinTone2 = "💆🏿‍♀" ;

		public const string PersonGettingHaircut = "💇" ;

		public const string PersonGettingHaircutLightSkinTone = "💇🏻" ;

		public const string PersonGettingHaircutMediumLightSkinTone = "💇🏼" ;

		public const string PersonGettingHaircutMediumSkinTone = "💇🏽" ;

		public const string PersonGettingHaircutMediumDarkSkinTone = "💇🏾" ;

		public const string PersonGettingHaircutDarkSkinTone = "💇🏿" ;

		public const string ManGettingHaircut = "💇‍♂️" ;

		public const string ManGettingHaircut2 = "💇‍♂" ;

		public const string ManGettingHaircutLightSkinTone = "💇🏻‍♂️" ;

		public const string ManGettingHaircutLightSkinTone2 = "💇🏻‍♂" ;

		public const string ManGettingHaircutMediumLightSkinTone = "💇🏼‍♂️" ;

		public const string ManGettingHaircutMediumLightSkinTone2 = "💇🏼‍♂" ;

		public const string ManGettingHaircutMediumSkinTone = "💇🏽‍♂️" ;

		public const string ManGettingHaircutMediumSkinTone2 = "💇🏽‍♂" ;

		public const string ManGettingHaircutMediumDarkSkinTone = "💇🏾‍♂️" ;

		public const string ManGettingHaircutMediumDarkSkinTone2 = "💇🏾‍♂" ;

		public const string ManGettingHaircutDarkSkinTone = "💇🏿‍♂️" ;

		public const string ManGettingHaircutDarkSkinTone2 = "💇🏿‍♂" ;

		public const string WomanGettingHaircut = "💇‍♀️" ;

		public const string WomanGettingHaircut2 = "💇‍♀" ;

		public const string WomanGettingHaircutLightSkinTone = "💇🏻‍♀️" ;

		public const string WomanGettingHaircutLightSkinTone2 = "💇🏻‍♀" ;

		public const string WomanGettingHaircutMediumLightSkinTone = "💇🏼‍♀️" ;

		public const string WomanGettingHaircutMediumLightSkinTone2 = "💇🏼‍♀" ;

		public const string WomanGettingHaircutMediumSkinTone = "💇🏽‍♀️" ;

		public const string WomanGettingHaircutMediumSkinTone2 = "💇🏽‍♀" ;

		public const string WomanGettingHaircutMediumDarkSkinTone = "💇🏾‍♀️" ;

		public const string WomanGettingHaircutMediumDarkSkinTone2 = "💇🏾‍♀" ;

		public const string WomanGettingHaircutDarkSkinTone = "💇🏿‍♀️" ;

		public const string WomanGettingHaircutDarkSkinTone2 = "💇🏿‍♀" ;

		public const string PersonWalking = "🚶" ;

		public const string PersonWalkingLightSkinTone = "🚶🏻" ;

		public const string PersonWalkingMediumLightSkinTone = "🚶🏼" ;

		public const string PersonWalkingMediumSkinTone = "🚶🏽" ;

		public const string PersonWalkingMediumDarkSkinTone = "🚶🏾" ;

		public const string PersonWalkingDarkSkinTone = "🚶🏿" ;

		public const string ManWalking = "🚶‍♂️" ;

		public const string ManWalking2 = "🚶‍♂" ;

		public const string ManWalkingLightSkinTone = "🚶🏻‍♂️" ;

		public const string ManWalkingLightSkinTone2 = "🚶🏻‍♂" ;

		public const string ManWalkingMediumLightSkinTone = "🚶🏼‍♂️" ;

		public const string ManWalkingMediumLightSkinTone2 = "🚶🏼‍♂" ;

		public const string ManWalkingMediumSkinTone = "🚶🏽‍♂️" ;

		public const string ManWalkingMediumSkinTone2 = "🚶🏽‍♂" ;

		public const string ManWalkingMediumDarkSkinTone = "🚶🏾‍♂️" ;

		public const string ManWalkingMediumDarkSkinTone2 = "🚶🏾‍♂" ;

		public const string ManWalkingDarkSkinTone = "🚶🏿‍♂️" ;

		public const string ManWalkingDarkSkinTone2 = "🚶🏿‍♂" ;

		public const string WomanWalking = "🚶‍♀️" ;

		public const string WomanWalking2 = "🚶‍♀" ;

		public const string WomanWalkingLightSkinTone = "🚶🏻‍♀️" ;

		public const string WomanWalkingLightSkinTone2 = "🚶🏻‍♀" ;

		public const string WomanWalkingMediumLightSkinTone = "🚶🏼‍♀️" ;

		public const string WomanWalkingMediumLightSkinTone2 = "🚶🏼‍♀" ;

		public const string WomanWalkingMediumSkinTone = "🚶🏽‍♀️" ;

		public const string WomanWalkingMediumSkinTone2 = "🚶🏽‍♀" ;

		public const string WomanWalkingMediumDarkSkinTone = "🚶🏾‍♀️" ;

		public const string WomanWalkingMediumDarkSkinTone2 = "🚶🏾‍♀" ;

		public const string WomanWalkingDarkSkinTone = "🚶🏿‍♀️" ;

		public const string WomanWalkingDarkSkinTone2 = "🚶🏿‍♀" ;

		public const string PersonStanding = "🧍" ;

		public const string PersonStandingLightSkinTone = "🧍🏻" ;

		public const string PersonStandingMediumLightSkinTone = "🧍🏼" ;

		public const string PersonStandingMediumSkinTone = "🧍🏽" ;

		public const string PersonStandingMediumDarkSkinTone = "🧍🏾" ;

		public const string PersonStandingDarkSkinTone = "🧍🏿" ;

		public const string ManStanding = "🧍‍♂️" ;

		public const string ManStanding2 = "🧍‍♂" ;

		public const string ManStandingLightSkinTone = "🧍🏻‍♂️" ;

		public const string ManStandingLightSkinTone2 = "🧍🏻‍♂" ;

		public const string ManStandingMediumLightSkinTone = "🧍🏼‍♂️" ;

		public const string ManStandingMediumLightSkinTone2 = "🧍🏼‍♂" ;

		public const string ManStandingMediumSkinTone = "🧍🏽‍♂️" ;

		public const string ManStandingMediumSkinTone2 = "🧍🏽‍♂" ;

		public const string ManStandingMediumDarkSkinTone = "🧍🏾‍♂️" ;

		public const string ManStandingMediumDarkSkinTone2 = "🧍🏾‍♂" ;

		public const string ManStandingDarkSkinTone = "🧍🏿‍♂️" ;

		public const string ManStandingDarkSkinTone2 = "🧍🏿‍♂" ;

		public const string WomanStanding = "🧍‍♀️" ;

		public const string WomanStanding2 = "🧍‍♀" ;

		public const string WomanStandingLightSkinTone = "🧍🏻‍♀️" ;

		public const string WomanStandingLightSkinTone2 = "🧍🏻‍♀" ;

		public const string WomanStandingMediumLightSkinTone = "🧍🏼‍♀️" ;

		public const string WomanStandingMediumLightSkinTone2 = "🧍🏼‍♀" ;

		public const string WomanStandingMediumSkinTone = "🧍🏽‍♀️" ;

		public const string WomanStandingMediumSkinTone2 = "🧍🏽‍♀" ;

		public const string WomanStandingMediumDarkSkinTone = "🧍🏾‍♀️" ;

		public const string WomanStandingMediumDarkSkinTone2 = "🧍🏾‍♀" ;

		public const string WomanStandingDarkSkinTone = "🧍🏿‍♀️" ;

		public const string WomanStandingDarkSkinTone2 = "🧍🏿‍♀" ;

		public const string PersonKneeling = "🧎" ;

		public const string PersonKneelingLightSkinTone = "🧎🏻" ;

		public const string PersonKneelingMediumLightSkinTone = "🧎🏼" ;

		public const string PersonKneelingMediumSkinTone = "🧎🏽" ;

		public const string PersonKneelingMediumDarkSkinTone = "🧎🏾" ;

		public const string PersonKneelingDarkSkinTone = "🧎🏿" ;

		public const string ManKneeling = "🧎‍♂️" ;

		public const string ManKneeling2 = "🧎‍♂" ;

		public const string ManKneelingLightSkinTone = "🧎🏻‍♂️" ;

		public const string ManKneelingLightSkinTone2 = "🧎🏻‍♂" ;

		public const string ManKneelingMediumLightSkinTone = "🧎🏼‍♂️" ;

		public const string ManKneelingMediumLightSkinTone2 = "🧎🏼‍♂" ;

		public const string ManKneelingMediumSkinTone = "🧎🏽‍♂️" ;

		public const string ManKneelingMediumSkinTone2 = "🧎🏽‍♂" ;

		public const string ManKneelingMediumDarkSkinTone = "🧎🏾‍♂️" ;

		public const string ManKneelingMediumDarkSkinTone2 = "🧎🏾‍♂" ;

		public const string ManKneelingDarkSkinTone = "🧎🏿‍♂️" ;

		public const string ManKneelingDarkSkinTone2 = "🧎🏿‍♂" ;

		public const string WomanKneeling = "🧎‍♀️" ;

		public const string WomanKneeling2 = "🧎‍♀" ;

		public const string WomanKneelingLightSkinTone = "🧎🏻‍♀️" ;

		public const string WomanKneelingLightSkinTone2 = "🧎🏻‍♀" ;

		public const string WomanKneelingMediumLightSkinTone = "🧎🏼‍♀️" ;

		public const string WomanKneelingMediumLightSkinTone2 = "🧎🏼‍♀" ;

		public const string WomanKneelingMediumSkinTone = "🧎🏽‍♀️" ;

		public const string WomanKneelingMediumSkinTone2 = "🧎🏽‍♀" ;

		public const string WomanKneelingMediumDarkSkinTone = "🧎🏾‍♀️" ;

		public const string WomanKneelingMediumDarkSkinTone2 = "🧎🏾‍♀" ;

		public const string WomanKneelingDarkSkinTone = "🧎🏿‍♀️" ;

		public const string WomanKneelingDarkSkinTone2 = "🧎🏿‍♀" ;

		public const string ManWithProbingCane = "👨‍🦯" ;

		public const string ManWithProbingCaneLightSkinTone = "👨🏻‍🦯" ;

		public const string ManWithProbingCaneMediumLightSkinTone = "👨🏼‍🦯" ;

		public const string ManWithProbingCaneMediumSkinTone = "👨🏽‍🦯" ;

		public const string ManWithProbingCaneMediumDarkSkinTone = "👨🏾‍🦯" ;

		public const string ManWithProbingCaneDarkSkinTone = "👨🏿‍🦯" ;

		public const string WomanWithProbingCane = "👩‍🦯" ;

		public const string WomanWithProbingCaneLightSkinTone = "👩🏻‍🦯" ;

		public const string WomanWithProbingCaneMediumLightSkinTone = "👩🏼‍🦯" ;

		public const string WomanWithProbingCaneMediumSkinTone = "👩🏽‍🦯" ;

		public const string WomanWithProbingCaneMediumDarkSkinTone = "👩🏾‍🦯" ;

		public const string WomanWithProbingCaneDarkSkinTone = "👩🏿‍🦯" ;

		public const string ManInMotorizedWheelchair = "👨‍🦼" ;

		public const string ManInMotorizedWheelchairLightSkinTone = "👨🏻‍🦼" ;

		public const string ManInMotorizedWheelchairMediumLightSkinTone = "👨🏼‍🦼" ;

		public const string ManInMotorizedWheelchairMediumSkinTone = "👨🏽‍🦼" ;

		public const string ManInMotorizedWheelchairMediumDarkSkinTone = "👨🏾‍🦼" ;

		public const string ManInMotorizedWheelchairDarkSkinTone = "👨🏿‍🦼" ;

		public const string WomanInMotorizedWheelchair = "👩‍🦼" ;

		public const string WomanInMotorizedWheelchairLightSkinTone = "👩🏻‍🦼" ;

		public const string WomanInMotorizedWheelchairMediumLightSkinTone = "👩🏼‍🦼" ;

		public const string WomanInMotorizedWheelchairMediumSkinTone = "👩🏽‍🦼" ;

		public const string WomanInMotorizedWheelchairMediumDarkSkinTone = "👩🏾‍🦼" ;

		public const string WomanInMotorizedWheelchairDarkSkinTone = "👩🏿‍🦼" ;

		public const string ManInManualWheelchair = "👨‍🦽" ;

		public const string ManInManualWheelchairLightSkinTone = "👨🏻‍🦽" ;

		public const string ManInManualWheelchairMediumLightSkinTone = "👨🏼‍🦽" ;

		public const string ManInManualWheelchairMediumSkinTone = "👨🏽‍🦽" ;

		public const string ManInManualWheelchairMediumDarkSkinTone = "👨🏾‍🦽" ;

		public const string ManInManualWheelchairDarkSkinTone = "👨🏿‍🦽" ;

		public const string WomanInManualWheelchair = "👩‍🦽" ;

		public const string WomanInManualWheelchairLightSkinTone = "👩🏻‍🦽" ;

		public const string WomanInManualWheelchairMediumLightSkinTone = "👩🏼‍🦽" ;

		public const string WomanInManualWheelchairMediumSkinTone = "👩🏽‍🦽" ;

		public const string WomanInManualWheelchairMediumDarkSkinTone = "👩🏾‍🦽" ;

		public const string WomanInManualWheelchairDarkSkinTone = "👩🏿‍🦽" ;

		public const string PersonRunning = "🏃" ;

		public const string PersonRunningLightSkinTone = "🏃🏻" ;

		public const string PersonRunningMediumLightSkinTone = "🏃🏼" ;

		public const string PersonRunningMediumSkinTone = "🏃🏽" ;

		public const string PersonRunningMediumDarkSkinTone = "🏃🏾" ;

		public const string PersonRunningDarkSkinTone = "🏃🏿" ;

		public const string ManRunning = "🏃‍♂️" ;

		public const string ManRunning2 = "🏃‍♂" ;

		public const string ManRunningLightSkinTone = "🏃🏻‍♂️" ;

		public const string ManRunningLightSkinTone2 = "🏃🏻‍♂" ;

		public const string ManRunningMediumLightSkinTone = "🏃🏼‍♂️" ;

		public const string ManRunningMediumLightSkinTone2 = "🏃🏼‍♂" ;

		public const string ManRunningMediumSkinTone = "🏃🏽‍♂️" ;

		public const string ManRunningMediumSkinTone2 = "🏃🏽‍♂" ;

		public const string ManRunningMediumDarkSkinTone = "🏃🏾‍♂️" ;

		public const string ManRunningMediumDarkSkinTone2 = "🏃🏾‍♂" ;

		public const string ManRunningDarkSkinTone = "🏃🏿‍♂️" ;

		public const string ManRunningDarkSkinTone2 = "🏃🏿‍♂" ;

		public const string WomanRunning = "🏃‍♀️" ;

		public const string WomanRunning2 = "🏃‍♀" ;

		public const string WomanRunningLightSkinTone = "🏃🏻‍♀️" ;

		public const string WomanRunningLightSkinTone2 = "🏃🏻‍♀" ;

		public const string WomanRunningMediumLightSkinTone = "🏃🏼‍♀️" ;

		public const string WomanRunningMediumLightSkinTone2 = "🏃🏼‍♀" ;

		public const string WomanRunningMediumSkinTone = "🏃🏽‍♀️" ;

		public const string WomanRunningMediumSkinTone2 = "🏃🏽‍♀" ;

		public const string WomanRunningMediumDarkSkinTone = "🏃🏾‍♀️" ;

		public const string WomanRunningMediumDarkSkinTone2 = "🏃🏾‍♀" ;

		public const string WomanRunningDarkSkinTone = "🏃🏿‍♀️" ;

		public const string WomanRunningDarkSkinTone2 = "🏃🏿‍♀" ;

		public const string WomanDancing = "💃" ;

		public const string WomanDancingLightSkinTone = "💃🏻" ;

		public const string WomanDancingMediumLightSkinTone = "💃🏼" ;

		public const string WomanDancingMediumSkinTone = "💃🏽" ;

		public const string WomanDancingMediumDarkSkinTone = "💃🏾" ;

		public const string WomanDancingDarkSkinTone = "💃🏿" ;

		public const string ManDancing = "🕺" ;

		public const string ManDancingLightSkinTone = "🕺🏻" ;

		public const string ManDancingMediumLightSkinTone = "🕺🏼" ;

		public const string ManDancingMediumSkinTone = "🕺🏽" ;

		public const string ManDancingMediumDarkSkinTone = "🕺🏾" ;

		public const string ManDancingDarkSkinTone = "🕺🏿" ;

		public const string ManInSuitLevitating = "🕴️" ;

		public const string ManInSuitLevitating2 = "🕴" ;

		public const string ManInSuitLevitatingLightSkinTone = "🕴🏻" ;

		public const string ManInSuitLevitatingMediumLightSkinTone = "🕴🏼" ;

		public const string ManInSuitLevitatingMediumSkinTone = "🕴🏽" ;

		public const string ManInSuitLevitatingMediumDarkSkinTone = "🕴🏾" ;

		public const string ManInSuitLevitatingDarkSkinTone = "🕴🏿" ;

		public const string PeopleWithBunnyEars = "👯" ;

		public const string PeopleWithBunnyEarsLightSkinTone = "👯🏻" ;

		public const string PeopleWithBunnyEarsMediumLightSkinTone = "👯🏼" ;

		public const string PeopleWithBunnyEarsMediumSkinTone = "👯🏽" ;

		public const string PeopleWithBunnyEarsMediumDarkSkinTone = "👯🏾" ;

		public const string PeopleWithBunnyEarsDarkSkinTone = "👯🏿" ;

		public const string MenWithBunnyEars = "👯‍♂️" ;

		public const string MenWithBunnyEars2 = "👯‍♂" ;

		public const string MenWithBunnyEarsLightSkinTone = "👯🏻‍♂️" ;

		public const string MenWithBunnyEarsLightSkinTone2 = "👯🏻‍♂" ;

		public const string MenWithBunnyEarsMediumLightSkinTone = "👯🏼‍♂️" ;

		public const string MenWithBunnyEarsMediumLightSkinTone2 = "👯🏼‍♂" ;

		public const string MenWithBunnyEarsMediumSkinTone = "👯🏽‍♂️" ;

		public const string MenWithBunnyEarsMediumSkinTone2 = "👯🏽‍♂" ;

		public const string MenWithBunnyEarsMediumDarkSkinTone = "👯🏾‍♂️" ;

		public const string MenWithBunnyEarsMediumDarkSkinTone2 = "👯🏾‍♂" ;

		public const string MenWithBunnyEarsDarkSkinTone = "👯🏿‍♂️" ;

		public const string MenWithBunnyEarsDarkSkinTone2 = "👯🏿‍♂" ;

		public const string WomenWithBunnyEars = "👯‍♀️" ;

		public const string WomenWithBunnyEars2 = "👯‍♀" ;

		public const string WomenWithBunnyEarsLightSkinTone = "👯🏻‍♀️" ;

		public const string WomenWithBunnyEarsLightSkinTone2 = "👯🏻‍♀" ;

		public const string WomenWithBunnyEarsMediumLightSkinTone = "👯🏼‍♀️" ;

		public const string WomenWithBunnyEarsMediumLightSkinTone2 = "👯🏼‍♀" ;

		public const string WomenWithBunnyEarsMediumSkinTone = "👯🏽‍♀️" ;

		public const string WomenWithBunnyEarsMediumSkinTone2 = "👯🏽‍♀" ;

		public const string WomenWithBunnyEarsMediumDarkSkinTone = "👯🏾‍♀️" ;

		public const string WomenWithBunnyEarsMediumDarkSkinTone2 = "👯🏾‍♀" ;

		public const string WomenWithBunnyEarsDarkSkinTone = "👯🏿‍♀️" ;

		public const string WomenWithBunnyEarsDarkSkinTone2 = "👯🏿‍♀" ;

		public const string PersonInSteamyRoom = "🧖" ;

		public const string PersonInSteamyRoomLightSkinTone = "🧖🏻" ;

		public const string PersonInSteamyRoomMediumLightSkinTone = "🧖🏼" ;

		public const string PersonInSteamyRoomMediumSkinTone = "🧖🏽" ;

		public const string PersonInSteamyRoomMediumDarkSkinTone = "🧖🏾" ;

		public const string PersonInSteamyRoomDarkSkinTone = "🧖🏿" ;

		public const string ManInSteamyRoom = "🧖‍♂️" ;

		public const string ManInSteamyRoom2 = "🧖‍♂" ;

		public const string ManInSteamyRoomLightSkinTone = "🧖🏻‍♂️" ;

		public const string ManInSteamyRoomLightSkinTone2 = "🧖🏻‍♂" ;

		public const string ManInSteamyRoomMediumLightSkinTone = "🧖🏼‍♂️" ;

		public const string ManInSteamyRoomMediumLightSkinTone2 = "🧖🏼‍♂" ;

		public const string ManInSteamyRoomMediumSkinTone = "🧖🏽‍♂️" ;

		public const string ManInSteamyRoomMediumSkinTone2 = "🧖🏽‍♂" ;

		public const string ManInSteamyRoomMediumDarkSkinTone = "🧖🏾‍♂️" ;

		public const string ManInSteamyRoomMediumDarkSkinTone2 = "🧖🏾‍♂" ;

		public const string ManInSteamyRoomDarkSkinTone = "🧖🏿‍♂️" ;

		public const string ManInSteamyRoomDarkSkinTone2 = "🧖🏿‍♂" ;

		public const string WomanInSteamyRoom = "🧖‍♀️" ;

		public const string WomanInSteamyRoom2 = "🧖‍♀" ;

		public const string WomanInSteamyRoomLightSkinTone = "🧖🏻‍♀️" ;

		public const string WomanInSteamyRoomLightSkinTone2 = "🧖🏻‍♀" ;

		public const string WomanInSteamyRoomMediumLightSkinTone = "🧖🏼‍♀️" ;

		public const string WomanInSteamyRoomMediumLightSkinTone2 = "🧖🏼‍♀" ;

		public const string WomanInSteamyRoomMediumSkinTone = "🧖🏽‍♀️" ;

		public const string WomanInSteamyRoomMediumSkinTone2 = "🧖🏽‍♀" ;

		public const string WomanInSteamyRoomMediumDarkSkinTone = "🧖🏾‍♀️" ;

		public const string WomanInSteamyRoomMediumDarkSkinTone2 = "🧖🏾‍♀" ;

		public const string WomanInSteamyRoomDarkSkinTone = "🧖🏿‍♀️" ;

		public const string WomanInSteamyRoomDarkSkinTone2 = "🧖🏿‍♀" ;

		public const string PersonClimbing = "🧗" ;

		public const string PersonClimbingLightSkinTone = "🧗🏻" ;

		public const string PersonClimbingMediumLightSkinTone = "🧗🏼" ;

		public const string PersonClimbingMediumSkinTone = "🧗🏽" ;

		public const string PersonClimbingMediumDarkSkinTone = "🧗🏾" ;

		public const string PersonClimbingDarkSkinTone = "🧗🏿" ;

		public const string ManClimbing = "🧗‍♂️" ;

		public const string ManClimbing2 = "🧗‍♂" ;

		public const string ManClimbingLightSkinTone = "🧗🏻‍♂️" ;

		public const string ManClimbingLightSkinTone2 = "🧗🏻‍♂" ;

		public const string ManClimbingMediumLightSkinTone = "🧗🏼‍♂️" ;

		public const string ManClimbingMediumLightSkinTone2 = "🧗🏼‍♂" ;

		public const string ManClimbingMediumSkinTone = "🧗🏽‍♂️" ;

		public const string ManClimbingMediumSkinTone2 = "🧗🏽‍♂" ;

		public const string ManClimbingMediumDarkSkinTone = "🧗🏾‍♂️" ;

		public const string ManClimbingMediumDarkSkinTone2 = "🧗🏾‍♂" ;

		public const string ManClimbingDarkSkinTone = "🧗🏿‍♂️" ;

		public const string ManClimbingDarkSkinTone2 = "🧗🏿‍♂" ;

		public const string WomanClimbing = "🧗‍♀️" ;

		public const string WomanClimbing2 = "🧗‍♀" ;

		public const string WomanClimbingLightSkinTone = "🧗🏻‍♀️" ;

		public const string WomanClimbingLightSkinTone2 = "🧗🏻‍♀" ;

		public const string WomanClimbingMediumLightSkinTone = "🧗🏼‍♀️" ;

		public const string WomanClimbingMediumLightSkinTone2 = "🧗🏼‍♀" ;

		public const string WomanClimbingMediumSkinTone = "🧗🏽‍♀️" ;

		public const string WomanClimbingMediumSkinTone2 = "🧗🏽‍♀" ;

		public const string WomanClimbingMediumDarkSkinTone = "🧗🏾‍♀️" ;

		public const string WomanClimbingMediumDarkSkinTone2 = "🧗🏾‍♀" ;

		public const string WomanClimbingDarkSkinTone = "🧗🏿‍♀️" ;

		public const string WomanClimbingDarkSkinTone2 = "🧗🏿‍♀" ;

		public const string PersonFencing = "🤺" ;

		public const string HorseRacing = "🏇" ;

		public const string HorseRacingLightSkinTone = "🏇🏻" ;

		public const string HorseRacingMediumLightSkinTone = "🏇🏼" ;

		public const string HorseRacingMediumSkinTone = "🏇🏽" ;

		public const string HorseRacingMediumDarkSkinTone = "🏇🏾" ;

		public const string HorseRacingDarkSkinTone = "🏇🏿" ;

		public const string Skier = "⛷️" ;

		public const string Skier2 = "⛷" ;

		public const string Snowboarder = "🏂" ;

		public const string SnowboarderLightSkinTone = "🏂🏻" ;

		public const string SnowboarderMediumLightSkinTone = "🏂🏼" ;

		public const string SnowboarderMediumSkinTone = "🏂🏽" ;

		public const string SnowboarderMediumDarkSkinTone = "🏂🏾" ;

		public const string SnowboarderDarkSkinTone = "🏂🏿" ;

		public const string PersonGolfing = "🏌️" ;

		public const string PersonGolfing2 = "🏌" ;

		public const string PersonGolfingLightSkinTone = "🏌🏻" ;

		public const string PersonGolfingMediumLightSkinTone = "🏌🏼" ;

		public const string PersonGolfingMediumSkinTone = "🏌🏽" ;

		public const string PersonGolfingMediumDarkSkinTone = "🏌🏾" ;

		public const string PersonGolfingDarkSkinTone = "🏌🏿" ;

		public const string ManGolfing = "🏌️‍♂️" ;

		public const string ManGolfing2 = "🏌‍♂️" ;

		public const string ManGolfing3 = "🏌️‍♂" ;

		public const string ManGolfing4 = "🏌‍♂" ;

		public const string ManGolfingLightSkinTone = "🏌🏻‍♂️" ;

		public const string ManGolfingLightSkinTone2 = "🏌🏻‍♂" ;

		public const string ManGolfingMediumLightSkinTone = "🏌🏼‍♂️" ;

		public const string ManGolfingMediumLightSkinTone2 = "🏌🏼‍♂" ;

		public const string ManGolfingMediumSkinTone = "🏌🏽‍♂️" ;

		public const string ManGolfingMediumSkinTone2 = "🏌🏽‍♂" ;

		public const string ManGolfingMediumDarkSkinTone = "🏌🏾‍♂️" ;

		public const string ManGolfingMediumDarkSkinTone2 = "🏌🏾‍♂" ;

		public const string ManGolfingDarkSkinTone = "🏌🏿‍♂️" ;

		public const string ManGolfingDarkSkinTone2 = "🏌🏿‍♂" ;

		public const string WomanGolfing = "🏌️‍♀️" ;

		public const string WomanGolfing2 = "🏌‍♀️" ;

		public const string WomanGolfing3 = "🏌️‍♀" ;

		public const string WomanGolfing4 = "🏌‍♀" ;

		public const string WomanGolfingLightSkinTone = "🏌🏻‍♀️" ;

		public const string WomanGolfingLightSkinTone2 = "🏌🏻‍♀" ;

		public const string WomanGolfingMediumLightSkinTone = "🏌🏼‍♀️" ;

		public const string WomanGolfingMediumLightSkinTone2 = "🏌🏼‍♀" ;

		public const string WomanGolfingMediumSkinTone = "🏌🏽‍♀️" ;

		public const string WomanGolfingMediumSkinTone2 = "🏌🏽‍♀" ;

		public const string WomanGolfingMediumDarkSkinTone = "🏌🏾‍♀️" ;

		public const string WomanGolfingMediumDarkSkinTone2 = "🏌🏾‍♀" ;

		public const string WomanGolfingDarkSkinTone = "🏌🏿‍♀️" ;

		public const string WomanGolfingDarkSkinTone2 = "🏌🏿‍♀" ;

		public const string PersonSurfing = "🏄" ;

		public const string PersonSurfingLightSkinTone = "🏄🏻" ;

		public const string PersonSurfingMediumLightSkinTone = "🏄🏼" ;

		public const string PersonSurfingMediumSkinTone = "🏄🏽" ;

		public const string PersonSurfingMediumDarkSkinTone = "🏄🏾" ;

		public const string PersonSurfingDarkSkinTone = "🏄🏿" ;

		public const string ManSurfing = "🏄‍♂️" ;

		public const string ManSurfing2 = "🏄‍♂" ;

		public const string ManSurfingLightSkinTone = "🏄🏻‍♂️" ;

		public const string ManSurfingLightSkinTone2 = "🏄🏻‍♂" ;

		public const string ManSurfingMediumLightSkinTone = "🏄🏼‍♂️" ;

		public const string ManSurfingMediumLightSkinTone2 = "🏄🏼‍♂" ;

		public const string ManSurfingMediumSkinTone = "🏄🏽‍♂️" ;

		public const string ManSurfingMediumSkinTone2 = "🏄🏽‍♂" ;

		public const string ManSurfingMediumDarkSkinTone = "🏄🏾‍♂️" ;

		public const string ManSurfingMediumDarkSkinTone2 = "🏄🏾‍♂" ;

		public const string ManSurfingDarkSkinTone = "🏄🏿‍♂️" ;

		public const string ManSurfingDarkSkinTone2 = "🏄🏿‍♂" ;

		public const string WomanSurfing = "🏄‍♀️" ;

		public const string WomanSurfing2 = "🏄‍♀" ;

		public const string WomanSurfingLightSkinTone = "🏄🏻‍♀️" ;

		public const string WomanSurfingLightSkinTone2 = "🏄🏻‍♀" ;

		public const string WomanSurfingMediumLightSkinTone = "🏄🏼‍♀️" ;

		public const string WomanSurfingMediumLightSkinTone2 = "🏄🏼‍♀" ;

		public const string WomanSurfingMediumSkinTone = "🏄🏽‍♀️" ;

		public const string WomanSurfingMediumSkinTone2 = "🏄🏽‍♀" ;

		public const string WomanSurfingMediumDarkSkinTone = "🏄🏾‍♀️" ;

		public const string WomanSurfingMediumDarkSkinTone2 = "🏄🏾‍♀" ;

		public const string WomanSurfingDarkSkinTone = "🏄🏿‍♀️" ;

		public const string WomanSurfingDarkSkinTone2 = "🏄🏿‍♀" ;

		public const string PersonRowingBoat = "🚣" ;

		public const string PersonRowingBoatLightSkinTone = "🚣🏻" ;

		public const string PersonRowingBoatMediumLightSkinTone = "🚣🏼" ;

		public const string PersonRowingBoatMediumSkinTone = "🚣🏽" ;

		public const string PersonRowingBoatMediumDarkSkinTone = "🚣🏾" ;

		public const string PersonRowingBoatDarkSkinTone = "🚣🏿" ;

		public const string ManRowingBoat = "🚣‍♂️" ;

		public const string ManRowingBoat2 = "🚣‍♂" ;

		public const string ManRowingBoatLightSkinTone = "🚣🏻‍♂️" ;

		public const string ManRowingBoatLightSkinTone2 = "🚣🏻‍♂" ;

		public const string ManRowingBoatMediumLightSkinTone = "🚣🏼‍♂️" ;

		public const string ManRowingBoatMediumLightSkinTone2 = "🚣🏼‍♂" ;

		public const string ManRowingBoatMediumSkinTone = "🚣🏽‍♂️" ;

		public const string ManRowingBoatMediumSkinTone2 = "🚣🏽‍♂" ;

		public const string ManRowingBoatMediumDarkSkinTone = "🚣🏾‍♂️" ;

		public const string ManRowingBoatMediumDarkSkinTone2 = "🚣🏾‍♂" ;

		public const string ManRowingBoatDarkSkinTone = "🚣🏿‍♂️" ;

		public const string ManRowingBoatDarkSkinTone2 = "🚣🏿‍♂" ;

		public const string WomanRowingBoat = "🚣‍♀️" ;

		public const string WomanRowingBoat2 = "🚣‍♀" ;

		public const string WomanRowingBoatLightSkinTone = "🚣🏻‍♀️" ;

		public const string WomanRowingBoatLightSkinTone2 = "🚣🏻‍♀" ;

		public const string WomanRowingBoatMediumLightSkinTone = "🚣🏼‍♀️" ;

		public const string WomanRowingBoatMediumLightSkinTone2 = "🚣🏼‍♀" ;

		public const string WomanRowingBoatMediumSkinTone = "🚣🏽‍♀️" ;

		public const string WomanRowingBoatMediumSkinTone2 = "🚣🏽‍♀" ;

		public const string WomanRowingBoatMediumDarkSkinTone = "🚣🏾‍♀️" ;

		public const string WomanRowingBoatMediumDarkSkinTone2 = "🚣🏾‍♀" ;

		public const string WomanRowingBoatDarkSkinTone = "🚣🏿‍♀️" ;

		public const string WomanRowingBoatDarkSkinTone2 = "🚣🏿‍♀" ;

		public const string PersonSwimming = "🏊" ;

		public const string PersonSwimmingLightSkinTone = "🏊🏻" ;

		public const string PersonSwimmingMediumLightSkinTone = "🏊🏼" ;

		public const string PersonSwimmingMediumSkinTone = "🏊🏽" ;

		public const string PersonSwimmingMediumDarkSkinTone = "🏊🏾" ;

		public const string PersonSwimmingDarkSkinTone = "🏊🏿" ;

		public const string ManSwimming = "🏊‍♂️" ;

		public const string ManSwimming2 = "🏊‍♂" ;

		public const string ManSwimmingLightSkinTone = "🏊🏻‍♂️" ;

		public const string ManSwimmingLightSkinTone2 = "🏊🏻‍♂" ;

		public const string ManSwimmingMediumLightSkinTone = "🏊🏼‍♂️" ;

		public const string ManSwimmingMediumLightSkinTone2 = "🏊🏼‍♂" ;

		public const string ManSwimmingMediumSkinTone = "🏊🏽‍♂️" ;

		public const string ManSwimmingMediumSkinTone2 = "🏊🏽‍♂" ;

		public const string ManSwimmingMediumDarkSkinTone = "🏊🏾‍♂️" ;

		public const string ManSwimmingMediumDarkSkinTone2 = "🏊🏾‍♂" ;

		public const string ManSwimmingDarkSkinTone = "🏊🏿‍♂️" ;

		public const string ManSwimmingDarkSkinTone2 = "🏊🏿‍♂" ;

		public const string WomanSwimming = "🏊‍♀️" ;

		public const string WomanSwimming2 = "🏊‍♀" ;

		public const string WomanSwimmingLightSkinTone = "🏊🏻‍♀️" ;

		public const string WomanSwimmingLightSkinTone2 = "🏊🏻‍♀" ;

		public const string WomanSwimmingMediumLightSkinTone = "🏊🏼‍♀️" ;

		public const string WomanSwimmingMediumLightSkinTone2 = "🏊🏼‍♀" ;

		public const string WomanSwimmingMediumSkinTone = "🏊🏽‍♀️" ;

		public const string WomanSwimmingMediumSkinTone2 = "🏊🏽‍♀" ;

		public const string WomanSwimmingMediumDarkSkinTone = "🏊🏾‍♀️" ;

		public const string WomanSwimmingMediumDarkSkinTone2 = "🏊🏾‍♀" ;

		public const string WomanSwimmingDarkSkinTone = "🏊🏿‍♀️" ;

		public const string WomanSwimmingDarkSkinTone2 = "🏊🏿‍♀" ;

		public const string PersonBouncingBall = "⛹️" ;

		public const string PersonBouncingBall2 = "⛹" ;

		public const string PersonBouncingBallLightSkinTone = "⛹🏻" ;

		public const string PersonBouncingBallMediumLightSkinTone = "⛹🏼" ;

		public const string PersonBouncingBallMediumSkinTone = "⛹🏽" ;

		public const string PersonBouncingBallMediumDarkSkinTone = "⛹🏾" ;

		public const string PersonBouncingBallDarkSkinTone = "⛹🏿" ;

		public const string ManBouncingBall = "⛹️‍♂️" ;

		public const string ManBouncingBall2 = "⛹‍♂️" ;

		public const string ManBouncingBall3 = "⛹️‍♂" ;

		public const string ManBouncingBall4 = "⛹‍♂" ;

		public const string ManBouncingBallLightSkinTone = "⛹🏻‍♂️" ;

		public const string ManBouncingBallLightSkinTone2 = "⛹🏻‍♂" ;

		public const string ManBouncingBallMediumLightSkinTone = "⛹🏼‍♂️" ;

		public const string ManBouncingBallMediumLightSkinTone2 = "⛹🏼‍♂" ;

		public const string ManBouncingBallMediumSkinTone = "⛹🏽‍♂️" ;

		public const string ManBouncingBallMediumSkinTone2 = "⛹🏽‍♂" ;

		public const string ManBouncingBallMediumDarkSkinTone = "⛹🏾‍♂️" ;

		public const string ManBouncingBallMediumDarkSkinTone2 = "⛹🏾‍♂" ;

		public const string ManBouncingBallDarkSkinTone = "⛹🏿‍♂️" ;

		public const string ManBouncingBallDarkSkinTone2 = "⛹🏿‍♂" ;

		public const string WomanBouncingBall = "⛹️‍♀️" ;

		public const string WomanBouncingBall2 = "⛹‍♀️" ;

		public const string WomanBouncingBall3 = "⛹️‍♀" ;

		public const string WomanBouncingBall4 = "⛹‍♀" ;

		public const string WomanBouncingBallLightSkinTone = "⛹🏻‍♀️" ;

		public const string WomanBouncingBallLightSkinTone2 = "⛹🏻‍♀" ;

		public const string WomanBouncingBallMediumLightSkinTone = "⛹🏼‍♀️" ;

		public const string WomanBouncingBallMediumLightSkinTone2 = "⛹🏼‍♀" ;

		public const string WomanBouncingBallMediumSkinTone = "⛹🏽‍♀️" ;

		public const string WomanBouncingBallMediumSkinTone2 = "⛹🏽‍♀" ;

		public const string WomanBouncingBallMediumDarkSkinTone = "⛹🏾‍♀️" ;

		public const string WomanBouncingBallMediumDarkSkinTone2 = "⛹🏾‍♀" ;

		public const string WomanBouncingBallDarkSkinTone = "⛹🏿‍♀️" ;

		public const string WomanBouncingBallDarkSkinTone2 = "⛹🏿‍♀" ;

		public const string PersonLiftingWeights = "🏋️" ;

		public const string PersonLiftingWeights2 = "🏋" ;

		public const string PersonLiftingWeightsLightSkinTone = "🏋🏻" ;

		public const string PersonLiftingWeightsMediumLightSkinTone = "🏋🏼" ;

		public const string PersonLiftingWeightsMediumSkinTone = "🏋🏽" ;

		public const string PersonLiftingWeightsMediumDarkSkinTone = "🏋🏾" ;

		public const string PersonLiftingWeightsDarkSkinTone = "🏋🏿" ;

		public const string ManLiftingWeights = "🏋️‍♂️" ;

		public const string ManLiftingWeights2 = "🏋‍♂️" ;

		public const string ManLiftingWeights3 = "🏋️‍♂" ;

		public const string ManLiftingWeights4 = "🏋‍♂" ;

		public const string ManLiftingWeightsLightSkinTone = "🏋🏻‍♂️" ;

		public const string ManLiftingWeightsLightSkinTone2 = "🏋🏻‍♂" ;

		public const string ManLiftingWeightsMediumLightSkinTone = "🏋🏼‍♂️" ;

		public const string ManLiftingWeightsMediumLightSkinTone2 = "🏋🏼‍♂" ;

		public const string ManLiftingWeightsMediumSkinTone = "🏋🏽‍♂️" ;

		public const string ManLiftingWeightsMediumSkinTone2 = "🏋🏽‍♂" ;

		public const string ManLiftingWeightsMediumDarkSkinTone = "🏋🏾‍♂️" ;

		public const string ManLiftingWeightsMediumDarkSkinTone2 = "🏋🏾‍♂" ;

		public const string ManLiftingWeightsDarkSkinTone = "🏋🏿‍♂️" ;

		public const string ManLiftingWeightsDarkSkinTone2 = "🏋🏿‍♂" ;

		public const string WomanLiftingWeights = "🏋️‍♀️" ;

		public const string WomanLiftingWeights2 = "🏋‍♀️" ;

		public const string WomanLiftingWeights3 = "🏋️‍♀" ;

		public const string WomanLiftingWeights4 = "🏋‍♀" ;

		public const string WomanLiftingWeightsLightSkinTone = "🏋🏻‍♀️" ;

		public const string WomanLiftingWeightsLightSkinTone2 = "🏋🏻‍♀" ;

		public const string WomanLiftingWeightsMediumLightSkinTone = "🏋🏼‍♀️" ;

		public const string WomanLiftingWeightsMediumLightSkinTone2 = "🏋🏼‍♀" ;

		public const string WomanLiftingWeightsMediumSkinTone = "🏋🏽‍♀️" ;

		public const string WomanLiftingWeightsMediumSkinTone2 = "🏋🏽‍♀" ;

		public const string WomanLiftingWeightsMediumDarkSkinTone = "🏋🏾‍♀️" ;

		public const string WomanLiftingWeightsMediumDarkSkinTone2 = "🏋🏾‍♀" ;

		public const string WomanLiftingWeightsDarkSkinTone = "🏋🏿‍♀️" ;

		public const string WomanLiftingWeightsDarkSkinTone2 = "🏋🏿‍♀" ;

		public const string PersonBiking = "🚴" ;

		public const string PersonBikingLightSkinTone = "🚴🏻" ;

		public const string PersonBikingMediumLightSkinTone = "🚴🏼" ;

		public const string PersonBikingMediumSkinTone = "🚴🏽" ;

		public const string PersonBikingMediumDarkSkinTone = "🚴🏾" ;

		public const string PersonBikingDarkSkinTone = "🚴🏿" ;

		public const string ManBiking = "🚴‍♂️" ;

		public const string ManBiking2 = "🚴‍♂" ;

		public const string ManBikingLightSkinTone = "🚴🏻‍♂️" ;

		public const string ManBikingLightSkinTone2 = "🚴🏻‍♂" ;

		public const string ManBikingMediumLightSkinTone = "🚴🏼‍♂️" ;

		public const string ManBikingMediumLightSkinTone2 = "🚴🏼‍♂" ;

		public const string ManBikingMediumSkinTone = "🚴🏽‍♂️" ;

		public const string ManBikingMediumSkinTone2 = "🚴🏽‍♂" ;

		public const string ManBikingMediumDarkSkinTone = "🚴🏾‍♂️" ;

		public const string ManBikingMediumDarkSkinTone2 = "🚴🏾‍♂" ;

		public const string ManBikingDarkSkinTone = "🚴🏿‍♂️" ;

		public const string ManBikingDarkSkinTone2 = "🚴🏿‍♂" ;

		public const string WomanBiking = "🚴‍♀️" ;

		public const string WomanBiking2 = "🚴‍♀" ;

		public const string WomanBikingLightSkinTone = "🚴🏻‍♀️" ;

		public const string WomanBikingLightSkinTone2 = "🚴🏻‍♀" ;

		public const string WomanBikingMediumLightSkinTone = "🚴🏼‍♀️" ;

		public const string WomanBikingMediumLightSkinTone2 = "🚴🏼‍♀" ;

		public const string WomanBikingMediumSkinTone = "🚴🏽‍♀️" ;

		public const string WomanBikingMediumSkinTone2 = "🚴🏽‍♀" ;

		public const string WomanBikingMediumDarkSkinTone = "🚴🏾‍♀️" ;

		public const string WomanBikingMediumDarkSkinTone2 = "🚴🏾‍♀" ;

		public const string WomanBikingDarkSkinTone = "🚴🏿‍♀️" ;

		public const string WomanBikingDarkSkinTone2 = "🚴🏿‍♀" ;

		public const string PersonMountainBiking = "🚵" ;

		public const string PersonMountainBikingLightSkinTone = "🚵🏻" ;

		public const string PersonMountainBikingMediumLightSkinTone = "🚵🏼" ;

		public const string PersonMountainBikingMediumSkinTone = "🚵🏽" ;

		public const string PersonMountainBikingMediumDarkSkinTone = "🚵🏾" ;

		public const string PersonMountainBikingDarkSkinTone = "🚵🏿" ;

		public const string ManMountainBiking = "🚵‍♂️" ;

		public const string ManMountainBiking2 = "🚵‍♂" ;

		public const string ManMountainBikingLightSkinTone = "🚵🏻‍♂️" ;

		public const string ManMountainBikingLightSkinTone2 = "🚵🏻‍♂" ;

		public const string ManMountainBikingMediumLightSkinTone = "🚵🏼‍♂️" ;

		public const string ManMountainBikingMediumLightSkinTone2 = "🚵🏼‍♂" ;

		public const string ManMountainBikingMediumSkinTone = "🚵🏽‍♂️" ;

		public const string ManMountainBikingMediumSkinTone2 = "🚵🏽‍♂" ;

		public const string ManMountainBikingMediumDarkSkinTone = "🚵🏾‍♂️" ;

		public const string ManMountainBikingMediumDarkSkinTone2 = "🚵🏾‍♂" ;

		public const string ManMountainBikingDarkSkinTone = "🚵🏿‍♂️" ;

		public const string ManMountainBikingDarkSkinTone2 = "🚵🏿‍♂" ;

		public const string WomanMountainBiking = "🚵‍♀️" ;

		public const string WomanMountainBiking2 = "🚵‍♀" ;

		public const string WomanMountainBikingLightSkinTone = "🚵🏻‍♀️" ;

		public const string WomanMountainBikingLightSkinTone2 = "🚵🏻‍♀" ;

		public const string WomanMountainBikingMediumLightSkinTone = "🚵🏼‍♀️" ;

		public const string WomanMountainBikingMediumLightSkinTone2 = "🚵🏼‍♀" ;

		public const string WomanMountainBikingMediumSkinTone = "🚵🏽‍♀️" ;

		public const string WomanMountainBikingMediumSkinTone2 = "🚵🏽‍♀" ;

		public const string WomanMountainBikingMediumDarkSkinTone = "🚵🏾‍♀️" ;

		public const string WomanMountainBikingMediumDarkSkinTone2 = "🚵🏾‍♀" ;

		public const string WomanMountainBikingDarkSkinTone = "🚵🏿‍♀️" ;

		public const string WomanMountainBikingDarkSkinTone2 = "🚵🏿‍♀" ;

		public const string PersonCartwheeling = "🤸" ;

		public const string PersonCartwheelingLightSkinTone = "🤸🏻" ;

		public const string PersonCartwheelingMediumLightSkinTone = "🤸🏼" ;

		public const string PersonCartwheelingMediumSkinTone = "🤸🏽" ;

		public const string PersonCartwheelingMediumDarkSkinTone = "🤸🏾" ;

		public const string PersonCartwheelingDarkSkinTone = "🤸🏿" ;

		public const string ManCartwheeling = "🤸‍♂️" ;

		public const string ManCartwheeling2 = "🤸‍♂" ;

		public const string ManCartwheelingLightSkinTone = "🤸🏻‍♂️" ;

		public const string ManCartwheelingLightSkinTone2 = "🤸🏻‍♂" ;

		public const string ManCartwheelingMediumLightSkinTone = "🤸🏼‍♂️" ;

		public const string ManCartwheelingMediumLightSkinTone2 = "🤸🏼‍♂" ;

		public const string ManCartwheelingMediumSkinTone = "🤸🏽‍♂️" ;

		public const string ManCartwheelingMediumSkinTone2 = "🤸🏽‍♂" ;

		public const string ManCartwheelingMediumDarkSkinTone = "🤸🏾‍♂️" ;

		public const string ManCartwheelingMediumDarkSkinTone2 = "🤸🏾‍♂" ;

		public const string ManCartwheelingDarkSkinTone = "🤸🏿‍♂️" ;

		public const string ManCartwheelingDarkSkinTone2 = "🤸🏿‍♂" ;

		public const string WomanCartwheeling = "🤸‍♀️" ;

		public const string WomanCartwheeling2 = "🤸‍♀" ;

		public const string WomanCartwheelingLightSkinTone = "🤸🏻‍♀️" ;

		public const string WomanCartwheelingLightSkinTone2 = "🤸🏻‍♀" ;

		public const string WomanCartwheelingMediumLightSkinTone = "🤸🏼‍♀️" ;

		public const string WomanCartwheelingMediumLightSkinTone2 = "🤸🏼‍♀" ;

		public const string WomanCartwheelingMediumSkinTone = "🤸🏽‍♀️" ;

		public const string WomanCartwheelingMediumSkinTone2 = "🤸🏽‍♀" ;

		public const string WomanCartwheelingMediumDarkSkinTone = "🤸🏾‍♀️" ;

		public const string WomanCartwheelingMediumDarkSkinTone2 = "🤸🏾‍♀" ;

		public const string WomanCartwheelingDarkSkinTone = "🤸🏿‍♀️" ;

		public const string WomanCartwheelingDarkSkinTone2 = "🤸🏿‍♀" ;

		public const string PeopleWrestling = "🤼" ;

		public const string PeopleWrestlingLightSkinTone = "🤼🏻" ;

		public const string PeopleWrestlingMediumLightSkinTone = "🤼🏼" ;

		public const string PeopleWrestlingMediumSkinTone = "🤼🏽" ;

		public const string PeopleWrestlingMediumDarkSkinTone = "🤼🏾" ;

		public const string PeopleWrestlingDarkSkinTone = "🤼🏿" ;

		public const string MenWrestling = "🤼‍♂️" ;

		public const string MenWrestling2 = "🤼‍♂" ;

		public const string MenWrestlingLightSkinTone = "🤼🏻‍♂️" ;

		public const string MenWrestlingLightSkinTone2 = "🤼🏻‍♂" ;

		public const string MenWrestlingMediumLightSkinTone = "🤼🏼‍♂️" ;

		public const string MenWrestlingMediumLightSkinTone2 = "🤼🏼‍♂" ;

		public const string MenWrestlingMediumSkinTone = "🤼🏽‍♂️" ;

		public const string MenWrestlingMediumSkinTone2 = "🤼🏽‍♂" ;

		public const string MenWrestlingMediumDarkSkinTone = "🤼🏾‍♂️" ;

		public const string MenWrestlingMediumDarkSkinTone2 = "🤼🏾‍♂" ;

		public const string MenWrestlingDarkSkinTone = "🤼🏿‍♂️" ;

		public const string MenWrestlingDarkSkinTone2 = "🤼🏿‍♂" ;

		public const string WomenWrestling = "🤼‍♀️" ;

		public const string WomenWrestling2 = "🤼‍♀" ;

		public const string WomenWrestlingLightSkinTone = "🤼🏻‍♀️" ;

		public const string WomenWrestlingLightSkinTone2 = "🤼🏻‍♀" ;

		public const string WomenWrestlingMediumLightSkinTone = "🤼🏼‍♀️" ;

		public const string WomenWrestlingMediumLightSkinTone2 = "🤼🏼‍♀" ;

		public const string WomenWrestlingMediumSkinTone = "🤼🏽‍♀️" ;

		public const string WomenWrestlingMediumSkinTone2 = "🤼🏽‍♀" ;

		public const string WomenWrestlingMediumDarkSkinTone = "🤼🏾‍♀️" ;

		public const string WomenWrestlingMediumDarkSkinTone2 = "🤼🏾‍♀" ;

		public const string WomenWrestlingDarkSkinTone = "🤼🏿‍♀️" ;

		public const string WomenWrestlingDarkSkinTone2 = "🤼🏿‍♀" ;

		public const string PersonPlayingWaterPolo = "🤽" ;

		public const string PersonPlayingWaterPoloLightSkinTone = "🤽🏻" ;

		public const string PersonPlayingWaterPoloMediumLightSkinTone = "🤽🏼" ;

		public const string PersonPlayingWaterPoloMediumSkinTone = "🤽🏽" ;

		public const string PersonPlayingWaterPoloMediumDarkSkinTone = "🤽🏾" ;

		public const string PersonPlayingWaterPoloDarkSkinTone = "🤽🏿" ;

		public const string ManPlayingWaterPolo = "🤽‍♂️" ;

		public const string ManPlayingWaterPolo2 = "🤽‍♂" ;

		public const string ManPlayingWaterPoloLightSkinTone = "🤽🏻‍♂️" ;

		public const string ManPlayingWaterPoloLightSkinTone2 = "🤽🏻‍♂" ;

		public const string ManPlayingWaterPoloMediumLightSkinTone = "🤽🏼‍♂️" ;

		public const string ManPlayingWaterPoloMediumLightSkinTone2 = "🤽🏼‍♂" ;

		public const string ManPlayingWaterPoloMediumSkinTone = "🤽🏽‍♂️" ;

		public const string ManPlayingWaterPoloMediumSkinTone2 = "🤽🏽‍♂" ;

		public const string ManPlayingWaterPoloMediumDarkSkinTone = "🤽🏾‍♂️" ;

		public const string ManPlayingWaterPoloMediumDarkSkinTone2 = "🤽🏾‍♂" ;

		public const string ManPlayingWaterPoloDarkSkinTone = "🤽🏿‍♂️" ;

		public const string ManPlayingWaterPoloDarkSkinTone2 = "🤽🏿‍♂" ;

		public const string WomanPlayingWaterPolo = "🤽‍♀️" ;

		public const string WomanPlayingWaterPolo2 = "🤽‍♀" ;

		public const string WomanPlayingWaterPoloLightSkinTone = "🤽🏻‍♀️" ;

		public const string WomanPlayingWaterPoloLightSkinTone2 = "🤽🏻‍♀" ;

		public const string WomanPlayingWaterPoloMediumLightSkinTone = "🤽🏼‍♀️" ;

		public const string WomanPlayingWaterPoloMediumLightSkinTone2 = "🤽🏼‍♀" ;

		public const string WomanPlayingWaterPoloMediumSkinTone = "🤽🏽‍♀️" ;

		public const string WomanPlayingWaterPoloMediumSkinTone2 = "🤽🏽‍♀" ;

		public const string WomanPlayingWaterPoloMediumDarkSkinTone = "🤽🏾‍♀️" ;

		public const string WomanPlayingWaterPoloMediumDarkSkinTone2 = "🤽🏾‍♀" ;

		public const string WomanPlayingWaterPoloDarkSkinTone = "🤽🏿‍♀️" ;

		public const string WomanPlayingWaterPoloDarkSkinTone2 = "🤽🏿‍♀" ;

		public const string PersonPlayingHandball = "🤾" ;

		public const string PersonPlayingHandballLightSkinTone = "🤾🏻" ;

		public const string PersonPlayingHandballMediumLightSkinTone = "🤾🏼" ;

		public const string PersonPlayingHandballMediumSkinTone = "🤾🏽" ;

		public const string PersonPlayingHandballMediumDarkSkinTone = "🤾🏾" ;

		public const string PersonPlayingHandballDarkSkinTone = "🤾🏿" ;

		public const string ManPlayingHandball = "🤾‍♂️" ;

		public const string ManPlayingHandball2 = "🤾‍♂" ;

		public const string ManPlayingHandballLightSkinTone = "🤾🏻‍♂️" ;

		public const string ManPlayingHandballLightSkinTone2 = "🤾🏻‍♂" ;

		public const string ManPlayingHandballMediumLightSkinTone = "🤾🏼‍♂️" ;

		public const string ManPlayingHandballMediumLightSkinTone2 = "🤾🏼‍♂" ;

		public const string ManPlayingHandballMediumSkinTone = "🤾🏽‍♂️" ;

		public const string ManPlayingHandballMediumSkinTone2 = "🤾🏽‍♂" ;

		public const string ManPlayingHandballMediumDarkSkinTone = "🤾🏾‍♂️" ;

		public const string ManPlayingHandballMediumDarkSkinTone2 = "🤾🏾‍♂" ;

		public const string ManPlayingHandballDarkSkinTone = "🤾🏿‍♂️" ;

		public const string ManPlayingHandballDarkSkinTone2 = "🤾🏿‍♂" ;

		public const string WomanPlayingHandball = "🤾‍♀️" ;

		public const string WomanPlayingHandball2 = "🤾‍♀" ;

		public const string WomanPlayingHandballLightSkinTone = "🤾🏻‍♀️" ;

		public const string WomanPlayingHandballLightSkinTone2 = "🤾🏻‍♀" ;

		public const string WomanPlayingHandballMediumLightSkinTone = "🤾🏼‍♀️" ;

		public const string WomanPlayingHandballMediumLightSkinTone2 = "🤾🏼‍♀" ;

		public const string WomanPlayingHandballMediumSkinTone = "🤾🏽‍♀️" ;

		public const string WomanPlayingHandballMediumSkinTone2 = "🤾🏽‍♀" ;

		public const string WomanPlayingHandballMediumDarkSkinTone = "🤾🏾‍♀️" ;

		public const string WomanPlayingHandballMediumDarkSkinTone2 = "🤾🏾‍♀" ;

		public const string WomanPlayingHandballDarkSkinTone = "🤾🏿‍♀️" ;

		public const string WomanPlayingHandballDarkSkinTone2 = "🤾🏿‍♀" ;

		public const string PersonJuggling = "🤹" ;

		public const string PersonJugglingLightSkinTone = "🤹🏻" ;

		public const string PersonJugglingMediumLightSkinTone = "🤹🏼" ;

		public const string PersonJugglingMediumSkinTone = "🤹🏽" ;

		public const string PersonJugglingMediumDarkSkinTone = "🤹🏾" ;

		public const string PersonJugglingDarkSkinTone = "🤹🏿" ;

		public const string ManJuggling = "🤹‍♂️" ;

		public const string ManJuggling2 = "🤹‍♂" ;

		public const string ManJugglingLightSkinTone = "🤹🏻‍♂️" ;

		public const string ManJugglingLightSkinTone2 = "🤹🏻‍♂" ;

		public const string ManJugglingMediumLightSkinTone = "🤹🏼‍♂️" ;

		public const string ManJugglingMediumLightSkinTone2 = "🤹🏼‍♂" ;

		public const string ManJugglingMediumSkinTone = "🤹🏽‍♂️" ;

		public const string ManJugglingMediumSkinTone2 = "🤹🏽‍♂" ;

		public const string ManJugglingMediumDarkSkinTone = "🤹🏾‍♂️" ;

		public const string ManJugglingMediumDarkSkinTone2 = "🤹🏾‍♂" ;

		public const string ManJugglingDarkSkinTone = "🤹🏿‍♂️" ;

		public const string ManJugglingDarkSkinTone2 = "🤹🏿‍♂" ;

		public const string WomanJuggling = "🤹‍♀️" ;

		public const string WomanJuggling2 = "🤹‍♀" ;

		public const string WomanJugglingLightSkinTone = "🤹🏻‍♀️" ;

		public const string WomanJugglingLightSkinTone2 = "🤹🏻‍♀" ;

		public const string WomanJugglingMediumLightSkinTone = "🤹🏼‍♀️" ;

		public const string WomanJugglingMediumLightSkinTone2 = "🤹🏼‍♀" ;

		public const string WomanJugglingMediumSkinTone = "🤹🏽‍♀️" ;

		public const string WomanJugglingMediumSkinTone2 = "🤹🏽‍♀" ;

		public const string WomanJugglingMediumDarkSkinTone = "🤹🏾‍♀️" ;

		public const string WomanJugglingMediumDarkSkinTone2 = "🤹🏾‍♀" ;

		public const string WomanJugglingDarkSkinTone = "🤹🏿‍♀️" ;

		public const string WomanJugglingDarkSkinTone2 = "🤹🏿‍♀" ;

		public const string PersonInLotusPosition = "🧘" ;

		public const string PersonInLotusPositionLightSkinTone = "🧘🏻" ;

		public const string PersonInLotusPositionMediumLightSkinTone = "🧘🏼" ;

		public const string PersonInLotusPositionMediumSkinTone = "🧘🏽" ;

		public const string PersonInLotusPositionMediumDarkSkinTone = "🧘🏾" ;

		public const string PersonInLotusPositionDarkSkinTone = "🧘🏿" ;

		public const string ManInLotusPosition = "🧘‍♂️" ;

		public const string ManInLotusPosition2 = "🧘‍♂" ;

		public const string ManInLotusPositionLightSkinTone = "🧘🏻‍♂️" ;

		public const string ManInLotusPositionLightSkinTone2 = "🧘🏻‍♂" ;

		public const string ManInLotusPositionMediumLightSkinTone = "🧘🏼‍♂️" ;

		public const string ManInLotusPositionMediumLightSkinTone2 = "🧘🏼‍♂" ;

		public const string ManInLotusPositionMediumSkinTone = "🧘🏽‍♂️" ;

		public const string ManInLotusPositionMediumSkinTone2 = "🧘🏽‍♂" ;

		public const string ManInLotusPositionMediumDarkSkinTone = "🧘🏾‍♂️" ;

		public const string ManInLotusPositionMediumDarkSkinTone2 = "🧘🏾‍♂" ;

		public const string ManInLotusPositionDarkSkinTone = "🧘🏿‍♂️" ;

		public const string ManInLotusPositionDarkSkinTone2 = "🧘🏿‍♂" ;

		public const string WomanInLotusPosition = "🧘‍♀️" ;

		public const string WomanInLotusPosition2 = "🧘‍♀" ;

		public const string WomanInLotusPositionLightSkinTone = "🧘🏻‍♀️" ;

		public const string WomanInLotusPositionLightSkinTone2 = "🧘🏻‍♀" ;

		public const string WomanInLotusPositionMediumLightSkinTone = "🧘🏼‍♀️" ;

		public const string WomanInLotusPositionMediumLightSkinTone2 = "🧘🏼‍♀" ;

		public const string WomanInLotusPositionMediumSkinTone = "🧘🏽‍♀️" ;

		public const string WomanInLotusPositionMediumSkinTone2 = "🧘🏽‍♀" ;

		public const string WomanInLotusPositionMediumDarkSkinTone = "🧘🏾‍♀️" ;

		public const string WomanInLotusPositionMediumDarkSkinTone2 = "🧘🏾‍♀" ;

		public const string WomanInLotusPositionDarkSkinTone = "🧘🏿‍♀️" ;

		public const string WomanInLotusPositionDarkSkinTone2 = "🧘🏿‍♀" ;

		public const string PersonTakingBath = "🛀" ;

		public const string PersonTakingBathLightSkinTone = "🛀🏻" ;

		public const string PersonTakingBathMediumLightSkinTone = "🛀🏼" ;

		public const string PersonTakingBathMediumSkinTone = "🛀🏽" ;

		public const string PersonTakingBathMediumDarkSkinTone = "🛀🏾" ;

		public const string PersonTakingBathDarkSkinTone = "🛀🏿" ;

		public const string PersonInBed = "🛌" ;

		public const string PersonInBedLightSkinTone = "🛌🏻" ;

		public const string PersonInBedMediumLightSkinTone = "🛌🏼" ;

		public const string PersonInBedMediumSkinTone = "🛌🏽" ;

		public const string PersonInBedMediumDarkSkinTone = "🛌🏾" ;

		public const string PersonInBedDarkSkinTone = "🛌🏿" ;

		public const string WomenHoldingHands = "👭" ;

		public const string WomenHoldingHandsLightSkinTone = "👭🏻" ;

		public const string WomenHoldingHandsMediumLightSkinToneLightSkinTone = "👩🏼‍🤝‍👩🏻" ;

		public const string WomenHoldingHandsMediumLightSkinTone = "👭🏼" ;

		public const string WomenHoldingHandsMediumSkinToneLightSkinTone = "👩🏽‍🤝‍👩🏻" ;

		public const string WomenHoldingHandsMediumSkinToneMediumLightSkinTone = "👩🏽‍🤝‍👩🏼" ;

		public const string WomenHoldingHandsMediumSkinTone = "👭🏽" ;

		public const string WomenHoldingHandsMediumDarkSkinToneLightSkinTone = "👩🏾‍🤝‍👩🏻" ;

		public const string WomenHoldingHandsMediumDarkSkinToneMediumLightSkinTone = "👩🏾‍🤝‍👩🏼" ;

		public const string WomenHoldingHandsMediumDarkSkinToneMediumSkinTone = "👩🏾‍🤝‍👩🏽" ;

		public const string WomenHoldingHandsMediumDarkSkinTone = "👭🏾" ;

		public const string WomenHoldingHandsDarkSkinToneLightSkinTone = "👩🏿‍🤝‍👩🏻" ;

		public const string WomenHoldingHandsDarkSkinToneMediumLightSkinTone = "👩🏿‍🤝‍👩🏼" ;

		public const string WomenHoldingHandsDarkSkinToneMediumSkinTone = "👩🏿‍🤝‍👩🏽" ;

		public const string WomenHoldingHandsDarkSkinToneMediumDarkSkinTone = "👩🏿‍🤝‍👩🏾" ;

		public const string WomenHoldingHandsDarkSkinTone = "👭🏿" ;

		public const string WomanAndManHoldingHands = "👫" ;

		public const string WomanAndManHoldingHandsLightSkinTone = "👫🏻" ;

		public const string WomanAndManHoldingHandsLightSkinToneMediumLightSkinTone = "👩🏻‍🤝‍👨🏼" ;

		public const string WomanAndManHoldingHandsLightSkinToneMediumSkinTone = "👩🏻‍🤝‍👨🏽" ;

		public const string WomanAndManHoldingHandsLightSkinToneMediumDarkSkinTone = "👩🏻‍🤝‍👨🏾" ;

		public const string WomanAndManHoldingHandsLightSkinToneDarkSkinTone = "👩🏻‍🤝‍👨🏿" ;

		public const string WomanAndManHoldingHandsMediumLightSkinToneLightSkinTone = "👩🏼‍🤝‍👨🏻" ;

		public const string WomanAndManHoldingHandsMediumLightSkinTone = "👫🏼" ;

		public const string WomanAndManHoldingHandsMediumLightSkinToneMediumSkinTone = "👩🏼‍🤝‍👨🏽" ;

		public const string WomanAndManHoldingHandsMediumLightSkinToneMediumDarkSkinTone = "👩🏼‍🤝‍👨🏾" ;

		public const string WomanAndManHoldingHandsMediumLightSkinToneDarkSkinTone = "👩🏼‍🤝‍👨🏿" ;

		public const string WomanAndManHoldingHandsMediumSkinToneLightSkinTone = "👩🏽‍🤝‍👨🏻" ;

		public const string WomanAndManHoldingHandsMediumSkinToneMediumLightSkinTone = "👩🏽‍🤝‍👨🏼" ;

		public const string WomanAndManHoldingHandsMediumSkinTone = "👫🏽" ;

		public const string WomanAndManHoldingHandsMediumSkinToneMediumDarkSkinTone = "👩🏽‍🤝‍👨🏾" ;

		public const string WomanAndManHoldingHandsMediumSkinToneDarkSkinTone = "👩🏽‍🤝‍👨🏿" ;

		public const string WomanAndManHoldingHandsMediumDarkSkinToneLightSkinTone = "👩🏾‍🤝‍👨🏻" ;

		public const string WomanAndManHoldingHandsMediumDarkSkinToneMediumLightSkinTone = "👩🏾‍🤝‍👨🏼" ;

		public const string WomanAndManHoldingHandsMediumDarkSkinToneMediumSkinTone = "👩🏾‍🤝‍👨🏽" ;

		public const string WomanAndManHoldingHandsMediumDarkSkinTone = "👫🏾" ;

		public const string WomanAndManHoldingHandsMediumDarkSkinToneDarkSkinTone = "👩🏾‍🤝‍👨🏿" ;

		public const string WomanAndManHoldingHandsDarkSkinToneLightSkinTone = "👩🏿‍🤝‍👨🏻" ;

		public const string WomanAndManHoldingHandsDarkSkinToneMediumLightSkinTone = "👩🏿‍🤝‍👨🏼" ;

		public const string WomanAndManHoldingHandsDarkSkinToneMediumSkinTone = "👩🏿‍🤝‍👨🏽" ;

		public const string WomanAndManHoldingHandsDarkSkinToneMediumDarkSkinTone = "👩🏿‍🤝‍👨🏾" ;

		public const string WomanAndManHoldingHandsDarkSkinTone = "👫🏿" ;

		public const string MenHoldingHands = "👬" ;

		public const string MenHoldingHandsLightSkinTone = "👬🏻" ;

		public const string MenHoldingHandsMediumLightSkinToneLightSkinTone = "👨🏼‍🤝‍👨🏻" ;

		public const string MenHoldingHandsMediumLightSkinTone = "👬🏼" ;

		public const string MenHoldingHandsMediumSkinToneLightSkinTone = "👨🏽‍🤝‍👨🏻" ;

		public const string MenHoldingHandsMediumSkinToneMediumLightSkinTone = "👨🏽‍🤝‍👨🏼" ;

		public const string MenHoldingHandsMediumSkinTone = "👬🏽" ;

		public const string MenHoldingHandsMediumDarkSkinToneLightSkinTone = "👨🏾‍🤝‍👨🏻" ;

		public const string MenHoldingHandsMediumDarkSkinToneMediumLightSkinTone = "👨🏾‍🤝‍👨🏼" ;

		public const string MenHoldingHandsMediumDarkSkinToneMediumSkinTone = "👨🏾‍🤝‍👨🏽" ;

		public const string MenHoldingHandsMediumDarkSkinTone = "👬🏾" ;

		public const string MenHoldingHandsDarkSkinToneLightSkinTone = "👨🏿‍🤝‍👨🏻" ;

		public const string MenHoldingHandsDarkSkinToneMediumLightSkinTone = "👨🏿‍🤝‍👨🏼" ;

		public const string MenHoldingHandsDarkSkinToneMediumSkinTone = "👨🏿‍🤝‍👨🏽" ;

		public const string MenHoldingHandsDarkSkinToneMediumDarkSkinTone = "👨🏿‍🤝‍👨🏾" ;

		public const string MenHoldingHandsDarkSkinTone = "👬🏿" ;

		public const string Kiss = "💏" ;

		public const string KissLightSkinTone = "💏🏻" ;

		public const string KissMediumLightSkinTone = "💏🏼" ;

		public const string KissMediumSkinTone = "💏🏽" ;

		public const string KissMediumDarkSkinTone = "💏🏾" ;

		public const string KissDarkSkinTone = "💏🏿" ;

		public const string KissWomanMan = "👩‍❤️‍💋‍👨" ;

		public const string KissWomanMan2 = "👩‍❤‍💋‍👨" ;

		public const string KissManMan = "👨‍❤️‍💋‍👨" ;

		public const string KissManMan2 = "👨‍❤‍💋‍👨" ;

		public const string KissWomanWoman = "👩‍❤️‍💋‍👩" ;

		public const string KissWomanWoman2 = "👩‍❤‍💋‍👩" ;

		public const string CoupleWithHeart = "💑" ;

		public const string CoupleWithHeartLightSkinTone = "💑🏻" ;

		public const string CoupleWithHeartMediumLightSkinTone = "💑🏼" ;

		public const string CoupleWithHeartMediumSkinTone = "💑🏽" ;

		public const string CoupleWithHeartMediumDarkSkinTone = "💑🏾" ;

		public const string CoupleWithHeartDarkSkinTone = "💑🏿" ;

		public const string CoupleWithHeartWomanMan = "👩‍❤️‍👨" ;

		public const string CoupleWithHeartWomanMan2 = "👩‍❤‍👨" ;

		public const string CoupleWithHeartManMan = "👨‍❤️‍👨" ;

		public const string CoupleWithHeartManMan2 = "👨‍❤‍👨" ;

		public const string CoupleWithHeartWomanWoman = "👩‍❤️‍👩" ;

		public const string CoupleWithHeartWomanWoman2 = "👩‍❤‍👩" ;

		public const string Family = "👪" ;

		public const string FamilyLightSkinTone = "👪🏻" ;

		public const string FamilyMediumLightSkinTone = "👪🏼" ;

		public const string FamilyMediumSkinTone = "👪🏽" ;

		public const string FamilyMediumDarkSkinTone = "👪🏾" ;

		public const string FamilyDarkSkinTone = "👪🏿" ;

		public const string FamilyManWomanBoy = "👨‍👩‍👦" ;

		public const string FamilyManWomanGirl = "👨‍👩‍👧" ;

		public const string FamilyManWomanGirlBoy = "👨‍👩‍👧‍👦" ;

		public const string FamilyManWomanBoyBoy = "👨‍👩‍👦‍👦" ;

		public const string FamilyManWomanGirlGirl = "👨‍👩‍👧‍👧" ;

		public const string FamilyManManBoy = "👨‍👨‍👦" ;

		public const string FamilyManManGirl = "👨‍👨‍👧" ;

		public const string FamilyManManGirlBoy = "👨‍👨‍👧‍👦" ;

		public const string FamilyManManBoyBoy = "👨‍👨‍👦‍👦" ;

		public const string FamilyManManGirlGirl = "👨‍👨‍👧‍👧" ;

		public const string FamilyWomanWomanBoy = "👩‍👩‍👦" ;

		public const string FamilyWomanWomanGirl = "👩‍👩‍👧" ;

		public const string FamilyWomanWomanGirlBoy = "👩‍👩‍👧‍👦" ;

		public const string FamilyWomanWomanBoyBoy = "👩‍👩‍👦‍👦" ;

		public const string FamilyWomanWomanGirlGirl = "👩‍👩‍👧‍👧" ;

		public const string FamilyManBoy = "👨‍👦" ;

		public const string FamilyManBoyBoy = "👨‍👦‍👦" ;

		public const string FamilyManGirl = "👨‍👧" ;

		public const string FamilyManGirlBoy = "👨‍👧‍👦" ;

		public const string FamilyManGirlGirl = "👨‍👧‍👧" ;

		public const string FamilyWomanBoy = "👩‍👦" ;

		public const string FamilyWomanBoyBoy = "👩‍👦‍👦" ;

		public const string FamilyWomanGirl = "👩‍👧" ;

		public const string FamilyWomanGirlBoy = "👩‍👧‍👦" ;

		public const string FamilyWomanGirlGirl = "👩‍👧‍👧" ;

		public const string SpeakingHead = "🗣️" ;

		public const string SpeakingHead2 = "🗣" ;

		public const string BustInSilhouette = "👤" ;

		public const string BustsInSilhouette = "👥" ;

		public const string Footprints = "👣" ;

		public const string LightSkinTone = "🏻" ;

		public const string MediumLightSkinTone = "🏼" ;

		public const string MediumSkinTone = "🏽" ;

		public const string MediumDarkSkinTone = "🏾" ;

		public const string DarkSkinTone = "🏿" ;

		public const string RedHair = "🦰" ;

		public const string CurlyHair = "🦱" ;

		public const string WhiteHair = "🦳" ;

		public const string Bald = "🦲" ;

		public const string MonkeyFace = "🐵" ;

		public const string Monkey = "🐒" ;

		public const string Gorilla = "🦍" ;

		public const string DogFace = "🐶" ;

		public const string Dog = "🐕" ;

		public const string GuideDog = "🦮" ;

		public const string ServiceDog = "🐕‍🦺" ;

		public const string Poodle = "🐩" ;

		public const string WolfFace = "🐺" ;

		public const string FoxFace = "🦊" ;

		public const string Raccoon = "🦝" ;

		public const string CatFace = "🐱" ;

		public const string Cat = "🐈" ;

		public const string LionFace = "🦁" ;

		public const string TigerFace = "🐯" ;

		public const string Tiger = "🐅" ;

		public const string Leopard = "🐆" ;

		public const string HorseFace = "🐴" ;

		public const string Horse = "🐎" ;

		public const string UnicornFace = "🦄" ;

		public const string Zebra = "🦓" ;

		public const string Deer = "🦌" ;

		public const string CowFace = "🐮" ;

		public const string Ox = "🐂" ;

		public const string WaterBuffalo = "🐃" ;

		public const string Cow = "🐄" ;

		public const string PigFace = "🐷" ;

		public const string Pig = "🐖" ;

		public const string Boar = "🐗" ;

		public const string PigNose = "🐽" ;

		public const string Ram = "🐏" ;

		public const string Ewe = "🐑" ;

		public const string Goat = "🐐" ;

		public const string Camel = "🐪" ;

		public const string TwoHumpCamel = "🐫" ;

		public const string Llama = "🦙" ;

		public const string Giraffe = "🦒" ;

		public const string Elephant = "🐘" ;

		public const string Rhinoceros = "🦏" ;

		public const string Hippopotamus = "🦛" ;

		public const string MouseFace = "🐭" ;

		public const string Mouse = "🐁" ;

		public const string Rat = "🐀" ;

		public const string HamsterFace = "🐹" ;

		public const string RabbitFace = "🐰" ;

		public const string Rabbit = "🐇" ;

		public const string Chipmunk = "🐿️" ;

		public const string Chipmunk2 = "🐿" ;

		public const string Hedgehog = "🦔" ;

		public const string Bat = "🦇" ;

		public const string BearFace = "🐻" ;

		public const string Koala = "🐨" ;

		public const string PandaFace = "🐼" ;

		public const string Sloth = "🦥" ;

		public const string Otter = "🦦" ;

		public const string Orangutan = "🦧" ;

		public const string Skunk = "🦨" ;

		public const string Kangaroo = "🦘" ;

		public const string Badger = "🦡" ;

		public const string PawPrints = "🐾" ;

		public const string Turkey = "🦃" ;

		public const string Chicken = "🐔" ;

		public const string Rooster = "🐓" ;

		public const string HatchingChick = "🐣" ;

		public const string BabyChick = "🐤" ;

		public const string FrontFacingBabyChick = "🐥" ;

		public const string Bird = "🐦" ;

		public const string Penguin = "🐧" ;

		public const string Dove = "🕊️" ;

		public const string Dove2 = "🕊" ;

		public const string Eagle = "🦅" ;

		public const string Duck = "🦆" ;

		public const string Swan = "🦢" ;

		public const string Owl = "🦉" ;

		public const string Flamingo = "🦩" ;

		public const string Peacock = "🦚" ;

		public const string Parrot = "🦜" ;

		public const string FrogFace = "🐸" ;

		public const string Crocodile = "🐊" ;

		public const string Turtle = "🐢" ;

		public const string Lizard = "🦎" ;

		public const string Snake = "🐍" ;

		public const string DragonFace = "🐲" ;

		public const string Dragon = "🐉" ;

		public const string Sauropod = "🦕" ;

		public const string TRex = "🦖" ;

		public const string SpoutingWhale = "🐳" ;

		public const string Whale = "🐋" ;

		public const string Dolphin = "🐬" ;

		public const string Fish = "🐟" ;

		public const string TropicalFish = "🐠" ;

		public const string Blowfish = "🐡" ;

		public const string Shark = "🦈" ;

		public const string Octopus = "🐙" ;

		public const string SpiralShell = "🐚" ;

		public const string Snail = "🐌" ;

		public const string Butterfly = "🦋" ;

		public const string Bug = "🐛" ;

		public const string Ant = "🐜" ;

		public const string Honeybee = "🐝" ;

		public const string LadyBeetle = "🐞" ;

		public const string Cricket = "🦗" ;

		public const string Spider = "🕷️" ;

		public const string Spider2 = "🕷" ;

		public const string SpiderWeb = "🕸️" ;

		public const string SpiderWeb2 = "🕸" ;

		public const string Scorpion = "🦂" ;

		public const string Mosquito = "🦟" ;

		public const string Microbe = "🦠" ;

		public const string Bouquet = "💐" ;

		public const string CherryBlossom = "🌸" ;

		public const string WhiteFlower = "💮" ;

		public const string Rosette = "🏵️" ;

		public const string Rosette2 = "🏵" ;

		public const string Rose = "🌹" ;

		public const string WiltedFlower = "🥀" ;

		public const string Hibiscus = "🌺" ;

		public const string Sunflower = "🌻" ;

		public const string Blossom = "🌼" ;

		public const string Tulip = "🌷" ;

		public const string Seedling = "🌱" ;

		public const string EvergreenTree = "🌲" ;

		public const string DeciduousTree = "🌳" ;

		public const string PalmTree = "🌴" ;

		public const string Cactus = "🌵" ;

		public const string SheafOfRice = "🌾" ;

		public const string Herb = "🌿" ;

		public const string Shamrock = "☘️" ;

		public const string Shamrock2 = "☘" ;

		public const string FourLeafClover = "🍀" ;

		public const string MapleLeaf = "🍁" ;

		public const string FallenLeaf = "🍂" ;

		public const string LeafFlutteringInWind = "🍃" ;

		public const string Grapes = "🍇" ;

		public const string Melon = "🍈" ;

		public const string Watermelon = "🍉" ;

		public const string Tangerine = "🍊" ;

		public const string Lemon = "🍋" ;

		public const string Banana = "🍌" ;

		public const string Pineapple = "🍍" ;

		public const string Mango = "🥭" ;

		public const string RedApple = "🍎" ;

		public const string GreenApple = "🍏" ;

		public const string Pear = "🍐" ;

		public const string Peach = "🍑" ;

		public const string Cherries = "🍒" ;

		public const string Strawberry = "🍓" ;

		public const string KiwiFruit = "🥝" ;

		public const string Tomato = "🍅" ;

		public const string Coconut = "🥥" ;

		public const string Avocado = "🥑" ;

		public const string Eggplant = "🍆" ;

		public const string Potato = "🥔" ;

		public const string Carrot = "🥕" ;

		public const string EarOfCorn = "🌽" ;

		public const string HotPepper = "🌶️" ;

		public const string HotPepper2 = "🌶" ;

		public const string Cucumber = "🥒" ;

		public const string LeafyGreen = "🥬" ;

		public const string Broccoli = "🥦" ;

		public const string Garlic = "🧄" ;

		public const string Onion = "🧅" ;

		public const string Mushroom = "🍄" ;

		public const string Peanuts = "🥜" ;

		public const string Chestnut = "🌰" ;

		public const string Bread = "🍞" ;

		public const string Croissant = "🥐" ;

		public const string BaguetteBread = "🥖" ;

		public const string Pretzel = "🥨" ;

		public const string Bagel = "🥯" ;

		public const string Pancakes = "🥞" ;

		public const string Waffle = "🧇" ;

		public const string CheeseWedge = "🧀" ;

		public const string MeatOnBone = "🍖" ;

		public const string PoultryLeg = "🍗" ;

		public const string CutOfMeat = "🥩" ;

		public const string Bacon = "🥓" ;

		public const string Hamburger = "🍔" ;

		public const string FrenchFries = "🍟" ;

		public const string Pizza = "🍕" ;

		public const string HotDog = "🌭" ;

		public const string Sandwich = "🥪" ;

		public const string Taco = "🌮" ;

		public const string Burrito = "🌯" ;

		public const string StuffedFlatbread = "🥙" ;

		public const string Falafel = "🧆" ;

		public const string Egg = "🥚" ;

		public const string Cooking = "🍳" ;

		public const string ShallowPanOfFood = "🥘" ;

		public const string PotOfFood = "🍲" ;

		public const string BowlWithSpoon = "🥣" ;

		public const string GreenSalad = "🥗" ;

		public const string Popcorn = "🍿" ;

		public const string Butter = "🧈" ;

		public const string Salt = "🧂" ;

		public const string CannedFood = "🥫" ;

		public const string BentoBox = "🍱" ;

		public const string RiceCracker = "🍘" ;

		public const string RiceBall = "🍙" ;

		public const string CookedRice = "🍚" ;

		public const string CurryRice = "🍛" ;

		public const string SteamingBowl = "🍜" ;

		public const string Spaghetti = "🍝" ;

		public const string RoastedSweetPotato = "🍠" ;

		public const string Oden = "🍢" ;

		public const string Sushi = "🍣" ;

		public const string FriedShrimp = "🍤" ;

		public const string FishCakeWithSwirl = "🍥" ;

		public const string MoonCake = "🥮" ;

		public const string Dango = "🍡" ;

		public const string Dumpling = "🥟" ;

		public const string FortuneCookie = "🥠" ;

		public const string TakeoutBox = "🥡" ;

		public const string Crab = "🦀" ;

		public const string Lobster = "🦞" ;

		public const string Shrimp = "🦐" ;

		public const string Squid = "🦑" ;

		public const string Oyster = "🦪" ;

		public const string SoftIceCream = "🍦" ;

		public const string ShavedIce = "🍧" ;

		public const string IceCream = "🍨" ;

		public const string Doughnut = "🍩" ;

		public const string Cookie = "🍪" ;

		public const string BirthdayCake = "🎂" ;

		public const string Shortcake = "🍰" ;

		public const string Cupcake = "🧁" ;

		public const string Pie = "🥧" ;

		public const string ChocolateBar = "🍫" ;

		public const string Candy = "🍬" ;

		public const string Lollipop = "🍭" ;

		public const string Custard = "🍮" ;

		public const string HoneyPot = "🍯" ;

		public const string BabyBottle = "🍼" ;

		public const string GlassOfMilk = "🥛" ;

		public const string HotBeverage = "☕" ;

		public const string TeacupWithoutHandle = "🍵" ;

		public const string Sake = "🍶" ;

		public const string BottleWithPoppingCork = "🍾" ;

		public const string WineGlass = "🍷" ;

		public const string CocktailGlass = "🍸" ;

		public const string TropicalDrink = "🍹" ;

		public const string BeerMug = "🍺" ;

		public const string ClinkingBeerMugs = "🍻" ;

		public const string ClinkingGlasses = "🥂" ;

		public const string TumblerGlass = "🥃" ;

		public const string CupWithStraw = "🥤" ;

		public const string BeverageBox = "🧃" ;

		public const string Mate = "🧉" ;

		public const string IceCube = "🧊" ;

		public const string Chopsticks = "🥢" ;

		public const string ForkAndKnifeWithPlate = "🍽️" ;

		public const string ForkAndKnifeWithPlate2 = "🍽" ;

		public const string ForkAndKnife = "🍴" ;

		public const string Spoon = "🥄" ;

		public const string KitchenKnife = "🔪" ;

		public const string Amphora = "🏺" ;

		public const string GlobeShowingEuropeAfrica = "🌍" ;

		public const string GlobeShowingAmericas = "🌎" ;

		public const string GlobeShowingAsiaAustralia = "🌏" ;

		public const string GlobeWithMeridians = "🌐" ;

		public const string WorldMap = "🗺️" ;

		public const string WorldMap2 = "🗺" ;

		public const string MapOfJapan = "🗾" ;

		public const string Compass = "🧭" ;

		public const string SnowCappedMountain = "🏔️" ;

		public const string SnowCappedMountain2 = "🏔" ;

		public const string Mountain = "⛰️" ;

		public const string Mountain2 = "⛰" ;

		public const string Volcano = "🌋" ;

		public const string MountFuji = "🗻" ;

		public const string Camping = "🏕️" ;

		public const string Camping2 = "🏕" ;

		public const string BeachWithUmbrella = "🏖️" ;

		public const string BeachWithUmbrella2 = "🏖" ;

		public const string Desert = "🏜️" ;

		public const string Desert2 = "🏜" ;

		public const string DesertIsland = "🏝️" ;

		public const string DesertIsland2 = "🏝" ;

		public const string NationalPark = "🏞️" ;

		public const string NationalPark2 = "🏞" ;

		public const string Stadium = "🏟️" ;

		public const string Stadium2 = "🏟" ;

		public const string ClassicalBuilding = "🏛️" ;

		public const string ClassicalBuilding2 = "🏛" ;

		public const string BuildingConstruction = "🏗️" ;

		public const string BuildingConstruction2 = "🏗" ;

		public const string Brick = "🧱" ;

		public const string Houses = "🏘️" ;

		public const string Houses2 = "🏘" ;

		public const string DerelictHouse = "🏚️" ;

		public const string DerelictHouse2 = "🏚" ;

		public const string House = "🏠" ;

		public const string HouseWithGarden = "🏡" ;

		public const string OfficeBuilding = "🏢" ;

		public const string JapanesePostOffice = "🏣" ;

		public const string PostOffice = "🏤" ;

		public const string Hospital = "🏥" ;

		public const string Bank = "🏦" ;

		public const string Hotel = "🏨" ;

		public const string LoveHotel = "🏩" ;

		public const string ConvenienceStore = "🏪" ;

		public const string School = "🏫" ;

		public const string DepartmentStore = "🏬" ;

		public const string Factory = "🏭" ;

		public const string JapaneseCastle = "🏯" ;

		public const string Castle = "🏰" ;

		public const string Wedding = "💒" ;

		public const string TokyoTower = "🗼" ;

		public const string StatueOfLiberty = "🗽" ;

		public const string Church = "⛪" ;

		public const string Mosque = "🕌" ;

		public const string HinduTemple = "🛕" ;

		public const string Synagogue = "🕍" ;

		public const string ShintoShrine = "⛩️" ;

		public const string ShintoShrine2 = "⛩" ;

		public const string Kaaba = "🕋" ;

		public const string Fountain = "⛲" ;

		public const string Tent = "⛺" ;

		public const string Foggy = "🌁" ;

		public const string NightWithStars = "🌃" ;

		public const string Cityscape = "🏙️" ;

		public const string Cityscape2 = "🏙" ;

		public const string SunriseOverMountains = "🌄" ;

		public const string Sunrise = "🌅" ;

		public const string CityscapeAtDusk = "🌆" ;

		public const string Sunset = "🌇" ;

		public const string BridgeAtNight = "🌉" ;

		public const string HotSprings = "♨️" ;

		public const string HotSprings2 = "♨" ;

		public const string MilkyWay = "🌌" ;

		public const string CarouselHorse = "🎠" ;

		public const string FerrisWheel = "🎡" ;

		public const string RollerCoaster = "🎢" ;

		public const string BarberPole = "💈" ;

		public const string CircusTent = "🎪" ;

		public const string Locomotive = "🚂" ;

		public const string RailwayCar = "🚃" ;

		public const string HighSpeedTrain = "🚄" ;

		public const string BulletTrain = "🚅" ;

		public const string Train = "🚆" ;

		public const string Metro = "🚇" ;

		public const string LightRail = "🚈" ;

		public const string Station = "🚉" ;

		public const string Tram = "🚊" ;

		public const string Monorail = "🚝" ;

		public const string MountainRailway = "🚞" ;

		public const string TramCar = "🚋" ;

		public const string Bus = "🚌" ;

		public const string OncomingBus = "🚍" ;

		public const string Trolleybus = "🚎" ;

		public const string Minibus = "🚐" ;

		public const string Ambulance = "🚑" ;

		public const string FireEngine = "🚒" ;

		public const string PoliceCar = "🚓" ;

		public const string OncomingPoliceCar = "🚔" ;

		public const string Taxi = "🚕" ;

		public const string OncomingTaxi = "🚖" ;

		public const string Automobile = "🚗" ;

		public const string OncomingAutomobile = "🚘" ;

		public const string SportUtilityVehicle = "🚙" ;

		public const string DeliveryTruck = "🚚" ;

		public const string ArticulatedLorry = "🚛" ;

		public const string Tractor = "🚜" ;

		public const string RacingCar = "🏎️" ;

		public const string RacingCar2 = "🏎" ;

		public const string Motorcycle = "🏍️" ;

		public const string Motorcycle2 = "🏍" ;

		public const string MotorScooter = "🛵" ;

		public const string ManualWheelchair = "🦽" ;

		public const string MotorizedWheelchair = "🦼" ;

		public const string AutoRickshaw = "🛺" ;

		public const string Bicycle = "🚲" ;

		public const string KickScooter = "🛴" ;

		public const string Skateboard = "🛹" ;

		public const string BusStop = "🚏" ;

		public const string Motorway = "🛣️" ;

		public const string Motorway2 = "🛣" ;

		public const string RailwayTrack = "🛤️" ;

		public const string RailwayTrack2 = "🛤" ;

		public const string OilDrum = "🛢️" ;

		public const string OilDrum2 = "🛢" ;

		public const string FuelPump = "⛽" ;

		public const string PoliceCarLight = "🚨" ;

		public const string HorizontalTrafficLight = "🚥" ;

		public const string VerticalTrafficLight = "🚦" ;

		public const string StopSign = "🛑" ;

		public const string Construction = "🚧" ;

		public const string Anchor = "⚓" ;

		public const string Sailboat = "⛵" ;

		public const string Canoe = "🛶" ;

		public const string Speedboat = "🚤" ;

		public const string PassengerShip = "🛳️" ;

		public const string PassengerShip2 = "🛳" ;

		public const string Ferry = "⛴️" ;

		public const string Ferry2 = "⛴" ;

		public const string MotorBoat = "🛥️" ;

		public const string MotorBoat2 = "🛥" ;

		public const string Ship = "🚢" ;

		public const string Airplane = "✈️" ;

		public const string Airplane2 = "✈" ;

		public const string SmallAirplane = "🛩️" ;

		public const string SmallAirplane2 = "🛩" ;

		public const string AirplaneDeparture = "🛫" ;

		public const string AirplaneArrival = "🛬" ;

		public const string Parachute = "🪂" ;

		public const string Seat = "💺" ;

		public const string Helicopter = "🚁" ;

		public const string SuspensionRailway = "🚟" ;

		public const string MountainCableway = "🚠" ;

		public const string AerialTramway = "🚡" ;

		public const string Satellite = "🛰️" ;

		public const string Satellite2 = "🛰" ;

		public const string Rocket = "🚀" ;

		public const string FlyingSaucer = "🛸" ;

		public const string BellhopBell = "🛎️" ;

		public const string BellhopBell2 = "🛎" ;

		public const string Luggage = "🧳" ;

		public const string HourglassDone = "⌛" ;

		public const string HourglassNotDone = "⏳" ;

		public const string Watch = "⌚" ;

		public const string AlarmClock = "⏰" ;

		public const string Stopwatch = "⏱️" ;

		public const string Stopwatch2 = "⏱" ;

		public const string TimerClock = "⏲️" ;

		public const string TimerClock2 = "⏲" ;

		public const string MantelpieceClock = "🕰️" ;

		public const string MantelpieceClock2 = "🕰" ;

		public const string TwelveOclock = "🕛" ;

		public const string TwelveThirty = "🕧" ;

		public const string OneOclock = "🕐" ;

		public const string OneThirty = "🕜" ;

		public const string TwoOclock = "🕑" ;

		public const string TwoThirty = "🕝" ;

		public const string ThreeOclock = "🕒" ;

		public const string ThreeThirty = "🕞" ;

		public const string FourOclock = "🕓" ;

		public const string FourThirty = "🕟" ;

		public const string FiveOclock = "🕔" ;

		public const string FiveThirty = "🕠" ;

		public const string SixOclock = "🕕" ;

		public const string SixThirty = "🕡" ;

		public const string SevenOclock = "🕖" ;

		public const string SevenThirty = "🕢" ;

		public const string EightOclock = "🕗" ;

		public const string EightThirty = "🕣" ;

		public const string NineOclock = "🕘" ;

		public const string NineThirty = "🕤" ;

		public const string TenOclock = "🕙" ;

		public const string TenThirty = "🕥" ;

		public const string ElevenOclock = "🕚" ;

		public const string ElevenThirty = "🕦" ;

		public const string NewMoon = "🌑" ;

		public const string WaxingCrescentMoon = "🌒" ;

		public const string FirstQuarterMoon = "🌓" ;

		public const string WaxingGibbousMoon = "🌔" ;

		public const string FullMoon = "🌕" ;

		public const string WaningGibbousMoon = "🌖" ;

		public const string LastQuarterMoon = "🌗" ;

		public const string WaningCrescentMoon = "🌘" ;

		public const string CrescentMoon = "🌙" ;

		public const string NewMoonFace = "🌚" ;

		public const string FirstQuarterMoonFace = "🌛" ;

		public const string LastQuarterMoonFace = "🌜" ;

		public const string Thermometer = "🌡️" ;

		public const string Thermometer2 = "🌡" ;

		public const string Sun = "☀️" ;

		public const string Sun2 = "☀" ;

		public const string FullMoonFace = "🌝" ;

		public const string SunWithFace = "🌞" ;

		public const string RingedPlanet = "🪐" ;

		public const string Star = "⭐" ;

		public const string GlowingStar = "🌟" ;

		public const string ShootingStar = "🌠" ;

		public const string Cloud = "☁️" ;

		public const string Cloud2 = "☁" ;

		public const string SunBehindCloud = "⛅" ;

		public const string CloudWithLightningAndRain = "⛈️" ;

		public const string CloudWithLightningAndRain2 = "⛈" ;

		public const string SunBehindSmallCloud = "🌤️" ;

		public const string SunBehindSmallCloud2 = "🌤" ;

		public const string SunBehindLargeCloud = "🌥️" ;

		public const string SunBehindLargeCloud2 = "🌥" ;

		public const string SunBehindRainCloud = "🌦️" ;

		public const string SunBehindRainCloud2 = "🌦" ;

		public const string CloudWithRain = "🌧️" ;

		public const string CloudWithRain2 = "🌧" ;

		public const string CloudWithSnow = "🌨️" ;

		public const string CloudWithSnow2 = "🌨" ;

		public const string CloudWithLightning = "🌩️" ;

		public const string CloudWithLightning2 = "🌩" ;

		public const string Tornado = "🌪️" ;

		public const string Tornado2 = "🌪" ;

		public const string Fog = "🌫️" ;

		public const string Fog2 = "🌫" ;

		public const string WindFace = "🌬️" ;

		public const string WindFace2 = "🌬" ;

		public const string Cyclone = "🌀" ;

		public const string Rainbow = "🌈" ;

		public const string ClosedUmbrella = "🌂" ;

		public const string Umbrella = "☂️" ;

		public const string Umbrella2 = "☂" ;

		public const string UmbrellaWithRainDrops = "☔" ;

		public const string UmbrellaOnGround = "⛱️" ;

		public const string UmbrellaOnGround2 = "⛱" ;

		public const string HighVoltage = "⚡" ;

		public const string Snowflake = "❄️" ;

		public const string Snowflake2 = "❄" ;

		public const string Snowman = "☃️" ;

		public const string Snowman2 = "☃" ;

		public const string SnowmanWithoutSnow = "⛄" ;

		public const string Comet = "☄️" ;

		public const string Comet2 = "☄" ;

		public const string Fire = "🔥" ;

		public const string Droplet = "💧" ;

		public const string WaterWave = "🌊" ;

		public const string JackOLantern = "🎃" ;

		public const string ChristmasTree = "🎄" ;

		public const string Fireworks = "🎆" ;

		public const string Sparkler = "🎇" ;

		public const string Firecracker = "🧨" ;

		public const string Sparkles = "✨" ;

		public const string Balloon = "🎈" ;

		public const string PartyPopper = "🎉" ;

		public const string ConfettiBall = "🎊" ;

		public const string TanabataTree = "🎋" ;

		public const string PineDecoration = "🎍" ;

		public const string JapaneseDolls = "🎎" ;

		public const string CarpStreamer = "🎏" ;

		public const string WindChime = "🎐" ;

		public const string MoonViewingCeremony = "🎑" ;

		public const string RedEnvelope = "🧧" ;

		public const string Ribbon = "🎀" ;

		public const string WrappedGift = "🎁" ;

		public const string ReminderRibbon = "🎗️" ;

		public const string ReminderRibbon2 = "🎗" ;

		public const string AdmissionTickets = "🎟️" ;

		public const string AdmissionTickets2 = "🎟" ;

		public const string Ticket = "🎫" ;

		public const string MilitaryMedal = "🎖️" ;

		public const string MilitaryMedal2 = "🎖" ;

		public const string Trophy = "🏆" ;

		public const string SportsMedal = "🏅" ;

		public const string FirstPlaceMedal = "🥇" ;

		public const string SecondPlaceMedal = "🥈" ;

		public const string ThirdPlaceMedal = "🥉" ;

		public const string SoccerBall = "⚽" ;

		public const string Baseball = "⚾" ;

		public const string Softball = "🥎" ;

		public const string Basketball = "🏀" ;

		public const string Volleyball = "🏐" ;

		public const string AmericanFootball = "🏈" ;

		public const string RugbyFootball = "🏉" ;

		public const string Tennis = "🎾" ;

		public const string FlyingDisc = "🥏" ;

		public const string Bowling = "🎳" ;

		public const string CricketGame = "🏏" ;

		public const string FieldHockey = "🏑" ;

		public const string IceHockey = "🏒" ;

		public const string Lacrosse = "🥍" ;

		public const string PingPong = "🏓" ;

		public const string Badminton = "🏸" ;

		public const string BoxingGlove = "🥊" ;

		public const string MartialArtsUniform = "🥋" ;

		public const string GoalNet = "🥅" ;

		public const string FlagInHole = "⛳" ;

		public const string IceSkate = "⛸️" ;

		public const string IceSkate2 = "⛸" ;

		public const string FishingPole = "🎣" ;

		public const string DivingMask = "🤿" ;

		public const string RunningShirt = "🎽" ;

		public const string Skis = "🎿" ;

		public const string Sled = "🛷" ;

		public const string CurlingStone = "🥌" ;

		public const string DirectHit = "🎯" ;

		public const string YoYo = "🪀" ;

		public const string Kite = "🪁" ;

		public const string Pool8Ball = "🎱" ;

		public const string CrystalBall = "🔮" ;

		public const string NazarAmulet = "🧿" ;

		public const string VideoGame = "🎮" ;

		public const string Joystick = "🕹️" ;

		public const string Joystick2 = "🕹" ;

		public const string SlotMachine = "🎰" ;

		public const string GameDie = "🎲" ;

		public const string Jigsaw = "🧩" ;

		public const string TeddyBear = "🧸" ;

		public const string SpadeSuit = "♠️" ;

		public const string SpadeSuit2 = "♠" ;

		public const string HeartSuit = "♥️" ;

		public const string HeartSuit2 = "♥" ;

		public const string DiamondSuit = "♦️" ;

		public const string DiamondSuit2 = "♦" ;

		public const string ClubSuit = "♣️" ;

		public const string ClubSuit2 = "♣" ;

		public const string ChessPawn = "♟️" ;

		public const string ChessPawn2 = "♟" ;

		public const string Joker = "🃏" ;

		public const string MahjongRedDragon = "🀄" ;

		public const string FlowerPlayingCards = "🎴" ;

		public const string PerformingArts = "🎭" ;

		public const string FramedPicture = "🖼️" ;

		public const string FramedPicture2 = "🖼" ;

		public const string ArtistPalette = "🎨" ;

		public const string Thread = "🧵" ;

		public const string Yarn = "🧶" ;

		public const string Glasses = "👓" ;

		public const string Sunglasses = "🕶️" ;

		public const string Sunglasses2 = "🕶" ;

		public const string Goggles = "🥽" ;

		public const string LabCoat = "🥼" ;

		public const string SafetyVest = "🦺" ;

		public const string Necktie = "👔" ;

		public const string TShirt = "👕" ;

		public const string Jeans = "👖" ;

		public const string Scarf = "🧣" ;

		public const string Gloves = "🧤" ;

		public const string Coat = "🧥" ;

		public const string Socks = "🧦" ;

		public const string Dress = "👗" ;

		public const string Kimono = "👘" ;

		public const string Sari = "🥻" ;

		public const string OnePiece = "🩱" ;

		public const string Briefs = "🩲" ;

		public const string Shorts = "🩳" ;

		public const string Bikini = "👙" ;

		public const string WomansClothes = "👚" ;

		public const string Purse = "👛" ;

		public const string Handbag = "👜" ;

		public const string ClutchBag = "👝" ;

		public const string ShoppingBags = "🛍️" ;

		public const string ShoppingBags2 = "🛍" ;

		public const string Backpack = "🎒" ;

		public const string MansShoe = "👞" ;

		public const string RunningShoe = "👟" ;

		public const string HikingBoot = "🥾" ;

		public const string FlatShoe = "🥿" ;

		public const string HighHeeledShoe = "👠" ;

		public const string WomansSandal = "👡" ;

		public const string BalletShoes = "🩰" ;

		public const string WomansBoot = "👢" ;

		public const string Crown = "👑" ;

		public const string WomansHat = "👒" ;

		public const string TopHat = "🎩" ;

		public const string GraduationCap = "🎓" ;

		public const string BilledCap = "🧢" ;

		public const string RescueWorkersHelmet = "⛑️" ;

		public const string RescueWorkersHelmet2 = "⛑" ;

		public const string PrayerBeads = "📿" ;

		public const string Lipstick = "💄" ;

		public const string Ring = "💍" ;

		public const string GemStone = "💎" ;

		public const string MutedSpeaker = "🔇" ;

		public const string SpeakerLowVolume = "🔈" ;

		public const string SpeakerMediumVolume = "🔉" ;

		public const string SpeakerHighVolume = "🔊" ;

		public const string Loudspeaker = "📢" ;

		public const string Megaphone = "📣" ;

		public const string PostalHorn = "📯" ;

		public const string Bell = "🔔" ;

		public const string BellWithSlash = "🔕" ;

		public const string MusicalScore = "🎼" ;

		public const string MusicalNote = "🎵" ;

		public const string MusicalNotes = "🎶" ;

		public const string StudioMicrophone = "🎙️" ;

		public const string StudioMicrophone2 = "🎙" ;

		public const string LevelSlider = "🎚️" ;

		public const string LevelSlider2 = "🎚" ;

		public const string ControlKnobs = "🎛️" ;

		public const string ControlKnobs2 = "🎛" ;

		public const string Microphone = "🎤" ;

		public const string Headphone = "🎧" ;

		public const string Radio = "📻" ;

		public const string Saxophone = "🎷" ;

		public const string Guitar = "🎸" ;

		public const string MusicalKeyboard = "🎹" ;

		public const string Trumpet = "🎺" ;

		public const string Violin = "🎻" ;

		public const string Banjo = "🪕" ;

		public const string Drum = "🥁" ;

		public const string MobilePhone = "📱" ;

		public const string MobilePhoneWithArrow = "📲" ;

		public const string Telephone = "☎️" ;

		public const string Telephone2 = "☎" ;

		public const string TelephoneReceiver = "📞" ;

		public const string Pager = "📟" ;

		public const string FaxMachine = "📠" ;

		public const string Battery = "🔋" ;

		public const string ElectricPlug = "🔌" ;

		public const string LaptopComputer = "💻" ;

		public const string DesktopComputer = "🖥️" ;

		public const string DesktopComputer2 = "🖥" ;

		public const string Printer = "🖨️" ;

		public const string Printer2 = "🖨" ;

		public const string Keyboard = "⌨️" ;

		public const string Keyboard2 = "⌨" ;

		public const string ComputerMouse = "🖱️" ;

		public const string ComputerMouse2 = "🖱" ;

		public const string Trackball = "🖲️" ;

		public const string Trackball2 = "🖲" ;

		public const string ComputerDisk = "💽" ;

		public const string FloppyDisk = "💾" ;

		public const string OpticalDisk = "💿" ;

		public const string Dvd = "📀" ;

		public const string Abacus = "🧮" ;

		public const string MovieCamera = "🎥" ;

		public const string FilmFrames = "🎞️" ;

		public const string FilmFrames2 = "🎞" ;

		public const string FilmProjector = "📽️" ;

		public const string FilmProjector2 = "📽" ;

		public const string ClapperBoard = "🎬" ;

		public const string Television = "📺" ;

		public const string Camera = "📷" ;

		public const string CameraWithFlash = "📸" ;

		public const string VideoCamera = "📹" ;

		public const string Videocassette = "📼" ;

		public const string MagnifyingGlassTiltedLeft = "🔍" ;

		public const string MagnifyingGlassTiltedRight = "🔎" ;

		public const string Candle = "🕯️" ;

		public const string Candle2 = "🕯" ;

		public const string LightBulb = "💡" ;

		public const string Flashlight = "🔦" ;

		public const string RedPaperLantern = "🏮" ;

		public const string DiyaLamp = "🪔" ;

		public const string NotebookWithDecorativeCover = "📔" ;

		public const string ClosedBook = "📕" ;

		public const string OpenBook = "📖" ;

		public const string GreenBook = "📗" ;

		public const string BlueBook = "📘" ;

		public const string OrangeBook = "📙" ;

		public const string Books = "📚" ;

		public const string Notebook = "📓" ;

		public const string Ledger = "📒" ;

		public const string PageWithCurl = "📃" ;

		public const string Scroll = "📜" ;

		public const string PageFacingUp = "📄" ;

		public const string Newspaper = "📰" ;

		public const string RolledUpNewspaper = "🗞️" ;

		public const string RolledUpNewspaper2 = "🗞" ;

		public const string BookmarkTabs = "📑" ;

		public const string Bookmark = "🔖" ;

		public const string Label = "🏷️" ;

		public const string Label2 = "🏷" ;

		public const string MoneyBag = "💰" ;

		public const string YenBanknote = "💴" ;

		public const string DollarBanknote = "💵" ;

		public const string EuroBanknote = "💶" ;

		public const string PoundBanknote = "💷" ;

		public const string MoneyWithWings = "💸" ;

		public const string CreditCard = "💳" ;

		public const string Receipt = "🧾" ;

		public const string ChartIncreasingWithYen = "💹" ;

		public const string CurrencyExchange = "💱" ;

		public const string HeavyDollarSign = "💲" ;

		public const string Envelope = "✉️" ;

		public const string Envelope2 = "✉" ;

		public const string EMail = "📧" ;

		public const string IncomingEnvelope = "📨" ;

		public const string EnvelopeWithArrow = "📩" ;

		public const string OutboxTray = "📤" ;

		public const string InboxTray = "📥" ;

		public const string Package = "📦" ;

		public const string ClosedMailboxWithRaisedFlag = "📫" ;

		public const string ClosedMailboxWithLoweredFlag = "📪" ;

		public const string OpenMailboxWithRaisedFlag = "📬" ;

		public const string OpenMailboxWithLoweredFlag = "📭" ;

		public const string Postbox = "📮" ;

		public const string BallotBoxWithBallot = "🗳️" ;

		public const string BallotBoxWithBallot2 = "🗳" ;

		public const string Pencil = "✏️" ;

		public const string Pencil2 = "✏" ;

		public const string BlackNib = "✒️" ;

		public const string BlackNib2 = "✒" ;

		public const string FountainPen = "🖋️" ;

		public const string FountainPen2 = "🖋" ;

		public const string Pen = "🖊️" ;

		public const string Pen2 = "🖊" ;

		public const string Paintbrush = "🖌️" ;

		public const string Paintbrush2 = "🖌" ;

		public const string Crayon = "🖍️" ;

		public const string Crayon2 = "🖍" ;

		public const string Memo = "📝" ;

		public const string Briefcase = "💼" ;

		public const string FileFolder = "📁" ;

		public const string OpenFileFolder = "📂" ;

		public const string CardIndexDividers = "🗂️" ;

		public const string CardIndexDividers2 = "🗂" ;

		public const string Calendar = "📅" ;

		public const string TearOffCalendar = "📆" ;

		public const string SpiralNotepad = "🗒️" ;

		public const string SpiralNotepad2 = "🗒" ;

		public const string SpiralCalendar = "🗓️" ;

		public const string SpiralCalendar2 = "🗓" ;

		public const string CardIndex = "📇" ;

		public const string ChartIncreasing = "📈" ;

		public const string ChartDecreasing = "📉" ;

		public const string BarChart = "📊" ;

		public const string Clipboard = "📋" ;

		public const string Pushpin = "📌" ;

		public const string RoundPushpin = "📍" ;

		public const string Paperclip = "📎" ;

		public const string LinkedPaperclips = "🖇️" ;

		public const string LinkedPaperclips2 = "🖇" ;

		public const string StraightRuler = "📏" ;

		public const string TriangularRuler = "📐" ;

		public const string Scissors = "✂️" ;

		public const string Scissors2 = "✂" ;

		public const string CardFileBox = "🗃️" ;

		public const string CardFileBox2 = "🗃" ;

		public const string FileCabinet = "🗄️" ;

		public const string FileCabinet2 = "🗄" ;

		public const string Wastebasket = "🗑️" ;

		public const string Wastebasket2 = "🗑" ;

		public const string Locked = "🔒" ;

		public const string Unlocked = "🔓" ;

		public const string LockedWithPen = "🔏" ;

		public const string LockedWithKey = "🔐" ;

		public const string Key = "🔑" ;

		public const string OldKey = "🗝️" ;

		public const string OldKey2 = "🗝" ;

		public const string Hammer = "🔨" ;

		public const string Axe = "🪓" ;

		public const string Pick = "⛏️" ;

		public const string Pick2 = "⛏" ;

		public const string HammerAndPick = "⚒️" ;

		public const string HammerAndPick2 = "⚒" ;

		public const string HammerAndWrench = "🛠️" ;

		public const string HammerAndWrench2 = "🛠" ;

		public const string Dagger = "🗡️" ;

		public const string Dagger2 = "🗡" ;

		public const string CrossedSwords = "⚔️" ;

		public const string CrossedSwords2 = "⚔" ;

		public const string Pistol = "🔫" ;

		public const string BowAndArrow = "🏹" ;

		public const string Shield = "🛡️" ;

		public const string Shield2 = "🛡" ;

		public const string Wrench = "🔧" ;

		public const string NutAndBolt = "🔩" ;

		public const string Gear = "⚙️" ;

		public const string Gear2 = "⚙" ;

		public const string Clamp = "🗜️" ;

		public const string Clamp2 = "🗜" ;

		public const string BalanceScale = "⚖️" ;

		public const string BalanceScale2 = "⚖" ;

		public const string ProbingCane = "🦯" ;

		public const string Link = "🔗" ;

		public const string Chains = "⛓️" ;

		public const string Chains2 = "⛓" ;

		public const string Toolbox = "🧰" ;

		public const string Magnet = "🧲" ;

		public const string Alembic = "⚗️" ;

		public const string Alembic2 = "⚗" ;

		public const string TestTube = "🧪" ;

		public const string PetriDish = "🧫" ;

		public const string Dna = "🧬" ;

		public const string Microscope = "🔬" ;

		public const string Telescope = "🔭" ;

		public const string SatelliteAntenna = "📡" ;

		public const string Syringe = "💉" ;

		public const string DropOfBlood = "🩸" ;

		public const string Pill = "💊" ;

		public const string AdhesiveBandage = "🩹" ;

		public const string Stethoscope = "🩺" ;

		public const string Door = "🚪" ;

		public const string Bed = "🛏️" ;

		public const string Bed2 = "🛏" ;

		public const string CouchAndLamp = "🛋️" ;

		public const string CouchAndLamp2 = "🛋" ;

		public const string Chair = "🪑" ;

		public const string Toilet = "🚽" ;

		public const string Shower = "🚿" ;

		public const string Bathtub = "🛁" ;

		public const string Razor = "🪒" ;

		public const string LotionBottle = "🧴" ;

		public const string SafetyPin = "🧷" ;

		public const string Broom = "🧹" ;

		public const string Basket = "🧺" ;

		public const string RollOfPaper = "🧻" ;

		public const string Soap = "🧼" ;

		public const string Sponge = "🧽" ;

		public const string FireExtinguisher = "🧯" ;

		public const string ShoppingCart = "🛒" ;

		public const string Cigarette = "🚬" ;

		public const string Coffin = "⚰️" ;

		public const string Coffin2 = "⚰" ;

		public const string FuneralUrn = "⚱️" ;

		public const string FuneralUrn2 = "⚱" ;

		public const string Moai = "🗿" ;

		public const string AtmSign = "🏧" ;

		public const string LitterInBinSign = "🚮" ;

		public const string PotableWater = "🚰" ;

		public const string WheelchairSymbol = "♿" ;

		public const string MensRoom = "🚹" ;

		public const string WomensRoom = "🚺" ;

		public const string Restroom = "🚻" ;

		public const string BabySymbol = "🚼" ;

		public const string WaterCloset = "🚾" ;

		public const string PassportControl = "🛂" ;

		public const string Customs = "🛃" ;

		public const string BaggageClaim = "🛄" ;

		public const string LeftLuggage = "🛅" ;

		public const string Warning = "⚠️" ;

		public const string Warning2 = "⚠" ;

		public const string ChildrenCrossing = "🚸" ;

		public const string NoEntry = "⛔" ;

		public const string Prohibited = "🚫" ;

		public const string NoBicycles = "🚳" ;

		public const string NoSmoking = "🚭" ;

		public const string NoLittering = "🚯" ;

		public const string NonPotableWater = "🚱" ;

		public const string NoPedestrians = "🚷" ;

		public const string NoMobilePhones = "📵" ;

		public const string NoOneUnderEighteen = "🔞" ;

		public const string Radioactive = "☢️" ;

		public const string Radioactive2 = "☢" ;

		public const string Biohazard = "☣️" ;

		public const string Biohazard2 = "☣" ;

		public const string UpArrow = "⬆️" ;

		public const string UpArrow2 = "⬆" ;

		public const string UpRightArrow = "↗️" ;

		public const string UpRightArrow2 = "↗" ;

		public const string RightArrow = "➡️" ;

		public const string RightArrow2 = "➡" ;

		public const string DownRightArrow = "↘️" ;

		public const string DownRightArrow2 = "↘" ;

		public const string DownArrow = "⬇️" ;

		public const string DownArrow2 = "⬇" ;

		public const string DownLeftArrow = "↙️" ;

		public const string DownLeftArrow2 = "↙" ;

		public const string LeftArrow = "⬅️" ;

		public const string LeftArrow2 = "⬅" ;

		public const string UpLeftArrow = "↖️" ;

		public const string UpLeftArrow2 = "↖" ;

		public const string UpDownArrow = "↕️" ;

		public const string UpDownArrow2 = "↕" ;

		public const string LeftRightArrow = "↔️" ;

		public const string LeftRightArrow2 = "↔" ;

		public const string RightArrowCurvingLeft = "↩️" ;

		public const string RightArrowCurvingLeft2 = "↩" ;

		public const string LeftArrowCurvingRight = "↪️" ;

		public const string LeftArrowCurvingRight2 = "↪" ;

		public const string RightArrowCurvingUp = "⤴️" ;

		public const string RightArrowCurvingUp2 = "⤴" ;

		public const string RightArrowCurvingDown = "⤵️" ;

		public const string RightArrowCurvingDown2 = "⤵" ;

		public const string ClockwiseVerticalArrows = "🔃" ;

		public const string CounterclockwiseArrowsButton = "🔄" ;

		public const string BackArrow = "🔙" ;

		public const string EndArrow = "🔚" ;

		public const string OnArrow = "🔛" ;

		public const string SoonArrow = "🔜" ;

		public const string TopArrow = "🔝" ;

		public const string PlaceOfWorship = "🛐" ;

		public const string AtomSymbol = "⚛️" ;

		public const string AtomSymbol2 = "⚛" ;

		public const string Om = "🕉️" ;

		public const string Om2 = "🕉" ;

		public const string StarOfDavid = "✡️" ;

		public const string StarOfDavid2 = "✡" ;

		public const string WheelOfDharma = "☸️" ;

		public const string WheelOfDharma2 = "☸" ;

		public const string YinYang = "☯️" ;

		public const string YinYang2 = "☯" ;

		public const string LatinCross = "✝️" ;

		public const string LatinCross2 = "✝" ;

		public const string OrthodoxCross = "☦️" ;

		public const string OrthodoxCross2 = "☦" ;

		public const string StarAndCrescent = "☪️" ;

		public const string StarAndCrescent2 = "☪" ;

		public const string PeaceSymbol = "☮️" ;

		public const string PeaceSymbol2 = "☮" ;

		public const string Menorah = "🕎" ;

		public const string DottedSixPointedStar = "🔯" ;

		public const string Aries = "♈" ;

		public const string Taurus = "♉" ;

		public const string Gemini = "♊" ;

		public const string Cancer = "♋" ;

		public const string Leo = "♌" ;

		public const string Virgo = "♍" ;

		public const string Libra = "♎" ;

		public const string Scorpio = "♏" ;

		public const string Sagittarius = "♐" ;

		public const string Capricorn = "♑" ;

		public const string Aquarius = "♒" ;

		public const string Pisces = "♓" ;

		public const string Ophiuchus = "⛎" ;

		public const string ShuffleTracksButton = "🔀" ;

		public const string RepeatButton = "🔁" ;

		public const string RepeatSingleButton = "🔂" ;

		public const string PlayButton = "▶️" ;

		public const string PlayButton2 = "▶" ;

		public const string FastForwardButton = "⏩" ;

		public const string NextTrackButton = "⏭️" ;

		public const string NextTrackButton2 = "⏭" ;

		public const string PlayOrPauseButton = "⏯️" ;

		public const string PlayOrPauseButton2 = "⏯" ;

		public const string ReverseButton = "◀️" ;

		public const string ReverseButton2 = "◀" ;

		public const string FastReverseButton = "⏪" ;

		public const string LastTrackButton = "⏮️" ;

		public const string LastTrackButton2 = "⏮" ;

		public const string UpwardsButton = "🔼" ;

		public const string FastUpButton = "⏫" ;

		public const string DownwardsButton = "🔽" ;

		public const string FastDownButton = "⏬" ;

		public const string PauseButton = "⏸️" ;

		public const string PauseButton2 = "⏸" ;

		public const string StopButton = "⏹️" ;

		public const string StopButton2 = "⏹" ;

		public const string RecordButton = "⏺️" ;

		public const string RecordButton2 = "⏺" ;


		public const string EjectButton = "⏏️" ;

		public const string EjectButton2 = "⏏" ;

		public const string Cinema = "🎦" ;

		public const string DimButton = "🔅" ;

		public const string BrightButton = "🔆" ;

		public const string AntennaBars = "📶" ;

		public const string VibrationMode = "📳" ;

		public const string MobilePhoneOff = "📴" ;

		public const string FemaleSign = "♀️" ;

		public const string FemaleSign2 = "♀" ;

		public const string MaleSign = "♂️" ;

		public const string MaleSign2 = "♂" ;

		public const string MedicalSymbol = "⚕️" ;

		public const string MedicalSymbol2 = "⚕" ;

		public const string Infinity = "♾️" ;

		public const string Infinity2 = "♾" ;

		public const string RecyclingSymbol = "♻️" ;

		public const string RecyclingSymbol2 = "♻" ;

		public const string FleurDeLis = "⚜️" ;

		public const string FleurDeLis2 = "⚜" ;

		public const string TridentEmblem = "🔱" ;

		public const string NameBadge = "📛" ;

		public const string JapaneseSymbolForBeginner = "🔰" ;

		public const string HeavyLargeCircle = "⭕" ;

		public const string WhiteHeavyCheckMark = "✅" ;

		public const string BallotBoxWithCheck = "☑️" ;

		public const string BallotBoxWithCheck2 = "☑" ;

		public const string HeavyCheckMark = "✔️" ;

		public const string HeavyCheckMark2 = "✔" ;

		public const string HeavyMultiplicationX = "✖️" ;

		public const string HeavyMultiplicationX2 = "✖" ;

		public const string CrossMark = "❌" ;

		public const string CrossMarkButton = "❎" ;

		public const string HeavyPlusSign = "➕" ;

		public const string HeavyMinusSign = "➖" ;

		public const string HeavyDivisionSign = "➗" ;

		public const string CurlyLoop = "➰" ;

		public const string DoubleCurlyLoop = "➿" ;

		public const string PartAlternationMark = "〽️" ;

		public const string PartAlternationMark2 = "〽" ;

		public const string EightSpokedAsterisk = "✳️" ;

		public const string EightSpokedAsterisk2 = "✳" ;

		public const string EightPointedStar = "✴️" ;

		public const string EightPointedStar2 = "✴" ;

		public const string Sparkle = "❇️" ;

		public const string Sparkle2 = "❇" ;

		public const string DoubleExclamationMark = "‼️" ;

		public const string DoubleExclamationMark2 = "‼" ;

		public const string ExclamationQuestionMark = "⁉️" ;

		public const string ExclamationQuestionMark2 = "⁉" ;

		public const string QuestionMark = "❓" ;

		public const string WhiteQuestionMark = "❔" ;

		public const string WhiteExclamationMark = "❕" ;

		public const string ExclamationMark = "❗" ;

		public const string WavyDash = "〰️" ;

		public const string WavyDash2 = "〰" ;

		public const string Copyright = "©️" ;

		public const string Copyright2 = "©" ;

		public const string Registered = "®️" ;

		public const string Registered2 = "®" ;

		public const string TradeMark = "™️" ;

		public const string TradeMark2 = "™" ;

		public const string KeycapHash = "️⃣" ;

		public const string KeycapHash2 = "⃣" ;

		public const string KeycapStar = "*️⃣" ;

		public const string KeycapStar2 = "*⃣" ;

		public const string Keycap0 = "0️⃣" ;

		public const string Keycap02 = "0⃣" ;

		public const string Keycap1 = "1️⃣" ;

		public const string Keycap1_2 = "1⃣" ;

		public const string Keycap2 = "2️⃣" ;

		public const string Keycap2_2 = "2⃣" ;

		public const string Keycap3 = "3️⃣" ;

		public const string Keycap3_2 = "3⃣" ;

		public const string Keycap4 = "4️⃣" ;

		public const string Keycap4_2 = "4⃣" ;

		public const string Keycap5 = "5️⃣" ;

		public const string Keycap5_2 = "5⃣" ;

		public const string Keycap6 = "6️⃣" ;

		public const string Keycap6_2 = "6⃣" ;

		public const string Keycap7 = "7️⃣" ;

		public const string Keycap7_2 = "7⃣" ;

		public const string Keycap8 = "8️⃣" ;

		public const string Keycap8_2 = "8⃣" ;

		public const string Keycap9 = "9️⃣" ;

		public const string Keycap9_2 = "9⃣" ;

		public const string Keycap10 = "🔟" ;

		public const string InputLatinUppercase = "🔠" ;

		public const string InputLatinLowercase = "🔡" ;

		public const string InputNumbers = "🔢" ;

		public const string InputSymbols = "🔣" ;

		public const string InputLatinLetters = "🔤" ;

		public const string AButtonBloodType = "🅰️" ;

		public const string AButtonBloodType2 = "🅰" ;

		public const string AbButtonBloodType = "🆎" ;

		public const string BButtonBloodType = "🅱️" ;

		public const string BButtonBloodType2 = "🅱" ;

		public const string ClButton = "🆑" ;

		public const string CoolButton = "🆒" ;

		public const string FreeButton = "🆓" ;

		public const string Information = "ℹ️" ;

		public const string Information2 = "ℹ" ;

		public const string IdButton = "🆔" ;

		public const string CircledM = "Ⓜ️" ;

		public const string CircledM2 = "Ⓜ" ;

		public const string NewButton = "🆕" ;

		public const string NgButton = "🆖" ;

		public const string OButtonBloodType = "🅾️" ;

		public const string OButtonBloodType2 = "🅾" ;

		public const string OkButton = "🆗" ;

		public const string PButton = "🅿️" ;

		public const string PButton2 = "🅿" ;

		public const string SosButton = "🆘" ;

		public const string UpButton = "🆙" ;

		public const string VsButton = "🆚" ;

		public const string JapaneseHereButton = "🈁" ;

		public const string JapaneseServiceChargeButton = "🈂️" ;

		public const string JapaneseServiceChargeButton2 = "🈂" ;

		public const string JapaneseMonthlyAmountButton = "🈷️" ;

		public const string JapaneseMonthlyAmountButton2 = "🈷" ;

		public const string JapaneseNotFreeOfChargeButton = "🈶" ;

		public const string JapaneseReservedButton = "🈯" ;

		public const string JapaneseBargainButton = "🉐" ;

		public const string JapaneseDiscountButton = "🈹" ;

		public const string JapaneseFreeOfChargeButton = "🈚" ;

		public const string JapaneseProhibitedButton = "🈲" ;

		public const string JapaneseAcceptableButton = "🉑" ;

		public const string JapaneseApplicationButton = "🈸" ;

		public const string JapanesePassingGradeButton = "🈴" ;

		public const string JapaneseVacancyButton = "🈳" ;

		public const string JapaneseCongratulationsButton = "㊗️" ;

		public const string JapaneseCongratulationsButton2 = "㊗" ;

		public const string JapaneseSecretButton = "㊙️" ;

		public const string JapaneseSecretButton2 = "㊙" ;

		public const string JapaneseOpenForBusinessButton = "🈺" ;

		public const string JapaneseNoVacancyButton = "🈵" ;

		public const string RedCircle = "🔴" ;

		public const string OrangeCircle = "🟠" ;

		public const string YellowCircle = "🟡" ;

		public const string GreenCircle = "🟢" ;

		public const string BlueCircle = "🔵" ;

		public const string PurpleCircle = "🟣" ;

		public const string WhiteCircle = "⚪" ;

		public const string BrownCircle = "🟤" ;

		public const string RedSquare = "🟥" ;

		public const string OrangeSquare = "🟧" ;

		public const string YellowSquare = "🟨" ;

		public const string GreenSquare = "🟩" ;

		public const string BlueSquare = "🟦" ;

		public const string PurpleSquare = "🟪" ;

		public const string BlackCircle = "⚫" ;

		public const string WhiteLargeSquare = "⬜" ;

		public const string BrownSquare = "🟫" ;

		public const string BlackLargeSquare = "⬛" ;

		public const string BlackMediumSquare = "◼️" ;

		public const string BlackMediumSquare2 = "◼" ;

		public const string WhiteMediumSquare = "◻️" ;

		public const string WhiteMediumSquare2 = "◻" ;

		public const string WhiteMediumSmallSquare = "◽" ;

		public const string BlackMediumSmallSquare = "◾" ;

		public const string WhiteSmallSquare = "▫️" ;

		public const string WhiteSmallSquare2 = "▫" ;

		public const string BlackSmallSquare = "▪️" ;

		public const string BlackSmallSquare2 = "▪" ;

		public const string LargeOrangeDiamond = "🔶" ;

		public const string LargeBlueDiamond = "🔷" ;

		public const string SmallOrangeDiamond = "🔸" ;

		public const string SmallBlueDiamond = "🔹" ;

		public const string RedTrianglePointedUp = "🔺" ;

		public const string RedTrianglePointedDown = "🔻" ;

		public const string DiamondWithADot = "💠" ;

		public const string RadioButton = "🔘" ;

		public const string BlackSquareButton = "🔲" ;

		public const string WhiteSquareButton = "🔳" ;

		public const string ChequeredFlag = "🏁" ;

		public const string TriangularFlag = "🚩" ;

		public const string CrossedFlags = "🎌" ;

		public const string BlackFlag = "🏴" ;

		public const string WhiteFlag = "🏳️" ;

		public const string WhiteFlag2 = "🏳" ;

		public const string RainbowFlag = "🏳️‍🌈" ;

		public const string RainbowFlag2 = "🏳‍🌈" ;

		public const string PirateFlag = "🏴‍☠️" ;

		public const string PirateFlag2 = "🏴‍☠" ;

		public const string FlagAscensionIsland = "🇦🇨" ;

		public const string FlagAndorra = "🇦🇩" ;

		public const string FlagUnitedArabEmirates = "🇦🇪" ;

		public const string FlagAfghanistan = "🇦🇫" ;

		public const string FlagAntiguaBarbuda = "🇦🇬" ;

		public const string FlagAnguilla = "🇦🇮" ;

		public const string FlagAlbania = "🇦🇱" ;

		public const string FlagArmenia = "🇦🇲" ;

		public const string FlagAngola = "🇦🇴" ;

		public const string FlagAntarctica = "🇦🇶" ;

		public const string FlagArgentina = "🇦🇷" ;

		public const string FlagAmericanSamoa = "🇦🇸" ;

		public const string FlagAustria = "🇦🇹" ;

		public const string FlagAustralia = "🇦🇺" ;

		public const string FlagAruba = "🇦🇼" ;

		public const string FlagAlandIslands = "🇦🇽" ;

		public const string FlagAzerbaijan = "🇦🇿" ;

		public const string FlagBosniaHerzegovina = "🇧🇦" ;

		public const string FlagBarbados = "🇧🇧" ;

		public const string FlagBangladesh = "🇧🇩" ;

		public const string FlagBelgium = "🇧🇪" ;

		public const string FlagBurkinaFaso = "🇧🇫" ;

		public const string FlagBulgaria = "🇧🇬" ;

		public const string FlagBahrain = "🇧🇭" ;

		public const string FlagBurundi = "🇧🇮" ;

		public const string FlagBenin = "🇧🇯" ;

		public const string FlagStBarthelemy = "🇧🇱" ;

		public const string FlagBermuda = "🇧🇲" ;

		public const string FlagBrunei = "🇧🇳" ;

		public const string FlagBolivia = "🇧🇴" ;

		public const string FlagCaribbeanNetherlands = "🇧🇶" ;

		public const string FlagBrazil = "🇧🇷" ;

		public const string FlagBahamas = "🇧🇸" ;

		public const string FlagBhutan = "🇧🇹" ;

		public const string FlagBouvetIsland = "🇧🇻" ;

		public const string FlagBotswana = "🇧🇼" ;

		public const string FlagBelarus = "🇧🇾" ;

		public const string FlagBelize = "🇧🇿" ;

		public const string FlagCanada = "🇨🇦" ;

		public const string FlagCocosKeelingIslands = "🇨🇨" ;

		public const string FlagCongoKinshasa = "🇨🇩" ;

		public const string FlagCentralAfricanRepublic = "🇨🇫" ;

		public const string FlagCongoBrazzaville = "🇨🇬" ;

		public const string FlagSwitzerland = "🇨🇭" ;

		public const string FlagCoteDivoire = "🇨🇮" ;

		public const string FlagCookIslands = "🇨🇰" ;

		public const string FlagChile = "🇨🇱" ;

		public const string FlagCameroon = "🇨🇲" ;

		public const string FlagChina = "🇨🇳" ;

		public const string FlagColombia = "🇨🇴" ;

		public const string FlagClippertonIsland = "🇨🇵" ;

		public const string FlagCostaRica = "🇨🇷" ;

		public const string FlagCuba = "🇨🇺" ;

		public const string FlagCapeVerde = "🇨🇻" ;

		public const string FlagCuracao = "🇨🇼" ;

		public const string FlagChristmasIsland = "🇨🇽" ;

		public const string FlagCyprus = "🇨🇾" ;

		public const string FlagCzechia = "🇨🇿" ;

		public const string FlagGermany = "🇩🇪" ;

		public const string FlagDiegoGarcia = "🇩🇬" ;

		public const string FlagDjibouti = "🇩🇯" ;

		public const string FlagDenmark = "🇩🇰" ;

		public const string FlagDominica = "🇩🇲" ;

		public const string FlagDominicanRepublic = "🇩🇴" ;

		public const string FlagAlgeria = "🇩🇿" ;

		public const string FlagCeutaMelilla = "🇪🇦" ;

		public const string FlagEcuador = "🇪🇨" ;

		public const string FlagEstonia = "🇪🇪" ;

		public const string FlagEgypt = "🇪🇬" ;

		public const string FlagWesternSahara = "🇪🇭" ;

		public const string FlagEritrea = "🇪🇷" ;

		public const string FlagSpain = "🇪🇸" ;

		public const string FlagEthiopia = "🇪🇹" ;

		public const string FlagEuropeanUnion = "🇪🇺" ;

		public const string FlagFinland = "🇫🇮" ;

		public const string FlagFiji = "🇫🇯" ;

		public const string FlagFalklandIslands = "🇫🇰" ;

		public const string FlagMicronesia = "🇫🇲" ;

		public const string FlagFaroeIslands = "🇫🇴" ;

		public const string FlagFrance = "🇫🇷" ;

		public const string FlagGabon = "🇬🇦" ;

		public const string FlagUnitedKingdom = "🇬🇧" ;

		public const string FlagGrenada = "🇬🇩" ;

		public const string FlagGeorgia = "🇬🇪" ;

		public const string FlagFrenchGuiana = "🇬🇫" ;

		public const string FlagGuernsey = "🇬🇬" ;

		public const string FlagGhana = "🇬🇭" ;

		public const string FlagGibraltar = "🇬🇮" ;

		public const string FlagGreenland = "🇬🇱" ;

		public const string FlagGambia = "🇬🇲" ;

		public const string FlagGuinea = "🇬🇳" ;

		public const string FlagGuadeloupe = "🇬🇵" ;

		public const string FlagEquatorialGuinea = "🇬🇶" ;

		public const string FlagGreece = "🇬🇷" ;

		public const string FlagSouthGeorgiaSouthSandwichIslands = "🇬🇸" ;

		public const string FlagGuatemala = "🇬🇹" ;

		public const string FlagGuam = "🇬🇺" ;

		public const string FlagGuineaBissau = "🇬🇼" ;

		public const string FlagGuyana = "🇬🇾" ;

		public const string FlagHongKongSarChina = "🇭🇰" ;

		public const string FlagHeardMcdonaldIslands = "🇭🇲" ;

		public const string FlagHonduras = "🇭🇳" ;

		public const string FlagCroatia = "🇭🇷" ;

		public const string FlagHaiti = "🇭🇹" ;

		public const string FlagHungary = "🇭🇺" ;

		public const string FlagCanaryIslands = "🇮🇨" ;

		public const string FlagIndonesia = "🇮🇩" ;

		public const string FlagIreland = "🇮🇪" ;

		public const string FlagIsrael = "🇮🇱" ;

		public const string FlagIsleOfMan = "🇮🇲" ;

		public const string FlagIndia = "🇮🇳" ;

		public const string FlagBritishIndianOceanTerritory = "🇮🇴" ;

		public const string FlagIraq = "🇮🇶" ;

		public const string FlagIran = "🇮🇷" ;

		public const string FlagIceland = "🇮🇸" ;

		public const string FlagItaly = "🇮🇹" ;

		public const string FlagJersey = "🇯🇪" ;

		public const string FlagJamaica = "🇯🇲" ;

		public const string FlagJordan = "🇯🇴" ;

		public const string FlagJapan = "🇯🇵" ;

		public const string FlagKenya = "🇰🇪" ;

		public const string FlagKyrgyzstan = "🇰🇬" ;

		public const string FlagCambodia = "🇰🇭" ;

		public const string FlagKiribati = "🇰🇮" ;

		public const string FlagComoros = "🇰🇲" ;

		public const string FlagStKittsNevis = "🇰🇳" ;

		public const string FlagNorthKorea = "🇰🇵" ;

		public const string FlagSouthKorea = "🇰🇷" ;

		public const string FlagKuwait = "🇰🇼" ;

		public const string FlagCaymanIslands = "🇰🇾" ;

		public const string FlagKazakhstan = "🇰🇿" ;

		public const string FlagLaos = "🇱🇦" ;

		public const string FlagLebanon = "🇱🇧" ;

		public const string FlagStLucia = "🇱🇨" ;

		public const string FlagLiechtenstein = "🇱🇮" ;

		public const string FlagSriLanka = "🇱🇰" ;

		public const string FlagLiberia = "🇱🇷" ;

		public const string FlagLesotho = "🇱🇸" ;

		public const string FlagLithuania = "🇱🇹" ;

		public const string FlagLuxembourg = "🇱🇺" ;

		public const string FlagLatvia = "🇱🇻" ;

		public const string FlagLibya = "🇱🇾" ;

		public const string FlagMorocco = "🇲🇦" ;

		public const string FlagMonaco = "🇲🇨" ;

		public const string FlagMoldova = "🇲🇩" ;

		public const string FlagMontenegro = "🇲🇪" ;

		public const string FlagStMartin = "🇲🇫" ;

		public const string FlagMadagascar = "🇲🇬" ;

		public const string FlagMarshallIslands = "🇲🇭" ;

		public const string FlagMacedonia = "🇲🇰" ;

		public const string FlagMali = "🇲🇱" ;

		public const string FlagMyanmarBurma = "🇲🇲" ;

		public const string FlagMongolia = "🇲🇳" ;

		public const string FlagMacauSarChina = "🇲🇴" ;

		public const string FlagNorthernMarianaIslands = "🇲🇵" ;

		public const string FlagMartinique = "🇲🇶" ;

		public const string FlagMauritania = "🇲🇷" ;

		public const string FlagMontserrat = "🇲🇸" ;

		public const string FlagMalta = "🇲🇹" ;

		public const string FlagMauritius = "🇲🇺" ;

		public const string FlagMaldives = "🇲🇻" ;

		public const string FlagMalawi = "🇲🇼" ;

		public const string FlagMexico = "🇲🇽" ;

		public const string FlagMalaysia = "🇲🇾" ;

		public const string FlagMozambique = "🇲🇿" ;

		public const string FlagNamibia = "🇳🇦" ;

		public const string FlagNewCaledonia = "🇳🇨" ;

		public const string FlagNiger = "🇳🇪" ;

		public const string FlagNorfolkIsland = "🇳🇫" ;

		public const string FlagNigeria = "🇳🇬" ;

		public const string FlagNicaragua = "🇳🇮" ;

		public const string FlagNetherlands = "🇳🇱" ;

		public const string FlagNorway = "🇳🇴" ;

		public const string FlagNepal = "🇳🇵" ;

		public const string FlagNauru = "🇳🇷" ;

		public const string FlagNiue = "🇳🇺" ;

		public const string FlagNewZealand = "🇳🇿" ;

		public const string FlagOman = "🇴🇲" ;

		public const string FlagPanama = "🇵🇦" ;

		public const string FlagPeru = "🇵🇪" ;

		public const string FlagFrenchPolynesia = "🇵🇫" ;

		public const string FlagPapuaNewGuinea = "🇵🇬" ;

		public const string FlagPhilippines = "🇵🇭" ;

		public const string FlagPakistan = "🇵🇰" ;

		public const string FlagPoland = "🇵🇱" ;

		public const string FlagStPierreMiquelon = "🇵🇲" ;

		public const string FlagPitcairnIslands = "🇵🇳" ;

		public const string FlagPuertoRico = "🇵🇷" ;

		public const string FlagPalestinianTerritories = "🇵🇸" ;

		public const string FlagPortugal = "🇵🇹" ;

		public const string FlagPalau = "🇵🇼" ;

		public const string FlagParaguay = "🇵🇾" ;

		public const string FlagQatar = "🇶🇦" ;

		public const string FlagReunion = "🇷🇪" ;

		public const string FlagRomania = "🇷🇴" ;

		public const string FlagSerbia = "🇷🇸" ;

		public const string FlagRussia = "🇷🇺" ;

		public const string FlagRwanda = "🇷🇼" ;

		public const string FlagSaudiArabia = "🇸🇦" ;

		public const string FlagSolomonIslands = "🇸🇧" ;

		public const string FlagSeychelles = "🇸🇨" ;

		public const string FlagSudan = "🇸🇩" ;

		public const string FlagSweden = "🇸🇪" ;

		public const string FlagSingapore = "🇸🇬" ;

		public const string FlagStHelena = "🇸🇭" ;

		public const string FlagSlovenia = "🇸🇮" ;

		public const string FlagSvalbardJanMayen = "🇸🇯" ;

		public const string FlagSlovakia = "🇸🇰" ;

		public const string FlagSierraLeone = "🇸🇱" ;

		public const string FlagSanMarino = "🇸🇲" ;

		public const string FlagSenegal = "🇸🇳" ;

		public const string FlagSomalia = "🇸🇴" ;

		public const string FlagSuriname = "🇸🇷" ;

		public const string FlagSouthSudan = "🇸🇸" ;

		public const string FlagSaoTomePrincipe = "🇸🇹" ;

		public const string FlagElSalvador = "🇸🇻" ;

		public const string FlagSintMaarten = "🇸🇽" ;

		public const string FlagSyria = "🇸🇾" ;

		public const string FlagSwaziland = "🇸🇿" ;

		public const string FlagTristanDaCunha = "🇹🇦" ;

		public const string FlagTurksCaicosIslands = "🇹🇨" ;

		public const string FlagChad = "🇹🇩" ;

		public const string FlagFrenchSouthernTerritories = "🇹🇫" ;

		public const string FlagTogo = "🇹🇬" ;

		public const string FlagThailand = "🇹🇭" ;

		public const string FlagTajikistan = "🇹🇯" ;

		public const string FlagTokelau = "🇹🇰" ;

		public const string FlagTimorLeste = "🇹🇱" ;

		public const string FlagTurkmenistan = "🇹🇲" ;

		public const string FlagTunisia = "🇹🇳" ;

		public const string FlagTonga = "🇹🇴" ;

		public const string FlagTurkey = "🇹🇷" ;

		public const string FlagTrinidadTobago = "🇹🇹" ;

		public const string FlagTuvalu = "🇹🇻" ;

		public const string FlagTaiwan = "🇹🇼" ;

		public const string FlagTanzania = "🇹🇿" ;

		public const string FlagUkraine = "🇺🇦" ;

		public const string FlagUganda = "🇺🇬" ;

		public const string FlagUsOutlyingIslands = "🇺🇲" ;

		public const string FlagUnitedNations = "🇺🇳" ;

		public const string FlagUnitedStates = "🇺🇸" ;

		public const string FlagUruguay = "🇺🇾" ;

		public const string FlagUzbekistan = "🇺🇿" ;

		public const string FlagVaticanCity = "🇻🇦" ;

		public const string FlagStVincentGrenadines = "🇻🇨" ;

		public const string FlagVenezuela = "🇻🇪" ;

		public const string FlagBritishVirginIslands = "🇻🇬" ;

		public const string FlagUsVirginIslands = "🇻🇮" ;

		public const string FlagVietnam = "🇻🇳" ;

		public const string FlagVanuatu = "🇻🇺" ;

		public const string FlagWallisFutuna = "🇼🇫" ;

		public const string FlagSamoa = "🇼🇸" ;

		public const string FlagKosovo = "🇽🇰" ;

		public const string FlagYemen = "🇾🇪" ;

		public const string FlagMayotte = "🇾🇹" ;

		public const string FlagSouthAfrica = "🇿🇦" ;

		public const string FlagZambia = "🇿🇲" ;

		public const string FlagZimbabwe = "🇿🇼" ;

		public const string FlagEngland = "🏴󠁧󠁢󠁥󠁮󠁧󠁿" ;

		public const string FlagScotland = "🏴󠁧󠁢󠁳󠁣󠁴󠁿" ;

		public const string FlagWales = "🏴󠁧󠁢󠁷󠁬󠁳󠁿" ;

	}

}
