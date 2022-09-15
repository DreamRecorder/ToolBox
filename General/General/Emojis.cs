using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Linq ;
using System . Reflection ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	/// <summary>
	///     Known Emojis, Update to 15.0
	/// </summary>
	[PublicAPI]
	public static class Emojis
	{

		public static ReadOnlyDictionary <string , string> EmojisList { get ; }

		static Emojis ( )
		{
			Dictionary <string , string> emojis = typeof ( Emojis ) .
												GetFields (
															BindingFlags . Static
															| BindingFlags . Public
															| BindingFlags . DeclaredOnly ) .
												ToDictionary (
															fieldInfo => fieldInfo . Name ,
															fieldInfo => ( string )fieldInfo . GetValue ( null ) ) ;

			EmojisList = new ReadOnlyDictionary <string , string> ( emojis ) ;
		}

		/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

using DreamRecorder.ToolBox.General;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			FileStream stream = File.OpenRead(@"C:\Users\wenceywang\Desktop\emoji-test-15.txt");
			FileStream oStream = File.OpenWrite(@"C:\Users\wenceywang\Desktop\emoji-test-15-result.txt");

			StreamReader reader = new StreamReader(stream);
			StreamWriter writer = new StreamWriter(oStream);

			string currentLine = reader.ReadToEnd();

			MatchCollection result = Regex.Matches(currentLine, @"^[^#\n]+; ([^\s]+)[\s]+# ([^\s]+)\s(?:[^\s]+)\s(.+)", RegexOptions.Multiline);

			Dictionary<string, string> resultDict = new Dictionary<string, string>();

			foreach (Match capture in result)
			{
				string name;


				if (result.Count((m) => m.Groups[3].Value == capture.Groups[3].Value)>1)
				{
					name =
						$"{CamelCase(capture.Groups[3].Value.Trim().ToSlug())}{CamelCase(capture.Groups[1].Value.Trim().ToSlug())}";
				}
				else
				{
					name = CamelCase(capture.Groups[3].Value.Trim().ToSlug());
				}

				int count = resultDict.Count((pair) => pair.Key == name);

				name = GetName(name, count);

				string value = $"public const string {name} = \"{capture.Groups[2].Value}\";";

				Console.WriteLine(value);

				writer.WriteLine(value);

				resultDict.Add(name, value);

			}

			writer.Flush();

		}

		static string CamelCase(string s)
		{
			return String.Join("", s.Split('-').Select(x => Char.ToUpper(x[0]) + x.Substring(1)));
		}

		static string GetName(string value, int count)
		{
			if (count <= 0)
			{
				return value;
			}
			else
			{
				return $"{value}{count + 1}";
			}
		}
	}
}
		*/
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

		public const string MeltingFace = "🫠" ;

		public const string WinkingFace = "😉" ;

		public const string SmilingFaceWithSmilingEyes = "😊" ;

		public const string SmilingFaceWithHalo = "😇" ;

		public const string SmilingFaceWithHearts = "🥰" ;

		public const string SmilingFaceWithHeartEyes = "😍" ;

		public const string StarStruck = "🤩" ;

		public const string FaceBlowingAKiss = "😘" ;

		public const string KissingFace = "😗" ;

		public const string SmilingFaceFullyQualified = "☺️" ;

		public const string SmilingFaceUnqualified = "☺" ;

		public const string KissingFaceWithClosedEyes = "😚" ;

		public const string KissingFaceWithSmilingEyes = "😙" ;

		public const string SmilingFaceWithTear = "🥲" ;

		public const string FaceSavoringFood = "😋" ;

		public const string FaceWithTongue = "😛" ;

		public const string WinkingFaceWithTongue = "😜" ;

		public const string ZanyFace = "🤪" ;

		public const string SquintingFaceWithTongue = "😝" ;

		public const string MoneyMouthFace = "🤑" ;

		public const string SmilingFaceWithOpenHands = "🤗" ;

		public const string FaceWithHandOverMouth = "🤭" ;

		public const string FaceWithOpenEyesAndHandOverMouth = "🫢" ;

		public const string FaceWithPeekingEye = "🫣" ;

		public const string ShushingFace = "🤫" ;

		public const string ThinkingFace = "🤔" ;

		public const string SalutingFace = "🫡" ;

		public const string ZipperMouthFace = "🤐" ;

		public const string FaceWithRaisedEyebrow = "🤨" ;

		public const string NeutralFace = "😐" ;

		public const string ExpressionlessFace = "😑" ;

		public const string FaceWithoutMouth = "😶" ;

		public const string DottedLineFace = "🫥" ;

		public const string FaceInCloudsFullyQualified = "😶‍🌫️" ;

		public const string FaceInCloudsMinimallyQualified = "😶‍🌫" ;

		public const string SmirkingFace = "😏" ;

		public const string UnamusedFace = "😒" ;

		public const string FaceWithRollingEyes = "🙄" ;

		public const string GrimacingFace = "😬" ;

		public const string FaceExhaling = "😮‍💨" ;

		public const string LyingFace = "🤥" ;

		public const string ShakingFace = "🫨" ;

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

		public const string FaceWithCrossedOutEyes = "😵" ;

		public const string FaceWithSpiralEyes = "😵‍💫" ;

		public const string ExplodingHead = "🤯" ;

		public const string CowboyHatFace = "🤠" ;

		public const string PartyingFace = "🥳" ;

		public const string DisguisedFace = "🥸" ;

		public const string SmilingFaceWithSunglasses = "😎" ;

		public const string NerdFace = "🤓" ;

		public const string FaceWithMonocle = "🧐" ;

		public const string ConfusedFace = "😕" ;

		public const string FaceWithDiagonalMouth = "🫤" ;

		public const string WorriedFace = "😟" ;

		public const string SlightlyFrowningFace = "🙁" ;

		public const string FrowningFaceFullyQualified = "☹️" ;

		public const string FrowningFaceUnqualified = "☹" ;

		public const string FaceWithOpenMouth = "😮" ;

		public const string HushedFace = "😯" ;

		public const string AstonishedFace = "😲" ;

		public const string FlushedFace = "😳" ;

		public const string PleadingFace = "🥺" ;

		public const string FaceHoldingBackTears = "🥹" ;

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

		public const string EnragedFace = "😡" ;

		public const string AngryFace = "😠" ;

		public const string FaceWithSymbolsOnMouth = "🤬" ;

		public const string SmilingFaceWithHorns = "😈" ;

		public const string AngryFaceWithHorns = "👿" ;

		public const string Skull = "💀" ;

		public const string SkullAndCrossbonesFullyQualified = "☠️" ;

		public const string SkullAndCrossbonesUnqualified = "☠" ;

		public const string PileOfPoo = "💩" ;

		public const string ClownFace = "🤡" ;

		public const string Ogre = "👹" ;

		public const string Goblin = "👺" ;

		public const string Ghost = "👻" ;

		public const string Alien = "👽" ;

		public const string AlienMonster = "👾" ;

		public const string Robot = "🤖" ;

		public const string GrinningCat = "😺" ;

		public const string GrinningCatWithSmilingEyes = "😸" ;

		public const string CatWithTearsOfJoy = "😹" ;

		public const string SmilingCatWithHeartEyes = "😻" ;

		public const string CatWithWrySmile = "😼" ;

		public const string KissingCat = "😽" ;

		public const string WearyCat = "🙀" ;

		public const string CryingCat = "😿" ;

		public const string PoutingCat = "😾" ;

		public const string SeeNoEvilMonkey = "🙈" ;

		public const string HearNoEvilMonkey = "🙉" ;

		public const string SpeakNoEvilMonkey = "🙊" ;

		public const string LoveLetter = "💌" ;

		public const string HeartWithArrow = "💘" ;

		public const string HeartWithRibbon = "💝" ;

		public const string SparklingHeart = "💖" ;

		public const string GrowingHeart = "💗" ;

		public const string BeatingHeart = "💓" ;

		public const string RevolvingHearts = "💞" ;

		public const string TwoHearts = "💕" ;

		public const string HeartDecoration = "💟" ;

		public const string HeartExclamationFullyQualified = "❣️" ;

		public const string HeartExclamationUnqualified = "❣" ;

		public const string BrokenHeart = "💔" ;

		public const string HeartOnFireFullyQualified = "❤️‍🔥" ;

		public const string HeartOnFireUnqualified = "❤‍🔥" ;

		public const string MendingHeartFullyQualified = "❤️‍🩹" ;

		public const string MendingHeartUnqualified = "❤‍🩹" ;

		public const string RedHeartFullyQualified = "❤️" ;

		public const string RedHeartUnqualified = "❤" ;

		public const string PinkHeart = "🩷" ;

		public const string OrangeHeart = "🧡" ;

		public const string YellowHeart = "💛" ;

		public const string GreenHeart = "💚" ;

		public const string BlueHeart = "💙" ;

		public const string LightBlueHeart = "🩵" ;

		public const string PurpleHeart = "💜" ;

		public const string BrownHeart = "🤎" ;

		public const string BlackHeart = "🖤" ;

		public const string GreyHeart = "🩶" ;

		public const string WhiteHeart = "🤍" ;

		public const string KissMark = "💋" ;

		public const string HundredPoints = "💯" ;

		public const string AngerSymbol = "💢" ;

		public const string Collision = "💥" ;

		public const string Dizzy = "💫" ;

		public const string SweatDroplets = "💦" ;

		public const string DashingAway = "💨" ;

		public const string HoleFullyQualified = "🕳️" ;

		public const string HoleUnqualified = "🕳" ;

		public const string SpeechBalloon = "💬" ;

		public const string EyeInSpeechBubbleFullyQualified = "👁️‍🗨️" ;

		public const string EyeInSpeechBubbleUnqualified = "👁‍🗨️" ;

		public const string EyeInSpeechBubbleMinimallyQualified = "👁️‍🗨" ;

		public const string EyeInSpeechBubbleUnqualified2 = "👁‍🗨" ;

		public const string LeftSpeechBubbleFullyQualified = "🗨️" ;

		public const string LeftSpeechBubbleUnqualified = "🗨" ;

		public const string RightAngerBubbleFullyQualified = "🗯️" ;

		public const string RightAngerBubbleUnqualified = "🗯" ;

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

		public const string HandWithFingersSplayedFullyQualified = "🖐️" ;

		public const string HandWithFingersSplayedUnqualified = "🖐" ;

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

		public const string RightwardsHand = "🫱" ;

		public const string RightwardsHandLightSkinTone = "🫱🏻" ;

		public const string RightwardsHandMediumLightSkinTone = "🫱🏼" ;

		public const string RightwardsHandMediumSkinTone = "🫱🏽" ;

		public const string RightwardsHandMediumDarkSkinTone = "🫱🏾" ;

		public const string RightwardsHandDarkSkinTone = "🫱🏿" ;

		public const string LeftwardsHand = "🫲" ;

		public const string LeftwardsHandLightSkinTone = "🫲🏻" ;

		public const string LeftwardsHandMediumLightSkinTone = "🫲🏼" ;

		public const string LeftwardsHandMediumSkinTone = "🫲🏽" ;

		public const string LeftwardsHandMediumDarkSkinTone = "🫲🏾" ;

		public const string LeftwardsHandDarkSkinTone = "🫲🏿" ;

		public const string PalmDownHand = "🫳" ;

		public const string PalmDownHandLightSkinTone = "🫳🏻" ;

		public const string PalmDownHandMediumLightSkinTone = "🫳🏼" ;

		public const string PalmDownHandMediumSkinTone = "🫳🏽" ;

		public const string PalmDownHandMediumDarkSkinTone = "🫳🏾" ;

		public const string PalmDownHandDarkSkinTone = "🫳🏿" ;

		public const string PalmUpHand = "🫴" ;

		public const string PalmUpHandLightSkinTone = "🫴🏻" ;

		public const string PalmUpHandMediumLightSkinTone = "🫴🏼" ;

		public const string PalmUpHandMediumSkinTone = "🫴🏽" ;

		public const string PalmUpHandMediumDarkSkinTone = "🫴🏾" ;

		public const string PalmUpHandDarkSkinTone = "🫴🏿" ;

		public const string LeftwardsPushingHand = "🫷" ;

		public const string LeftwardsPushingHandLightSkinTone = "🫷🏻" ;

		public const string LeftwardsPushingHandMediumLightSkinTone = "🫷🏼" ;

		public const string LeftwardsPushingHandMediumSkinTone = "🫷🏽" ;

		public const string LeftwardsPushingHandMediumDarkSkinTone = "🫷🏾" ;

		public const string LeftwardsPushingHandDarkSkinTone = "🫷🏿" ;

		public const string RightwardsPushingHand = "🫸" ;

		public const string RightwardsPushingHandLightSkinTone = "🫸🏻" ;

		public const string RightwardsPushingHandMediumLightSkinTone = "🫸🏼" ;

		public const string RightwardsPushingHandMediumSkinTone = "🫸🏽" ;

		public const string RightwardsPushingHandMediumDarkSkinTone = "🫸🏾" ;

		public const string RightwardsPushingHandDarkSkinTone = "🫸🏿" ;

		public const string OkHand = "👌" ;

		public const string OkHandLightSkinTone = "👌🏻" ;

		public const string OkHandMediumLightSkinTone = "👌🏼" ;

		public const string OkHandMediumSkinTone = "👌🏽" ;

		public const string OkHandMediumDarkSkinTone = "👌🏾" ;

		public const string OkHandDarkSkinTone = "👌🏿" ;

		public const string PinchedFingers = "🤌" ;

		public const string PinchedFingersLightSkinTone = "🤌🏻" ;

		public const string PinchedFingersMediumLightSkinTone = "🤌🏼" ;

		public const string PinchedFingersMediumSkinTone = "🤌🏽" ;

		public const string PinchedFingersMediumDarkSkinTone = "🤌🏾" ;

		public const string PinchedFingersDarkSkinTone = "🤌🏿" ;

		public const string PinchingHand = "🤏" ;

		public const string PinchingHandLightSkinTone = "🤏🏻" ;

		public const string PinchingHandMediumLightSkinTone = "🤏🏼" ;

		public const string PinchingHandMediumSkinTone = "🤏🏽" ;

		public const string PinchingHandMediumDarkSkinTone = "🤏🏾" ;

		public const string PinchingHandDarkSkinTone = "🤏🏿" ;

		public const string VictoryHandFullyQualified = "✌️" ;

		public const string VictoryHandUnqualified = "✌" ;

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

		public const string HandWithIndexFingerAndThumbCrossed = "🫰" ;

		public const string HandWithIndexFingerAndThumbCrossedLightSkinTone = "🫰🏻" ;

		public const string HandWithIndexFingerAndThumbCrossedMediumLightSkinTone = "🫰🏼" ;

		public const string HandWithIndexFingerAndThumbCrossedMediumSkinTone = "🫰🏽" ;

		public const string HandWithIndexFingerAndThumbCrossedMediumDarkSkinTone = "🫰🏾" ;

		public const string HandWithIndexFingerAndThumbCrossedDarkSkinTone = "🫰🏿" ;

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

		public const string IndexPointingUpFullyQualified = "☝️" ;

		public const string IndexPointingUpUnqualified = "☝" ;

		public const string IndexPointingUpLightSkinTone = "☝🏻" ;

		public const string IndexPointingUpMediumLightSkinTone = "☝🏼" ;

		public const string IndexPointingUpMediumSkinTone = "☝🏽" ;

		public const string IndexPointingUpMediumDarkSkinTone = "☝🏾" ;

		public const string IndexPointingUpDarkSkinTone = "☝🏿" ;

		public const string IndexPointingAtTheViewer = "🫵" ;

		public const string IndexPointingAtTheViewerLightSkinTone = "🫵🏻" ;

		public const string IndexPointingAtTheViewerMediumLightSkinTone = "🫵🏼" ;

		public const string IndexPointingAtTheViewerMediumSkinTone = "🫵🏽" ;

		public const string IndexPointingAtTheViewerMediumDarkSkinTone = "🫵🏾" ;

		public const string IndexPointingAtTheViewerDarkSkinTone = "🫵🏿" ;

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

		public const string HeartHands = "🫶" ;

		public const string HeartHandsLightSkinTone = "🫶🏻" ;

		public const string HeartHandsMediumLightSkinTone = "🫶🏼" ;

		public const string HeartHandsMediumSkinTone = "🫶🏽" ;

		public const string HeartHandsMediumDarkSkinTone = "🫶🏾" ;

		public const string HeartHandsDarkSkinTone = "🫶🏿" ;

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

		public const string HandshakeLightSkinToneMediumLightSkinTone = "🫱🏻‍🫲🏼" ;

		public const string HandshakeLightSkinToneMediumSkinTone = "🫱🏻‍🫲🏽" ;

		public const string HandshakeLightSkinToneMediumDarkSkinTone = "🫱🏻‍🫲🏾" ;

		public const string HandshakeLightSkinToneDarkSkinTone = "🫱🏻‍🫲🏿" ;

		public const string HandshakeMediumLightSkinToneLightSkinTone = "🫱🏼‍🫲🏻" ;

		public const string HandshakeMediumLightSkinToneMediumSkinTone = "🫱🏼‍🫲🏽" ;

		public const string HandshakeMediumLightSkinToneMediumDarkSkinTone = "🫱🏼‍🫲🏾" ;

		public const string HandshakeMediumLightSkinToneDarkSkinTone = "🫱🏼‍🫲🏿" ;

		public const string HandshakeMediumSkinToneLightSkinTone = "🫱🏽‍🫲🏻" ;

		public const string HandshakeMediumSkinToneMediumLightSkinTone = "🫱🏽‍🫲🏼" ;

		public const string HandshakeMediumSkinToneMediumDarkSkinTone = "🫱🏽‍🫲🏾" ;

		public const string HandshakeMediumSkinToneDarkSkinTone = "🫱🏽‍🫲🏿" ;

		public const string HandshakeMediumDarkSkinToneLightSkinTone = "🫱🏾‍🫲🏻" ;

		public const string HandshakeMediumDarkSkinToneMediumLightSkinTone = "🫱🏾‍🫲🏼" ;

		public const string HandshakeMediumDarkSkinToneMediumSkinTone = "🫱🏾‍🫲🏽" ;

		public const string HandshakeMediumDarkSkinToneDarkSkinTone = "🫱🏾‍🫲🏿" ;

		public const string HandshakeDarkSkinToneLightSkinTone = "🫱🏿‍🫲🏻" ;

		public const string HandshakeDarkSkinToneMediumLightSkinTone = "🫱🏿‍🫲🏼" ;

		public const string HandshakeDarkSkinToneMediumSkinTone = "🫱🏿‍🫲🏽" ;

		public const string HandshakeDarkSkinToneMediumDarkSkinTone = "🫱🏿‍🫲🏾" ;

		public const string FoldedHands = "🙏" ;

		public const string FoldedHandsLightSkinTone = "🙏🏻" ;

		public const string FoldedHandsMediumLightSkinTone = "🙏🏼" ;

		public const string FoldedHandsMediumSkinTone = "🙏🏽" ;

		public const string FoldedHandsMediumDarkSkinTone = "🙏🏾" ;

		public const string FoldedHandsDarkSkinTone = "🙏🏿" ;

		public const string WritingHandFullyQualified = "✍️" ;

		public const string WritingHandUnqualified = "✍" ;

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

		public const string AnatomicalHeart = "🫀" ;

		public const string Lungs = "🫁" ;

		public const string Tooth = "🦷" ;

		public const string Bone = "🦴" ;

		public const string Eyes = "👀" ;

		public const string EyeFullyQualified = "👁️" ;

		public const string EyeUnqualified = "👁" ;

		public const string Tongue = "👅" ;

		public const string Mouth = "👄" ;

		public const string BitingLip = "🫦" ;

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

		public const string PersonBeard = "🧔" ;

		public const string PersonLightSkinToneBeard = "🧔🏻" ;

		public const string PersonMediumLightSkinToneBeard = "🧔🏼" ;

		public const string PersonMediumSkinToneBeard = "🧔🏽" ;

		public const string PersonMediumDarkSkinToneBeard = "🧔🏾" ;

		public const string PersonDarkSkinToneBeard = "🧔🏿" ;

		public const string ManBeardFullyQualified = "🧔‍♂️" ;

		public const string ManBeardMinimallyQualified = "🧔‍♂" ;

		public const string ManLightSkinToneBeardFullyQualified = "🧔🏻‍♂️" ;

		public const string ManLightSkinToneBeardMinimallyQualified = "🧔🏻‍♂" ;

		public const string ManMediumLightSkinToneBeardFullyQualified = "🧔🏼‍♂️" ;

		public const string ManMediumLightSkinToneBeardMinimallyQualified = "🧔🏼‍♂" ;

		public const string ManMediumSkinToneBeardFullyQualified = "🧔🏽‍♂️" ;

		public const string ManMediumSkinToneBeardMinimallyQualified = "🧔🏽‍♂" ;

		public const string ManMediumDarkSkinToneBeardFullyQualified = "🧔🏾‍♂️" ;

		public const string ManMediumDarkSkinToneBeardMinimallyQualified = "🧔🏾‍♂" ;

		public const string ManDarkSkinToneBeardFullyQualified = "🧔🏿‍♂️" ;

		public const string ManDarkSkinToneBeardMinimallyQualified = "🧔🏿‍♂" ;

		public const string WomanBeardFullyQualified = "🧔‍♀️" ;

		public const string WomanBeardMinimallyQualified = "🧔‍♀" ;

		public const string WomanLightSkinToneBeardFullyQualified = "🧔🏻‍♀️" ;

		public const string WomanLightSkinToneBeardMinimallyQualified = "🧔🏻‍♀" ;

		public const string WomanMediumLightSkinToneBeardFullyQualified = "🧔🏼‍♀️" ;

		public const string WomanMediumLightSkinToneBeardMinimallyQualified = "🧔🏼‍♀" ;

		public const string WomanMediumSkinToneBeardFullyQualified = "🧔🏽‍♀️" ;

		public const string WomanMediumSkinToneBeardMinimallyQualified = "🧔🏽‍♀" ;

		public const string WomanMediumDarkSkinToneBeardFullyQualified = "🧔🏾‍♀️" ;

		public const string WomanMediumDarkSkinToneBeardMinimallyQualified = "🧔🏾‍♀" ;

		public const string WomanDarkSkinToneBeardFullyQualified = "🧔🏿‍♀️" ;

		public const string WomanDarkSkinToneBeardMinimallyQualified = "🧔🏿‍♀" ;

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

		public const string Woman = "👩" ;

		public const string WomanLightSkinTone = "👩🏻" ;

		public const string WomanMediumLightSkinTone = "👩🏼" ;

		public const string WomanMediumSkinTone = "👩🏽" ;

		public const string WomanMediumDarkSkinTone = "👩🏾" ;

		public const string WomanDarkSkinTone = "👩🏿" ;

		public const string WomanRedHair = "👩‍🦰" ;

		public const string WomanLightSkinToneRedHair = "👩🏻‍🦰" ;

		public const string WomanMediumLightSkinToneRedHair = "👩🏼‍🦰" ;

		public const string WomanMediumSkinToneRedHair = "👩🏽‍🦰" ;

		public const string WomanMediumDarkSkinToneRedHair = "👩🏾‍🦰" ;

		public const string WomanDarkSkinToneRedHair = "👩🏿‍🦰" ;

		public const string PersonRedHair = "🧑‍🦰" ;

		public const string PersonLightSkinToneRedHair = "🧑🏻‍🦰" ;

		public const string PersonMediumLightSkinToneRedHair = "🧑🏼‍🦰" ;

		public const string PersonMediumSkinToneRedHair = "🧑🏽‍🦰" ;

		public const string PersonMediumDarkSkinToneRedHair = "🧑🏾‍🦰" ;

		public const string PersonDarkSkinToneRedHair = "🧑🏿‍🦰" ;

		public const string WomanCurlyHair = "👩‍🦱" ;

		public const string WomanLightSkinToneCurlyHair = "👩🏻‍🦱" ;

		public const string WomanMediumLightSkinToneCurlyHair = "👩🏼‍🦱" ;

		public const string WomanMediumSkinToneCurlyHair = "👩🏽‍🦱" ;

		public const string WomanMediumDarkSkinToneCurlyHair = "👩🏾‍🦱" ;

		public const string WomanDarkSkinToneCurlyHair = "👩🏿‍🦱" ;

		public const string PersonCurlyHair = "🧑‍🦱" ;

		public const string PersonLightSkinToneCurlyHair = "🧑🏻‍🦱" ;

		public const string PersonMediumLightSkinToneCurlyHair = "🧑🏼‍🦱" ;

		public const string PersonMediumSkinToneCurlyHair = "🧑🏽‍🦱" ;

		public const string PersonMediumDarkSkinToneCurlyHair = "🧑🏾‍🦱" ;

		public const string PersonDarkSkinToneCurlyHair = "🧑🏿‍🦱" ;

		public const string WomanWhiteHair = "👩‍🦳" ;

		public const string WomanLightSkinToneWhiteHair = "👩🏻‍🦳" ;

		public const string WomanMediumLightSkinToneWhiteHair = "👩🏼‍🦳" ;

		public const string WomanMediumSkinToneWhiteHair = "👩🏽‍🦳" ;

		public const string WomanMediumDarkSkinToneWhiteHair = "👩🏾‍🦳" ;

		public const string WomanDarkSkinToneWhiteHair = "👩🏿‍🦳" ;

		public const string PersonWhiteHair = "🧑‍🦳" ;

		public const string PersonLightSkinToneWhiteHair = "🧑🏻‍🦳" ;

		public const string PersonMediumLightSkinToneWhiteHair = "🧑🏼‍🦳" ;

		public const string PersonMediumSkinToneWhiteHair = "🧑🏽‍🦳" ;

		public const string PersonMediumDarkSkinToneWhiteHair = "🧑🏾‍🦳" ;

		public const string PersonDarkSkinToneWhiteHair = "🧑🏿‍🦳" ;

		public const string WomanBald = "👩‍🦲" ;

		public const string WomanLightSkinToneBald = "👩🏻‍🦲" ;

		public const string WomanMediumLightSkinToneBald = "👩🏼‍🦲" ;

		public const string WomanMediumSkinToneBald = "👩🏽‍🦲" ;

		public const string WomanMediumDarkSkinToneBald = "👩🏾‍🦲" ;

		public const string WomanDarkSkinToneBald = "👩🏿‍🦲" ;

		public const string PersonBald = "🧑‍🦲" ;

		public const string PersonLightSkinToneBald = "🧑🏻‍🦲" ;

		public const string PersonMediumLightSkinToneBald = "🧑🏼‍🦲" ;

		public const string PersonMediumSkinToneBald = "🧑🏽‍🦲" ;

		public const string PersonMediumDarkSkinToneBald = "🧑🏾‍🦲" ;

		public const string PersonDarkSkinToneBald = "🧑🏿‍🦲" ;

		public const string WomanBlondHairFullyQualified = "👱‍♀️" ;

		public const string WomanBlondHairMinimallyQualified = "👱‍♀" ;

		public const string WomanLightSkinToneBlondHairFullyQualified = "👱🏻‍♀️" ;

		public const string WomanLightSkinToneBlondHairMinimallyQualified = "👱🏻‍♀" ;

		public const string WomanMediumLightSkinToneBlondHairFullyQualified = "👱🏼‍♀️" ;

		public const string WomanMediumLightSkinToneBlondHairMinimallyQualified = "👱🏼‍♀" ;

		public const string WomanMediumSkinToneBlondHairFullyQualified = "👱🏽‍♀️" ;

		public const string WomanMediumSkinToneBlondHairMinimallyQualified = "👱🏽‍♀" ;

		public const string WomanMediumDarkSkinToneBlondHairFullyQualified = "👱🏾‍♀️" ;

		public const string WomanMediumDarkSkinToneBlondHairMinimallyQualified = "👱🏾‍♀" ;

		public const string WomanDarkSkinToneBlondHairFullyQualified = "👱🏿‍♀️" ;

		public const string WomanDarkSkinToneBlondHairMinimallyQualified = "👱🏿‍♀" ;

		public const string ManBlondHairFullyQualified = "👱‍♂️" ;

		public const string ManBlondHairMinimallyQualified = "👱‍♂" ;

		public const string ManLightSkinToneBlondHairFullyQualified = "👱🏻‍♂️" ;

		public const string ManLightSkinToneBlondHairMinimallyQualified = "👱🏻‍♂" ;

		public const string ManMediumLightSkinToneBlondHairFullyQualified = "👱🏼‍♂️" ;

		public const string ManMediumLightSkinToneBlondHairMinimallyQualified = "👱🏼‍♂" ;

		public const string ManMediumSkinToneBlondHairFullyQualified = "👱🏽‍♂️" ;

		public const string ManMediumSkinToneBlondHairMinimallyQualified = "👱🏽‍♂" ;

		public const string ManMediumDarkSkinToneBlondHairFullyQualified = "👱🏾‍♂️" ;

		public const string ManMediumDarkSkinToneBlondHairMinimallyQualified = "👱🏾‍♂" ;

		public const string ManDarkSkinToneBlondHairFullyQualified = "👱🏿‍♂️" ;

		public const string ManDarkSkinToneBlondHairMinimallyQualified = "👱🏿‍♂" ;

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

		public const string ManFrowningFullyQualified = "🙍‍♂️" ;

		public const string ManFrowningMinimallyQualified = "🙍‍♂" ;

		public const string ManFrowningLightSkinToneFullyQualified = "🙍🏻‍♂️" ;

		public const string ManFrowningLightSkinToneMinimallyQualified = "🙍🏻‍♂" ;

		public const string ManFrowningMediumLightSkinToneFullyQualified = "🙍🏼‍♂️" ;

		public const string ManFrowningMediumLightSkinToneMinimallyQualified = "🙍🏼‍♂" ;

		public const string ManFrowningMediumSkinToneFullyQualified = "🙍🏽‍♂️" ;

		public const string ManFrowningMediumSkinToneMinimallyQualified = "🙍🏽‍♂" ;

		public const string ManFrowningMediumDarkSkinToneFullyQualified = "🙍🏾‍♂️" ;

		public const string ManFrowningMediumDarkSkinToneMinimallyQualified = "🙍🏾‍♂" ;

		public const string ManFrowningDarkSkinToneFullyQualified = "🙍🏿‍♂️" ;

		public const string ManFrowningDarkSkinToneMinimallyQualified = "🙍🏿‍♂" ;

		public const string WomanFrowningFullyQualified = "🙍‍♀️" ;

		public const string WomanFrowningMinimallyQualified = "🙍‍♀" ;

		public const string WomanFrowningLightSkinToneFullyQualified = "🙍🏻‍♀️" ;

		public const string WomanFrowningLightSkinToneMinimallyQualified = "🙍🏻‍♀" ;

		public const string WomanFrowningMediumLightSkinToneFullyQualified = "🙍🏼‍♀️" ;

		public const string WomanFrowningMediumLightSkinToneMinimallyQualified = "🙍🏼‍♀" ;

		public const string WomanFrowningMediumSkinToneFullyQualified = "🙍🏽‍♀️" ;

		public const string WomanFrowningMediumSkinToneMinimallyQualified = "🙍🏽‍♀" ;

		public const string WomanFrowningMediumDarkSkinToneFullyQualified = "🙍🏾‍♀️" ;

		public const string WomanFrowningMediumDarkSkinToneMinimallyQualified = "🙍🏾‍♀" ;

		public const string WomanFrowningDarkSkinToneFullyQualified = "🙍🏿‍♀️" ;

		public const string WomanFrowningDarkSkinToneMinimallyQualified = "🙍🏿‍♀" ;

		public const string PersonPouting = "🙎" ;

		public const string PersonPoutingLightSkinTone = "🙎🏻" ;

		public const string PersonPoutingMediumLightSkinTone = "🙎🏼" ;

		public const string PersonPoutingMediumSkinTone = "🙎🏽" ;

		public const string PersonPoutingMediumDarkSkinTone = "🙎🏾" ;

		public const string PersonPoutingDarkSkinTone = "🙎🏿" ;

		public const string ManPoutingFullyQualified = "🙎‍♂️" ;

		public const string ManPoutingMinimallyQualified = "🙎‍♂" ;

		public const string ManPoutingLightSkinToneFullyQualified = "🙎🏻‍♂️" ;

		public const string ManPoutingLightSkinToneMinimallyQualified = "🙎🏻‍♂" ;

		public const string ManPoutingMediumLightSkinToneFullyQualified = "🙎🏼‍♂️" ;

		public const string ManPoutingMediumLightSkinToneMinimallyQualified = "🙎🏼‍♂" ;

		public const string ManPoutingMediumSkinToneFullyQualified = "🙎🏽‍♂️" ;

		public const string ManPoutingMediumSkinToneMinimallyQualified = "🙎🏽‍♂" ;

		public const string ManPoutingMediumDarkSkinToneFullyQualified = "🙎🏾‍♂️" ;

		public const string ManPoutingMediumDarkSkinToneMinimallyQualified = "🙎🏾‍♂" ;

		public const string ManPoutingDarkSkinToneFullyQualified = "🙎🏿‍♂️" ;

		public const string ManPoutingDarkSkinToneMinimallyQualified = "🙎🏿‍♂" ;

		public const string WomanPoutingFullyQualified = "🙎‍♀️" ;

		public const string WomanPoutingMinimallyQualified = "🙎‍♀" ;

		public const string WomanPoutingLightSkinToneFullyQualified = "🙎🏻‍♀️" ;

		public const string WomanPoutingLightSkinToneMinimallyQualified = "🙎🏻‍♀" ;

		public const string WomanPoutingMediumLightSkinToneFullyQualified = "🙎🏼‍♀️" ;

		public const string WomanPoutingMediumLightSkinToneMinimallyQualified = "🙎🏼‍♀" ;

		public const string WomanPoutingMediumSkinToneFullyQualified = "🙎🏽‍♀️" ;

		public const string WomanPoutingMediumSkinToneMinimallyQualified = "🙎🏽‍♀" ;

		public const string WomanPoutingMediumDarkSkinToneFullyQualified = "🙎🏾‍♀️" ;

		public const string WomanPoutingMediumDarkSkinToneMinimallyQualified = "🙎🏾‍♀" ;

		public const string WomanPoutingDarkSkinToneFullyQualified = "🙎🏿‍♀️" ;

		public const string WomanPoutingDarkSkinToneMinimallyQualified = "🙎🏿‍♀" ;

		public const string PersonGesturingNo = "🙅" ;

		public const string PersonGesturingNoLightSkinTone = "🙅🏻" ;

		public const string PersonGesturingNoMediumLightSkinTone = "🙅🏼" ;

		public const string PersonGesturingNoMediumSkinTone = "🙅🏽" ;

		public const string PersonGesturingNoMediumDarkSkinTone = "🙅🏾" ;

		public const string PersonGesturingNoDarkSkinTone = "🙅🏿" ;

		public const string ManGesturingNoFullyQualified = "🙅‍♂️" ;

		public const string ManGesturingNoMinimallyQualified = "🙅‍♂" ;

		public const string ManGesturingNoLightSkinToneFullyQualified = "🙅🏻‍♂️" ;

		public const string ManGesturingNoLightSkinToneMinimallyQualified = "🙅🏻‍♂" ;

		public const string ManGesturingNoMediumLightSkinToneFullyQualified = "🙅🏼‍♂️" ;

		public const string ManGesturingNoMediumLightSkinToneMinimallyQualified = "🙅🏼‍♂" ;

		public const string ManGesturingNoMediumSkinToneFullyQualified = "🙅🏽‍♂️" ;

		public const string ManGesturingNoMediumSkinToneMinimallyQualified = "🙅🏽‍♂" ;

		public const string ManGesturingNoMediumDarkSkinToneFullyQualified = "🙅🏾‍♂️" ;

		public const string ManGesturingNoMediumDarkSkinToneMinimallyQualified = "🙅🏾‍♂" ;

		public const string ManGesturingNoDarkSkinToneFullyQualified = "🙅🏿‍♂️" ;

		public const string ManGesturingNoDarkSkinToneMinimallyQualified = "🙅🏿‍♂" ;

		public const string WomanGesturingNoFullyQualified = "🙅‍♀️" ;

		public const string WomanGesturingNoMinimallyQualified = "🙅‍♀" ;

		public const string WomanGesturingNoLightSkinToneFullyQualified = "🙅🏻‍♀️" ;

		public const string WomanGesturingNoLightSkinToneMinimallyQualified = "🙅🏻‍♀" ;

		public const string WomanGesturingNoMediumLightSkinToneFullyQualified = "🙅🏼‍♀️" ;

		public const string WomanGesturingNoMediumLightSkinToneMinimallyQualified = "🙅🏼‍♀" ;

		public const string WomanGesturingNoMediumSkinToneFullyQualified = "🙅🏽‍♀️" ;

		public const string WomanGesturingNoMediumSkinToneMinimallyQualified = "🙅🏽‍♀" ;

		public const string WomanGesturingNoMediumDarkSkinToneFullyQualified = "🙅🏾‍♀️" ;

		public const string WomanGesturingNoMediumDarkSkinToneMinimallyQualified = "🙅🏾‍♀" ;

		public const string WomanGesturingNoDarkSkinToneFullyQualified = "🙅🏿‍♀️" ;

		public const string WomanGesturingNoDarkSkinToneMinimallyQualified = "🙅🏿‍♀" ;

		public const string PersonGesturingOk = "🙆" ;

		public const string PersonGesturingOkLightSkinTone = "🙆🏻" ;

		public const string PersonGesturingOkMediumLightSkinTone = "🙆🏼" ;

		public const string PersonGesturingOkMediumSkinTone = "🙆🏽" ;

		public const string PersonGesturingOkMediumDarkSkinTone = "🙆🏾" ;

		public const string PersonGesturingOkDarkSkinTone = "🙆🏿" ;

		public const string ManGesturingOkFullyQualified = "🙆‍♂️" ;

		public const string ManGesturingOkMinimallyQualified = "🙆‍♂" ;

		public const string ManGesturingOkLightSkinToneFullyQualified = "🙆🏻‍♂️" ;

		public const string ManGesturingOkLightSkinToneMinimallyQualified = "🙆🏻‍♂" ;

		public const string ManGesturingOkMediumLightSkinToneFullyQualified = "🙆🏼‍♂️" ;

		public const string ManGesturingOkMediumLightSkinToneMinimallyQualified = "🙆🏼‍♂" ;

		public const string ManGesturingOkMediumSkinToneFullyQualified = "🙆🏽‍♂️" ;

		public const string ManGesturingOkMediumSkinToneMinimallyQualified = "🙆🏽‍♂" ;

		public const string ManGesturingOkMediumDarkSkinToneFullyQualified = "🙆🏾‍♂️" ;

		public const string ManGesturingOkMediumDarkSkinToneMinimallyQualified = "🙆🏾‍♂" ;

		public const string ManGesturingOkDarkSkinToneFullyQualified = "🙆🏿‍♂️" ;

		public const string ManGesturingOkDarkSkinToneMinimallyQualified = "🙆🏿‍♂" ;

		public const string WomanGesturingOkFullyQualified = "🙆‍♀️" ;

		public const string WomanGesturingOkMinimallyQualified = "🙆‍♀" ;

		public const string WomanGesturingOkLightSkinToneFullyQualified = "🙆🏻‍♀️" ;

		public const string WomanGesturingOkLightSkinToneMinimallyQualified = "🙆🏻‍♀" ;

		public const string WomanGesturingOkMediumLightSkinToneFullyQualified = "🙆🏼‍♀️" ;

		public const string WomanGesturingOkMediumLightSkinToneMinimallyQualified = "🙆🏼‍♀" ;

		public const string WomanGesturingOkMediumSkinToneFullyQualified = "🙆🏽‍♀️" ;

		public const string WomanGesturingOkMediumSkinToneMinimallyQualified = "🙆🏽‍♀" ;

		public const string WomanGesturingOkMediumDarkSkinToneFullyQualified = "🙆🏾‍♀️" ;

		public const string WomanGesturingOkMediumDarkSkinToneMinimallyQualified = "🙆🏾‍♀" ;

		public const string WomanGesturingOkDarkSkinToneFullyQualified = "🙆🏿‍♀️" ;

		public const string WomanGesturingOkDarkSkinToneMinimallyQualified = "🙆🏿‍♀" ;

		public const string PersonTippingHand = "💁" ;

		public const string PersonTippingHandLightSkinTone = "💁🏻" ;

		public const string PersonTippingHandMediumLightSkinTone = "💁🏼" ;

		public const string PersonTippingHandMediumSkinTone = "💁🏽" ;

		public const string PersonTippingHandMediumDarkSkinTone = "💁🏾" ;

		public const string PersonTippingHandDarkSkinTone = "💁🏿" ;

		public const string ManTippingHandFullyQualified = "💁‍♂️" ;

		public const string ManTippingHandMinimallyQualified = "💁‍♂" ;

		public const string ManTippingHandLightSkinToneFullyQualified = "💁🏻‍♂️" ;

		public const string ManTippingHandLightSkinToneMinimallyQualified = "💁🏻‍♂" ;

		public const string ManTippingHandMediumLightSkinToneFullyQualified = "💁🏼‍♂️" ;

		public const string ManTippingHandMediumLightSkinToneMinimallyQualified = "💁🏼‍♂" ;

		public const string ManTippingHandMediumSkinToneFullyQualified = "💁🏽‍♂️" ;

		public const string ManTippingHandMediumSkinToneMinimallyQualified = "💁🏽‍♂" ;

		public const string ManTippingHandMediumDarkSkinToneFullyQualified = "💁🏾‍♂️" ;

		public const string ManTippingHandMediumDarkSkinToneMinimallyQualified = "💁🏾‍♂" ;

		public const string ManTippingHandDarkSkinToneFullyQualified = "💁🏿‍♂️" ;

		public const string ManTippingHandDarkSkinToneMinimallyQualified = "💁🏿‍♂" ;

		public const string WomanTippingHandFullyQualified = "💁‍♀️" ;

		public const string WomanTippingHandMinimallyQualified = "💁‍♀" ;

		public const string WomanTippingHandLightSkinToneFullyQualified = "💁🏻‍♀️" ;

		public const string WomanTippingHandLightSkinToneMinimallyQualified = "💁🏻‍♀" ;

		public const string WomanTippingHandMediumLightSkinToneFullyQualified = "💁🏼‍♀️" ;

		public const string WomanTippingHandMediumLightSkinToneMinimallyQualified = "💁🏼‍♀" ;

		public const string WomanTippingHandMediumSkinToneFullyQualified = "💁🏽‍♀️" ;

		public const string WomanTippingHandMediumSkinToneMinimallyQualified = "💁🏽‍♀" ;

		public const string WomanTippingHandMediumDarkSkinToneFullyQualified = "💁🏾‍♀️" ;

		public const string WomanTippingHandMediumDarkSkinToneMinimallyQualified = "💁🏾‍♀" ;

		public const string WomanTippingHandDarkSkinToneFullyQualified = "💁🏿‍♀️" ;

		public const string WomanTippingHandDarkSkinToneMinimallyQualified = "💁🏿‍♀" ;

		public const string PersonRaisingHand = "🙋" ;

		public const string PersonRaisingHandLightSkinTone = "🙋🏻" ;

		public const string PersonRaisingHandMediumLightSkinTone = "🙋🏼" ;

		public const string PersonRaisingHandMediumSkinTone = "🙋🏽" ;

		public const string PersonRaisingHandMediumDarkSkinTone = "🙋🏾" ;

		public const string PersonRaisingHandDarkSkinTone = "🙋🏿" ;

		public const string ManRaisingHandFullyQualified = "🙋‍♂️" ;

		public const string ManRaisingHandMinimallyQualified = "🙋‍♂" ;

		public const string ManRaisingHandLightSkinToneFullyQualified = "🙋🏻‍♂️" ;

		public const string ManRaisingHandLightSkinToneMinimallyQualified = "🙋🏻‍♂" ;

		public const string ManRaisingHandMediumLightSkinToneFullyQualified = "🙋🏼‍♂️" ;

		public const string ManRaisingHandMediumLightSkinToneMinimallyQualified = "🙋🏼‍♂" ;

		public const string ManRaisingHandMediumSkinToneFullyQualified = "🙋🏽‍♂️" ;

		public const string ManRaisingHandMediumSkinToneMinimallyQualified = "🙋🏽‍♂" ;

		public const string ManRaisingHandMediumDarkSkinToneFullyQualified = "🙋🏾‍♂️" ;

		public const string ManRaisingHandMediumDarkSkinToneMinimallyQualified = "🙋🏾‍♂" ;

		public const string ManRaisingHandDarkSkinToneFullyQualified = "🙋🏿‍♂️" ;

		public const string ManRaisingHandDarkSkinToneMinimallyQualified = "🙋🏿‍♂" ;

		public const string WomanRaisingHandFullyQualified = "🙋‍♀️" ;

		public const string WomanRaisingHandMinimallyQualified = "🙋‍♀" ;

		public const string WomanRaisingHandLightSkinToneFullyQualified = "🙋🏻‍♀️" ;

		public const string WomanRaisingHandLightSkinToneMinimallyQualified = "🙋🏻‍♀" ;

		public const string WomanRaisingHandMediumLightSkinToneFullyQualified = "🙋🏼‍♀️" ;

		public const string WomanRaisingHandMediumLightSkinToneMinimallyQualified = "🙋🏼‍♀" ;

		public const string WomanRaisingHandMediumSkinToneFullyQualified = "🙋🏽‍♀️" ;

		public const string WomanRaisingHandMediumSkinToneMinimallyQualified = "🙋🏽‍♀" ;

		public const string WomanRaisingHandMediumDarkSkinToneFullyQualified = "🙋🏾‍♀️" ;

		public const string WomanRaisingHandMediumDarkSkinToneMinimallyQualified = "🙋🏾‍♀" ;

		public const string WomanRaisingHandDarkSkinToneFullyQualified = "🙋🏿‍♀️" ;

		public const string WomanRaisingHandDarkSkinToneMinimallyQualified = "🙋🏿‍♀" ;

		public const string DeafPerson = "🧏" ;

		public const string DeafPersonLightSkinTone = "🧏🏻" ;

		public const string DeafPersonMediumLightSkinTone = "🧏🏼" ;

		public const string DeafPersonMediumSkinTone = "🧏🏽" ;

		public const string DeafPersonMediumDarkSkinTone = "🧏🏾" ;

		public const string DeafPersonDarkSkinTone = "🧏🏿" ;

		public const string DeafManFullyQualified = "🧏‍♂️" ;

		public const string DeafManMinimallyQualified = "🧏‍♂" ;

		public const string DeafManLightSkinToneFullyQualified = "🧏🏻‍♂️" ;

		public const string DeafManLightSkinToneMinimallyQualified = "🧏🏻‍♂" ;

		public const string DeafManMediumLightSkinToneFullyQualified = "🧏🏼‍♂️" ;

		public const string DeafManMediumLightSkinToneMinimallyQualified = "🧏🏼‍♂" ;

		public const string DeafManMediumSkinToneFullyQualified = "🧏🏽‍♂️" ;

		public const string DeafManMediumSkinToneMinimallyQualified = "🧏🏽‍♂" ;

		public const string DeafManMediumDarkSkinToneFullyQualified = "🧏🏾‍♂️" ;

		public const string DeafManMediumDarkSkinToneMinimallyQualified = "🧏🏾‍♂" ;

		public const string DeafManDarkSkinToneFullyQualified = "🧏🏿‍♂️" ;

		public const string DeafManDarkSkinToneMinimallyQualified = "🧏🏿‍♂" ;

		public const string DeafWomanFullyQualified = "🧏‍♀️" ;

		public const string DeafWomanMinimallyQualified = "🧏‍♀" ;

		public const string DeafWomanLightSkinToneFullyQualified = "🧏🏻‍♀️" ;

		public const string DeafWomanLightSkinToneMinimallyQualified = "🧏🏻‍♀" ;

		public const string DeafWomanMediumLightSkinToneFullyQualified = "🧏🏼‍♀️" ;

		public const string DeafWomanMediumLightSkinToneMinimallyQualified = "🧏🏼‍♀" ;

		public const string DeafWomanMediumSkinToneFullyQualified = "🧏🏽‍♀️" ;

		public const string DeafWomanMediumSkinToneMinimallyQualified = "🧏🏽‍♀" ;

		public const string DeafWomanMediumDarkSkinToneFullyQualified = "🧏🏾‍♀️" ;

		public const string DeafWomanMediumDarkSkinToneMinimallyQualified = "🧏🏾‍♀" ;

		public const string DeafWomanDarkSkinToneFullyQualified = "🧏🏿‍♀️" ;

		public const string DeafWomanDarkSkinToneMinimallyQualified = "🧏🏿‍♀" ;

		public const string PersonBowing = "🙇" ;

		public const string PersonBowingLightSkinTone = "🙇🏻" ;

		public const string PersonBowingMediumLightSkinTone = "🙇🏼" ;

		public const string PersonBowingMediumSkinTone = "🙇🏽" ;

		public const string PersonBowingMediumDarkSkinTone = "🙇🏾" ;

		public const string PersonBowingDarkSkinTone = "🙇🏿" ;

		public const string ManBowingFullyQualified = "🙇‍♂️" ;

		public const string ManBowingMinimallyQualified = "🙇‍♂" ;

		public const string ManBowingLightSkinToneFullyQualified = "🙇🏻‍♂️" ;

		public const string ManBowingLightSkinToneMinimallyQualified = "🙇🏻‍♂" ;

		public const string ManBowingMediumLightSkinToneFullyQualified = "🙇🏼‍♂️" ;

		public const string ManBowingMediumLightSkinToneMinimallyQualified = "🙇🏼‍♂" ;

		public const string ManBowingMediumSkinToneFullyQualified = "🙇🏽‍♂️" ;

		public const string ManBowingMediumSkinToneMinimallyQualified = "🙇🏽‍♂" ;

		public const string ManBowingMediumDarkSkinToneFullyQualified = "🙇🏾‍♂️" ;

		public const string ManBowingMediumDarkSkinToneMinimallyQualified = "🙇🏾‍♂" ;

		public const string ManBowingDarkSkinToneFullyQualified = "🙇🏿‍♂️" ;

		public const string ManBowingDarkSkinToneMinimallyQualified = "🙇🏿‍♂" ;

		public const string WomanBowingFullyQualified = "🙇‍♀️" ;

		public const string WomanBowingMinimallyQualified = "🙇‍♀" ;

		public const string WomanBowingLightSkinToneFullyQualified = "🙇🏻‍♀️" ;

		public const string WomanBowingLightSkinToneMinimallyQualified = "🙇🏻‍♀" ;

		public const string WomanBowingMediumLightSkinToneFullyQualified = "🙇🏼‍♀️" ;

		public const string WomanBowingMediumLightSkinToneMinimallyQualified = "🙇🏼‍♀" ;

		public const string WomanBowingMediumSkinToneFullyQualified = "🙇🏽‍♀️" ;

		public const string WomanBowingMediumSkinToneMinimallyQualified = "🙇🏽‍♀" ;

		public const string WomanBowingMediumDarkSkinToneFullyQualified = "🙇🏾‍♀️" ;

		public const string WomanBowingMediumDarkSkinToneMinimallyQualified = "🙇🏾‍♀" ;

		public const string WomanBowingDarkSkinToneFullyQualified = "🙇🏿‍♀️" ;

		public const string WomanBowingDarkSkinToneMinimallyQualified = "🙇🏿‍♀" ;

		public const string PersonFacepalming = "🤦" ;

		public const string PersonFacepalmingLightSkinTone = "🤦🏻" ;

		public const string PersonFacepalmingMediumLightSkinTone = "🤦🏼" ;

		public const string PersonFacepalmingMediumSkinTone = "🤦🏽" ;

		public const string PersonFacepalmingMediumDarkSkinTone = "🤦🏾" ;

		public const string PersonFacepalmingDarkSkinTone = "🤦🏿" ;

		public const string ManFacepalmingFullyQualified = "🤦‍♂️" ;

		public const string ManFacepalmingMinimallyQualified = "🤦‍♂" ;

		public const string ManFacepalmingLightSkinToneFullyQualified = "🤦🏻‍♂️" ;

		public const string ManFacepalmingLightSkinToneMinimallyQualified = "🤦🏻‍♂" ;

		public const string ManFacepalmingMediumLightSkinToneFullyQualified = "🤦🏼‍♂️" ;

		public const string ManFacepalmingMediumLightSkinToneMinimallyQualified = "🤦🏼‍♂" ;

		public const string ManFacepalmingMediumSkinToneFullyQualified = "🤦🏽‍♂️" ;

		public const string ManFacepalmingMediumSkinToneMinimallyQualified = "🤦🏽‍♂" ;

		public const string ManFacepalmingMediumDarkSkinToneFullyQualified = "🤦🏾‍♂️" ;

		public const string ManFacepalmingMediumDarkSkinToneMinimallyQualified = "🤦🏾‍♂" ;

		public const string ManFacepalmingDarkSkinToneFullyQualified = "🤦🏿‍♂️" ;

		public const string ManFacepalmingDarkSkinToneMinimallyQualified = "🤦🏿‍♂" ;

		public const string WomanFacepalmingFullyQualified = "🤦‍♀️" ;

		public const string WomanFacepalmingMinimallyQualified = "🤦‍♀" ;

		public const string WomanFacepalmingLightSkinToneFullyQualified = "🤦🏻‍♀️" ;

		public const string WomanFacepalmingLightSkinToneMinimallyQualified = "🤦🏻‍♀" ;

		public const string WomanFacepalmingMediumLightSkinToneFullyQualified = "🤦🏼‍♀️" ;

		public const string WomanFacepalmingMediumLightSkinToneMinimallyQualified = "🤦🏼‍♀" ;

		public const string WomanFacepalmingMediumSkinToneFullyQualified = "🤦🏽‍♀️" ;

		public const string WomanFacepalmingMediumSkinToneMinimallyQualified = "🤦🏽‍♀" ;

		public const string WomanFacepalmingMediumDarkSkinToneFullyQualified = "🤦🏾‍♀️" ;

		public const string WomanFacepalmingMediumDarkSkinToneMinimallyQualified = "🤦🏾‍♀" ;

		public const string WomanFacepalmingDarkSkinToneFullyQualified = "🤦🏿‍♀️" ;

		public const string WomanFacepalmingDarkSkinToneMinimallyQualified = "🤦🏿‍♀" ;

		public const string PersonShrugging = "🤷" ;

		public const string PersonShruggingLightSkinTone = "🤷🏻" ;

		public const string PersonShruggingMediumLightSkinTone = "🤷🏼" ;

		public const string PersonShruggingMediumSkinTone = "🤷🏽" ;

		public const string PersonShruggingMediumDarkSkinTone = "🤷🏾" ;

		public const string PersonShruggingDarkSkinTone = "🤷🏿" ;

		public const string ManShruggingFullyQualified = "🤷‍♂️" ;

		public const string ManShruggingMinimallyQualified = "🤷‍♂" ;

		public const string ManShruggingLightSkinToneFullyQualified = "🤷🏻‍♂️" ;

		public const string ManShruggingLightSkinToneMinimallyQualified = "🤷🏻‍♂" ;

		public const string ManShruggingMediumLightSkinToneFullyQualified = "🤷🏼‍♂️" ;

		public const string ManShruggingMediumLightSkinToneMinimallyQualified = "🤷🏼‍♂" ;

		public const string ManShruggingMediumSkinToneFullyQualified = "🤷🏽‍♂️" ;

		public const string ManShruggingMediumSkinToneMinimallyQualified = "🤷🏽‍♂" ;

		public const string ManShruggingMediumDarkSkinToneFullyQualified = "🤷🏾‍♂️" ;

		public const string ManShruggingMediumDarkSkinToneMinimallyQualified = "🤷🏾‍♂" ;

		public const string ManShruggingDarkSkinToneFullyQualified = "🤷🏿‍♂️" ;

		public const string ManShruggingDarkSkinToneMinimallyQualified = "🤷🏿‍♂" ;

		public const string WomanShruggingFullyQualified = "🤷‍♀️" ;

		public const string WomanShruggingMinimallyQualified = "🤷‍♀" ;

		public const string WomanShruggingLightSkinToneFullyQualified = "🤷🏻‍♀️" ;

		public const string WomanShruggingLightSkinToneMinimallyQualified = "🤷🏻‍♀" ;

		public const string WomanShruggingMediumLightSkinToneFullyQualified = "🤷🏼‍♀️" ;

		public const string WomanShruggingMediumLightSkinToneMinimallyQualified = "🤷🏼‍♀" ;

		public const string WomanShruggingMediumSkinToneFullyQualified = "🤷🏽‍♀️" ;

		public const string WomanShruggingMediumSkinToneMinimallyQualified = "🤷🏽‍♀" ;

		public const string WomanShruggingMediumDarkSkinToneFullyQualified = "🤷🏾‍♀️" ;

		public const string WomanShruggingMediumDarkSkinToneMinimallyQualified = "🤷🏾‍♀" ;

		public const string WomanShruggingDarkSkinToneFullyQualified = "🤷🏿‍♀️" ;

		public const string WomanShruggingDarkSkinToneMinimallyQualified = "🤷🏿‍♀" ;

		public const string HealthWorkerFullyQualified = "🧑‍⚕️" ;

		public const string HealthWorkerMinimallyQualified = "🧑‍⚕" ;

		public const string HealthWorkerLightSkinToneFullyQualified = "🧑🏻‍⚕️" ;

		public const string HealthWorkerLightSkinToneMinimallyQualified = "🧑🏻‍⚕" ;

		public const string HealthWorkerMediumLightSkinToneFullyQualified = "🧑🏼‍⚕️" ;

		public const string HealthWorkerMediumLightSkinToneMinimallyQualified = "🧑🏼‍⚕" ;

		public const string HealthWorkerMediumSkinToneFullyQualified = "🧑🏽‍⚕️" ;

		public const string HealthWorkerMediumSkinToneMinimallyQualified = "🧑🏽‍⚕" ;

		public const string HealthWorkerMediumDarkSkinToneFullyQualified = "🧑🏾‍⚕️" ;

		public const string HealthWorkerMediumDarkSkinToneMinimallyQualified = "🧑🏾‍⚕" ;

		public const string HealthWorkerDarkSkinToneFullyQualified = "🧑🏿‍⚕️" ;

		public const string HealthWorkerDarkSkinToneMinimallyQualified = "🧑🏿‍⚕" ;

		public const string ManHealthWorkerFullyQualified = "👨‍⚕️" ;

		public const string ManHealthWorkerMinimallyQualified = "👨‍⚕" ;

		public const string ManHealthWorkerLightSkinToneFullyQualified = "👨🏻‍⚕️" ;

		public const string ManHealthWorkerLightSkinToneMinimallyQualified = "👨🏻‍⚕" ;

		public const string ManHealthWorkerMediumLightSkinToneFullyQualified = "👨🏼‍⚕️" ;

		public const string ManHealthWorkerMediumLightSkinToneMinimallyQualified = "👨🏼‍⚕" ;

		public const string ManHealthWorkerMediumSkinToneFullyQualified = "👨🏽‍⚕️" ;

		public const string ManHealthWorkerMediumSkinToneMinimallyQualified = "👨🏽‍⚕" ;

		public const string ManHealthWorkerMediumDarkSkinToneFullyQualified = "👨🏾‍⚕️" ;

		public const string ManHealthWorkerMediumDarkSkinToneMinimallyQualified = "👨🏾‍⚕" ;

		public const string ManHealthWorkerDarkSkinToneFullyQualified = "👨🏿‍⚕️" ;

		public const string ManHealthWorkerDarkSkinToneMinimallyQualified = "👨🏿‍⚕" ;

		public const string WomanHealthWorkerFullyQualified = "👩‍⚕️" ;

		public const string WomanHealthWorkerMinimallyQualified = "👩‍⚕" ;

		public const string WomanHealthWorkerLightSkinToneFullyQualified = "👩🏻‍⚕️" ;

		public const string WomanHealthWorkerLightSkinToneMinimallyQualified = "👩🏻‍⚕" ;

		public const string WomanHealthWorkerMediumLightSkinToneFullyQualified = "👩🏼‍⚕️" ;

		public const string WomanHealthWorkerMediumLightSkinToneMinimallyQualified = "👩🏼‍⚕" ;

		public const string WomanHealthWorkerMediumSkinToneFullyQualified = "👩🏽‍⚕️" ;

		public const string WomanHealthWorkerMediumSkinToneMinimallyQualified = "👩🏽‍⚕" ;

		public const string WomanHealthWorkerMediumDarkSkinToneFullyQualified = "👩🏾‍⚕️" ;

		public const string WomanHealthWorkerMediumDarkSkinToneMinimallyQualified = "👩🏾‍⚕" ;

		public const string WomanHealthWorkerDarkSkinToneFullyQualified = "👩🏿‍⚕️" ;

		public const string WomanHealthWorkerDarkSkinToneMinimallyQualified = "👩🏿‍⚕" ;

		public const string Student = "🧑‍🎓" ;

		public const string StudentLightSkinTone = "🧑🏻‍🎓" ;

		public const string StudentMediumLightSkinTone = "🧑🏼‍🎓" ;

		public const string StudentMediumSkinTone = "🧑🏽‍🎓" ;

		public const string StudentMediumDarkSkinTone = "🧑🏾‍🎓" ;

		public const string StudentDarkSkinTone = "🧑🏿‍🎓" ;

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

		public const string Teacher = "🧑‍🏫" ;

		public const string TeacherLightSkinTone = "🧑🏻‍🏫" ;

		public const string TeacherMediumLightSkinTone = "🧑🏼‍🏫" ;

		public const string TeacherMediumSkinTone = "🧑🏽‍🏫" ;

		public const string TeacherMediumDarkSkinTone = "🧑🏾‍🏫" ;

		public const string TeacherDarkSkinTone = "🧑🏿‍🏫" ;

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

		public const string JudgeFullyQualified = "🧑‍⚖️" ;

		public const string JudgeMinimallyQualified = "🧑‍⚖" ;

		public const string JudgeLightSkinToneFullyQualified = "🧑🏻‍⚖️" ;

		public const string JudgeLightSkinToneMinimallyQualified = "🧑🏻‍⚖" ;

		public const string JudgeMediumLightSkinToneFullyQualified = "🧑🏼‍⚖️" ;

		public const string JudgeMediumLightSkinToneMinimallyQualified = "🧑🏼‍⚖" ;

		public const string JudgeMediumSkinToneFullyQualified = "🧑🏽‍⚖️" ;

		public const string JudgeMediumSkinToneMinimallyQualified = "🧑🏽‍⚖" ;

		public const string JudgeMediumDarkSkinToneFullyQualified = "🧑🏾‍⚖️" ;

		public const string JudgeMediumDarkSkinToneMinimallyQualified = "🧑🏾‍⚖" ;

		public const string JudgeDarkSkinToneFullyQualified = "🧑🏿‍⚖️" ;

		public const string JudgeDarkSkinToneMinimallyQualified = "🧑🏿‍⚖" ;

		public const string ManJudgeFullyQualified = "👨‍⚖️" ;

		public const string ManJudgeMinimallyQualified = "👨‍⚖" ;

		public const string ManJudgeLightSkinToneFullyQualified = "👨🏻‍⚖️" ;

		public const string ManJudgeLightSkinToneMinimallyQualified = "👨🏻‍⚖" ;

		public const string ManJudgeMediumLightSkinToneFullyQualified = "👨🏼‍⚖️" ;

		public const string ManJudgeMediumLightSkinToneMinimallyQualified = "👨🏼‍⚖" ;

		public const string ManJudgeMediumSkinToneFullyQualified = "👨🏽‍⚖️" ;

		public const string ManJudgeMediumSkinToneMinimallyQualified = "👨🏽‍⚖" ;

		public const string ManJudgeMediumDarkSkinToneFullyQualified = "👨🏾‍⚖️" ;

		public const string ManJudgeMediumDarkSkinToneMinimallyQualified = "👨🏾‍⚖" ;

		public const string ManJudgeDarkSkinToneFullyQualified = "👨🏿‍⚖️" ;

		public const string ManJudgeDarkSkinToneMinimallyQualified = "👨🏿‍⚖" ;

		public const string WomanJudgeFullyQualified = "👩‍⚖️" ;

		public const string WomanJudgeMinimallyQualified = "👩‍⚖" ;

		public const string WomanJudgeLightSkinToneFullyQualified = "👩🏻‍⚖️" ;

		public const string WomanJudgeLightSkinToneMinimallyQualified = "👩🏻‍⚖" ;

		public const string WomanJudgeMediumLightSkinToneFullyQualified = "👩🏼‍⚖️" ;

		public const string WomanJudgeMediumLightSkinToneMinimallyQualified = "👩🏼‍⚖" ;

		public const string WomanJudgeMediumSkinToneFullyQualified = "👩🏽‍⚖️" ;

		public const string WomanJudgeMediumSkinToneMinimallyQualified = "👩🏽‍⚖" ;

		public const string WomanJudgeMediumDarkSkinToneFullyQualified = "👩🏾‍⚖️" ;

		public const string WomanJudgeMediumDarkSkinToneMinimallyQualified = "👩🏾‍⚖" ;

		public const string WomanJudgeDarkSkinToneFullyQualified = "👩🏿‍⚖️" ;

		public const string WomanJudgeDarkSkinToneMinimallyQualified = "👩🏿‍⚖" ;

		public const string Farmer = "🧑‍🌾" ;

		public const string FarmerLightSkinTone = "🧑🏻‍🌾" ;

		public const string FarmerMediumLightSkinTone = "🧑🏼‍🌾" ;

		public const string FarmerMediumSkinTone = "🧑🏽‍🌾" ;

		public const string FarmerMediumDarkSkinTone = "🧑🏾‍🌾" ;

		public const string FarmerDarkSkinTone = "🧑🏿‍🌾" ;

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

		public const string Cook = "🧑‍🍳" ;

		public const string CookLightSkinTone = "🧑🏻‍🍳" ;

		public const string CookMediumLightSkinTone = "🧑🏼‍🍳" ;

		public const string CookMediumSkinTone = "🧑🏽‍🍳" ;

		public const string CookMediumDarkSkinTone = "🧑🏾‍🍳" ;

		public const string CookDarkSkinTone = "🧑🏿‍🍳" ;

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

		public const string Mechanic = "🧑‍🔧" ;

		public const string MechanicLightSkinTone = "🧑🏻‍🔧" ;

		public const string MechanicMediumLightSkinTone = "🧑🏼‍🔧" ;

		public const string MechanicMediumSkinTone = "🧑🏽‍🔧" ;

		public const string MechanicMediumDarkSkinTone = "🧑🏾‍🔧" ;

		public const string MechanicDarkSkinTone = "🧑🏿‍🔧" ;

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

		public const string FactoryWorker = "🧑‍🏭" ;

		public const string FactoryWorkerLightSkinTone = "🧑🏻‍🏭" ;

		public const string FactoryWorkerMediumLightSkinTone = "🧑🏼‍🏭" ;

		public const string FactoryWorkerMediumSkinTone = "🧑🏽‍🏭" ;

		public const string FactoryWorkerMediumDarkSkinTone = "🧑🏾‍🏭" ;

		public const string FactoryWorkerDarkSkinTone = "🧑🏿‍🏭" ;

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

		public const string OfficeWorker = "🧑‍💼" ;

		public const string OfficeWorkerLightSkinTone = "🧑🏻‍💼" ;

		public const string OfficeWorkerMediumLightSkinTone = "🧑🏼‍💼" ;

		public const string OfficeWorkerMediumSkinTone = "🧑🏽‍💼" ;

		public const string OfficeWorkerMediumDarkSkinTone = "🧑🏾‍💼" ;

		public const string OfficeWorkerDarkSkinTone = "🧑🏿‍💼" ;

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

		public const string Scientist = "🧑‍🔬" ;

		public const string ScientistLightSkinTone = "🧑🏻‍🔬" ;

		public const string ScientistMediumLightSkinTone = "🧑🏼‍🔬" ;

		public const string ScientistMediumSkinTone = "🧑🏽‍🔬" ;

		public const string ScientistMediumDarkSkinTone = "🧑🏾‍🔬" ;

		public const string ScientistDarkSkinTone = "🧑🏿‍🔬" ;

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

		public const string Technologist = "🧑‍💻" ;

		public const string TechnologistLightSkinTone = "🧑🏻‍💻" ;

		public const string TechnologistMediumLightSkinTone = "🧑🏼‍💻" ;

		public const string TechnologistMediumSkinTone = "🧑🏽‍💻" ;

		public const string TechnologistMediumDarkSkinTone = "🧑🏾‍💻" ;

		public const string TechnologistDarkSkinTone = "🧑🏿‍💻" ;

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

		public const string Singer = "🧑‍🎤" ;

		public const string SingerLightSkinTone = "🧑🏻‍🎤" ;

		public const string SingerMediumLightSkinTone = "🧑🏼‍🎤" ;

		public const string SingerMediumSkinTone = "🧑🏽‍🎤" ;

		public const string SingerMediumDarkSkinTone = "🧑🏾‍🎤" ;

		public const string SingerDarkSkinTone = "🧑🏿‍🎤" ;

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

		public const string Artist = "🧑‍🎨" ;

		public const string ArtistLightSkinTone = "🧑🏻‍🎨" ;

		public const string ArtistMediumLightSkinTone = "🧑🏼‍🎨" ;

		public const string ArtistMediumSkinTone = "🧑🏽‍🎨" ;

		public const string ArtistMediumDarkSkinTone = "🧑🏾‍🎨" ;

		public const string ArtistDarkSkinTone = "🧑🏿‍🎨" ;

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

		public const string PilotFullyQualified = "🧑‍✈️" ;

		public const string PilotMinimallyQualified = "🧑‍✈" ;

		public const string PilotLightSkinToneFullyQualified = "🧑🏻‍✈️" ;

		public const string PilotLightSkinToneMinimallyQualified = "🧑🏻‍✈" ;

		public const string PilotMediumLightSkinToneFullyQualified = "🧑🏼‍✈️" ;

		public const string PilotMediumLightSkinToneMinimallyQualified = "🧑🏼‍✈" ;

		public const string PilotMediumSkinToneFullyQualified = "🧑🏽‍✈️" ;

		public const string PilotMediumSkinToneMinimallyQualified = "🧑🏽‍✈" ;

		public const string PilotMediumDarkSkinToneFullyQualified = "🧑🏾‍✈️" ;

		public const string PilotMediumDarkSkinToneMinimallyQualified = "🧑🏾‍✈" ;

		public const string PilotDarkSkinToneFullyQualified = "🧑🏿‍✈️" ;

		public const string PilotDarkSkinToneMinimallyQualified = "🧑🏿‍✈" ;

		public const string ManPilotFullyQualified = "👨‍✈️" ;

		public const string ManPilotMinimallyQualified = "👨‍✈" ;

		public const string ManPilotLightSkinToneFullyQualified = "👨🏻‍✈️" ;

		public const string ManPilotLightSkinToneMinimallyQualified = "👨🏻‍✈" ;

		public const string ManPilotMediumLightSkinToneFullyQualified = "👨🏼‍✈️" ;

		public const string ManPilotMediumLightSkinToneMinimallyQualified = "👨🏼‍✈" ;

		public const string ManPilotMediumSkinToneFullyQualified = "👨🏽‍✈️" ;

		public const string ManPilotMediumSkinToneMinimallyQualified = "👨🏽‍✈" ;

		public const string ManPilotMediumDarkSkinToneFullyQualified = "👨🏾‍✈️" ;

		public const string ManPilotMediumDarkSkinToneMinimallyQualified = "👨🏾‍✈" ;

		public const string ManPilotDarkSkinToneFullyQualified = "👨🏿‍✈️" ;

		public const string ManPilotDarkSkinToneMinimallyQualified = "👨🏿‍✈" ;

		public const string WomanPilotFullyQualified = "👩‍✈️" ;

		public const string WomanPilotMinimallyQualified = "👩‍✈" ;

		public const string WomanPilotLightSkinToneFullyQualified = "👩🏻‍✈️" ;

		public const string WomanPilotLightSkinToneMinimallyQualified = "👩🏻‍✈" ;

		public const string WomanPilotMediumLightSkinToneFullyQualified = "👩🏼‍✈️" ;

		public const string WomanPilotMediumLightSkinToneMinimallyQualified = "👩🏼‍✈" ;

		public const string WomanPilotMediumSkinToneFullyQualified = "👩🏽‍✈️" ;

		public const string WomanPilotMediumSkinToneMinimallyQualified = "👩🏽‍✈" ;

		public const string WomanPilotMediumDarkSkinToneFullyQualified = "👩🏾‍✈️" ;

		public const string WomanPilotMediumDarkSkinToneMinimallyQualified = "👩🏾‍✈" ;

		public const string WomanPilotDarkSkinToneFullyQualified = "👩🏿‍✈️" ;

		public const string WomanPilotDarkSkinToneMinimallyQualified = "👩🏿‍✈" ;

		public const string Astronaut = "🧑‍🚀" ;

		public const string AstronautLightSkinTone = "🧑🏻‍🚀" ;

		public const string AstronautMediumLightSkinTone = "🧑🏼‍🚀" ;

		public const string AstronautMediumSkinTone = "🧑🏽‍🚀" ;

		public const string AstronautMediumDarkSkinTone = "🧑🏾‍🚀" ;

		public const string AstronautDarkSkinTone = "🧑🏿‍🚀" ;

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

		public const string Firefighter = "🧑‍🚒" ;

		public const string FirefighterLightSkinTone = "🧑🏻‍🚒" ;

		public const string FirefighterMediumLightSkinTone = "🧑🏼‍🚒" ;

		public const string FirefighterMediumSkinTone = "🧑🏽‍🚒" ;

		public const string FirefighterMediumDarkSkinTone = "🧑🏾‍🚒" ;

		public const string FirefighterDarkSkinTone = "🧑🏿‍🚒" ;

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

		public const string ManPoliceOfficerFullyQualified = "👮‍♂️" ;

		public const string ManPoliceOfficerMinimallyQualified = "👮‍♂" ;

		public const string ManPoliceOfficerLightSkinToneFullyQualified = "👮🏻‍♂️" ;

		public const string ManPoliceOfficerLightSkinToneMinimallyQualified = "👮🏻‍♂" ;

		public const string ManPoliceOfficerMediumLightSkinToneFullyQualified = "👮🏼‍♂️" ;

		public const string ManPoliceOfficerMediumLightSkinToneMinimallyQualified = "👮🏼‍♂" ;

		public const string ManPoliceOfficerMediumSkinToneFullyQualified = "👮🏽‍♂️" ;

		public const string ManPoliceOfficerMediumSkinToneMinimallyQualified = "👮🏽‍♂" ;

		public const string ManPoliceOfficerMediumDarkSkinToneFullyQualified = "👮🏾‍♂️" ;

		public const string ManPoliceOfficerMediumDarkSkinToneMinimallyQualified = "👮🏾‍♂" ;

		public const string ManPoliceOfficerDarkSkinToneFullyQualified = "👮🏿‍♂️" ;

		public const string ManPoliceOfficerDarkSkinToneMinimallyQualified = "👮🏿‍♂" ;

		public const string WomanPoliceOfficerFullyQualified = "👮‍♀️" ;

		public const string WomanPoliceOfficerMinimallyQualified = "👮‍♀" ;

		public const string WomanPoliceOfficerLightSkinToneFullyQualified = "👮🏻‍♀️" ;

		public const string WomanPoliceOfficerLightSkinToneMinimallyQualified = "👮🏻‍♀" ;

		public const string WomanPoliceOfficerMediumLightSkinToneFullyQualified = "👮🏼‍♀️" ;

		public const string WomanPoliceOfficerMediumLightSkinToneMinimallyQualified = "👮🏼‍♀" ;

		public const string WomanPoliceOfficerMediumSkinToneFullyQualified = "👮🏽‍♀️" ;

		public const string WomanPoliceOfficerMediumSkinToneMinimallyQualified = "👮🏽‍♀" ;

		public const string WomanPoliceOfficerMediumDarkSkinToneFullyQualified = "👮🏾‍♀️" ;

		public const string WomanPoliceOfficerMediumDarkSkinToneMinimallyQualified = "👮🏾‍♀" ;

		public const string WomanPoliceOfficerDarkSkinToneFullyQualified = "👮🏿‍♀️" ;

		public const string WomanPoliceOfficerDarkSkinToneMinimallyQualified = "👮🏿‍♀" ;

		public const string DetectiveFullyQualified = "🕵️" ;

		public const string DetectiveUnqualified = "🕵" ;

		public const string DetectiveLightSkinTone = "🕵🏻" ;

		public const string DetectiveMediumLightSkinTone = "🕵🏼" ;

		public const string DetectiveMediumSkinTone = "🕵🏽" ;

		public const string DetectiveMediumDarkSkinTone = "🕵🏾" ;

		public const string DetectiveDarkSkinTone = "🕵🏿" ;

		public const string ManDetectiveFullyQualified = "🕵️‍♂️" ;

		public const string ManDetectiveUnqualified = "🕵‍♂️" ;

		public const string ManDetectiveMinimallyQualified = "🕵️‍♂" ;

		public const string ManDetectiveUnqualified2 = "🕵‍♂" ;

		public const string ManDetectiveLightSkinToneFullyQualified = "🕵🏻‍♂️" ;

		public const string ManDetectiveLightSkinToneMinimallyQualified = "🕵🏻‍♂" ;

		public const string ManDetectiveMediumLightSkinToneFullyQualified = "🕵🏼‍♂️" ;

		public const string ManDetectiveMediumLightSkinToneMinimallyQualified = "🕵🏼‍♂" ;

		public const string ManDetectiveMediumSkinToneFullyQualified = "🕵🏽‍♂️" ;

		public const string ManDetectiveMediumSkinToneMinimallyQualified = "🕵🏽‍♂" ;

		public const string ManDetectiveMediumDarkSkinToneFullyQualified = "🕵🏾‍♂️" ;

		public const string ManDetectiveMediumDarkSkinToneMinimallyQualified = "🕵🏾‍♂" ;

		public const string ManDetectiveDarkSkinToneFullyQualified = "🕵🏿‍♂️" ;

		public const string ManDetectiveDarkSkinToneMinimallyQualified = "🕵🏿‍♂" ;

		public const string WomanDetectiveFullyQualified = "🕵️‍♀️" ;

		public const string WomanDetectiveUnqualified = "🕵‍♀️" ;

		public const string WomanDetectiveMinimallyQualified = "🕵️‍♀" ;

		public const string WomanDetectiveUnqualified2 = "🕵‍♀" ;

		public const string WomanDetectiveLightSkinToneFullyQualified = "🕵🏻‍♀️" ;

		public const string WomanDetectiveLightSkinToneMinimallyQualified = "🕵🏻‍♀" ;

		public const string WomanDetectiveMediumLightSkinToneFullyQualified = "🕵🏼‍♀️" ;

		public const string WomanDetectiveMediumLightSkinToneMinimallyQualified = "🕵🏼‍♀" ;

		public const string WomanDetectiveMediumSkinToneFullyQualified = "🕵🏽‍♀️" ;

		public const string WomanDetectiveMediumSkinToneMinimallyQualified = "🕵🏽‍♀" ;

		public const string WomanDetectiveMediumDarkSkinToneFullyQualified = "🕵🏾‍♀️" ;

		public const string WomanDetectiveMediumDarkSkinToneMinimallyQualified = "🕵🏾‍♀" ;

		public const string WomanDetectiveDarkSkinToneFullyQualified = "🕵🏿‍♀️" ;

		public const string WomanDetectiveDarkSkinToneMinimallyQualified = "🕵🏿‍♀" ;

		public const string Guard = "💂" ;

		public const string GuardLightSkinTone = "💂🏻" ;

		public const string GuardMediumLightSkinTone = "💂🏼" ;

		public const string GuardMediumSkinTone = "💂🏽" ;

		public const string GuardMediumDarkSkinTone = "💂🏾" ;

		public const string GuardDarkSkinTone = "💂🏿" ;

		public const string ManGuardFullyQualified = "💂‍♂️" ;

		public const string ManGuardMinimallyQualified = "💂‍♂" ;

		public const string ManGuardLightSkinToneFullyQualified = "💂🏻‍♂️" ;

		public const string ManGuardLightSkinToneMinimallyQualified = "💂🏻‍♂" ;

		public const string ManGuardMediumLightSkinToneFullyQualified = "💂🏼‍♂️" ;

		public const string ManGuardMediumLightSkinToneMinimallyQualified = "💂🏼‍♂" ;

		public const string ManGuardMediumSkinToneFullyQualified = "💂🏽‍♂️" ;

		public const string ManGuardMediumSkinToneMinimallyQualified = "💂🏽‍♂" ;

		public const string ManGuardMediumDarkSkinToneFullyQualified = "💂🏾‍♂️" ;

		public const string ManGuardMediumDarkSkinToneMinimallyQualified = "💂🏾‍♂" ;

		public const string ManGuardDarkSkinToneFullyQualified = "💂🏿‍♂️" ;

		public const string ManGuardDarkSkinToneMinimallyQualified = "💂🏿‍♂" ;

		public const string WomanGuardFullyQualified = "💂‍♀️" ;

		public const string WomanGuardMinimallyQualified = "💂‍♀" ;

		public const string WomanGuardLightSkinToneFullyQualified = "💂🏻‍♀️" ;

		public const string WomanGuardLightSkinToneMinimallyQualified = "💂🏻‍♀" ;

		public const string WomanGuardMediumLightSkinToneFullyQualified = "💂🏼‍♀️" ;

		public const string WomanGuardMediumLightSkinToneMinimallyQualified = "💂🏼‍♀" ;

		public const string WomanGuardMediumSkinToneFullyQualified = "💂🏽‍♀️" ;

		public const string WomanGuardMediumSkinToneMinimallyQualified = "💂🏽‍♀" ;

		public const string WomanGuardMediumDarkSkinToneFullyQualified = "💂🏾‍♀️" ;

		public const string WomanGuardMediumDarkSkinToneMinimallyQualified = "💂🏾‍♀" ;

		public const string WomanGuardDarkSkinToneFullyQualified = "💂🏿‍♀️" ;

		public const string WomanGuardDarkSkinToneMinimallyQualified = "💂🏿‍♀" ;

		public const string Ninja = "🥷" ;

		public const string NinjaLightSkinTone = "🥷🏻" ;

		public const string NinjaMediumLightSkinTone = "🥷🏼" ;

		public const string NinjaMediumSkinTone = "🥷🏽" ;

		public const string NinjaMediumDarkSkinTone = "🥷🏾" ;

		public const string NinjaDarkSkinTone = "🥷🏿" ;

		public const string ConstructionWorker = "👷" ;

		public const string ConstructionWorkerLightSkinTone = "👷🏻" ;

		public const string ConstructionWorkerMediumLightSkinTone = "👷🏼" ;

		public const string ConstructionWorkerMediumSkinTone = "👷🏽" ;

		public const string ConstructionWorkerMediumDarkSkinTone = "👷🏾" ;

		public const string ConstructionWorkerDarkSkinTone = "👷🏿" ;

		public const string ManConstructionWorkerFullyQualified = "👷‍♂️" ;

		public const string ManConstructionWorkerMinimallyQualified = "👷‍♂" ;

		public const string ManConstructionWorkerLightSkinToneFullyQualified = "👷🏻‍♂️" ;

		public const string ManConstructionWorkerLightSkinToneMinimallyQualified = "👷🏻‍♂" ;

		public const string ManConstructionWorkerMediumLightSkinToneFullyQualified = "👷🏼‍♂️" ;

		public const string ManConstructionWorkerMediumLightSkinToneMinimallyQualified = "👷🏼‍♂" ;

		public const string ManConstructionWorkerMediumSkinToneFullyQualified = "👷🏽‍♂️" ;

		public const string ManConstructionWorkerMediumSkinToneMinimallyQualified = "👷🏽‍♂" ;

		public const string ManConstructionWorkerMediumDarkSkinToneFullyQualified = "👷🏾‍♂️" ;

		public const string ManConstructionWorkerMediumDarkSkinToneMinimallyQualified = "👷🏾‍♂" ;

		public const string ManConstructionWorkerDarkSkinToneFullyQualified = "👷🏿‍♂️" ;

		public const string ManConstructionWorkerDarkSkinToneMinimallyQualified = "👷🏿‍♂" ;

		public const string WomanConstructionWorkerFullyQualified = "👷‍♀️" ;

		public const string WomanConstructionWorkerMinimallyQualified = "👷‍♀" ;

		public const string WomanConstructionWorkerLightSkinToneFullyQualified = "👷🏻‍♀️" ;

		public const string WomanConstructionWorkerLightSkinToneMinimallyQualified = "👷🏻‍♀" ;

		public const string WomanConstructionWorkerMediumLightSkinToneFullyQualified = "👷🏼‍♀️" ;

		public const string WomanConstructionWorkerMediumLightSkinToneMinimallyQualified = "👷🏼‍♀" ;

		public const string WomanConstructionWorkerMediumSkinToneFullyQualified = "👷🏽‍♀️" ;

		public const string WomanConstructionWorkerMediumSkinToneMinimallyQualified = "👷🏽‍♀" ;

		public const string WomanConstructionWorkerMediumDarkSkinToneFullyQualified = "👷🏾‍♀️" ;

		public const string WomanConstructionWorkerMediumDarkSkinToneMinimallyQualified = "👷🏾‍♀" ;

		public const string WomanConstructionWorkerDarkSkinToneFullyQualified = "👷🏿‍♀️" ;

		public const string WomanConstructionWorkerDarkSkinToneMinimallyQualified = "👷🏿‍♀" ;

		public const string PersonWithCrown = "🫅" ;

		public const string PersonWithCrownLightSkinTone = "🫅🏻" ;

		public const string PersonWithCrownMediumLightSkinTone = "🫅🏼" ;

		public const string PersonWithCrownMediumSkinTone = "🫅🏽" ;

		public const string PersonWithCrownMediumDarkSkinTone = "🫅🏾" ;

		public const string PersonWithCrownDarkSkinTone = "🫅🏿" ;

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

		public const string ManWearingTurbanFullyQualified = "👳‍♂️" ;

		public const string ManWearingTurbanMinimallyQualified = "👳‍♂" ;

		public const string ManWearingTurbanLightSkinToneFullyQualified = "👳🏻‍♂️" ;

		public const string ManWearingTurbanLightSkinToneMinimallyQualified = "👳🏻‍♂" ;

		public const string ManWearingTurbanMediumLightSkinToneFullyQualified = "👳🏼‍♂️" ;

		public const string ManWearingTurbanMediumLightSkinToneMinimallyQualified = "👳🏼‍♂" ;

		public const string ManWearingTurbanMediumSkinToneFullyQualified = "👳🏽‍♂️" ;

		public const string ManWearingTurbanMediumSkinToneMinimallyQualified = "👳🏽‍♂" ;

		public const string ManWearingTurbanMediumDarkSkinToneFullyQualified = "👳🏾‍♂️" ;

		public const string ManWearingTurbanMediumDarkSkinToneMinimallyQualified = "👳🏾‍♂" ;

		public const string ManWearingTurbanDarkSkinToneFullyQualified = "👳🏿‍♂️" ;

		public const string ManWearingTurbanDarkSkinToneMinimallyQualified = "👳🏿‍♂" ;

		public const string WomanWearingTurbanFullyQualified = "👳‍♀️" ;

		public const string WomanWearingTurbanMinimallyQualified = "👳‍♀" ;

		public const string WomanWearingTurbanLightSkinToneFullyQualified = "👳🏻‍♀️" ;

		public const string WomanWearingTurbanLightSkinToneMinimallyQualified = "👳🏻‍♀" ;

		public const string WomanWearingTurbanMediumLightSkinToneFullyQualified = "👳🏼‍♀️" ;

		public const string WomanWearingTurbanMediumLightSkinToneMinimallyQualified = "👳🏼‍♀" ;

		public const string WomanWearingTurbanMediumSkinToneFullyQualified = "👳🏽‍♀️" ;

		public const string WomanWearingTurbanMediumSkinToneMinimallyQualified = "👳🏽‍♀" ;

		public const string WomanWearingTurbanMediumDarkSkinToneFullyQualified = "👳🏾‍♀️" ;

		public const string WomanWearingTurbanMediumDarkSkinToneMinimallyQualified = "👳🏾‍♀" ;

		public const string WomanWearingTurbanDarkSkinToneFullyQualified = "👳🏿‍♀️" ;

		public const string WomanWearingTurbanDarkSkinToneMinimallyQualified = "👳🏿‍♀" ;

		public const string PersonWithSkullcap = "👲" ;

		public const string PersonWithSkullcapLightSkinTone = "👲🏻" ;

		public const string PersonWithSkullcapMediumLightSkinTone = "👲🏼" ;

		public const string PersonWithSkullcapMediumSkinTone = "👲🏽" ;

		public const string PersonWithSkullcapMediumDarkSkinTone = "👲🏾" ;

		public const string PersonWithSkullcapDarkSkinTone = "👲🏿" ;

		public const string WomanWithHeadscarf = "🧕" ;

		public const string WomanWithHeadscarfLightSkinTone = "🧕🏻" ;

		public const string WomanWithHeadscarfMediumLightSkinTone = "🧕🏼" ;

		public const string WomanWithHeadscarfMediumSkinTone = "🧕🏽" ;

		public const string WomanWithHeadscarfMediumDarkSkinTone = "🧕🏾" ;

		public const string WomanWithHeadscarfDarkSkinTone = "🧕🏿" ;

		public const string PersonInTuxedo = "🤵" ;

		public const string PersonInTuxedoLightSkinTone = "🤵🏻" ;

		public const string PersonInTuxedoMediumLightSkinTone = "🤵🏼" ;

		public const string PersonInTuxedoMediumSkinTone = "🤵🏽" ;

		public const string PersonInTuxedoMediumDarkSkinTone = "🤵🏾" ;

		public const string PersonInTuxedoDarkSkinTone = "🤵🏿" ;

		public const string ManInTuxedoFullyQualified = "🤵‍♂️" ;

		public const string ManInTuxedoMinimallyQualified = "🤵‍♂" ;

		public const string ManInTuxedoLightSkinToneFullyQualified = "🤵🏻‍♂️" ;

		public const string ManInTuxedoLightSkinToneMinimallyQualified = "🤵🏻‍♂" ;

		public const string ManInTuxedoMediumLightSkinToneFullyQualified = "🤵🏼‍♂️" ;

		public const string ManInTuxedoMediumLightSkinToneMinimallyQualified = "🤵🏼‍♂" ;

		public const string ManInTuxedoMediumSkinToneFullyQualified = "🤵🏽‍♂️" ;

		public const string ManInTuxedoMediumSkinToneMinimallyQualified = "🤵🏽‍♂" ;

		public const string ManInTuxedoMediumDarkSkinToneFullyQualified = "🤵🏾‍♂️" ;

		public const string ManInTuxedoMediumDarkSkinToneMinimallyQualified = "🤵🏾‍♂" ;

		public const string ManInTuxedoDarkSkinToneFullyQualified = "🤵🏿‍♂️" ;

		public const string ManInTuxedoDarkSkinToneMinimallyQualified = "🤵🏿‍♂" ;

		public const string WomanInTuxedoFullyQualified = "🤵‍♀️" ;

		public const string WomanInTuxedoMinimallyQualified = "🤵‍♀" ;

		public const string WomanInTuxedoLightSkinToneFullyQualified = "🤵🏻‍♀️" ;

		public const string WomanInTuxedoLightSkinToneMinimallyQualified = "🤵🏻‍♀" ;

		public const string WomanInTuxedoMediumLightSkinToneFullyQualified = "🤵🏼‍♀️" ;

		public const string WomanInTuxedoMediumLightSkinToneMinimallyQualified = "🤵🏼‍♀" ;

		public const string WomanInTuxedoMediumSkinToneFullyQualified = "🤵🏽‍♀️" ;

		public const string WomanInTuxedoMediumSkinToneMinimallyQualified = "🤵🏽‍♀" ;

		public const string WomanInTuxedoMediumDarkSkinToneFullyQualified = "🤵🏾‍♀️" ;

		public const string WomanInTuxedoMediumDarkSkinToneMinimallyQualified = "🤵🏾‍♀" ;

		public const string WomanInTuxedoDarkSkinToneFullyQualified = "🤵🏿‍♀️" ;

		public const string WomanInTuxedoDarkSkinToneMinimallyQualified = "🤵🏿‍♀" ;

		public const string PersonWithVeil = "👰" ;

		public const string PersonWithVeilLightSkinTone = "👰🏻" ;

		public const string PersonWithVeilMediumLightSkinTone = "👰🏼" ;

		public const string PersonWithVeilMediumSkinTone = "👰🏽" ;

		public const string PersonWithVeilMediumDarkSkinTone = "👰🏾" ;

		public const string PersonWithVeilDarkSkinTone = "👰🏿" ;

		public const string ManWithVeilFullyQualified = "👰‍♂️" ;

		public const string ManWithVeilMinimallyQualified = "👰‍♂" ;

		public const string ManWithVeilLightSkinToneFullyQualified = "👰🏻‍♂️" ;

		public const string ManWithVeilLightSkinToneMinimallyQualified = "👰🏻‍♂" ;

		public const string ManWithVeilMediumLightSkinToneFullyQualified = "👰🏼‍♂️" ;

		public const string ManWithVeilMediumLightSkinToneMinimallyQualified = "👰🏼‍♂" ;

		public const string ManWithVeilMediumSkinToneFullyQualified = "👰🏽‍♂️" ;

		public const string ManWithVeilMediumSkinToneMinimallyQualified = "👰🏽‍♂" ;

		public const string ManWithVeilMediumDarkSkinToneFullyQualified = "👰🏾‍♂️" ;

		public const string ManWithVeilMediumDarkSkinToneMinimallyQualified = "👰🏾‍♂" ;

		public const string ManWithVeilDarkSkinToneFullyQualified = "👰🏿‍♂️" ;

		public const string ManWithVeilDarkSkinToneMinimallyQualified = "👰🏿‍♂" ;

		public const string WomanWithVeilFullyQualified = "👰‍♀️" ;

		public const string WomanWithVeilMinimallyQualified = "👰‍♀" ;

		public const string WomanWithVeilLightSkinToneFullyQualified = "👰🏻‍♀️" ;

		public const string WomanWithVeilLightSkinToneMinimallyQualified = "👰🏻‍♀" ;

		public const string WomanWithVeilMediumLightSkinToneFullyQualified = "👰🏼‍♀️" ;

		public const string WomanWithVeilMediumLightSkinToneMinimallyQualified = "👰🏼‍♀" ;

		public const string WomanWithVeilMediumSkinToneFullyQualified = "👰🏽‍♀️" ;

		public const string WomanWithVeilMediumSkinToneMinimallyQualified = "👰🏽‍♀" ;

		public const string WomanWithVeilMediumDarkSkinToneFullyQualified = "👰🏾‍♀️" ;

		public const string WomanWithVeilMediumDarkSkinToneMinimallyQualified = "👰🏾‍♀" ;

		public const string WomanWithVeilDarkSkinToneFullyQualified = "👰🏿‍♀️" ;

		public const string WomanWithVeilDarkSkinToneMinimallyQualified = "👰🏿‍♀" ;

		public const string PregnantWoman = "🤰" ;

		public const string PregnantWomanLightSkinTone = "🤰🏻" ;

		public const string PregnantWomanMediumLightSkinTone = "🤰🏼" ;

		public const string PregnantWomanMediumSkinTone = "🤰🏽" ;

		public const string PregnantWomanMediumDarkSkinTone = "🤰🏾" ;

		public const string PregnantWomanDarkSkinTone = "🤰🏿" ;

		public const string PregnantMan = "🫃" ;

		public const string PregnantManLightSkinTone = "🫃🏻" ;

		public const string PregnantManMediumLightSkinTone = "🫃🏼" ;

		public const string PregnantManMediumSkinTone = "🫃🏽" ;

		public const string PregnantManMediumDarkSkinTone = "🫃🏾" ;

		public const string PregnantManDarkSkinTone = "🫃🏿" ;

		public const string PregnantPerson = "🫄" ;

		public const string PregnantPersonLightSkinTone = "🫄🏻" ;

		public const string PregnantPersonMediumLightSkinTone = "🫄🏼" ;

		public const string PregnantPersonMediumSkinTone = "🫄🏽" ;

		public const string PregnantPersonMediumDarkSkinTone = "🫄🏾" ;

		public const string PregnantPersonDarkSkinTone = "🫄🏿" ;

		public const string BreastFeeding = "🤱" ;

		public const string BreastFeedingLightSkinTone = "🤱🏻" ;

		public const string BreastFeedingMediumLightSkinTone = "🤱🏼" ;

		public const string BreastFeedingMediumSkinTone = "🤱🏽" ;

		public const string BreastFeedingMediumDarkSkinTone = "🤱🏾" ;

		public const string BreastFeedingDarkSkinTone = "🤱🏿" ;

		public const string WomanFeedingBaby = "👩‍🍼" ;

		public const string WomanFeedingBabyLightSkinTone = "👩🏻‍🍼" ;

		public const string WomanFeedingBabyMediumLightSkinTone = "👩🏼‍🍼" ;

		public const string WomanFeedingBabyMediumSkinTone = "👩🏽‍🍼" ;

		public const string WomanFeedingBabyMediumDarkSkinTone = "👩🏾‍🍼" ;

		public const string WomanFeedingBabyDarkSkinTone = "👩🏿‍🍼" ;

		public const string ManFeedingBaby = "👨‍🍼" ;

		public const string ManFeedingBabyLightSkinTone = "👨🏻‍🍼" ;

		public const string ManFeedingBabyMediumLightSkinTone = "👨🏼‍🍼" ;

		public const string ManFeedingBabyMediumSkinTone = "👨🏽‍🍼" ;

		public const string ManFeedingBabyMediumDarkSkinTone = "👨🏾‍🍼" ;

		public const string ManFeedingBabyDarkSkinTone = "👨🏿‍🍼" ;

		public const string PersonFeedingBaby = "🧑‍🍼" ;

		public const string PersonFeedingBabyLightSkinTone = "🧑🏻‍🍼" ;

		public const string PersonFeedingBabyMediumLightSkinTone = "🧑🏼‍🍼" ;

		public const string PersonFeedingBabyMediumSkinTone = "🧑🏽‍🍼" ;

		public const string PersonFeedingBabyMediumDarkSkinTone = "🧑🏾‍🍼" ;

		public const string PersonFeedingBabyDarkSkinTone = "🧑🏿‍🍼" ;

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

		public const string MxClaus = "🧑‍🎄" ;

		public const string MxClausLightSkinTone = "🧑🏻‍🎄" ;

		public const string MxClausMediumLightSkinTone = "🧑🏼‍🎄" ;

		public const string MxClausMediumSkinTone = "🧑🏽‍🎄" ;

		public const string MxClausMediumDarkSkinTone = "🧑🏾‍🎄" ;

		public const string MxClausDarkSkinTone = "🧑🏿‍🎄" ;

		public const string Superhero = "🦸" ;

		public const string SuperheroLightSkinTone = "🦸🏻" ;

		public const string SuperheroMediumLightSkinTone = "🦸🏼" ;

		public const string SuperheroMediumSkinTone = "🦸🏽" ;

		public const string SuperheroMediumDarkSkinTone = "🦸🏾" ;

		public const string SuperheroDarkSkinTone = "🦸🏿" ;

		public const string ManSuperheroFullyQualified = "🦸‍♂️" ;

		public const string ManSuperheroMinimallyQualified = "🦸‍♂" ;

		public const string ManSuperheroLightSkinToneFullyQualified = "🦸🏻‍♂️" ;

		public const string ManSuperheroLightSkinToneMinimallyQualified = "🦸🏻‍♂" ;

		public const string ManSuperheroMediumLightSkinToneFullyQualified = "🦸🏼‍♂️" ;

		public const string ManSuperheroMediumLightSkinToneMinimallyQualified = "🦸🏼‍♂" ;

		public const string ManSuperheroMediumSkinToneFullyQualified = "🦸🏽‍♂️" ;

		public const string ManSuperheroMediumSkinToneMinimallyQualified = "🦸🏽‍♂" ;

		public const string ManSuperheroMediumDarkSkinToneFullyQualified = "🦸🏾‍♂️" ;

		public const string ManSuperheroMediumDarkSkinToneMinimallyQualified = "🦸🏾‍♂" ;

		public const string ManSuperheroDarkSkinToneFullyQualified = "🦸🏿‍♂️" ;

		public const string ManSuperheroDarkSkinToneMinimallyQualified = "🦸🏿‍♂" ;

		public const string WomanSuperheroFullyQualified = "🦸‍♀️" ;

		public const string WomanSuperheroMinimallyQualified = "🦸‍♀" ;

		public const string WomanSuperheroLightSkinToneFullyQualified = "🦸🏻‍♀️" ;

		public const string WomanSuperheroLightSkinToneMinimallyQualified = "🦸🏻‍♀" ;

		public const string WomanSuperheroMediumLightSkinToneFullyQualified = "🦸🏼‍♀️" ;

		public const string WomanSuperheroMediumLightSkinToneMinimallyQualified = "🦸🏼‍♀" ;

		public const string WomanSuperheroMediumSkinToneFullyQualified = "🦸🏽‍♀️" ;

		public const string WomanSuperheroMediumSkinToneMinimallyQualified = "🦸🏽‍♀" ;

		public const string WomanSuperheroMediumDarkSkinToneFullyQualified = "🦸🏾‍♀️" ;

		public const string WomanSuperheroMediumDarkSkinToneMinimallyQualified = "🦸🏾‍♀" ;

		public const string WomanSuperheroDarkSkinToneFullyQualified = "🦸🏿‍♀️" ;

		public const string WomanSuperheroDarkSkinToneMinimallyQualified = "🦸🏿‍♀" ;

		public const string Supervillain = "🦹" ;

		public const string SupervillainLightSkinTone = "🦹🏻" ;

		public const string SupervillainMediumLightSkinTone = "🦹🏼" ;

		public const string SupervillainMediumSkinTone = "🦹🏽" ;

		public const string SupervillainMediumDarkSkinTone = "🦹🏾" ;

		public const string SupervillainDarkSkinTone = "🦹🏿" ;

		public const string ManSupervillainFullyQualified = "🦹‍♂️" ;

		public const string ManSupervillainMinimallyQualified = "🦹‍♂" ;

		public const string ManSupervillainLightSkinToneFullyQualified = "🦹🏻‍♂️" ;

		public const string ManSupervillainLightSkinToneMinimallyQualified = "🦹🏻‍♂" ;

		public const string ManSupervillainMediumLightSkinToneFullyQualified = "🦹🏼‍♂️" ;

		public const string ManSupervillainMediumLightSkinToneMinimallyQualified = "🦹🏼‍♂" ;

		public const string ManSupervillainMediumSkinToneFullyQualified = "🦹🏽‍♂️" ;

		public const string ManSupervillainMediumSkinToneMinimallyQualified = "🦹🏽‍♂" ;

		public const string ManSupervillainMediumDarkSkinToneFullyQualified = "🦹🏾‍♂️" ;

		public const string ManSupervillainMediumDarkSkinToneMinimallyQualified = "🦹🏾‍♂" ;

		public const string ManSupervillainDarkSkinToneFullyQualified = "🦹🏿‍♂️" ;

		public const string ManSupervillainDarkSkinToneMinimallyQualified = "🦹🏿‍♂" ;

		public const string WomanSupervillainFullyQualified = "🦹‍♀️" ;

		public const string WomanSupervillainMinimallyQualified = "🦹‍♀" ;

		public const string WomanSupervillainLightSkinToneFullyQualified = "🦹🏻‍♀️" ;

		public const string WomanSupervillainLightSkinToneMinimallyQualified = "🦹🏻‍♀" ;

		public const string WomanSupervillainMediumLightSkinToneFullyQualified = "🦹🏼‍♀️" ;

		public const string WomanSupervillainMediumLightSkinToneMinimallyQualified = "🦹🏼‍♀" ;

		public const string WomanSupervillainMediumSkinToneFullyQualified = "🦹🏽‍♀️" ;

		public const string WomanSupervillainMediumSkinToneMinimallyQualified = "🦹🏽‍♀" ;

		public const string WomanSupervillainMediumDarkSkinToneFullyQualified = "🦹🏾‍♀️" ;

		public const string WomanSupervillainMediumDarkSkinToneMinimallyQualified = "🦹🏾‍♀" ;

		public const string WomanSupervillainDarkSkinToneFullyQualified = "🦹🏿‍♀️" ;

		public const string WomanSupervillainDarkSkinToneMinimallyQualified = "🦹🏿‍♀" ;

		public const string Mage = "🧙" ;

		public const string MageLightSkinTone = "🧙🏻" ;

		public const string MageMediumLightSkinTone = "🧙🏼" ;

		public const string MageMediumSkinTone = "🧙🏽" ;

		public const string MageMediumDarkSkinTone = "🧙🏾" ;

		public const string MageDarkSkinTone = "🧙🏿" ;

		public const string ManMageFullyQualified = "🧙‍♂️" ;

		public const string ManMageMinimallyQualified = "🧙‍♂" ;

		public const string ManMageLightSkinToneFullyQualified = "🧙🏻‍♂️" ;

		public const string ManMageLightSkinToneMinimallyQualified = "🧙🏻‍♂" ;

		public const string ManMageMediumLightSkinToneFullyQualified = "🧙🏼‍♂️" ;

		public const string ManMageMediumLightSkinToneMinimallyQualified = "🧙🏼‍♂" ;

		public const string ManMageMediumSkinToneFullyQualified = "🧙🏽‍♂️" ;

		public const string ManMageMediumSkinToneMinimallyQualified = "🧙🏽‍♂" ;

		public const string ManMageMediumDarkSkinToneFullyQualified = "🧙🏾‍♂️" ;

		public const string ManMageMediumDarkSkinToneMinimallyQualified = "🧙🏾‍♂" ;

		public const string ManMageDarkSkinToneFullyQualified = "🧙🏿‍♂️" ;

		public const string ManMageDarkSkinToneMinimallyQualified = "🧙🏿‍♂" ;

		public const string WomanMageFullyQualified = "🧙‍♀️" ;

		public const string WomanMageMinimallyQualified = "🧙‍♀" ;

		public const string WomanMageLightSkinToneFullyQualified = "🧙🏻‍♀️" ;

		public const string WomanMageLightSkinToneMinimallyQualified = "🧙🏻‍♀" ;

		public const string WomanMageMediumLightSkinToneFullyQualified = "🧙🏼‍♀️" ;

		public const string WomanMageMediumLightSkinToneMinimallyQualified = "🧙🏼‍♀" ;

		public const string WomanMageMediumSkinToneFullyQualified = "🧙🏽‍♀️" ;

		public const string WomanMageMediumSkinToneMinimallyQualified = "🧙🏽‍♀" ;

		public const string WomanMageMediumDarkSkinToneFullyQualified = "🧙🏾‍♀️" ;

		public const string WomanMageMediumDarkSkinToneMinimallyQualified = "🧙🏾‍♀" ;

		public const string WomanMageDarkSkinToneFullyQualified = "🧙🏿‍♀️" ;

		public const string WomanMageDarkSkinToneMinimallyQualified = "🧙🏿‍♀" ;

		public const string Fairy = "🧚" ;

		public const string FairyLightSkinTone = "🧚🏻" ;

		public const string FairyMediumLightSkinTone = "🧚🏼" ;

		public const string FairyMediumSkinTone = "🧚🏽" ;

		public const string FairyMediumDarkSkinTone = "🧚🏾" ;

		public const string FairyDarkSkinTone = "🧚🏿" ;

		public const string ManFairyFullyQualified = "🧚‍♂️" ;

		public const string ManFairyMinimallyQualified = "🧚‍♂" ;

		public const string ManFairyLightSkinToneFullyQualified = "🧚🏻‍♂️" ;

		public const string ManFairyLightSkinToneMinimallyQualified = "🧚🏻‍♂" ;

		public const string ManFairyMediumLightSkinToneFullyQualified = "🧚🏼‍♂️" ;

		public const string ManFairyMediumLightSkinToneMinimallyQualified = "🧚🏼‍♂" ;

		public const string ManFairyMediumSkinToneFullyQualified = "🧚🏽‍♂️" ;

		public const string ManFairyMediumSkinToneMinimallyQualified = "🧚🏽‍♂" ;

		public const string ManFairyMediumDarkSkinToneFullyQualified = "🧚🏾‍♂️" ;

		public const string ManFairyMediumDarkSkinToneMinimallyQualified = "🧚🏾‍♂" ;

		public const string ManFairyDarkSkinToneFullyQualified = "🧚🏿‍♂️" ;

		public const string ManFairyDarkSkinToneMinimallyQualified = "🧚🏿‍♂" ;

		public const string WomanFairyFullyQualified = "🧚‍♀️" ;

		public const string WomanFairyMinimallyQualified = "🧚‍♀" ;

		public const string WomanFairyLightSkinToneFullyQualified = "🧚🏻‍♀️" ;

		public const string WomanFairyLightSkinToneMinimallyQualified = "🧚🏻‍♀" ;

		public const string WomanFairyMediumLightSkinToneFullyQualified = "🧚🏼‍♀️" ;

		public const string WomanFairyMediumLightSkinToneMinimallyQualified = "🧚🏼‍♀" ;

		public const string WomanFairyMediumSkinToneFullyQualified = "🧚🏽‍♀️" ;

		public const string WomanFairyMediumSkinToneMinimallyQualified = "🧚🏽‍♀" ;

		public const string WomanFairyMediumDarkSkinToneFullyQualified = "🧚🏾‍♀️" ;

		public const string WomanFairyMediumDarkSkinToneMinimallyQualified = "🧚🏾‍♀" ;

		public const string WomanFairyDarkSkinToneFullyQualified = "🧚🏿‍♀️" ;

		public const string WomanFairyDarkSkinToneMinimallyQualified = "🧚🏿‍♀" ;

		public const string Vampire = "🧛" ;

		public const string VampireLightSkinTone = "🧛🏻" ;

		public const string VampireMediumLightSkinTone = "🧛🏼" ;

		public const string VampireMediumSkinTone = "🧛🏽" ;

		public const string VampireMediumDarkSkinTone = "🧛🏾" ;

		public const string VampireDarkSkinTone = "🧛🏿" ;

		public const string ManVampireFullyQualified = "🧛‍♂️" ;

		public const string ManVampireMinimallyQualified = "🧛‍♂" ;

		public const string ManVampireLightSkinToneFullyQualified = "🧛🏻‍♂️" ;

		public const string ManVampireLightSkinToneMinimallyQualified = "🧛🏻‍♂" ;

		public const string ManVampireMediumLightSkinToneFullyQualified = "🧛🏼‍♂️" ;

		public const string ManVampireMediumLightSkinToneMinimallyQualified = "🧛🏼‍♂" ;

		public const string ManVampireMediumSkinToneFullyQualified = "🧛🏽‍♂️" ;

		public const string ManVampireMediumSkinToneMinimallyQualified = "🧛🏽‍♂" ;

		public const string ManVampireMediumDarkSkinToneFullyQualified = "🧛🏾‍♂️" ;

		public const string ManVampireMediumDarkSkinToneMinimallyQualified = "🧛🏾‍♂" ;

		public const string ManVampireDarkSkinToneFullyQualified = "🧛🏿‍♂️" ;

		public const string ManVampireDarkSkinToneMinimallyQualified = "🧛🏿‍♂" ;

		public const string WomanVampireFullyQualified = "🧛‍♀️" ;

		public const string WomanVampireMinimallyQualified = "🧛‍♀" ;

		public const string WomanVampireLightSkinToneFullyQualified = "🧛🏻‍♀️" ;

		public const string WomanVampireLightSkinToneMinimallyQualified = "🧛🏻‍♀" ;

		public const string WomanVampireMediumLightSkinToneFullyQualified = "🧛🏼‍♀️" ;

		public const string WomanVampireMediumLightSkinToneMinimallyQualified = "🧛🏼‍♀" ;

		public const string WomanVampireMediumSkinToneFullyQualified = "🧛🏽‍♀️" ;

		public const string WomanVampireMediumSkinToneMinimallyQualified = "🧛🏽‍♀" ;

		public const string WomanVampireMediumDarkSkinToneFullyQualified = "🧛🏾‍♀️" ;

		public const string WomanVampireMediumDarkSkinToneMinimallyQualified = "🧛🏾‍♀" ;

		public const string WomanVampireDarkSkinToneFullyQualified = "🧛🏿‍♀️" ;

		public const string WomanVampireDarkSkinToneMinimallyQualified = "🧛🏿‍♀" ;

		public const string Merperson = "🧜" ;

		public const string MerpersonLightSkinTone = "🧜🏻" ;

		public const string MerpersonMediumLightSkinTone = "🧜🏼" ;

		public const string MerpersonMediumSkinTone = "🧜🏽" ;

		public const string MerpersonMediumDarkSkinTone = "🧜🏾" ;

		public const string MerpersonDarkSkinTone = "🧜🏿" ;

		public const string MermanFullyQualified = "🧜‍♂️" ;

		public const string MermanMinimallyQualified = "🧜‍♂" ;

		public const string MermanLightSkinToneFullyQualified = "🧜🏻‍♂️" ;

		public const string MermanLightSkinToneMinimallyQualified = "🧜🏻‍♂" ;

		public const string MermanMediumLightSkinToneFullyQualified = "🧜🏼‍♂️" ;

		public const string MermanMediumLightSkinToneMinimallyQualified = "🧜🏼‍♂" ;

		public const string MermanMediumSkinToneFullyQualified = "🧜🏽‍♂️" ;

		public const string MermanMediumSkinToneMinimallyQualified = "🧜🏽‍♂" ;

		public const string MermanMediumDarkSkinToneFullyQualified = "🧜🏾‍♂️" ;

		public const string MermanMediumDarkSkinToneMinimallyQualified = "🧜🏾‍♂" ;

		public const string MermanDarkSkinToneFullyQualified = "🧜🏿‍♂️" ;

		public const string MermanDarkSkinToneMinimallyQualified = "🧜🏿‍♂" ;

		public const string MermaidFullyQualified = "🧜‍♀️" ;

		public const string MermaidMinimallyQualified = "🧜‍♀" ;

		public const string MermaidLightSkinToneFullyQualified = "🧜🏻‍♀️" ;

		public const string MermaidLightSkinToneMinimallyQualified = "🧜🏻‍♀" ;

		public const string MermaidMediumLightSkinToneFullyQualified = "🧜🏼‍♀️" ;

		public const string MermaidMediumLightSkinToneMinimallyQualified = "🧜🏼‍♀" ;

		public const string MermaidMediumSkinToneFullyQualified = "🧜🏽‍♀️" ;

		public const string MermaidMediumSkinToneMinimallyQualified = "🧜🏽‍♀" ;

		public const string MermaidMediumDarkSkinToneFullyQualified = "🧜🏾‍♀️" ;

		public const string MermaidMediumDarkSkinToneMinimallyQualified = "🧜🏾‍♀" ;

		public const string MermaidDarkSkinToneFullyQualified = "🧜🏿‍♀️" ;

		public const string MermaidDarkSkinToneMinimallyQualified = "🧜🏿‍♀" ;

		public const string Elf = "🧝" ;

		public const string ElfLightSkinTone = "🧝🏻" ;

		public const string ElfMediumLightSkinTone = "🧝🏼" ;

		public const string ElfMediumSkinTone = "🧝🏽" ;

		public const string ElfMediumDarkSkinTone = "🧝🏾" ;

		public const string ElfDarkSkinTone = "🧝🏿" ;

		public const string ManElfFullyQualified = "🧝‍♂️" ;

		public const string ManElfMinimallyQualified = "🧝‍♂" ;

		public const string ManElfLightSkinToneFullyQualified = "🧝🏻‍♂️" ;

		public const string ManElfLightSkinToneMinimallyQualified = "🧝🏻‍♂" ;

		public const string ManElfMediumLightSkinToneFullyQualified = "🧝🏼‍♂️" ;

		public const string ManElfMediumLightSkinToneMinimallyQualified = "🧝🏼‍♂" ;

		public const string ManElfMediumSkinToneFullyQualified = "🧝🏽‍♂️" ;

		public const string ManElfMediumSkinToneMinimallyQualified = "🧝🏽‍♂" ;

		public const string ManElfMediumDarkSkinToneFullyQualified = "🧝🏾‍♂️" ;

		public const string ManElfMediumDarkSkinToneMinimallyQualified = "🧝🏾‍♂" ;

		public const string ManElfDarkSkinToneFullyQualified = "🧝🏿‍♂️" ;

		public const string ManElfDarkSkinToneMinimallyQualified = "🧝🏿‍♂" ;

		public const string WomanElfFullyQualified = "🧝‍♀️" ;

		public const string WomanElfMinimallyQualified = "🧝‍♀" ;

		public const string WomanElfLightSkinToneFullyQualified = "🧝🏻‍♀️" ;

		public const string WomanElfLightSkinToneMinimallyQualified = "🧝🏻‍♀" ;

		public const string WomanElfMediumLightSkinToneFullyQualified = "🧝🏼‍♀️" ;

		public const string WomanElfMediumLightSkinToneMinimallyQualified = "🧝🏼‍♀" ;

		public const string WomanElfMediumSkinToneFullyQualified = "🧝🏽‍♀️" ;

		public const string WomanElfMediumSkinToneMinimallyQualified = "🧝🏽‍♀" ;

		public const string WomanElfMediumDarkSkinToneFullyQualified = "🧝🏾‍♀️" ;

		public const string WomanElfMediumDarkSkinToneMinimallyQualified = "🧝🏾‍♀" ;

		public const string WomanElfDarkSkinToneFullyQualified = "🧝🏿‍♀️" ;

		public const string WomanElfDarkSkinToneMinimallyQualified = "🧝🏿‍♀" ;

		public const string Genie = "🧞" ;

		public const string ManGenieFullyQualified = "🧞‍♂️" ;

		public const string ManGenieMinimallyQualified = "🧞‍♂" ;

		public const string WomanGenieFullyQualified = "🧞‍♀️" ;

		public const string WomanGenieMinimallyQualified = "🧞‍♀" ;

		public const string Zombie = "🧟" ;

		public const string ManZombieFullyQualified = "🧟‍♂️" ;

		public const string ManZombieMinimallyQualified = "🧟‍♂" ;

		public const string WomanZombieFullyQualified = "🧟‍♀️" ;

		public const string WomanZombieMinimallyQualified = "🧟‍♀" ;

		public const string Troll = "🧌" ;

		public const string PersonGettingMassage = "💆" ;

		public const string PersonGettingMassageLightSkinTone = "💆🏻" ;

		public const string PersonGettingMassageMediumLightSkinTone = "💆🏼" ;

		public const string PersonGettingMassageMediumSkinTone = "💆🏽" ;

		public const string PersonGettingMassageMediumDarkSkinTone = "💆🏾" ;

		public const string PersonGettingMassageDarkSkinTone = "💆🏿" ;

		public const string ManGettingMassageFullyQualified = "💆‍♂️" ;

		public const string ManGettingMassageMinimallyQualified = "💆‍♂" ;

		public const string ManGettingMassageLightSkinToneFullyQualified = "💆🏻‍♂️" ;

		public const string ManGettingMassageLightSkinToneMinimallyQualified = "💆🏻‍♂" ;

		public const string ManGettingMassageMediumLightSkinToneFullyQualified = "💆🏼‍♂️" ;

		public const string ManGettingMassageMediumLightSkinToneMinimallyQualified = "💆🏼‍♂" ;

		public const string ManGettingMassageMediumSkinToneFullyQualified = "💆🏽‍♂️" ;

		public const string ManGettingMassageMediumSkinToneMinimallyQualified = "💆🏽‍♂" ;

		public const string ManGettingMassageMediumDarkSkinToneFullyQualified = "💆🏾‍♂️" ;

		public const string ManGettingMassageMediumDarkSkinToneMinimallyQualified = "💆🏾‍♂" ;

		public const string ManGettingMassageDarkSkinToneFullyQualified = "💆🏿‍♂️" ;

		public const string ManGettingMassageDarkSkinToneMinimallyQualified = "💆🏿‍♂" ;

		public const string WomanGettingMassageFullyQualified = "💆‍♀️" ;

		public const string WomanGettingMassageMinimallyQualified = "💆‍♀" ;

		public const string WomanGettingMassageLightSkinToneFullyQualified = "💆🏻‍♀️" ;

		public const string WomanGettingMassageLightSkinToneMinimallyQualified = "💆🏻‍♀" ;

		public const string WomanGettingMassageMediumLightSkinToneFullyQualified = "💆🏼‍♀️" ;

		public const string WomanGettingMassageMediumLightSkinToneMinimallyQualified = "💆🏼‍♀" ;

		public const string WomanGettingMassageMediumSkinToneFullyQualified = "💆🏽‍♀️" ;

		public const string WomanGettingMassageMediumSkinToneMinimallyQualified = "💆🏽‍♀" ;

		public const string WomanGettingMassageMediumDarkSkinToneFullyQualified = "💆🏾‍♀️" ;

		public const string WomanGettingMassageMediumDarkSkinToneMinimallyQualified = "💆🏾‍♀" ;

		public const string WomanGettingMassageDarkSkinToneFullyQualified = "💆🏿‍♀️" ;

		public const string WomanGettingMassageDarkSkinToneMinimallyQualified = "💆🏿‍♀" ;

		public const string PersonGettingHaircut = "💇" ;

		public const string PersonGettingHaircutLightSkinTone = "💇🏻" ;

		public const string PersonGettingHaircutMediumLightSkinTone = "💇🏼" ;

		public const string PersonGettingHaircutMediumSkinTone = "💇🏽" ;

		public const string PersonGettingHaircutMediumDarkSkinTone = "💇🏾" ;

		public const string PersonGettingHaircutDarkSkinTone = "💇🏿" ;

		public const string ManGettingHaircutFullyQualified = "💇‍♂️" ;

		public const string ManGettingHaircutMinimallyQualified = "💇‍♂" ;

		public const string ManGettingHaircutLightSkinToneFullyQualified = "💇🏻‍♂️" ;

		public const string ManGettingHaircutLightSkinToneMinimallyQualified = "💇🏻‍♂" ;

		public const string ManGettingHaircutMediumLightSkinToneFullyQualified = "💇🏼‍♂️" ;

		public const string ManGettingHaircutMediumLightSkinToneMinimallyQualified = "💇🏼‍♂" ;

		public const string ManGettingHaircutMediumSkinToneFullyQualified = "💇🏽‍♂️" ;

		public const string ManGettingHaircutMediumSkinToneMinimallyQualified = "💇🏽‍♂" ;

		public const string ManGettingHaircutMediumDarkSkinToneFullyQualified = "💇🏾‍♂️" ;

		public const string ManGettingHaircutMediumDarkSkinToneMinimallyQualified = "💇🏾‍♂" ;

		public const string ManGettingHaircutDarkSkinToneFullyQualified = "💇🏿‍♂️" ;

		public const string ManGettingHaircutDarkSkinToneMinimallyQualified = "💇🏿‍♂" ;

		public const string WomanGettingHaircutFullyQualified = "💇‍♀️" ;

		public const string WomanGettingHaircutMinimallyQualified = "💇‍♀" ;

		public const string WomanGettingHaircutLightSkinToneFullyQualified = "💇🏻‍♀️" ;

		public const string WomanGettingHaircutLightSkinToneMinimallyQualified = "💇🏻‍♀" ;

		public const string WomanGettingHaircutMediumLightSkinToneFullyQualified = "💇🏼‍♀️" ;

		public const string WomanGettingHaircutMediumLightSkinToneMinimallyQualified = "💇🏼‍♀" ;

		public const string WomanGettingHaircutMediumSkinToneFullyQualified = "💇🏽‍♀️" ;

		public const string WomanGettingHaircutMediumSkinToneMinimallyQualified = "💇🏽‍♀" ;

		public const string WomanGettingHaircutMediumDarkSkinToneFullyQualified = "💇🏾‍♀️" ;

		public const string WomanGettingHaircutMediumDarkSkinToneMinimallyQualified = "💇🏾‍♀" ;

		public const string WomanGettingHaircutDarkSkinToneFullyQualified = "💇🏿‍♀️" ;

		public const string WomanGettingHaircutDarkSkinToneMinimallyQualified = "💇🏿‍♀" ;

		public const string PersonWalking = "🚶" ;

		public const string PersonWalkingLightSkinTone = "🚶🏻" ;

		public const string PersonWalkingMediumLightSkinTone = "🚶🏼" ;

		public const string PersonWalkingMediumSkinTone = "🚶🏽" ;

		public const string PersonWalkingMediumDarkSkinTone = "🚶🏾" ;

		public const string PersonWalkingDarkSkinTone = "🚶🏿" ;

		public const string ManWalkingFullyQualified = "🚶‍♂️" ;

		public const string ManWalkingMinimallyQualified = "🚶‍♂" ;

		public const string ManWalkingLightSkinToneFullyQualified = "🚶🏻‍♂️" ;

		public const string ManWalkingLightSkinToneMinimallyQualified = "🚶🏻‍♂" ;

		public const string ManWalkingMediumLightSkinToneFullyQualified = "🚶🏼‍♂️" ;

		public const string ManWalkingMediumLightSkinToneMinimallyQualified = "🚶🏼‍♂" ;

		public const string ManWalkingMediumSkinToneFullyQualified = "🚶🏽‍♂️" ;

		public const string ManWalkingMediumSkinToneMinimallyQualified = "🚶🏽‍♂" ;

		public const string ManWalkingMediumDarkSkinToneFullyQualified = "🚶🏾‍♂️" ;

		public const string ManWalkingMediumDarkSkinToneMinimallyQualified = "🚶🏾‍♂" ;

		public const string ManWalkingDarkSkinToneFullyQualified = "🚶🏿‍♂️" ;

		public const string ManWalkingDarkSkinToneMinimallyQualified = "🚶🏿‍♂" ;

		public const string WomanWalkingFullyQualified = "🚶‍♀️" ;

		public const string WomanWalkingMinimallyQualified = "🚶‍♀" ;

		public const string WomanWalkingLightSkinToneFullyQualified = "🚶🏻‍♀️" ;

		public const string WomanWalkingLightSkinToneMinimallyQualified = "🚶🏻‍♀" ;

		public const string WomanWalkingMediumLightSkinToneFullyQualified = "🚶🏼‍♀️" ;

		public const string WomanWalkingMediumLightSkinToneMinimallyQualified = "🚶🏼‍♀" ;

		public const string WomanWalkingMediumSkinToneFullyQualified = "🚶🏽‍♀️" ;

		public const string WomanWalkingMediumSkinToneMinimallyQualified = "🚶🏽‍♀" ;

		public const string WomanWalkingMediumDarkSkinToneFullyQualified = "🚶🏾‍♀️" ;

		public const string WomanWalkingMediumDarkSkinToneMinimallyQualified = "🚶🏾‍♀" ;

		public const string WomanWalkingDarkSkinToneFullyQualified = "🚶🏿‍♀️" ;

		public const string WomanWalkingDarkSkinToneMinimallyQualified = "🚶🏿‍♀" ;

		public const string PersonStanding = "🧍" ;

		public const string PersonStandingLightSkinTone = "🧍🏻" ;

		public const string PersonStandingMediumLightSkinTone = "🧍🏼" ;

		public const string PersonStandingMediumSkinTone = "🧍🏽" ;

		public const string PersonStandingMediumDarkSkinTone = "🧍🏾" ;

		public const string PersonStandingDarkSkinTone = "🧍🏿" ;

		public const string ManStandingFullyQualified = "🧍‍♂️" ;

		public const string ManStandingMinimallyQualified = "🧍‍♂" ;

		public const string ManStandingLightSkinToneFullyQualified = "🧍🏻‍♂️" ;

		public const string ManStandingLightSkinToneMinimallyQualified = "🧍🏻‍♂" ;

		public const string ManStandingMediumLightSkinToneFullyQualified = "🧍🏼‍♂️" ;

		public const string ManStandingMediumLightSkinToneMinimallyQualified = "🧍🏼‍♂" ;

		public const string ManStandingMediumSkinToneFullyQualified = "🧍🏽‍♂️" ;

		public const string ManStandingMediumSkinToneMinimallyQualified = "🧍🏽‍♂" ;

		public const string ManStandingMediumDarkSkinToneFullyQualified = "🧍🏾‍♂️" ;

		public const string ManStandingMediumDarkSkinToneMinimallyQualified = "🧍🏾‍♂" ;

		public const string ManStandingDarkSkinToneFullyQualified = "🧍🏿‍♂️" ;

		public const string ManStandingDarkSkinToneMinimallyQualified = "🧍🏿‍♂" ;

		public const string WomanStandingFullyQualified = "🧍‍♀️" ;

		public const string WomanStandingMinimallyQualified = "🧍‍♀" ;

		public const string WomanStandingLightSkinToneFullyQualified = "🧍🏻‍♀️" ;

		public const string WomanStandingLightSkinToneMinimallyQualified = "🧍🏻‍♀" ;

		public const string WomanStandingMediumLightSkinToneFullyQualified = "🧍🏼‍♀️" ;

		public const string WomanStandingMediumLightSkinToneMinimallyQualified = "🧍🏼‍♀" ;

		public const string WomanStandingMediumSkinToneFullyQualified = "🧍🏽‍♀️" ;

		public const string WomanStandingMediumSkinToneMinimallyQualified = "🧍🏽‍♀" ;

		public const string WomanStandingMediumDarkSkinToneFullyQualified = "🧍🏾‍♀️" ;

		public const string WomanStandingMediumDarkSkinToneMinimallyQualified = "🧍🏾‍♀" ;

		public const string WomanStandingDarkSkinToneFullyQualified = "🧍🏿‍♀️" ;

		public const string WomanStandingDarkSkinToneMinimallyQualified = "🧍🏿‍♀" ;

		public const string PersonKneeling = "🧎" ;

		public const string PersonKneelingLightSkinTone = "🧎🏻" ;

		public const string PersonKneelingMediumLightSkinTone = "🧎🏼" ;

		public const string PersonKneelingMediumSkinTone = "🧎🏽" ;

		public const string PersonKneelingMediumDarkSkinTone = "🧎🏾" ;

		public const string PersonKneelingDarkSkinTone = "🧎🏿" ;

		public const string ManKneelingFullyQualified = "🧎‍♂️" ;

		public const string ManKneelingMinimallyQualified = "🧎‍♂" ;

		public const string ManKneelingLightSkinToneFullyQualified = "🧎🏻‍♂️" ;

		public const string ManKneelingLightSkinToneMinimallyQualified = "🧎🏻‍♂" ;

		public const string ManKneelingMediumLightSkinToneFullyQualified = "🧎🏼‍♂️" ;

		public const string ManKneelingMediumLightSkinToneMinimallyQualified = "🧎🏼‍♂" ;

		public const string ManKneelingMediumSkinToneFullyQualified = "🧎🏽‍♂️" ;

		public const string ManKneelingMediumSkinToneMinimallyQualified = "🧎🏽‍♂" ;

		public const string ManKneelingMediumDarkSkinToneFullyQualified = "🧎🏾‍♂️" ;

		public const string ManKneelingMediumDarkSkinToneMinimallyQualified = "🧎🏾‍♂" ;

		public const string ManKneelingDarkSkinToneFullyQualified = "🧎🏿‍♂️" ;

		public const string ManKneelingDarkSkinToneMinimallyQualified = "🧎🏿‍♂" ;

		public const string WomanKneelingFullyQualified = "🧎‍♀️" ;

		public const string WomanKneelingMinimallyQualified = "🧎‍♀" ;

		public const string WomanKneelingLightSkinToneFullyQualified = "🧎🏻‍♀️" ;

		public const string WomanKneelingLightSkinToneMinimallyQualified = "🧎🏻‍♀" ;

		public const string WomanKneelingMediumLightSkinToneFullyQualified = "🧎🏼‍♀️" ;

		public const string WomanKneelingMediumLightSkinToneMinimallyQualified = "🧎🏼‍♀" ;

		public const string WomanKneelingMediumSkinToneFullyQualified = "🧎🏽‍♀️" ;

		public const string WomanKneelingMediumSkinToneMinimallyQualified = "🧎🏽‍♀" ;

		public const string WomanKneelingMediumDarkSkinToneFullyQualified = "🧎🏾‍♀️" ;

		public const string WomanKneelingMediumDarkSkinToneMinimallyQualified = "🧎🏾‍♀" ;

		public const string WomanKneelingDarkSkinToneFullyQualified = "🧎🏿‍♀️" ;

		public const string WomanKneelingDarkSkinToneMinimallyQualified = "🧎🏿‍♀" ;

		public const string PersonWithWhiteCane = "🧑‍🦯" ;

		public const string PersonWithWhiteCaneLightSkinTone = "🧑🏻‍🦯" ;

		public const string PersonWithWhiteCaneMediumLightSkinTone = "🧑🏼‍🦯" ;

		public const string PersonWithWhiteCaneMediumSkinTone = "🧑🏽‍🦯" ;

		public const string PersonWithWhiteCaneMediumDarkSkinTone = "🧑🏾‍🦯" ;

		public const string PersonWithWhiteCaneDarkSkinTone = "🧑🏿‍🦯" ;

		public const string ManWithWhiteCane = "👨‍🦯" ;

		public const string ManWithWhiteCaneLightSkinTone = "👨🏻‍🦯" ;

		public const string ManWithWhiteCaneMediumLightSkinTone = "👨🏼‍🦯" ;

		public const string ManWithWhiteCaneMediumSkinTone = "👨🏽‍🦯" ;

		public const string ManWithWhiteCaneMediumDarkSkinTone = "👨🏾‍🦯" ;

		public const string ManWithWhiteCaneDarkSkinTone = "👨🏿‍🦯" ;

		public const string WomanWithWhiteCane = "👩‍🦯" ;

		public const string WomanWithWhiteCaneLightSkinTone = "👩🏻‍🦯" ;

		public const string WomanWithWhiteCaneMediumLightSkinTone = "👩🏼‍🦯" ;

		public const string WomanWithWhiteCaneMediumSkinTone = "👩🏽‍🦯" ;

		public const string WomanWithWhiteCaneMediumDarkSkinTone = "👩🏾‍🦯" ;

		public const string WomanWithWhiteCaneDarkSkinTone = "👩🏿‍🦯" ;

		public const string PersonInMotorizedWheelchair = "🧑‍🦼" ;

		public const string PersonInMotorizedWheelchairLightSkinTone = "🧑🏻‍🦼" ;

		public const string PersonInMotorizedWheelchairMediumLightSkinTone = "🧑🏼‍🦼" ;

		public const string PersonInMotorizedWheelchairMediumSkinTone = "🧑🏽‍🦼" ;

		public const string PersonInMotorizedWheelchairMediumDarkSkinTone = "🧑🏾‍🦼" ;

		public const string PersonInMotorizedWheelchairDarkSkinTone = "🧑🏿‍🦼" ;

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

		public const string PersonInManualWheelchair = "🧑‍🦽" ;

		public const string PersonInManualWheelchairLightSkinTone = "🧑🏻‍🦽" ;

		public const string PersonInManualWheelchairMediumLightSkinTone = "🧑🏼‍🦽" ;

		public const string PersonInManualWheelchairMediumSkinTone = "🧑🏽‍🦽" ;

		public const string PersonInManualWheelchairMediumDarkSkinTone = "🧑🏾‍🦽" ;

		public const string PersonInManualWheelchairDarkSkinTone = "🧑🏿‍🦽" ;

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

		public const string ManRunningFullyQualified = "🏃‍♂️" ;

		public const string ManRunningMinimallyQualified = "🏃‍♂" ;

		public const string ManRunningLightSkinToneFullyQualified = "🏃🏻‍♂️" ;

		public const string ManRunningLightSkinToneMinimallyQualified = "🏃🏻‍♂" ;

		public const string ManRunningMediumLightSkinToneFullyQualified = "🏃🏼‍♂️" ;

		public const string ManRunningMediumLightSkinToneMinimallyQualified = "🏃🏼‍♂" ;

		public const string ManRunningMediumSkinToneFullyQualified = "🏃🏽‍♂️" ;

		public const string ManRunningMediumSkinToneMinimallyQualified = "🏃🏽‍♂" ;

		public const string ManRunningMediumDarkSkinToneFullyQualified = "🏃🏾‍♂️" ;

		public const string ManRunningMediumDarkSkinToneMinimallyQualified = "🏃🏾‍♂" ;

		public const string ManRunningDarkSkinToneFullyQualified = "🏃🏿‍♂️" ;

		public const string ManRunningDarkSkinToneMinimallyQualified = "🏃🏿‍♂" ;

		public const string WomanRunningFullyQualified = "🏃‍♀️" ;

		public const string WomanRunningMinimallyQualified = "🏃‍♀" ;

		public const string WomanRunningLightSkinToneFullyQualified = "🏃🏻‍♀️" ;

		public const string WomanRunningLightSkinToneMinimallyQualified = "🏃🏻‍♀" ;

		public const string WomanRunningMediumLightSkinToneFullyQualified = "🏃🏼‍♀️" ;

		public const string WomanRunningMediumLightSkinToneMinimallyQualified = "🏃🏼‍♀" ;

		public const string WomanRunningMediumSkinToneFullyQualified = "🏃🏽‍♀️" ;

		public const string WomanRunningMediumSkinToneMinimallyQualified = "🏃🏽‍♀" ;

		public const string WomanRunningMediumDarkSkinToneFullyQualified = "🏃🏾‍♀️" ;

		public const string WomanRunningMediumDarkSkinToneMinimallyQualified = "🏃🏾‍♀" ;

		public const string WomanRunningDarkSkinToneFullyQualified = "🏃🏿‍♀️" ;

		public const string WomanRunningDarkSkinToneMinimallyQualified = "🏃🏿‍♀" ;

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

		public const string PersonInSuitLevitatingFullyQualified = "🕴️" ;

		public const string PersonInSuitLevitatingUnqualified = "🕴" ;

		public const string PersonInSuitLevitatingLightSkinTone = "🕴🏻" ;

		public const string PersonInSuitLevitatingMediumLightSkinTone = "🕴🏼" ;

		public const string PersonInSuitLevitatingMediumSkinTone = "🕴🏽" ;

		public const string PersonInSuitLevitatingMediumDarkSkinTone = "🕴🏾" ;

		public const string PersonInSuitLevitatingDarkSkinTone = "🕴🏿" ;

		public const string PeopleWithBunnyEars = "👯" ;

		public const string MenWithBunnyEarsFullyQualified = "👯‍♂️" ;

		public const string MenWithBunnyEarsMinimallyQualified = "👯‍♂" ;

		public const string WomenWithBunnyEarsFullyQualified = "👯‍♀️" ;

		public const string WomenWithBunnyEarsMinimallyQualified = "👯‍♀" ;

		public const string PersonInSteamyRoom = "🧖" ;

		public const string PersonInSteamyRoomLightSkinTone = "🧖🏻" ;

		public const string PersonInSteamyRoomMediumLightSkinTone = "🧖🏼" ;

		public const string PersonInSteamyRoomMediumSkinTone = "🧖🏽" ;

		public const string PersonInSteamyRoomMediumDarkSkinTone = "🧖🏾" ;

		public const string PersonInSteamyRoomDarkSkinTone = "🧖🏿" ;

		public const string ManInSteamyRoomFullyQualified = "🧖‍♂️" ;

		public const string ManInSteamyRoomMinimallyQualified = "🧖‍♂" ;

		public const string ManInSteamyRoomLightSkinToneFullyQualified = "🧖🏻‍♂️" ;

		public const string ManInSteamyRoomLightSkinToneMinimallyQualified = "🧖🏻‍♂" ;

		public const string ManInSteamyRoomMediumLightSkinToneFullyQualified = "🧖🏼‍♂️" ;

		public const string ManInSteamyRoomMediumLightSkinToneMinimallyQualified = "🧖🏼‍♂" ;

		public const string ManInSteamyRoomMediumSkinToneFullyQualified = "🧖🏽‍♂️" ;

		public const string ManInSteamyRoomMediumSkinToneMinimallyQualified = "🧖🏽‍♂" ;

		public const string ManInSteamyRoomMediumDarkSkinToneFullyQualified = "🧖🏾‍♂️" ;

		public const string ManInSteamyRoomMediumDarkSkinToneMinimallyQualified = "🧖🏾‍♂" ;

		public const string ManInSteamyRoomDarkSkinToneFullyQualified = "🧖🏿‍♂️" ;

		public const string ManInSteamyRoomDarkSkinToneMinimallyQualified = "🧖🏿‍♂" ;

		public const string WomanInSteamyRoomFullyQualified = "🧖‍♀️" ;

		public const string WomanInSteamyRoomMinimallyQualified = "🧖‍♀" ;

		public const string WomanInSteamyRoomLightSkinToneFullyQualified = "🧖🏻‍♀️" ;

		public const string WomanInSteamyRoomLightSkinToneMinimallyQualified = "🧖🏻‍♀" ;

		public const string WomanInSteamyRoomMediumLightSkinToneFullyQualified = "🧖🏼‍♀️" ;

		public const string WomanInSteamyRoomMediumLightSkinToneMinimallyQualified = "🧖🏼‍♀" ;

		public const string WomanInSteamyRoomMediumSkinToneFullyQualified = "🧖🏽‍♀️" ;

		public const string WomanInSteamyRoomMediumSkinToneMinimallyQualified = "🧖🏽‍♀" ;

		public const string WomanInSteamyRoomMediumDarkSkinToneFullyQualified = "🧖🏾‍♀️" ;

		public const string WomanInSteamyRoomMediumDarkSkinToneMinimallyQualified = "🧖🏾‍♀" ;

		public const string WomanInSteamyRoomDarkSkinToneFullyQualified = "🧖🏿‍♀️" ;

		public const string WomanInSteamyRoomDarkSkinToneMinimallyQualified = "🧖🏿‍♀" ;

		public const string PersonClimbing = "🧗" ;

		public const string PersonClimbingLightSkinTone = "🧗🏻" ;

		public const string PersonClimbingMediumLightSkinTone = "🧗🏼" ;

		public const string PersonClimbingMediumSkinTone = "🧗🏽" ;

		public const string PersonClimbingMediumDarkSkinTone = "🧗🏾" ;

		public const string PersonClimbingDarkSkinTone = "🧗🏿" ;

		public const string ManClimbingFullyQualified = "🧗‍♂️" ;

		public const string ManClimbingMinimallyQualified = "🧗‍♂" ;

		public const string ManClimbingLightSkinToneFullyQualified = "🧗🏻‍♂️" ;

		public const string ManClimbingLightSkinToneMinimallyQualified = "🧗🏻‍♂" ;

		public const string ManClimbingMediumLightSkinToneFullyQualified = "🧗🏼‍♂️" ;

		public const string ManClimbingMediumLightSkinToneMinimallyQualified = "🧗🏼‍♂" ;

		public const string ManClimbingMediumSkinToneFullyQualified = "🧗🏽‍♂️" ;

		public const string ManClimbingMediumSkinToneMinimallyQualified = "🧗🏽‍♂" ;

		public const string ManClimbingMediumDarkSkinToneFullyQualified = "🧗🏾‍♂️" ;

		public const string ManClimbingMediumDarkSkinToneMinimallyQualified = "🧗🏾‍♂" ;

		public const string ManClimbingDarkSkinToneFullyQualified = "🧗🏿‍♂️" ;

		public const string ManClimbingDarkSkinToneMinimallyQualified = "🧗🏿‍♂" ;

		public const string WomanClimbingFullyQualified = "🧗‍♀️" ;

		public const string WomanClimbingMinimallyQualified = "🧗‍♀" ;

		public const string WomanClimbingLightSkinToneFullyQualified = "🧗🏻‍♀️" ;

		public const string WomanClimbingLightSkinToneMinimallyQualified = "🧗🏻‍♀" ;

		public const string WomanClimbingMediumLightSkinToneFullyQualified = "🧗🏼‍♀️" ;

		public const string WomanClimbingMediumLightSkinToneMinimallyQualified = "🧗🏼‍♀" ;

		public const string WomanClimbingMediumSkinToneFullyQualified = "🧗🏽‍♀️" ;

		public const string WomanClimbingMediumSkinToneMinimallyQualified = "🧗🏽‍♀" ;

		public const string WomanClimbingMediumDarkSkinToneFullyQualified = "🧗🏾‍♀️" ;

		public const string WomanClimbingMediumDarkSkinToneMinimallyQualified = "🧗🏾‍♀" ;

		public const string WomanClimbingDarkSkinToneFullyQualified = "🧗🏿‍♀️" ;

		public const string WomanClimbingDarkSkinToneMinimallyQualified = "🧗🏿‍♀" ;

		public const string PersonFencing = "🤺" ;

		public const string HorseRacing = "🏇" ;

		public const string HorseRacingLightSkinTone = "🏇🏻" ;

		public const string HorseRacingMediumLightSkinTone = "🏇🏼" ;

		public const string HorseRacingMediumSkinTone = "🏇🏽" ;

		public const string HorseRacingMediumDarkSkinTone = "🏇🏾" ;

		public const string HorseRacingDarkSkinTone = "🏇🏿" ;

		public const string SkierFullyQualified = "⛷️" ;

		public const string SkierUnqualified = "⛷" ;

		public const string Snowboarder = "🏂" ;

		public const string SnowboarderLightSkinTone = "🏂🏻" ;

		public const string SnowboarderMediumLightSkinTone = "🏂🏼" ;

		public const string SnowboarderMediumSkinTone = "🏂🏽" ;

		public const string SnowboarderMediumDarkSkinTone = "🏂🏾" ;

		public const string SnowboarderDarkSkinTone = "🏂🏿" ;

		public const string PersonGolfingFullyQualified = "🏌️" ;

		public const string PersonGolfingUnqualified = "🏌" ;

		public const string PersonGolfingLightSkinTone = "🏌🏻" ;

		public const string PersonGolfingMediumLightSkinTone = "🏌🏼" ;

		public const string PersonGolfingMediumSkinTone = "🏌🏽" ;

		public const string PersonGolfingMediumDarkSkinTone = "🏌🏾" ;

		public const string PersonGolfingDarkSkinTone = "🏌🏿" ;

		public const string ManGolfingFullyQualified = "🏌️‍♂️" ;

		public const string ManGolfingUnqualified = "🏌‍♂️" ;

		public const string ManGolfingMinimallyQualified = "🏌️‍♂" ;

		public const string ManGolfingUnqualified2 = "🏌‍♂" ;

		public const string ManGolfingLightSkinToneFullyQualified = "🏌🏻‍♂️" ;

		public const string ManGolfingLightSkinToneMinimallyQualified = "🏌🏻‍♂" ;

		public const string ManGolfingMediumLightSkinToneFullyQualified = "🏌🏼‍♂️" ;

		public const string ManGolfingMediumLightSkinToneMinimallyQualified = "🏌🏼‍♂" ;

		public const string ManGolfingMediumSkinToneFullyQualified = "🏌🏽‍♂️" ;

		public const string ManGolfingMediumSkinToneMinimallyQualified = "🏌🏽‍♂" ;

		public const string ManGolfingMediumDarkSkinToneFullyQualified = "🏌🏾‍♂️" ;

		public const string ManGolfingMediumDarkSkinToneMinimallyQualified = "🏌🏾‍♂" ;

		public const string ManGolfingDarkSkinToneFullyQualified = "🏌🏿‍♂️" ;

		public const string ManGolfingDarkSkinToneMinimallyQualified = "🏌🏿‍♂" ;

		public const string WomanGolfingFullyQualified = "🏌️‍♀️" ;

		public const string WomanGolfingUnqualified = "🏌‍♀️" ;

		public const string WomanGolfingMinimallyQualified = "🏌️‍♀" ;

		public const string WomanGolfingUnqualified2 = "🏌‍♀" ;

		public const string WomanGolfingLightSkinToneFullyQualified = "🏌🏻‍♀️" ;

		public const string WomanGolfingLightSkinToneMinimallyQualified = "🏌🏻‍♀" ;

		public const string WomanGolfingMediumLightSkinToneFullyQualified = "🏌🏼‍♀️" ;

		public const string WomanGolfingMediumLightSkinToneMinimallyQualified = "🏌🏼‍♀" ;

		public const string WomanGolfingMediumSkinToneFullyQualified = "🏌🏽‍♀️" ;

		public const string WomanGolfingMediumSkinToneMinimallyQualified = "🏌🏽‍♀" ;

		public const string WomanGolfingMediumDarkSkinToneFullyQualified = "🏌🏾‍♀️" ;

		public const string WomanGolfingMediumDarkSkinToneMinimallyQualified = "🏌🏾‍♀" ;

		public const string WomanGolfingDarkSkinToneFullyQualified = "🏌🏿‍♀️" ;

		public const string WomanGolfingDarkSkinToneMinimallyQualified = "🏌🏿‍♀" ;

		public const string PersonSurfing = "🏄" ;

		public const string PersonSurfingLightSkinTone = "🏄🏻" ;

		public const string PersonSurfingMediumLightSkinTone = "🏄🏼" ;

		public const string PersonSurfingMediumSkinTone = "🏄🏽" ;

		public const string PersonSurfingMediumDarkSkinTone = "🏄🏾" ;

		public const string PersonSurfingDarkSkinTone = "🏄🏿" ;

		public const string ManSurfingFullyQualified = "🏄‍♂️" ;

		public const string ManSurfingMinimallyQualified = "🏄‍♂" ;

		public const string ManSurfingLightSkinToneFullyQualified = "🏄🏻‍♂️" ;

		public const string ManSurfingLightSkinToneMinimallyQualified = "🏄🏻‍♂" ;

		public const string ManSurfingMediumLightSkinToneFullyQualified = "🏄🏼‍♂️" ;

		public const string ManSurfingMediumLightSkinToneMinimallyQualified = "🏄🏼‍♂" ;

		public const string ManSurfingMediumSkinToneFullyQualified = "🏄🏽‍♂️" ;

		public const string ManSurfingMediumSkinToneMinimallyQualified = "🏄🏽‍♂" ;

		public const string ManSurfingMediumDarkSkinToneFullyQualified = "🏄🏾‍♂️" ;

		public const string ManSurfingMediumDarkSkinToneMinimallyQualified = "🏄🏾‍♂" ;

		public const string ManSurfingDarkSkinToneFullyQualified = "🏄🏿‍♂️" ;

		public const string ManSurfingDarkSkinToneMinimallyQualified = "🏄🏿‍♂" ;

		public const string WomanSurfingFullyQualified = "🏄‍♀️" ;

		public const string WomanSurfingMinimallyQualified = "🏄‍♀" ;

		public const string WomanSurfingLightSkinToneFullyQualified = "🏄🏻‍♀️" ;

		public const string WomanSurfingLightSkinToneMinimallyQualified = "🏄🏻‍♀" ;

		public const string WomanSurfingMediumLightSkinToneFullyQualified = "🏄🏼‍♀️" ;

		public const string WomanSurfingMediumLightSkinToneMinimallyQualified = "🏄🏼‍♀" ;

		public const string WomanSurfingMediumSkinToneFullyQualified = "🏄🏽‍♀️" ;

		public const string WomanSurfingMediumSkinToneMinimallyQualified = "🏄🏽‍♀" ;

		public const string WomanSurfingMediumDarkSkinToneFullyQualified = "🏄🏾‍♀️" ;

		public const string WomanSurfingMediumDarkSkinToneMinimallyQualified = "🏄🏾‍♀" ;

		public const string WomanSurfingDarkSkinToneFullyQualified = "🏄🏿‍♀️" ;

		public const string WomanSurfingDarkSkinToneMinimallyQualified = "🏄🏿‍♀" ;

		public const string PersonRowingBoat = "🚣" ;

		public const string PersonRowingBoatLightSkinTone = "🚣🏻" ;

		public const string PersonRowingBoatMediumLightSkinTone = "🚣🏼" ;

		public const string PersonRowingBoatMediumSkinTone = "🚣🏽" ;

		public const string PersonRowingBoatMediumDarkSkinTone = "🚣🏾" ;

		public const string PersonRowingBoatDarkSkinTone = "🚣🏿" ;

		public const string ManRowingBoatFullyQualified = "🚣‍♂️" ;

		public const string ManRowingBoatMinimallyQualified = "🚣‍♂" ;

		public const string ManRowingBoatLightSkinToneFullyQualified = "🚣🏻‍♂️" ;

		public const string ManRowingBoatLightSkinToneMinimallyQualified = "🚣🏻‍♂" ;

		public const string ManRowingBoatMediumLightSkinToneFullyQualified = "🚣🏼‍♂️" ;

		public const string ManRowingBoatMediumLightSkinToneMinimallyQualified = "🚣🏼‍♂" ;

		public const string ManRowingBoatMediumSkinToneFullyQualified = "🚣🏽‍♂️" ;

		public const string ManRowingBoatMediumSkinToneMinimallyQualified = "🚣🏽‍♂" ;

		public const string ManRowingBoatMediumDarkSkinToneFullyQualified = "🚣🏾‍♂️" ;

		public const string ManRowingBoatMediumDarkSkinToneMinimallyQualified = "🚣🏾‍♂" ;

		public const string ManRowingBoatDarkSkinToneFullyQualified = "🚣🏿‍♂️" ;

		public const string ManRowingBoatDarkSkinToneMinimallyQualified = "🚣🏿‍♂" ;

		public const string WomanRowingBoatFullyQualified = "🚣‍♀️" ;

		public const string WomanRowingBoatMinimallyQualified = "🚣‍♀" ;

		public const string WomanRowingBoatLightSkinToneFullyQualified = "🚣🏻‍♀️" ;

		public const string WomanRowingBoatLightSkinToneMinimallyQualified = "🚣🏻‍♀" ;

		public const string WomanRowingBoatMediumLightSkinToneFullyQualified = "🚣🏼‍♀️" ;

		public const string WomanRowingBoatMediumLightSkinToneMinimallyQualified = "🚣🏼‍♀" ;

		public const string WomanRowingBoatMediumSkinToneFullyQualified = "🚣🏽‍♀️" ;

		public const string WomanRowingBoatMediumSkinToneMinimallyQualified = "🚣🏽‍♀" ;

		public const string WomanRowingBoatMediumDarkSkinToneFullyQualified = "🚣🏾‍♀️" ;

		public const string WomanRowingBoatMediumDarkSkinToneMinimallyQualified = "🚣🏾‍♀" ;

		public const string WomanRowingBoatDarkSkinToneFullyQualified = "🚣🏿‍♀️" ;

		public const string WomanRowingBoatDarkSkinToneMinimallyQualified = "🚣🏿‍♀" ;

		public const string PersonSwimming = "🏊" ;

		public const string PersonSwimmingLightSkinTone = "🏊🏻" ;

		public const string PersonSwimmingMediumLightSkinTone = "🏊🏼" ;

		public const string PersonSwimmingMediumSkinTone = "🏊🏽" ;

		public const string PersonSwimmingMediumDarkSkinTone = "🏊🏾" ;

		public const string PersonSwimmingDarkSkinTone = "🏊🏿" ;

		public const string ManSwimmingFullyQualified = "🏊‍♂️" ;

		public const string ManSwimmingMinimallyQualified = "🏊‍♂" ;

		public const string ManSwimmingLightSkinToneFullyQualified = "🏊🏻‍♂️" ;

		public const string ManSwimmingLightSkinToneMinimallyQualified = "🏊🏻‍♂" ;

		public const string ManSwimmingMediumLightSkinToneFullyQualified = "🏊🏼‍♂️" ;

		public const string ManSwimmingMediumLightSkinToneMinimallyQualified = "🏊🏼‍♂" ;

		public const string ManSwimmingMediumSkinToneFullyQualified = "🏊🏽‍♂️" ;

		public const string ManSwimmingMediumSkinToneMinimallyQualified = "🏊🏽‍♂" ;

		public const string ManSwimmingMediumDarkSkinToneFullyQualified = "🏊🏾‍♂️" ;

		public const string ManSwimmingMediumDarkSkinToneMinimallyQualified = "🏊🏾‍♂" ;

		public const string ManSwimmingDarkSkinToneFullyQualified = "🏊🏿‍♂️" ;

		public const string ManSwimmingDarkSkinToneMinimallyQualified = "🏊🏿‍♂" ;

		public const string WomanSwimmingFullyQualified = "🏊‍♀️" ;

		public const string WomanSwimmingMinimallyQualified = "🏊‍♀" ;

		public const string WomanSwimmingLightSkinToneFullyQualified = "🏊🏻‍♀️" ;

		public const string WomanSwimmingLightSkinToneMinimallyQualified = "🏊🏻‍♀" ;

		public const string WomanSwimmingMediumLightSkinToneFullyQualified = "🏊🏼‍♀️" ;

		public const string WomanSwimmingMediumLightSkinToneMinimallyQualified = "🏊🏼‍♀" ;

		public const string WomanSwimmingMediumSkinToneFullyQualified = "🏊🏽‍♀️" ;

		public const string WomanSwimmingMediumSkinToneMinimallyQualified = "🏊🏽‍♀" ;

		public const string WomanSwimmingMediumDarkSkinToneFullyQualified = "🏊🏾‍♀️" ;

		public const string WomanSwimmingMediumDarkSkinToneMinimallyQualified = "🏊🏾‍♀" ;

		public const string WomanSwimmingDarkSkinToneFullyQualified = "🏊🏿‍♀️" ;

		public const string WomanSwimmingDarkSkinToneMinimallyQualified = "🏊🏿‍♀" ;

		public const string PersonBouncingBallFullyQualified = "⛹️" ;

		public const string PersonBouncingBallUnqualified = "⛹" ;

		public const string PersonBouncingBallLightSkinTone = "⛹🏻" ;

		public const string PersonBouncingBallMediumLightSkinTone = "⛹🏼" ;

		public const string PersonBouncingBallMediumSkinTone = "⛹🏽" ;

		public const string PersonBouncingBallMediumDarkSkinTone = "⛹🏾" ;

		public const string PersonBouncingBallDarkSkinTone = "⛹🏿" ;

		public const string ManBouncingBallFullyQualified = "⛹️‍♂️" ;

		public const string ManBouncingBallUnqualified = "⛹‍♂️" ;

		public const string ManBouncingBallMinimallyQualified = "⛹️‍♂" ;

		public const string ManBouncingBallUnqualified2 = "⛹‍♂" ;

		public const string ManBouncingBallLightSkinToneFullyQualified = "⛹🏻‍♂️" ;

		public const string ManBouncingBallLightSkinToneMinimallyQualified = "⛹🏻‍♂" ;

		public const string ManBouncingBallMediumLightSkinToneFullyQualified = "⛹🏼‍♂️" ;

		public const string ManBouncingBallMediumLightSkinToneMinimallyQualified = "⛹🏼‍♂" ;

		public const string ManBouncingBallMediumSkinToneFullyQualified = "⛹🏽‍♂️" ;

		public const string ManBouncingBallMediumSkinToneMinimallyQualified = "⛹🏽‍♂" ;

		public const string ManBouncingBallMediumDarkSkinToneFullyQualified = "⛹🏾‍♂️" ;

		public const string ManBouncingBallMediumDarkSkinToneMinimallyQualified = "⛹🏾‍♂" ;

		public const string ManBouncingBallDarkSkinToneFullyQualified = "⛹🏿‍♂️" ;

		public const string ManBouncingBallDarkSkinToneMinimallyQualified = "⛹🏿‍♂" ;

		public const string WomanBouncingBallFullyQualified = "⛹️‍♀️" ;

		public const string WomanBouncingBallUnqualified = "⛹‍♀️" ;

		public const string WomanBouncingBallMinimallyQualified = "⛹️‍♀" ;

		public const string WomanBouncingBallUnqualified2 = "⛹‍♀" ;

		public const string WomanBouncingBallLightSkinToneFullyQualified = "⛹🏻‍♀️" ;

		public const string WomanBouncingBallLightSkinToneMinimallyQualified = "⛹🏻‍♀" ;

		public const string WomanBouncingBallMediumLightSkinToneFullyQualified = "⛹🏼‍♀️" ;

		public const string WomanBouncingBallMediumLightSkinToneMinimallyQualified = "⛹🏼‍♀" ;

		public const string WomanBouncingBallMediumSkinToneFullyQualified = "⛹🏽‍♀️" ;

		public const string WomanBouncingBallMediumSkinToneMinimallyQualified = "⛹🏽‍♀" ;

		public const string WomanBouncingBallMediumDarkSkinToneFullyQualified = "⛹🏾‍♀️" ;

		public const string WomanBouncingBallMediumDarkSkinToneMinimallyQualified = "⛹🏾‍♀" ;

		public const string WomanBouncingBallDarkSkinToneFullyQualified = "⛹🏿‍♀️" ;

		public const string WomanBouncingBallDarkSkinToneMinimallyQualified = "⛹🏿‍♀" ;

		public const string PersonLiftingWeightsFullyQualified = "🏋️" ;

		public const string PersonLiftingWeightsUnqualified = "🏋" ;

		public const string PersonLiftingWeightsLightSkinTone = "🏋🏻" ;

		public const string PersonLiftingWeightsMediumLightSkinTone = "🏋🏼" ;

		public const string PersonLiftingWeightsMediumSkinTone = "🏋🏽" ;

		public const string PersonLiftingWeightsMediumDarkSkinTone = "🏋🏾" ;

		public const string PersonLiftingWeightsDarkSkinTone = "🏋🏿" ;

		public const string ManLiftingWeightsFullyQualified = "🏋️‍♂️" ;

		public const string ManLiftingWeightsUnqualified = "🏋‍♂️" ;

		public const string ManLiftingWeightsMinimallyQualified = "🏋️‍♂" ;

		public const string ManLiftingWeightsUnqualified2 = "🏋‍♂" ;

		public const string ManLiftingWeightsLightSkinToneFullyQualified = "🏋🏻‍♂️" ;

		public const string ManLiftingWeightsLightSkinToneMinimallyQualified = "🏋🏻‍♂" ;

		public const string ManLiftingWeightsMediumLightSkinToneFullyQualified = "🏋🏼‍♂️" ;

		public const string ManLiftingWeightsMediumLightSkinToneMinimallyQualified = "🏋🏼‍♂" ;

		public const string ManLiftingWeightsMediumSkinToneFullyQualified = "🏋🏽‍♂️" ;

		public const string ManLiftingWeightsMediumSkinToneMinimallyQualified = "🏋🏽‍♂" ;

		public const string ManLiftingWeightsMediumDarkSkinToneFullyQualified = "🏋🏾‍♂️" ;

		public const string ManLiftingWeightsMediumDarkSkinToneMinimallyQualified = "🏋🏾‍♂" ;

		public const string ManLiftingWeightsDarkSkinToneFullyQualified = "🏋🏿‍♂️" ;

		public const string ManLiftingWeightsDarkSkinToneMinimallyQualified = "🏋🏿‍♂" ;

		public const string WomanLiftingWeightsFullyQualified = "🏋️‍♀️" ;

		public const string WomanLiftingWeightsUnqualified = "🏋‍♀️" ;

		public const string WomanLiftingWeightsMinimallyQualified = "🏋️‍♀" ;

		public const string WomanLiftingWeightsUnqualified2 = "🏋‍♀" ;

		public const string WomanLiftingWeightsLightSkinToneFullyQualified = "🏋🏻‍♀️" ;

		public const string WomanLiftingWeightsLightSkinToneMinimallyQualified = "🏋🏻‍♀" ;

		public const string WomanLiftingWeightsMediumLightSkinToneFullyQualified = "🏋🏼‍♀️" ;

		public const string WomanLiftingWeightsMediumLightSkinToneMinimallyQualified = "🏋🏼‍♀" ;

		public const string WomanLiftingWeightsMediumSkinToneFullyQualified = "🏋🏽‍♀️" ;

		public const string WomanLiftingWeightsMediumSkinToneMinimallyQualified = "🏋🏽‍♀" ;

		public const string WomanLiftingWeightsMediumDarkSkinToneFullyQualified = "🏋🏾‍♀️" ;

		public const string WomanLiftingWeightsMediumDarkSkinToneMinimallyQualified = "🏋🏾‍♀" ;

		public const string WomanLiftingWeightsDarkSkinToneFullyQualified = "🏋🏿‍♀️" ;

		public const string WomanLiftingWeightsDarkSkinToneMinimallyQualified = "🏋🏿‍♀" ;

		public const string PersonBiking = "🚴" ;

		public const string PersonBikingLightSkinTone = "🚴🏻" ;

		public const string PersonBikingMediumLightSkinTone = "🚴🏼" ;

		public const string PersonBikingMediumSkinTone = "🚴🏽" ;

		public const string PersonBikingMediumDarkSkinTone = "🚴🏾" ;

		public const string PersonBikingDarkSkinTone = "🚴🏿" ;

		public const string ManBikingFullyQualified = "🚴‍♂️" ;

		public const string ManBikingMinimallyQualified = "🚴‍♂" ;

		public const string ManBikingLightSkinToneFullyQualified = "🚴🏻‍♂️" ;

		public const string ManBikingLightSkinToneMinimallyQualified = "🚴🏻‍♂" ;

		public const string ManBikingMediumLightSkinToneFullyQualified = "🚴🏼‍♂️" ;

		public const string ManBikingMediumLightSkinToneMinimallyQualified = "🚴🏼‍♂" ;

		public const string ManBikingMediumSkinToneFullyQualified = "🚴🏽‍♂️" ;

		public const string ManBikingMediumSkinToneMinimallyQualified = "🚴🏽‍♂" ;

		public const string ManBikingMediumDarkSkinToneFullyQualified = "🚴🏾‍♂️" ;

		public const string ManBikingMediumDarkSkinToneMinimallyQualified = "🚴🏾‍♂" ;

		public const string ManBikingDarkSkinToneFullyQualified = "🚴🏿‍♂️" ;

		public const string ManBikingDarkSkinToneMinimallyQualified = "🚴🏿‍♂" ;

		public const string WomanBikingFullyQualified = "🚴‍♀️" ;

		public const string WomanBikingMinimallyQualified = "🚴‍♀" ;

		public const string WomanBikingLightSkinToneFullyQualified = "🚴🏻‍♀️" ;

		public const string WomanBikingLightSkinToneMinimallyQualified = "🚴🏻‍♀" ;

		public const string WomanBikingMediumLightSkinToneFullyQualified = "🚴🏼‍♀️" ;

		public const string WomanBikingMediumLightSkinToneMinimallyQualified = "🚴🏼‍♀" ;

		public const string WomanBikingMediumSkinToneFullyQualified = "🚴🏽‍♀️" ;

		public const string WomanBikingMediumSkinToneMinimallyQualified = "🚴🏽‍♀" ;

		public const string WomanBikingMediumDarkSkinToneFullyQualified = "🚴🏾‍♀️" ;

		public const string WomanBikingMediumDarkSkinToneMinimallyQualified = "🚴🏾‍♀" ;

		public const string WomanBikingDarkSkinToneFullyQualified = "🚴🏿‍♀️" ;

		public const string WomanBikingDarkSkinToneMinimallyQualified = "🚴🏿‍♀" ;

		public const string PersonMountainBiking = "🚵" ;

		public const string PersonMountainBikingLightSkinTone = "🚵🏻" ;

		public const string PersonMountainBikingMediumLightSkinTone = "🚵🏼" ;

		public const string PersonMountainBikingMediumSkinTone = "🚵🏽" ;

		public const string PersonMountainBikingMediumDarkSkinTone = "🚵🏾" ;

		public const string PersonMountainBikingDarkSkinTone = "🚵🏿" ;

		public const string ManMountainBikingFullyQualified = "🚵‍♂️" ;

		public const string ManMountainBikingMinimallyQualified = "🚵‍♂" ;

		public const string ManMountainBikingLightSkinToneFullyQualified = "🚵🏻‍♂️" ;

		public const string ManMountainBikingLightSkinToneMinimallyQualified = "🚵🏻‍♂" ;

		public const string ManMountainBikingMediumLightSkinToneFullyQualified = "🚵🏼‍♂️" ;

		public const string ManMountainBikingMediumLightSkinToneMinimallyQualified = "🚵🏼‍♂" ;

		public const string ManMountainBikingMediumSkinToneFullyQualified = "🚵🏽‍♂️" ;

		public const string ManMountainBikingMediumSkinToneMinimallyQualified = "🚵🏽‍♂" ;

		public const string ManMountainBikingMediumDarkSkinToneFullyQualified = "🚵🏾‍♂️" ;

		public const string ManMountainBikingMediumDarkSkinToneMinimallyQualified = "🚵🏾‍♂" ;

		public const string ManMountainBikingDarkSkinToneFullyQualified = "🚵🏿‍♂️" ;

		public const string ManMountainBikingDarkSkinToneMinimallyQualified = "🚵🏿‍♂" ;

		public const string WomanMountainBikingFullyQualified = "🚵‍♀️" ;

		public const string WomanMountainBikingMinimallyQualified = "🚵‍♀" ;

		public const string WomanMountainBikingLightSkinToneFullyQualified = "🚵🏻‍♀️" ;

		public const string WomanMountainBikingLightSkinToneMinimallyQualified = "🚵🏻‍♀" ;

		public const string WomanMountainBikingMediumLightSkinToneFullyQualified = "🚵🏼‍♀️" ;

		public const string WomanMountainBikingMediumLightSkinToneMinimallyQualified = "🚵🏼‍♀" ;

		public const string WomanMountainBikingMediumSkinToneFullyQualified = "🚵🏽‍♀️" ;

		public const string WomanMountainBikingMediumSkinToneMinimallyQualified = "🚵🏽‍♀" ;

		public const string WomanMountainBikingMediumDarkSkinToneFullyQualified = "🚵🏾‍♀️" ;

		public const string WomanMountainBikingMediumDarkSkinToneMinimallyQualified = "🚵🏾‍♀" ;

		public const string WomanMountainBikingDarkSkinToneFullyQualified = "🚵🏿‍♀️" ;

		public const string WomanMountainBikingDarkSkinToneMinimallyQualified = "🚵🏿‍♀" ;

		public const string PersonCartwheeling = "🤸" ;

		public const string PersonCartwheelingLightSkinTone = "🤸🏻" ;

		public const string PersonCartwheelingMediumLightSkinTone = "🤸🏼" ;

		public const string PersonCartwheelingMediumSkinTone = "🤸🏽" ;

		public const string PersonCartwheelingMediumDarkSkinTone = "🤸🏾" ;

		public const string PersonCartwheelingDarkSkinTone = "🤸🏿" ;

		public const string ManCartwheelingFullyQualified = "🤸‍♂️" ;

		public const string ManCartwheelingMinimallyQualified = "🤸‍♂" ;

		public const string ManCartwheelingLightSkinToneFullyQualified = "🤸🏻‍♂️" ;

		public const string ManCartwheelingLightSkinToneMinimallyQualified = "🤸🏻‍♂" ;

		public const string ManCartwheelingMediumLightSkinToneFullyQualified = "🤸🏼‍♂️" ;

		public const string ManCartwheelingMediumLightSkinToneMinimallyQualified = "🤸🏼‍♂" ;

		public const string ManCartwheelingMediumSkinToneFullyQualified = "🤸🏽‍♂️" ;

		public const string ManCartwheelingMediumSkinToneMinimallyQualified = "🤸🏽‍♂" ;

		public const string ManCartwheelingMediumDarkSkinToneFullyQualified = "🤸🏾‍♂️" ;

		public const string ManCartwheelingMediumDarkSkinToneMinimallyQualified = "🤸🏾‍♂" ;

		public const string ManCartwheelingDarkSkinToneFullyQualified = "🤸🏿‍♂️" ;

		public const string ManCartwheelingDarkSkinToneMinimallyQualified = "🤸🏿‍♂" ;

		public const string WomanCartwheelingFullyQualified = "🤸‍♀️" ;

		public const string WomanCartwheelingMinimallyQualified = "🤸‍♀" ;

		public const string WomanCartwheelingLightSkinToneFullyQualified = "🤸🏻‍♀️" ;

		public const string WomanCartwheelingLightSkinToneMinimallyQualified = "🤸🏻‍♀" ;

		public const string WomanCartwheelingMediumLightSkinToneFullyQualified = "🤸🏼‍♀️" ;

		public const string WomanCartwheelingMediumLightSkinToneMinimallyQualified = "🤸🏼‍♀" ;

		public const string WomanCartwheelingMediumSkinToneFullyQualified = "🤸🏽‍♀️" ;

		public const string WomanCartwheelingMediumSkinToneMinimallyQualified = "🤸🏽‍♀" ;

		public const string WomanCartwheelingMediumDarkSkinToneFullyQualified = "🤸🏾‍♀️" ;

		public const string WomanCartwheelingMediumDarkSkinToneMinimallyQualified = "🤸🏾‍♀" ;

		public const string WomanCartwheelingDarkSkinToneFullyQualified = "🤸🏿‍♀️" ;

		public const string WomanCartwheelingDarkSkinToneMinimallyQualified = "🤸🏿‍♀" ;

		public const string PeopleWrestling = "🤼" ;

		public const string MenWrestlingFullyQualified = "🤼‍♂️" ;

		public const string MenWrestlingMinimallyQualified = "🤼‍♂" ;

		public const string WomenWrestlingFullyQualified = "🤼‍♀️" ;

		public const string WomenWrestlingMinimallyQualified = "🤼‍♀" ;

		public const string PersonPlayingWaterPolo = "🤽" ;

		public const string PersonPlayingWaterPoloLightSkinTone = "🤽🏻" ;

		public const string PersonPlayingWaterPoloMediumLightSkinTone = "🤽🏼" ;

		public const string PersonPlayingWaterPoloMediumSkinTone = "🤽🏽" ;

		public const string PersonPlayingWaterPoloMediumDarkSkinTone = "🤽🏾" ;

		public const string PersonPlayingWaterPoloDarkSkinTone = "🤽🏿" ;

		public const string ManPlayingWaterPoloFullyQualified = "🤽‍♂️" ;

		public const string ManPlayingWaterPoloMinimallyQualified = "🤽‍♂" ;

		public const string ManPlayingWaterPoloLightSkinToneFullyQualified = "🤽🏻‍♂️" ;

		public const string ManPlayingWaterPoloLightSkinToneMinimallyQualified = "🤽🏻‍♂" ;

		public const string ManPlayingWaterPoloMediumLightSkinToneFullyQualified = "🤽🏼‍♂️" ;

		public const string ManPlayingWaterPoloMediumLightSkinToneMinimallyQualified = "🤽🏼‍♂" ;

		public const string ManPlayingWaterPoloMediumSkinToneFullyQualified = "🤽🏽‍♂️" ;

		public const string ManPlayingWaterPoloMediumSkinToneMinimallyQualified = "🤽🏽‍♂" ;

		public const string ManPlayingWaterPoloMediumDarkSkinToneFullyQualified = "🤽🏾‍♂️" ;

		public const string ManPlayingWaterPoloMediumDarkSkinToneMinimallyQualified = "🤽🏾‍♂" ;

		public const string ManPlayingWaterPoloDarkSkinToneFullyQualified = "🤽🏿‍♂️" ;

		public const string ManPlayingWaterPoloDarkSkinToneMinimallyQualified = "🤽🏿‍♂" ;

		public const string WomanPlayingWaterPoloFullyQualified = "🤽‍♀️" ;

		public const string WomanPlayingWaterPoloMinimallyQualified = "🤽‍♀" ;

		public const string WomanPlayingWaterPoloLightSkinToneFullyQualified = "🤽🏻‍♀️" ;

		public const string WomanPlayingWaterPoloLightSkinToneMinimallyQualified = "🤽🏻‍♀" ;

		public const string WomanPlayingWaterPoloMediumLightSkinToneFullyQualified = "🤽🏼‍♀️" ;

		public const string WomanPlayingWaterPoloMediumLightSkinToneMinimallyQualified = "🤽🏼‍♀" ;

		public const string WomanPlayingWaterPoloMediumSkinToneFullyQualified = "🤽🏽‍♀️" ;

		public const string WomanPlayingWaterPoloMediumSkinToneMinimallyQualified = "🤽🏽‍♀" ;

		public const string WomanPlayingWaterPoloMediumDarkSkinToneFullyQualified = "🤽🏾‍♀️" ;

		public const string WomanPlayingWaterPoloMediumDarkSkinToneMinimallyQualified = "🤽🏾‍♀" ;

		public const string WomanPlayingWaterPoloDarkSkinToneFullyQualified = "🤽🏿‍♀️" ;

		public const string WomanPlayingWaterPoloDarkSkinToneMinimallyQualified = "🤽🏿‍♀" ;

		public const string PersonPlayingHandball = "🤾" ;

		public const string PersonPlayingHandballLightSkinTone = "🤾🏻" ;

		public const string PersonPlayingHandballMediumLightSkinTone = "🤾🏼" ;

		public const string PersonPlayingHandballMediumSkinTone = "🤾🏽" ;

		public const string PersonPlayingHandballMediumDarkSkinTone = "🤾🏾" ;

		public const string PersonPlayingHandballDarkSkinTone = "🤾🏿" ;

		public const string ManPlayingHandballFullyQualified = "🤾‍♂️" ;

		public const string ManPlayingHandballMinimallyQualified = "🤾‍♂" ;

		public const string ManPlayingHandballLightSkinToneFullyQualified = "🤾🏻‍♂️" ;

		public const string ManPlayingHandballLightSkinToneMinimallyQualified = "🤾🏻‍♂" ;

		public const string ManPlayingHandballMediumLightSkinToneFullyQualified = "🤾🏼‍♂️" ;

		public const string ManPlayingHandballMediumLightSkinToneMinimallyQualified = "🤾🏼‍♂" ;

		public const string ManPlayingHandballMediumSkinToneFullyQualified = "🤾🏽‍♂️" ;

		public const string ManPlayingHandballMediumSkinToneMinimallyQualified = "🤾🏽‍♂" ;

		public const string ManPlayingHandballMediumDarkSkinToneFullyQualified = "🤾🏾‍♂️" ;

		public const string ManPlayingHandballMediumDarkSkinToneMinimallyQualified = "🤾🏾‍♂" ;

		public const string ManPlayingHandballDarkSkinToneFullyQualified = "🤾🏿‍♂️" ;

		public const string ManPlayingHandballDarkSkinToneMinimallyQualified = "🤾🏿‍♂" ;

		public const string WomanPlayingHandballFullyQualified = "🤾‍♀️" ;

		public const string WomanPlayingHandballMinimallyQualified = "🤾‍♀" ;

		public const string WomanPlayingHandballLightSkinToneFullyQualified = "🤾🏻‍♀️" ;

		public const string WomanPlayingHandballLightSkinToneMinimallyQualified = "🤾🏻‍♀" ;

		public const string WomanPlayingHandballMediumLightSkinToneFullyQualified = "🤾🏼‍♀️" ;

		public const string WomanPlayingHandballMediumLightSkinToneMinimallyQualified = "🤾🏼‍♀" ;

		public const string WomanPlayingHandballMediumSkinToneFullyQualified = "🤾🏽‍♀️" ;

		public const string WomanPlayingHandballMediumSkinToneMinimallyQualified = "🤾🏽‍♀" ;

		public const string WomanPlayingHandballMediumDarkSkinToneFullyQualified = "🤾🏾‍♀️" ;

		public const string WomanPlayingHandballMediumDarkSkinToneMinimallyQualified = "🤾🏾‍♀" ;

		public const string WomanPlayingHandballDarkSkinToneFullyQualified = "🤾🏿‍♀️" ;

		public const string WomanPlayingHandballDarkSkinToneMinimallyQualified = "🤾🏿‍♀" ;

		public const string PersonJuggling = "🤹" ;

		public const string PersonJugglingLightSkinTone = "🤹🏻" ;

		public const string PersonJugglingMediumLightSkinTone = "🤹🏼" ;

		public const string PersonJugglingMediumSkinTone = "🤹🏽" ;

		public const string PersonJugglingMediumDarkSkinTone = "🤹🏾" ;

		public const string PersonJugglingDarkSkinTone = "🤹🏿" ;

		public const string ManJugglingFullyQualified = "🤹‍♂️" ;

		public const string ManJugglingMinimallyQualified = "🤹‍♂" ;

		public const string ManJugglingLightSkinToneFullyQualified = "🤹🏻‍♂️" ;

		public const string ManJugglingLightSkinToneMinimallyQualified = "🤹🏻‍♂" ;

		public const string ManJugglingMediumLightSkinToneFullyQualified = "🤹🏼‍♂️" ;

		public const string ManJugglingMediumLightSkinToneMinimallyQualified = "🤹🏼‍♂" ;

		public const string ManJugglingMediumSkinToneFullyQualified = "🤹🏽‍♂️" ;

		public const string ManJugglingMediumSkinToneMinimallyQualified = "🤹🏽‍♂" ;

		public const string ManJugglingMediumDarkSkinToneFullyQualified = "🤹🏾‍♂️" ;

		public const string ManJugglingMediumDarkSkinToneMinimallyQualified = "🤹🏾‍♂" ;

		public const string ManJugglingDarkSkinToneFullyQualified = "🤹🏿‍♂️" ;

		public const string ManJugglingDarkSkinToneMinimallyQualified = "🤹🏿‍♂" ;

		public const string WomanJugglingFullyQualified = "🤹‍♀️" ;

		public const string WomanJugglingMinimallyQualified = "🤹‍♀" ;

		public const string WomanJugglingLightSkinToneFullyQualified = "🤹🏻‍♀️" ;

		public const string WomanJugglingLightSkinToneMinimallyQualified = "🤹🏻‍♀" ;

		public const string WomanJugglingMediumLightSkinToneFullyQualified = "🤹🏼‍♀️" ;

		public const string WomanJugglingMediumLightSkinToneMinimallyQualified = "🤹🏼‍♀" ;

		public const string WomanJugglingMediumSkinToneFullyQualified = "🤹🏽‍♀️" ;

		public const string WomanJugglingMediumSkinToneMinimallyQualified = "🤹🏽‍♀" ;

		public const string WomanJugglingMediumDarkSkinToneFullyQualified = "🤹🏾‍♀️" ;

		public const string WomanJugglingMediumDarkSkinToneMinimallyQualified = "🤹🏾‍♀" ;

		public const string WomanJugglingDarkSkinToneFullyQualified = "🤹🏿‍♀️" ;

		public const string WomanJugglingDarkSkinToneMinimallyQualified = "🤹🏿‍♀" ;

		public const string PersonInLotusPosition = "🧘" ;

		public const string PersonInLotusPositionLightSkinTone = "🧘🏻" ;

		public const string PersonInLotusPositionMediumLightSkinTone = "🧘🏼" ;

		public const string PersonInLotusPositionMediumSkinTone = "🧘🏽" ;

		public const string PersonInLotusPositionMediumDarkSkinTone = "🧘🏾" ;

		public const string PersonInLotusPositionDarkSkinTone = "🧘🏿" ;

		public const string ManInLotusPositionFullyQualified = "🧘‍♂️" ;

		public const string ManInLotusPositionMinimallyQualified = "🧘‍♂" ;

		public const string ManInLotusPositionLightSkinToneFullyQualified = "🧘🏻‍♂️" ;

		public const string ManInLotusPositionLightSkinToneMinimallyQualified = "🧘🏻‍♂" ;

		public const string ManInLotusPositionMediumLightSkinToneFullyQualified = "🧘🏼‍♂️" ;

		public const string ManInLotusPositionMediumLightSkinToneMinimallyQualified = "🧘🏼‍♂" ;

		public const string ManInLotusPositionMediumSkinToneFullyQualified = "🧘🏽‍♂️" ;

		public const string ManInLotusPositionMediumSkinToneMinimallyQualified = "🧘🏽‍♂" ;

		public const string ManInLotusPositionMediumDarkSkinToneFullyQualified = "🧘🏾‍♂️" ;

		public const string ManInLotusPositionMediumDarkSkinToneMinimallyQualified = "🧘🏾‍♂" ;

		public const string ManInLotusPositionDarkSkinToneFullyQualified = "🧘🏿‍♂️" ;

		public const string ManInLotusPositionDarkSkinToneMinimallyQualified = "🧘🏿‍♂" ;

		public const string WomanInLotusPositionFullyQualified = "🧘‍♀️" ;

		public const string WomanInLotusPositionMinimallyQualified = "🧘‍♀" ;

		public const string WomanInLotusPositionLightSkinToneFullyQualified = "🧘🏻‍♀️" ;

		public const string WomanInLotusPositionLightSkinToneMinimallyQualified = "🧘🏻‍♀" ;

		public const string WomanInLotusPositionMediumLightSkinToneFullyQualified = "🧘🏼‍♀️" ;

		public const string WomanInLotusPositionMediumLightSkinToneMinimallyQualified = "🧘🏼‍♀" ;

		public const string WomanInLotusPositionMediumSkinToneFullyQualified = "🧘🏽‍♀️" ;

		public const string WomanInLotusPositionMediumSkinToneMinimallyQualified = "🧘🏽‍♀" ;

		public const string WomanInLotusPositionMediumDarkSkinToneFullyQualified = "🧘🏾‍♀️" ;

		public const string WomanInLotusPositionMediumDarkSkinToneMinimallyQualified = "🧘🏾‍♀" ;

		public const string WomanInLotusPositionDarkSkinToneFullyQualified = "🧘🏿‍♀️" ;

		public const string WomanInLotusPositionDarkSkinToneMinimallyQualified = "🧘🏿‍♀" ;

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

		public const string PeopleHoldingHands = "🧑‍🤝‍🧑" ;

		public const string PeopleHoldingHandsLightSkinTone = "🧑🏻‍🤝‍🧑🏻" ;

		public const string PeopleHoldingHandsLightSkinToneMediumLightSkinTone = "🧑🏻‍🤝‍🧑🏼" ;

		public const string PeopleHoldingHandsLightSkinToneMediumSkinTone = "🧑🏻‍🤝‍🧑🏽" ;

		public const string PeopleHoldingHandsLightSkinToneMediumDarkSkinTone = "🧑🏻‍🤝‍🧑🏾" ;

		public const string PeopleHoldingHandsLightSkinToneDarkSkinTone = "🧑🏻‍🤝‍🧑🏿" ;

		public const string PeopleHoldingHandsMediumLightSkinToneLightSkinTone = "🧑🏼‍🤝‍🧑🏻" ;

		public const string PeopleHoldingHandsMediumLightSkinTone = "🧑🏼‍🤝‍🧑🏼" ;

		public const string PeopleHoldingHandsMediumLightSkinToneMediumSkinTone = "🧑🏼‍🤝‍🧑🏽" ;

		public const string PeopleHoldingHandsMediumLightSkinToneMediumDarkSkinTone = "🧑🏼‍🤝‍🧑🏾" ;

		public const string PeopleHoldingHandsMediumLightSkinToneDarkSkinTone = "🧑🏼‍🤝‍🧑🏿" ;

		public const string PeopleHoldingHandsMediumSkinToneLightSkinTone = "🧑🏽‍🤝‍🧑🏻" ;

		public const string PeopleHoldingHandsMediumSkinToneMediumLightSkinTone = "🧑🏽‍🤝‍🧑🏼" ;

		public const string PeopleHoldingHandsMediumSkinTone = "🧑🏽‍🤝‍🧑🏽" ;

		public const string PeopleHoldingHandsMediumSkinToneMediumDarkSkinTone = "🧑🏽‍🤝‍🧑🏾" ;

		public const string PeopleHoldingHandsMediumSkinToneDarkSkinTone = "🧑🏽‍🤝‍🧑🏿" ;

		public const string PeopleHoldingHandsMediumDarkSkinToneLightSkinTone = "🧑🏾‍🤝‍🧑🏻" ;

		public const string PeopleHoldingHandsMediumDarkSkinToneMediumLightSkinTone = "🧑🏾‍🤝‍🧑🏼" ;

		public const string PeopleHoldingHandsMediumDarkSkinToneMediumSkinTone = "🧑🏾‍🤝‍🧑🏽" ;

		public const string PeopleHoldingHandsMediumDarkSkinTone = "🧑🏾‍🤝‍🧑🏾" ;

		public const string PeopleHoldingHandsMediumDarkSkinToneDarkSkinTone = "🧑🏾‍🤝‍🧑🏿" ;

		public const string PeopleHoldingHandsDarkSkinToneLightSkinTone = "🧑🏿‍🤝‍🧑🏻" ;

		public const string PeopleHoldingHandsDarkSkinToneMediumLightSkinTone = "🧑🏿‍🤝‍🧑🏼" ;

		public const string PeopleHoldingHandsDarkSkinToneMediumSkinTone = "🧑🏿‍🤝‍🧑🏽" ;

		public const string PeopleHoldingHandsDarkSkinToneMediumDarkSkinTone = "🧑🏿‍🤝‍🧑🏾" ;

		public const string PeopleHoldingHandsDarkSkinTone = "🧑🏿‍🤝‍🧑🏿" ;

		public const string WomenHoldingHands = "👭" ;

		public const string WomenHoldingHandsLightSkinTone = "👭🏻" ;

		public const string WomenHoldingHandsLightSkinToneMediumLightSkinTone = "👩🏻‍🤝‍👩🏼" ;

		public const string WomenHoldingHandsLightSkinToneMediumSkinTone = "👩🏻‍🤝‍👩🏽" ;

		public const string WomenHoldingHandsLightSkinToneMediumDarkSkinTone = "👩🏻‍🤝‍👩🏾" ;

		public const string WomenHoldingHandsLightSkinToneDarkSkinTone = "👩🏻‍🤝‍👩🏿" ;

		public const string WomenHoldingHandsMediumLightSkinToneLightSkinTone = "👩🏼‍🤝‍👩🏻" ;

		public const string WomenHoldingHandsMediumLightSkinTone = "👭🏼" ;

		public const string WomenHoldingHandsMediumLightSkinToneMediumSkinTone = "👩🏼‍🤝‍👩🏽" ;

		public const string WomenHoldingHandsMediumLightSkinToneMediumDarkSkinTone = "👩🏼‍🤝‍👩🏾" ;

		public const string WomenHoldingHandsMediumLightSkinToneDarkSkinTone = "👩🏼‍🤝‍👩🏿" ;

		public const string WomenHoldingHandsMediumSkinToneLightSkinTone = "👩🏽‍🤝‍👩🏻" ;

		public const string WomenHoldingHandsMediumSkinToneMediumLightSkinTone = "👩🏽‍🤝‍👩🏼" ;

		public const string WomenHoldingHandsMediumSkinTone = "👭🏽" ;

		public const string WomenHoldingHandsMediumSkinToneMediumDarkSkinTone = "👩🏽‍🤝‍👩🏾" ;

		public const string WomenHoldingHandsMediumSkinToneDarkSkinTone = "👩🏽‍🤝‍👩🏿" ;

		public const string WomenHoldingHandsMediumDarkSkinToneLightSkinTone = "👩🏾‍🤝‍👩🏻" ;

		public const string WomenHoldingHandsMediumDarkSkinToneMediumLightSkinTone = "👩🏾‍🤝‍👩🏼" ;

		public const string WomenHoldingHandsMediumDarkSkinToneMediumSkinTone = "👩🏾‍🤝‍👩🏽" ;

		public const string WomenHoldingHandsMediumDarkSkinTone = "👭🏾" ;

		public const string WomenHoldingHandsMediumDarkSkinToneDarkSkinTone = "👩🏾‍🤝‍👩🏿" ;

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

		public const string MenHoldingHandsLightSkinToneMediumLightSkinTone = "👨🏻‍🤝‍👨🏼" ;

		public const string MenHoldingHandsLightSkinToneMediumSkinTone = "👨🏻‍🤝‍👨🏽" ;

		public const string MenHoldingHandsLightSkinToneMediumDarkSkinTone = "👨🏻‍🤝‍👨🏾" ;

		public const string MenHoldingHandsLightSkinToneDarkSkinTone = "👨🏻‍🤝‍👨🏿" ;

		public const string MenHoldingHandsMediumLightSkinToneLightSkinTone = "👨🏼‍🤝‍👨🏻" ;

		public const string MenHoldingHandsMediumLightSkinTone = "👬🏼" ;

		public const string MenHoldingHandsMediumLightSkinToneMediumSkinTone = "👨🏼‍🤝‍👨🏽" ;

		public const string MenHoldingHandsMediumLightSkinToneMediumDarkSkinTone = "👨🏼‍🤝‍👨🏾" ;

		public const string MenHoldingHandsMediumLightSkinToneDarkSkinTone = "👨🏼‍🤝‍👨🏿" ;

		public const string MenHoldingHandsMediumSkinToneLightSkinTone = "👨🏽‍🤝‍👨🏻" ;

		public const string MenHoldingHandsMediumSkinToneMediumLightSkinTone = "👨🏽‍🤝‍👨🏼" ;

		public const string MenHoldingHandsMediumSkinTone = "👬🏽" ;

		public const string MenHoldingHandsMediumSkinToneMediumDarkSkinTone = "👨🏽‍🤝‍👨🏾" ;

		public const string MenHoldingHandsMediumSkinToneDarkSkinTone = "👨🏽‍🤝‍👨🏿" ;

		public const string MenHoldingHandsMediumDarkSkinToneLightSkinTone = "👨🏾‍🤝‍👨🏻" ;

		public const string MenHoldingHandsMediumDarkSkinToneMediumLightSkinTone = "👨🏾‍🤝‍👨🏼" ;

		public const string MenHoldingHandsMediumDarkSkinToneMediumSkinTone = "👨🏾‍🤝‍👨🏽" ;

		public const string MenHoldingHandsMediumDarkSkinTone = "👬🏾" ;

		public const string MenHoldingHandsMediumDarkSkinToneDarkSkinTone = "👨🏾‍🤝‍👨🏿" ;

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

		public const string KissPersonPersonLightSkinToneMediumLightSkinToneFullyQualified = "🧑🏻‍❤️‍💋‍🧑🏼" ;

		public const string KissPersonPersonLightSkinToneMediumLightSkinToneMinimallyQualified = "🧑🏻‍❤‍💋‍🧑🏼" ;

		public const string KissPersonPersonLightSkinToneMediumSkinToneFullyQualified = "🧑🏻‍❤️‍💋‍🧑🏽" ;

		public const string KissPersonPersonLightSkinToneMediumSkinToneMinimallyQualified = "🧑🏻‍❤‍💋‍🧑🏽" ;

		public const string KissPersonPersonLightSkinToneMediumDarkSkinToneFullyQualified = "🧑🏻‍❤️‍💋‍🧑🏾" ;

		public const string KissPersonPersonLightSkinToneMediumDarkSkinToneMinimallyQualified = "🧑🏻‍❤‍💋‍🧑🏾" ;

		public const string KissPersonPersonLightSkinToneDarkSkinToneFullyQualified = "🧑🏻‍❤️‍💋‍🧑🏿" ;

		public const string KissPersonPersonLightSkinToneDarkSkinToneMinimallyQualified = "🧑🏻‍❤‍💋‍🧑🏿" ;

		public const string KissPersonPersonMediumLightSkinToneLightSkinToneFullyQualified = "🧑🏼‍❤️‍💋‍🧑🏻" ;

		public const string KissPersonPersonMediumLightSkinToneLightSkinToneMinimallyQualified = "🧑🏼‍❤‍💋‍🧑🏻" ;

		public const string KissPersonPersonMediumLightSkinToneMediumSkinToneFullyQualified = "🧑🏼‍❤️‍💋‍🧑🏽" ;

		public const string KissPersonPersonMediumLightSkinToneMediumSkinToneMinimallyQualified = "🧑🏼‍❤‍💋‍🧑🏽" ;

		public const string KissPersonPersonMediumLightSkinToneMediumDarkSkinToneFullyQualified = "🧑🏼‍❤️‍💋‍🧑🏾" ;

		public const string KissPersonPersonMediumLightSkinToneMediumDarkSkinToneMinimallyQualified = "🧑🏼‍❤‍💋‍🧑🏾" ;

		public const string KissPersonPersonMediumLightSkinToneDarkSkinToneFullyQualified = "🧑🏼‍❤️‍💋‍🧑🏿" ;

		public const string KissPersonPersonMediumLightSkinToneDarkSkinToneMinimallyQualified = "🧑🏼‍❤‍💋‍🧑🏿" ;

		public const string KissPersonPersonMediumSkinToneLightSkinToneFullyQualified = "🧑🏽‍❤️‍💋‍🧑🏻" ;

		public const string KissPersonPersonMediumSkinToneLightSkinToneMinimallyQualified = "🧑🏽‍❤‍💋‍🧑🏻" ;

		public const string KissPersonPersonMediumSkinToneMediumLightSkinToneFullyQualified = "🧑🏽‍❤️‍💋‍🧑🏼" ;

		public const string KissPersonPersonMediumSkinToneMediumLightSkinToneMinimallyQualified = "🧑🏽‍❤‍💋‍🧑🏼" ;

		public const string KissPersonPersonMediumSkinToneMediumDarkSkinToneFullyQualified = "🧑🏽‍❤️‍💋‍🧑🏾" ;

		public const string KissPersonPersonMediumSkinToneMediumDarkSkinToneMinimallyQualified = "🧑🏽‍❤‍💋‍🧑🏾" ;

		public const string KissPersonPersonMediumSkinToneDarkSkinToneFullyQualified = "🧑🏽‍❤️‍💋‍🧑🏿" ;

		public const string KissPersonPersonMediumSkinToneDarkSkinToneMinimallyQualified = "🧑🏽‍❤‍💋‍🧑🏿" ;

		public const string KissPersonPersonMediumDarkSkinToneLightSkinToneFullyQualified = "🧑🏾‍❤️‍💋‍🧑🏻" ;

		public const string KissPersonPersonMediumDarkSkinToneLightSkinToneMinimallyQualified = "🧑🏾‍❤‍💋‍🧑🏻" ;

		public const string KissPersonPersonMediumDarkSkinToneMediumLightSkinToneFullyQualified = "🧑🏾‍❤️‍💋‍🧑🏼" ;

		public const string KissPersonPersonMediumDarkSkinToneMediumLightSkinToneMinimallyQualified = "🧑🏾‍❤‍💋‍🧑🏼" ;

		public const string KissPersonPersonMediumDarkSkinToneMediumSkinToneFullyQualified = "🧑🏾‍❤️‍💋‍🧑🏽" ;

		public const string KissPersonPersonMediumDarkSkinToneMediumSkinToneMinimallyQualified = "🧑🏾‍❤‍💋‍🧑🏽" ;

		public const string KissPersonPersonMediumDarkSkinToneDarkSkinToneFullyQualified = "🧑🏾‍❤️‍💋‍🧑🏿" ;

		public const string KissPersonPersonMediumDarkSkinToneDarkSkinToneMinimallyQualified = "🧑🏾‍❤‍💋‍🧑🏿" ;

		public const string KissPersonPersonDarkSkinToneLightSkinToneFullyQualified = "🧑🏿‍❤️‍💋‍🧑🏻" ;

		public const string KissPersonPersonDarkSkinToneLightSkinToneMinimallyQualified = "🧑🏿‍❤‍💋‍🧑🏻" ;

		public const string KissPersonPersonDarkSkinToneMediumLightSkinToneFullyQualified = "🧑🏿‍❤️‍💋‍🧑🏼" ;

		public const string KissPersonPersonDarkSkinToneMediumLightSkinToneMinimallyQualified = "🧑🏿‍❤‍💋‍🧑🏼" ;

		public const string KissPersonPersonDarkSkinToneMediumSkinToneFullyQualified = "🧑🏿‍❤️‍💋‍🧑🏽" ;

		public const string KissPersonPersonDarkSkinToneMediumSkinToneMinimallyQualified = "🧑🏿‍❤‍💋‍🧑🏽" ;

		public const string KissPersonPersonDarkSkinToneMediumDarkSkinToneFullyQualified = "🧑🏿‍❤️‍💋‍🧑🏾" ;

		public const string KissPersonPersonDarkSkinToneMediumDarkSkinToneMinimallyQualified = "🧑🏿‍❤‍💋‍🧑🏾" ;

		public const string KissWomanManFullyQualified = "👩‍❤️‍💋‍👨" ;

		public const string KissWomanManMinimallyQualified = "👩‍❤‍💋‍👨" ;

		public const string KissWomanManLightSkinToneFullyQualified = "👩🏻‍❤️‍💋‍👨🏻" ;

		public const string KissWomanManLightSkinToneMinimallyQualified = "👩🏻‍❤‍💋‍👨🏻" ;

		public const string KissWomanManLightSkinToneMediumLightSkinToneFullyQualified = "👩🏻‍❤️‍💋‍👨🏼" ;

		public const string KissWomanManLightSkinToneMediumLightSkinToneMinimallyQualified = "👩🏻‍❤‍💋‍👨🏼" ;

		public const string KissWomanManLightSkinToneMediumSkinToneFullyQualified = "👩🏻‍❤️‍💋‍👨🏽" ;

		public const string KissWomanManLightSkinToneMediumSkinToneMinimallyQualified = "👩🏻‍❤‍💋‍👨🏽" ;

		public const string KissWomanManLightSkinToneMediumDarkSkinToneFullyQualified = "👩🏻‍❤️‍💋‍👨🏾" ;

		public const string KissWomanManLightSkinToneMediumDarkSkinToneMinimallyQualified = "👩🏻‍❤‍💋‍👨🏾" ;

		public const string KissWomanManLightSkinToneDarkSkinToneFullyQualified = "👩🏻‍❤️‍💋‍👨🏿" ;

		public const string KissWomanManLightSkinToneDarkSkinToneMinimallyQualified = "👩🏻‍❤‍💋‍👨🏿" ;

		public const string KissWomanManMediumLightSkinToneLightSkinToneFullyQualified = "👩🏼‍❤️‍💋‍👨🏻" ;

		public const string KissWomanManMediumLightSkinToneLightSkinToneMinimallyQualified = "👩🏼‍❤‍💋‍👨🏻" ;

		public const string KissWomanManMediumLightSkinToneFullyQualified = "👩🏼‍❤️‍💋‍👨🏼" ;

		public const string KissWomanManMediumLightSkinToneMinimallyQualified = "👩🏼‍❤‍💋‍👨🏼" ;

		public const string KissWomanManMediumLightSkinToneMediumSkinToneFullyQualified = "👩🏼‍❤️‍💋‍👨🏽" ;

		public const string KissWomanManMediumLightSkinToneMediumSkinToneMinimallyQualified = "👩🏼‍❤‍💋‍👨🏽" ;

		public const string KissWomanManMediumLightSkinToneMediumDarkSkinToneFullyQualified = "👩🏼‍❤️‍💋‍👨🏾" ;

		public const string KissWomanManMediumLightSkinToneMediumDarkSkinToneMinimallyQualified = "👩🏼‍❤‍💋‍👨🏾" ;

		public const string KissWomanManMediumLightSkinToneDarkSkinToneFullyQualified = "👩🏼‍❤️‍💋‍👨🏿" ;

		public const string KissWomanManMediumLightSkinToneDarkSkinToneMinimallyQualified = "👩🏼‍❤‍💋‍👨🏿" ;

		public const string KissWomanManMediumSkinToneLightSkinToneFullyQualified = "👩🏽‍❤️‍💋‍👨🏻" ;

		public const string KissWomanManMediumSkinToneLightSkinToneMinimallyQualified = "👩🏽‍❤‍💋‍👨🏻" ;

		public const string KissWomanManMediumSkinToneMediumLightSkinToneFullyQualified = "👩🏽‍❤️‍💋‍👨🏼" ;

		public const string KissWomanManMediumSkinToneMediumLightSkinToneMinimallyQualified = "👩🏽‍❤‍💋‍👨🏼" ;

		public const string KissWomanManMediumSkinToneFullyQualified = "👩🏽‍❤️‍💋‍👨🏽" ;

		public const string KissWomanManMediumSkinToneMinimallyQualified = "👩🏽‍❤‍💋‍👨🏽" ;

		public const string KissWomanManMediumSkinToneMediumDarkSkinToneFullyQualified = "👩🏽‍❤️‍💋‍👨🏾" ;

		public const string KissWomanManMediumSkinToneMediumDarkSkinToneMinimallyQualified = "👩🏽‍❤‍💋‍👨🏾" ;

		public const string KissWomanManMediumSkinToneDarkSkinToneFullyQualified = "👩🏽‍❤️‍💋‍👨🏿" ;

		public const string KissWomanManMediumSkinToneDarkSkinToneMinimallyQualified = "👩🏽‍❤‍💋‍👨🏿" ;

		public const string KissWomanManMediumDarkSkinToneLightSkinToneFullyQualified = "👩🏾‍❤️‍💋‍👨🏻" ;

		public const string KissWomanManMediumDarkSkinToneLightSkinToneMinimallyQualified = "👩🏾‍❤‍💋‍👨🏻" ;

		public const string KissWomanManMediumDarkSkinToneMediumLightSkinToneFullyQualified = "👩🏾‍❤️‍💋‍👨🏼" ;

		public const string KissWomanManMediumDarkSkinToneMediumLightSkinToneMinimallyQualified = "👩🏾‍❤‍💋‍👨🏼" ;

		public const string KissWomanManMediumDarkSkinToneMediumSkinToneFullyQualified = "👩🏾‍❤️‍💋‍👨🏽" ;

		public const string KissWomanManMediumDarkSkinToneMediumSkinToneMinimallyQualified = "👩🏾‍❤‍💋‍👨🏽" ;

		public const string KissWomanManMediumDarkSkinToneFullyQualified = "👩🏾‍❤️‍💋‍👨🏾" ;

		public const string KissWomanManMediumDarkSkinToneMinimallyQualified = "👩🏾‍❤‍💋‍👨🏾" ;

		public const string KissWomanManMediumDarkSkinToneDarkSkinToneFullyQualified = "👩🏾‍❤️‍💋‍👨🏿" ;

		public const string KissWomanManMediumDarkSkinToneDarkSkinToneMinimallyQualified = "👩🏾‍❤‍💋‍👨🏿" ;

		public const string KissWomanManDarkSkinToneLightSkinToneFullyQualified = "👩🏿‍❤️‍💋‍👨🏻" ;

		public const string KissWomanManDarkSkinToneLightSkinToneMinimallyQualified = "👩🏿‍❤‍💋‍👨🏻" ;

		public const string KissWomanManDarkSkinToneMediumLightSkinToneFullyQualified = "👩🏿‍❤️‍💋‍👨🏼" ;

		public const string KissWomanManDarkSkinToneMediumLightSkinToneMinimallyQualified = "👩🏿‍❤‍💋‍👨🏼" ;

		public const string KissWomanManDarkSkinToneMediumSkinToneFullyQualified = "👩🏿‍❤️‍💋‍👨🏽" ;

		public const string KissWomanManDarkSkinToneMediumSkinToneMinimallyQualified = "👩🏿‍❤‍💋‍👨🏽" ;

		public const string KissWomanManDarkSkinToneMediumDarkSkinToneFullyQualified = "👩🏿‍❤️‍💋‍👨🏾" ;

		public const string KissWomanManDarkSkinToneMediumDarkSkinToneMinimallyQualified = "👩🏿‍❤‍💋‍👨🏾" ;

		public const string KissWomanManDarkSkinToneFullyQualified = "👩🏿‍❤️‍💋‍👨🏿" ;

		public const string KissWomanManDarkSkinToneMinimallyQualified = "👩🏿‍❤‍💋‍👨🏿" ;

		public const string KissManManFullyQualified = "👨‍❤️‍💋‍👨" ;

		public const string KissManManMinimallyQualified = "👨‍❤‍💋‍👨" ;

		public const string KissManManLightSkinToneFullyQualified = "👨🏻‍❤️‍💋‍👨🏻" ;

		public const string KissManManLightSkinToneMinimallyQualified = "👨🏻‍❤‍💋‍👨🏻" ;

		public const string KissManManLightSkinToneMediumLightSkinToneFullyQualified = "👨🏻‍❤️‍💋‍👨🏼" ;

		public const string KissManManLightSkinToneMediumLightSkinToneMinimallyQualified = "👨🏻‍❤‍💋‍👨🏼" ;

		public const string KissManManLightSkinToneMediumSkinToneFullyQualified = "👨🏻‍❤️‍💋‍👨🏽" ;

		public const string KissManManLightSkinToneMediumSkinToneMinimallyQualified = "👨🏻‍❤‍💋‍👨🏽" ;

		public const string KissManManLightSkinToneMediumDarkSkinToneFullyQualified = "👨🏻‍❤️‍💋‍👨🏾" ;

		public const string KissManManLightSkinToneMediumDarkSkinToneMinimallyQualified = "👨🏻‍❤‍💋‍👨🏾" ;

		public const string KissManManLightSkinToneDarkSkinToneFullyQualified = "👨🏻‍❤️‍💋‍👨🏿" ;

		public const string KissManManLightSkinToneDarkSkinToneMinimallyQualified = "👨🏻‍❤‍💋‍👨🏿" ;

		public const string KissManManMediumLightSkinToneLightSkinToneFullyQualified = "👨🏼‍❤️‍💋‍👨🏻" ;

		public const string KissManManMediumLightSkinToneLightSkinToneMinimallyQualified = "👨🏼‍❤‍💋‍👨🏻" ;

		public const string KissManManMediumLightSkinToneFullyQualified = "👨🏼‍❤️‍💋‍👨🏼" ;

		public const string KissManManMediumLightSkinToneMinimallyQualified = "👨🏼‍❤‍💋‍👨🏼" ;

		public const string KissManManMediumLightSkinToneMediumSkinToneFullyQualified = "👨🏼‍❤️‍💋‍👨🏽" ;

		public const string KissManManMediumLightSkinToneMediumSkinToneMinimallyQualified = "👨🏼‍❤‍💋‍👨🏽" ;

		public const string KissManManMediumLightSkinToneMediumDarkSkinToneFullyQualified = "👨🏼‍❤️‍💋‍👨🏾" ;

		public const string KissManManMediumLightSkinToneMediumDarkSkinToneMinimallyQualified = "👨🏼‍❤‍💋‍👨🏾" ;

		public const string KissManManMediumLightSkinToneDarkSkinToneFullyQualified = "👨🏼‍❤️‍💋‍👨🏿" ;

		public const string KissManManMediumLightSkinToneDarkSkinToneMinimallyQualified = "👨🏼‍❤‍💋‍👨🏿" ;

		public const string KissManManMediumSkinToneLightSkinToneFullyQualified = "👨🏽‍❤️‍💋‍👨🏻" ;

		public const string KissManManMediumSkinToneLightSkinToneMinimallyQualified = "👨🏽‍❤‍💋‍👨🏻" ;

		public const string KissManManMediumSkinToneMediumLightSkinToneFullyQualified = "👨🏽‍❤️‍💋‍👨🏼" ;

		public const string KissManManMediumSkinToneMediumLightSkinToneMinimallyQualified = "👨🏽‍❤‍💋‍👨🏼" ;

		public const string KissManManMediumSkinToneFullyQualified = "👨🏽‍❤️‍💋‍👨🏽" ;

		public const string KissManManMediumSkinToneMinimallyQualified = "👨🏽‍❤‍💋‍👨🏽" ;

		public const string KissManManMediumSkinToneMediumDarkSkinToneFullyQualified = "👨🏽‍❤️‍💋‍👨🏾" ;

		public const string KissManManMediumSkinToneMediumDarkSkinToneMinimallyQualified = "👨🏽‍❤‍💋‍👨🏾" ;

		public const string KissManManMediumSkinToneDarkSkinToneFullyQualified = "👨🏽‍❤️‍💋‍👨🏿" ;

		public const string KissManManMediumSkinToneDarkSkinToneMinimallyQualified = "👨🏽‍❤‍💋‍👨🏿" ;

		public const string KissManManMediumDarkSkinToneLightSkinToneFullyQualified = "👨🏾‍❤️‍💋‍👨🏻" ;

		public const string KissManManMediumDarkSkinToneLightSkinToneMinimallyQualified = "👨🏾‍❤‍💋‍👨🏻" ;

		public const string KissManManMediumDarkSkinToneMediumLightSkinToneFullyQualified = "👨🏾‍❤️‍💋‍👨🏼" ;

		public const string KissManManMediumDarkSkinToneMediumLightSkinToneMinimallyQualified = "👨🏾‍❤‍💋‍👨🏼" ;

		public const string KissManManMediumDarkSkinToneMediumSkinToneFullyQualified = "👨🏾‍❤️‍💋‍👨🏽" ;

		public const string KissManManMediumDarkSkinToneMediumSkinToneMinimallyQualified = "👨🏾‍❤‍💋‍👨🏽" ;

		public const string KissManManMediumDarkSkinToneFullyQualified = "👨🏾‍❤️‍💋‍👨🏾" ;

		public const string KissManManMediumDarkSkinToneMinimallyQualified = "👨🏾‍❤‍💋‍👨🏾" ;

		public const string KissManManMediumDarkSkinToneDarkSkinToneFullyQualified = "👨🏾‍❤️‍💋‍👨🏿" ;

		public const string KissManManMediumDarkSkinToneDarkSkinToneMinimallyQualified = "👨🏾‍❤‍💋‍👨🏿" ;

		public const string KissManManDarkSkinToneLightSkinToneFullyQualified = "👨🏿‍❤️‍💋‍👨🏻" ;

		public const string KissManManDarkSkinToneLightSkinToneMinimallyQualified = "👨🏿‍❤‍💋‍👨🏻" ;

		public const string KissManManDarkSkinToneMediumLightSkinToneFullyQualified = "👨🏿‍❤️‍💋‍👨🏼" ;

		public const string KissManManDarkSkinToneMediumLightSkinToneMinimallyQualified = "👨🏿‍❤‍💋‍👨🏼" ;

		public const string KissManManDarkSkinToneMediumSkinToneFullyQualified = "👨🏿‍❤️‍💋‍👨🏽" ;

		public const string KissManManDarkSkinToneMediumSkinToneMinimallyQualified = "👨🏿‍❤‍💋‍👨🏽" ;

		public const string KissManManDarkSkinToneMediumDarkSkinToneFullyQualified = "👨🏿‍❤️‍💋‍👨🏾" ;

		public const string KissManManDarkSkinToneMediumDarkSkinToneMinimallyQualified = "👨🏿‍❤‍💋‍👨🏾" ;

		public const string KissManManDarkSkinToneFullyQualified = "👨🏿‍❤️‍💋‍👨🏿" ;

		public const string KissManManDarkSkinToneMinimallyQualified = "👨🏿‍❤‍💋‍👨🏿" ;

		public const string KissWomanWomanFullyQualified = "👩‍❤️‍💋‍👩" ;

		public const string KissWomanWomanMinimallyQualified = "👩‍❤‍💋‍👩" ;

		public const string KissWomanWomanLightSkinToneFullyQualified = "👩🏻‍❤️‍💋‍👩🏻" ;

		public const string KissWomanWomanLightSkinToneMinimallyQualified = "👩🏻‍❤‍💋‍👩🏻" ;

		public const string KissWomanWomanLightSkinToneMediumLightSkinToneFullyQualified = "👩🏻‍❤️‍💋‍👩🏼" ;

		public const string KissWomanWomanLightSkinToneMediumLightSkinToneMinimallyQualified = "👩🏻‍❤‍💋‍👩🏼" ;

		public const string KissWomanWomanLightSkinToneMediumSkinToneFullyQualified = "👩🏻‍❤️‍💋‍👩🏽" ;

		public const string KissWomanWomanLightSkinToneMediumSkinToneMinimallyQualified = "👩🏻‍❤‍💋‍👩🏽" ;

		public const string KissWomanWomanLightSkinToneMediumDarkSkinToneFullyQualified = "👩🏻‍❤️‍💋‍👩🏾" ;

		public const string KissWomanWomanLightSkinToneMediumDarkSkinToneMinimallyQualified = "👩🏻‍❤‍💋‍👩🏾" ;

		public const string KissWomanWomanLightSkinToneDarkSkinToneFullyQualified = "👩🏻‍❤️‍💋‍👩🏿" ;

		public const string KissWomanWomanLightSkinToneDarkSkinToneMinimallyQualified = "👩🏻‍❤‍💋‍👩🏿" ;

		public const string KissWomanWomanMediumLightSkinToneLightSkinToneFullyQualified = "👩🏼‍❤️‍💋‍👩🏻" ;

		public const string KissWomanWomanMediumLightSkinToneLightSkinToneMinimallyQualified = "👩🏼‍❤‍💋‍👩🏻" ;

		public const string KissWomanWomanMediumLightSkinToneFullyQualified = "👩🏼‍❤️‍💋‍👩🏼" ;

		public const string KissWomanWomanMediumLightSkinToneMinimallyQualified = "👩🏼‍❤‍💋‍👩🏼" ;

		public const string KissWomanWomanMediumLightSkinToneMediumSkinToneFullyQualified = "👩🏼‍❤️‍💋‍👩🏽" ;

		public const string KissWomanWomanMediumLightSkinToneMediumSkinToneMinimallyQualified = "👩🏼‍❤‍💋‍👩🏽" ;

		public const string KissWomanWomanMediumLightSkinToneMediumDarkSkinToneFullyQualified = "👩🏼‍❤️‍💋‍👩🏾" ;

		public const string KissWomanWomanMediumLightSkinToneMediumDarkSkinToneMinimallyQualified = "👩🏼‍❤‍💋‍👩🏾" ;

		public const string KissWomanWomanMediumLightSkinToneDarkSkinToneFullyQualified = "👩🏼‍❤️‍💋‍👩🏿" ;

		public const string KissWomanWomanMediumLightSkinToneDarkSkinToneMinimallyQualified = "👩🏼‍❤‍💋‍👩🏿" ;

		public const string KissWomanWomanMediumSkinToneLightSkinToneFullyQualified = "👩🏽‍❤️‍💋‍👩🏻" ;

		public const string KissWomanWomanMediumSkinToneLightSkinToneMinimallyQualified = "👩🏽‍❤‍💋‍👩🏻" ;

		public const string KissWomanWomanMediumSkinToneMediumLightSkinToneFullyQualified = "👩🏽‍❤️‍💋‍👩🏼" ;

		public const string KissWomanWomanMediumSkinToneMediumLightSkinToneMinimallyQualified = "👩🏽‍❤‍💋‍👩🏼" ;

		public const string KissWomanWomanMediumSkinToneFullyQualified = "👩🏽‍❤️‍💋‍👩🏽" ;

		public const string KissWomanWomanMediumSkinToneMinimallyQualified = "👩🏽‍❤‍💋‍👩🏽" ;

		public const string KissWomanWomanMediumSkinToneMediumDarkSkinToneFullyQualified = "👩🏽‍❤️‍💋‍👩🏾" ;

		public const string KissWomanWomanMediumSkinToneMediumDarkSkinToneMinimallyQualified = "👩🏽‍❤‍💋‍👩🏾" ;

		public const string KissWomanWomanMediumSkinToneDarkSkinToneFullyQualified = "👩🏽‍❤️‍💋‍👩🏿" ;

		public const string KissWomanWomanMediumSkinToneDarkSkinToneMinimallyQualified = "👩🏽‍❤‍💋‍👩🏿" ;

		public const string KissWomanWomanMediumDarkSkinToneLightSkinToneFullyQualified = "👩🏾‍❤️‍💋‍👩🏻" ;

		public const string KissWomanWomanMediumDarkSkinToneLightSkinToneMinimallyQualified = "👩🏾‍❤‍💋‍👩🏻" ;

		public const string KissWomanWomanMediumDarkSkinToneMediumLightSkinToneFullyQualified = "👩🏾‍❤️‍💋‍👩🏼" ;

		public const string KissWomanWomanMediumDarkSkinToneMediumLightSkinToneMinimallyQualified = "👩🏾‍❤‍💋‍👩🏼" ;

		public const string KissWomanWomanMediumDarkSkinToneMediumSkinToneFullyQualified = "👩🏾‍❤️‍💋‍👩🏽" ;

		public const string KissWomanWomanMediumDarkSkinToneMediumSkinToneMinimallyQualified = "👩🏾‍❤‍💋‍👩🏽" ;

		public const string KissWomanWomanMediumDarkSkinToneFullyQualified = "👩🏾‍❤️‍💋‍👩🏾" ;

		public const string KissWomanWomanMediumDarkSkinToneMinimallyQualified = "👩🏾‍❤‍💋‍👩🏾" ;

		public const string KissWomanWomanMediumDarkSkinToneDarkSkinToneFullyQualified = "👩🏾‍❤️‍💋‍👩🏿" ;

		public const string KissWomanWomanMediumDarkSkinToneDarkSkinToneMinimallyQualified = "👩🏾‍❤‍💋‍👩🏿" ;

		public const string KissWomanWomanDarkSkinToneLightSkinToneFullyQualified = "👩🏿‍❤️‍💋‍👩🏻" ;

		public const string KissWomanWomanDarkSkinToneLightSkinToneMinimallyQualified = "👩🏿‍❤‍💋‍👩🏻" ;

		public const string KissWomanWomanDarkSkinToneMediumLightSkinToneFullyQualified = "👩🏿‍❤️‍💋‍👩🏼" ;

		public const string KissWomanWomanDarkSkinToneMediumLightSkinToneMinimallyQualified = "👩🏿‍❤‍💋‍👩🏼" ;

		public const string KissWomanWomanDarkSkinToneMediumSkinToneFullyQualified = "👩🏿‍❤️‍💋‍👩🏽" ;

		public const string KissWomanWomanDarkSkinToneMediumSkinToneMinimallyQualified = "👩🏿‍❤‍💋‍👩🏽" ;

		public const string KissWomanWomanDarkSkinToneMediumDarkSkinToneFullyQualified = "👩🏿‍❤️‍💋‍👩🏾" ;

		public const string KissWomanWomanDarkSkinToneMediumDarkSkinToneMinimallyQualified = "👩🏿‍❤‍💋‍👩🏾" ;

		public const string KissWomanWomanDarkSkinToneFullyQualified = "👩🏿‍❤️‍💋‍👩🏿" ;

		public const string KissWomanWomanDarkSkinToneMinimallyQualified = "👩🏿‍❤‍💋‍👩🏿" ;

		public const string CoupleWithHeart = "💑" ;

		public const string CoupleWithHeartLightSkinTone = "💑🏻" ;

		public const string CoupleWithHeartMediumLightSkinTone = "💑🏼" ;

		public const string CoupleWithHeartMediumSkinTone = "💑🏽" ;

		public const string CoupleWithHeartMediumDarkSkinTone = "💑🏾" ;

		public const string CoupleWithHeartDarkSkinTone = "💑🏿" ;

		public const string CoupleWithHeartPersonPersonLightSkinToneMediumLightSkinToneFullyQualified = "🧑🏻‍❤️‍🧑🏼" ;

		public const string CoupleWithHeartPersonPersonLightSkinToneMediumLightSkinToneMinimallyQualified =
			"🧑🏻‍❤‍🧑🏼" ;

		public const string CoupleWithHeartPersonPersonLightSkinToneMediumSkinToneFullyQualified = "🧑🏻‍❤️‍🧑🏽" ;

		public const string CoupleWithHeartPersonPersonLightSkinToneMediumSkinToneMinimallyQualified = "🧑🏻‍❤‍🧑🏽" ;

		public const string CoupleWithHeartPersonPersonLightSkinToneMediumDarkSkinToneFullyQualified = "🧑🏻‍❤️‍🧑🏾" ;

		public const string CoupleWithHeartPersonPersonLightSkinToneMediumDarkSkinToneMinimallyQualified =
			"🧑🏻‍❤‍🧑🏾" ;

		public const string CoupleWithHeartPersonPersonLightSkinToneDarkSkinToneFullyQualified = "🧑🏻‍❤️‍🧑🏿" ;

		public const string CoupleWithHeartPersonPersonLightSkinToneDarkSkinToneMinimallyQualified = "🧑🏻‍❤‍🧑🏿" ;

		public const string CoupleWithHeartPersonPersonMediumLightSkinToneLightSkinToneFullyQualified = "🧑🏼‍❤️‍🧑🏻" ;

		public const string CoupleWithHeartPersonPersonMediumLightSkinToneLightSkinToneMinimallyQualified =
			"🧑🏼‍❤‍🧑🏻" ;

		public const string CoupleWithHeartPersonPersonMediumLightSkinToneMediumSkinToneFullyQualified =
			"🧑🏼‍❤️‍🧑🏽" ;

		public const string CoupleWithHeartPersonPersonMediumLightSkinToneMediumSkinToneMinimallyQualified =
			"🧑🏼‍❤‍🧑🏽" ;

		public const string CoupleWithHeartPersonPersonMediumLightSkinToneMediumDarkSkinToneFullyQualified =
			"🧑🏼‍❤️‍🧑🏾" ;

		public const string CoupleWithHeartPersonPersonMediumLightSkinToneMediumDarkSkinToneMinimallyQualified =
			"🧑🏼‍❤‍🧑🏾" ;

		public const string CoupleWithHeartPersonPersonMediumLightSkinToneDarkSkinToneFullyQualified = "🧑🏼‍❤️‍🧑🏿" ;

		public const string CoupleWithHeartPersonPersonMediumLightSkinToneDarkSkinToneMinimallyQualified =
			"🧑🏼‍❤‍🧑🏿" ;

		public const string CoupleWithHeartPersonPersonMediumSkinToneLightSkinToneFullyQualified = "🧑🏽‍❤️‍🧑🏻" ;

		public const string CoupleWithHeartPersonPersonMediumSkinToneLightSkinToneMinimallyQualified = "🧑🏽‍❤‍🧑🏻" ;

		public const string CoupleWithHeartPersonPersonMediumSkinToneMediumLightSkinToneFullyQualified =
			"🧑🏽‍❤️‍🧑🏼" ;

		public const string CoupleWithHeartPersonPersonMediumSkinToneMediumLightSkinToneMinimallyQualified =
			"🧑🏽‍❤‍🧑🏼" ;

		public const string CoupleWithHeartPersonPersonMediumSkinToneMediumDarkSkinToneFullyQualified = "🧑🏽‍❤️‍🧑🏾" ;

		public const string CoupleWithHeartPersonPersonMediumSkinToneMediumDarkSkinToneMinimallyQualified =
			"🧑🏽‍❤‍🧑🏾" ;

		public const string CoupleWithHeartPersonPersonMediumSkinToneDarkSkinToneFullyQualified = "🧑🏽‍❤️‍🧑🏿" ;

		public const string CoupleWithHeartPersonPersonMediumSkinToneDarkSkinToneMinimallyQualified = "🧑🏽‍❤‍🧑🏿" ;

		public const string CoupleWithHeartPersonPersonMediumDarkSkinToneLightSkinToneFullyQualified = "🧑🏾‍❤️‍🧑🏻" ;

		public const string CoupleWithHeartPersonPersonMediumDarkSkinToneLightSkinToneMinimallyQualified =
			"🧑🏾‍❤‍🧑🏻" ;

		public const string CoupleWithHeartPersonPersonMediumDarkSkinToneMediumLightSkinToneFullyQualified =
			"🧑🏾‍❤️‍🧑🏼" ;

		public const string CoupleWithHeartPersonPersonMediumDarkSkinToneMediumLightSkinToneMinimallyQualified =
			"🧑🏾‍❤‍🧑🏼" ;

		public const string CoupleWithHeartPersonPersonMediumDarkSkinToneMediumSkinToneFullyQualified = "🧑🏾‍❤️‍🧑🏽" ;

		public const string CoupleWithHeartPersonPersonMediumDarkSkinToneMediumSkinToneMinimallyQualified =
			"🧑🏾‍❤‍🧑🏽" ;

		public const string CoupleWithHeartPersonPersonMediumDarkSkinToneDarkSkinToneFullyQualified = "🧑🏾‍❤️‍🧑🏿" ;

		public const string CoupleWithHeartPersonPersonMediumDarkSkinToneDarkSkinToneMinimallyQualified =
			"🧑🏾‍❤‍🧑🏿" ;

		public const string CoupleWithHeartPersonPersonDarkSkinToneLightSkinToneFullyQualified = "🧑🏿‍❤️‍🧑🏻" ;

		public const string CoupleWithHeartPersonPersonDarkSkinToneLightSkinToneMinimallyQualified = "🧑🏿‍❤‍🧑🏻" ;

		public const string CoupleWithHeartPersonPersonDarkSkinToneMediumLightSkinToneFullyQualified = "🧑🏿‍❤️‍🧑🏼" ;

		public const string CoupleWithHeartPersonPersonDarkSkinToneMediumLightSkinToneMinimallyQualified =
			"🧑🏿‍❤‍🧑🏼" ;

		public const string CoupleWithHeartPersonPersonDarkSkinToneMediumSkinToneFullyQualified = "🧑🏿‍❤️‍🧑🏽" ;

		public const string CoupleWithHeartPersonPersonDarkSkinToneMediumSkinToneMinimallyQualified = "🧑🏿‍❤‍🧑🏽" ;

		public const string CoupleWithHeartPersonPersonDarkSkinToneMediumDarkSkinToneFullyQualified = "🧑🏿‍❤️‍🧑🏾" ;

		public const string CoupleWithHeartPersonPersonDarkSkinToneMediumDarkSkinToneMinimallyQualified =
			"🧑🏿‍❤‍🧑🏾" ;

		public const string CoupleWithHeartWomanManFullyQualified = "👩‍❤️‍👨" ;

		public const string CoupleWithHeartWomanManMinimallyQualified = "👩‍❤‍👨" ;

		public const string CoupleWithHeartWomanManLightSkinToneFullyQualified = "👩🏻‍❤️‍👨🏻" ;

		public const string CoupleWithHeartWomanManLightSkinToneMinimallyQualified = "👩🏻‍❤‍👨🏻" ;

		public const string CoupleWithHeartWomanManLightSkinToneMediumLightSkinToneFullyQualified = "👩🏻‍❤️‍👨🏼" ;

		public const string CoupleWithHeartWomanManLightSkinToneMediumLightSkinToneMinimallyQualified = "👩🏻‍❤‍👨🏼" ;

		public const string CoupleWithHeartWomanManLightSkinToneMediumSkinToneFullyQualified = "👩🏻‍❤️‍👨🏽" ;

		public const string CoupleWithHeartWomanManLightSkinToneMediumSkinToneMinimallyQualified = "👩🏻‍❤‍👨🏽" ;

		public const string CoupleWithHeartWomanManLightSkinToneMediumDarkSkinToneFullyQualified = "👩🏻‍❤️‍👨🏾" ;

		public const string CoupleWithHeartWomanManLightSkinToneMediumDarkSkinToneMinimallyQualified = "👩🏻‍❤‍👨🏾" ;

		public const string CoupleWithHeartWomanManLightSkinToneDarkSkinToneFullyQualified = "👩🏻‍❤️‍👨🏿" ;

		public const string CoupleWithHeartWomanManLightSkinToneDarkSkinToneMinimallyQualified = "👩🏻‍❤‍👨🏿" ;

		public const string CoupleWithHeartWomanManMediumLightSkinToneLightSkinToneFullyQualified = "👩🏼‍❤️‍👨🏻" ;

		public const string CoupleWithHeartWomanManMediumLightSkinToneLightSkinToneMinimallyQualified = "👩🏼‍❤‍👨🏻" ;

		public const string CoupleWithHeartWomanManMediumLightSkinToneFullyQualified = "👩🏼‍❤️‍👨🏼" ;

		public const string CoupleWithHeartWomanManMediumLightSkinToneMinimallyQualified = "👩🏼‍❤‍👨🏼" ;

		public const string CoupleWithHeartWomanManMediumLightSkinToneMediumSkinToneFullyQualified = "👩🏼‍❤️‍👨🏽" ;

		public const string CoupleWithHeartWomanManMediumLightSkinToneMediumSkinToneMinimallyQualified = "👩🏼‍❤‍👨🏽" ;

		public const string CoupleWithHeartWomanManMediumLightSkinToneMediumDarkSkinToneFullyQualified =
			"👩🏼‍❤️‍👨🏾" ;

		public const string CoupleWithHeartWomanManMediumLightSkinToneMediumDarkSkinToneMinimallyQualified =
			"👩🏼‍❤‍👨🏾" ;

		public const string CoupleWithHeartWomanManMediumLightSkinToneDarkSkinToneFullyQualified = "👩🏼‍❤️‍👨🏿" ;

		public const string CoupleWithHeartWomanManMediumLightSkinToneDarkSkinToneMinimallyQualified = "👩🏼‍❤‍👨🏿" ;

		public const string CoupleWithHeartWomanManMediumSkinToneLightSkinToneFullyQualified = "👩🏽‍❤️‍👨🏻" ;

		public const string CoupleWithHeartWomanManMediumSkinToneLightSkinToneMinimallyQualified = "👩🏽‍❤‍👨🏻" ;

		public const string CoupleWithHeartWomanManMediumSkinToneMediumLightSkinToneFullyQualified = "👩🏽‍❤️‍👨🏼" ;

		public const string CoupleWithHeartWomanManMediumSkinToneMediumLightSkinToneMinimallyQualified = "👩🏽‍❤‍👨🏼" ;

		public const string CoupleWithHeartWomanManMediumSkinToneFullyQualified = "👩🏽‍❤️‍👨🏽" ;

		public const string CoupleWithHeartWomanManMediumSkinToneMinimallyQualified = "👩🏽‍❤‍👨🏽" ;

		public const string CoupleWithHeartWomanManMediumSkinToneMediumDarkSkinToneFullyQualified = "👩🏽‍❤️‍👨🏾" ;

		public const string CoupleWithHeartWomanManMediumSkinToneMediumDarkSkinToneMinimallyQualified = "👩🏽‍❤‍👨🏾" ;

		public const string CoupleWithHeartWomanManMediumSkinToneDarkSkinToneFullyQualified = "👩🏽‍❤️‍👨🏿" ;

		public const string CoupleWithHeartWomanManMediumSkinToneDarkSkinToneMinimallyQualified = "👩🏽‍❤‍👨🏿" ;

		public const string CoupleWithHeartWomanManMediumDarkSkinToneLightSkinToneFullyQualified = "👩🏾‍❤️‍👨🏻" ;

		public const string CoupleWithHeartWomanManMediumDarkSkinToneLightSkinToneMinimallyQualified = "👩🏾‍❤‍👨🏻" ;

		public const string CoupleWithHeartWomanManMediumDarkSkinToneMediumLightSkinToneFullyQualified =
			"👩🏾‍❤️‍👨🏼" ;

		public const string CoupleWithHeartWomanManMediumDarkSkinToneMediumLightSkinToneMinimallyQualified =
			"👩🏾‍❤‍👨🏼" ;

		public const string CoupleWithHeartWomanManMediumDarkSkinToneMediumSkinToneFullyQualified = "👩🏾‍❤️‍👨🏽" ;

		public const string CoupleWithHeartWomanManMediumDarkSkinToneMediumSkinToneMinimallyQualified = "👩🏾‍❤‍👨🏽" ;

		public const string CoupleWithHeartWomanManMediumDarkSkinToneFullyQualified = "👩🏾‍❤️‍👨🏾" ;

		public const string CoupleWithHeartWomanManMediumDarkSkinToneMinimallyQualified = "👩🏾‍❤‍👨🏾" ;

		public const string CoupleWithHeartWomanManMediumDarkSkinToneDarkSkinToneFullyQualified = "👩🏾‍❤️‍👨🏿" ;

		public const string CoupleWithHeartWomanManMediumDarkSkinToneDarkSkinToneMinimallyQualified = "👩🏾‍❤‍👨🏿" ;

		public const string CoupleWithHeartWomanManDarkSkinToneLightSkinToneFullyQualified = "👩🏿‍❤️‍👨🏻" ;

		public const string CoupleWithHeartWomanManDarkSkinToneLightSkinToneMinimallyQualified = "👩🏿‍❤‍👨🏻" ;

		public const string CoupleWithHeartWomanManDarkSkinToneMediumLightSkinToneFullyQualified = "👩🏿‍❤️‍👨🏼" ;

		public const string CoupleWithHeartWomanManDarkSkinToneMediumLightSkinToneMinimallyQualified = "👩🏿‍❤‍👨🏼" ;

		public const string CoupleWithHeartWomanManDarkSkinToneMediumSkinToneFullyQualified = "👩🏿‍❤️‍👨🏽" ;

		public const string CoupleWithHeartWomanManDarkSkinToneMediumSkinToneMinimallyQualified = "👩🏿‍❤‍👨🏽" ;

		public const string CoupleWithHeartWomanManDarkSkinToneMediumDarkSkinToneFullyQualified = "👩🏿‍❤️‍👨🏾" ;

		public const string CoupleWithHeartWomanManDarkSkinToneMediumDarkSkinToneMinimallyQualified = "👩🏿‍❤‍👨🏾" ;

		public const string CoupleWithHeartWomanManDarkSkinToneFullyQualified = "👩🏿‍❤️‍👨🏿" ;

		public const string CoupleWithHeartWomanManDarkSkinToneMinimallyQualified = "👩🏿‍❤‍👨🏿" ;

		public const string CoupleWithHeartManManFullyQualified = "👨‍❤️‍👨" ;

		public const string CoupleWithHeartManManMinimallyQualified = "👨‍❤‍👨" ;

		public const string CoupleWithHeartManManLightSkinToneFullyQualified = "👨🏻‍❤️‍👨🏻" ;

		public const string CoupleWithHeartManManLightSkinToneMinimallyQualified = "👨🏻‍❤‍👨🏻" ;

		public const string CoupleWithHeartManManLightSkinToneMediumLightSkinToneFullyQualified = "👨🏻‍❤️‍👨🏼" ;

		public const string CoupleWithHeartManManLightSkinToneMediumLightSkinToneMinimallyQualified = "👨🏻‍❤‍👨🏼" ;

		public const string CoupleWithHeartManManLightSkinToneMediumSkinToneFullyQualified = "👨🏻‍❤️‍👨🏽" ;

		public const string CoupleWithHeartManManLightSkinToneMediumSkinToneMinimallyQualified = "👨🏻‍❤‍👨🏽" ;

		public const string CoupleWithHeartManManLightSkinToneMediumDarkSkinToneFullyQualified = "👨🏻‍❤️‍👨🏾" ;

		public const string CoupleWithHeartManManLightSkinToneMediumDarkSkinToneMinimallyQualified = "👨🏻‍❤‍👨🏾" ;

		public const string CoupleWithHeartManManLightSkinToneDarkSkinToneFullyQualified = "👨🏻‍❤️‍👨🏿" ;

		public const string CoupleWithHeartManManLightSkinToneDarkSkinToneMinimallyQualified = "👨🏻‍❤‍👨🏿" ;

		public const string CoupleWithHeartManManMediumLightSkinToneLightSkinToneFullyQualified = "👨🏼‍❤️‍👨🏻" ;

		public const string CoupleWithHeartManManMediumLightSkinToneLightSkinToneMinimallyQualified = "👨🏼‍❤‍👨🏻" ;

		public const string CoupleWithHeartManManMediumLightSkinToneFullyQualified = "👨🏼‍❤️‍👨🏼" ;

		public const string CoupleWithHeartManManMediumLightSkinToneMinimallyQualified = "👨🏼‍❤‍👨🏼" ;

		public const string CoupleWithHeartManManMediumLightSkinToneMediumSkinToneFullyQualified = "👨🏼‍❤️‍👨🏽" ;

		public const string CoupleWithHeartManManMediumLightSkinToneMediumSkinToneMinimallyQualified = "👨🏼‍❤‍👨🏽" ;

		public const string CoupleWithHeartManManMediumLightSkinToneMediumDarkSkinToneFullyQualified = "👨🏼‍❤️‍👨🏾" ;

		public const string CoupleWithHeartManManMediumLightSkinToneMediumDarkSkinToneMinimallyQualified =
			"👨🏼‍❤‍👨🏾" ;

		public const string CoupleWithHeartManManMediumLightSkinToneDarkSkinToneFullyQualified = "👨🏼‍❤️‍👨🏿" ;

		public const string CoupleWithHeartManManMediumLightSkinToneDarkSkinToneMinimallyQualified = "👨🏼‍❤‍👨🏿" ;

		public const string CoupleWithHeartManManMediumSkinToneLightSkinToneFullyQualified = "👨🏽‍❤️‍👨🏻" ;

		public const string CoupleWithHeartManManMediumSkinToneLightSkinToneMinimallyQualified = "👨🏽‍❤‍👨🏻" ;

		public const string CoupleWithHeartManManMediumSkinToneMediumLightSkinToneFullyQualified = "👨🏽‍❤️‍👨🏼" ;

		public const string CoupleWithHeartManManMediumSkinToneMediumLightSkinToneMinimallyQualified = "👨🏽‍❤‍👨🏼" ;

		public const string CoupleWithHeartManManMediumSkinToneFullyQualified = "👨🏽‍❤️‍👨🏽" ;

		public const string CoupleWithHeartManManMediumSkinToneMinimallyQualified = "👨🏽‍❤‍👨🏽" ;

		public const string CoupleWithHeartManManMediumSkinToneMediumDarkSkinToneFullyQualified = "👨🏽‍❤️‍👨🏾" ;

		public const string CoupleWithHeartManManMediumSkinToneMediumDarkSkinToneMinimallyQualified = "👨🏽‍❤‍👨🏾" ;

		public const string CoupleWithHeartManManMediumSkinToneDarkSkinToneFullyQualified = "👨🏽‍❤️‍👨🏿" ;

		public const string CoupleWithHeartManManMediumSkinToneDarkSkinToneMinimallyQualified = "👨🏽‍❤‍👨🏿" ;

		public const string CoupleWithHeartManManMediumDarkSkinToneLightSkinToneFullyQualified = "👨🏾‍❤️‍👨🏻" ;

		public const string CoupleWithHeartManManMediumDarkSkinToneLightSkinToneMinimallyQualified = "👨🏾‍❤‍👨🏻" ;

		public const string CoupleWithHeartManManMediumDarkSkinToneMediumLightSkinToneFullyQualified = "👨🏾‍❤️‍👨🏼" ;

		public const string CoupleWithHeartManManMediumDarkSkinToneMediumLightSkinToneMinimallyQualified =
			"👨🏾‍❤‍👨🏼" ;

		public const string CoupleWithHeartManManMediumDarkSkinToneMediumSkinToneFullyQualified = "👨🏾‍❤️‍👨🏽" ;

		public const string CoupleWithHeartManManMediumDarkSkinToneMediumSkinToneMinimallyQualified = "👨🏾‍❤‍👨🏽" ;

		public const string CoupleWithHeartManManMediumDarkSkinToneFullyQualified = "👨🏾‍❤️‍👨🏾" ;

		public const string CoupleWithHeartManManMediumDarkSkinToneMinimallyQualified = "👨🏾‍❤‍👨🏾" ;

		public const string CoupleWithHeartManManMediumDarkSkinToneDarkSkinToneFullyQualified = "👨🏾‍❤️‍👨🏿" ;

		public const string CoupleWithHeartManManMediumDarkSkinToneDarkSkinToneMinimallyQualified = "👨🏾‍❤‍👨🏿" ;

		public const string CoupleWithHeartManManDarkSkinToneLightSkinToneFullyQualified = "👨🏿‍❤️‍👨🏻" ;

		public const string CoupleWithHeartManManDarkSkinToneLightSkinToneMinimallyQualified = "👨🏿‍❤‍👨🏻" ;

		public const string CoupleWithHeartManManDarkSkinToneMediumLightSkinToneFullyQualified = "👨🏿‍❤️‍👨🏼" ;

		public const string CoupleWithHeartManManDarkSkinToneMediumLightSkinToneMinimallyQualified = "👨🏿‍❤‍👨🏼" ;

		public const string CoupleWithHeartManManDarkSkinToneMediumSkinToneFullyQualified = "👨🏿‍❤️‍👨🏽" ;

		public const string CoupleWithHeartManManDarkSkinToneMediumSkinToneMinimallyQualified = "👨🏿‍❤‍👨🏽" ;

		public const string CoupleWithHeartManManDarkSkinToneMediumDarkSkinToneFullyQualified = "👨🏿‍❤️‍👨🏾" ;

		public const string CoupleWithHeartManManDarkSkinToneMediumDarkSkinToneMinimallyQualified = "👨🏿‍❤‍👨🏾" ;

		public const string CoupleWithHeartManManDarkSkinToneFullyQualified = "👨🏿‍❤️‍👨🏿" ;

		public const string CoupleWithHeartManManDarkSkinToneMinimallyQualified = "👨🏿‍❤‍👨🏿" ;

		public const string CoupleWithHeartWomanWomanFullyQualified = "👩‍❤️‍👩" ;

		public const string CoupleWithHeartWomanWomanMinimallyQualified = "👩‍❤‍👩" ;

		public const string CoupleWithHeartWomanWomanLightSkinToneFullyQualified = "👩🏻‍❤️‍👩🏻" ;

		public const string CoupleWithHeartWomanWomanLightSkinToneMinimallyQualified = "👩🏻‍❤‍👩🏻" ;

		public const string CoupleWithHeartWomanWomanLightSkinToneMediumLightSkinToneFullyQualified = "👩🏻‍❤️‍👩🏼" ;

		public const string CoupleWithHeartWomanWomanLightSkinToneMediumLightSkinToneMinimallyQualified =
			"👩🏻‍❤‍👩🏼" ;

		public const string CoupleWithHeartWomanWomanLightSkinToneMediumSkinToneFullyQualified = "👩🏻‍❤️‍👩🏽" ;

		public const string CoupleWithHeartWomanWomanLightSkinToneMediumSkinToneMinimallyQualified = "👩🏻‍❤‍👩🏽" ;

		public const string CoupleWithHeartWomanWomanLightSkinToneMediumDarkSkinToneFullyQualified = "👩🏻‍❤️‍👩🏾" ;

		public const string CoupleWithHeartWomanWomanLightSkinToneMediumDarkSkinToneMinimallyQualified = "👩🏻‍❤‍👩🏾" ;

		public const string CoupleWithHeartWomanWomanLightSkinToneDarkSkinToneFullyQualified = "👩🏻‍❤️‍👩🏿" ;

		public const string CoupleWithHeartWomanWomanLightSkinToneDarkSkinToneMinimallyQualified = "👩🏻‍❤‍👩🏿" ;

		public const string CoupleWithHeartWomanWomanMediumLightSkinToneLightSkinToneFullyQualified = "👩🏼‍❤️‍👩🏻" ;

		public const string CoupleWithHeartWomanWomanMediumLightSkinToneLightSkinToneMinimallyQualified =
			"👩🏼‍❤‍👩🏻" ;

		public const string CoupleWithHeartWomanWomanMediumLightSkinToneFullyQualified = "👩🏼‍❤️‍👩🏼" ;

		public const string CoupleWithHeartWomanWomanMediumLightSkinToneMinimallyQualified = "👩🏼‍❤‍👩🏼" ;

		public const string CoupleWithHeartWomanWomanMediumLightSkinToneMediumSkinToneFullyQualified = "👩🏼‍❤️‍👩🏽" ;

		public const string CoupleWithHeartWomanWomanMediumLightSkinToneMediumSkinToneMinimallyQualified =
			"👩🏼‍❤‍👩🏽" ;

		public const string CoupleWithHeartWomanWomanMediumLightSkinToneMediumDarkSkinToneFullyQualified =
			"👩🏼‍❤️‍👩🏾" ;

		public const string CoupleWithHeartWomanWomanMediumLightSkinToneMediumDarkSkinToneMinimallyQualified =
			"👩🏼‍❤‍👩🏾" ;

		public const string CoupleWithHeartWomanWomanMediumLightSkinToneDarkSkinToneFullyQualified = "👩🏼‍❤️‍👩🏿" ;

		public const string CoupleWithHeartWomanWomanMediumLightSkinToneDarkSkinToneMinimallyQualified = "👩🏼‍❤‍👩🏿" ;

		public const string CoupleWithHeartWomanWomanMediumSkinToneLightSkinToneFullyQualified = "👩🏽‍❤️‍👩🏻" ;

		public const string CoupleWithHeartWomanWomanMediumSkinToneLightSkinToneMinimallyQualified = "👩🏽‍❤‍👩🏻" ;

		public const string CoupleWithHeartWomanWomanMediumSkinToneMediumLightSkinToneFullyQualified = "👩🏽‍❤️‍👩🏼" ;

		public const string CoupleWithHeartWomanWomanMediumSkinToneMediumLightSkinToneMinimallyQualified =
			"👩🏽‍❤‍👩🏼" ;

		public const string CoupleWithHeartWomanWomanMediumSkinToneFullyQualified = "👩🏽‍❤️‍👩🏽" ;

		public const string CoupleWithHeartWomanWomanMediumSkinToneMinimallyQualified = "👩🏽‍❤‍👩🏽" ;

		public const string CoupleWithHeartWomanWomanMediumSkinToneMediumDarkSkinToneFullyQualified = "👩🏽‍❤️‍👩🏾" ;

		public const string CoupleWithHeartWomanWomanMediumSkinToneMediumDarkSkinToneMinimallyQualified =
			"👩🏽‍❤‍👩🏾" ;

		public const string CoupleWithHeartWomanWomanMediumSkinToneDarkSkinToneFullyQualified = "👩🏽‍❤️‍👩🏿" ;

		public const string CoupleWithHeartWomanWomanMediumSkinToneDarkSkinToneMinimallyQualified = "👩🏽‍❤‍👩🏿" ;

		public const string CoupleWithHeartWomanWomanMediumDarkSkinToneLightSkinToneFullyQualified = "👩🏾‍❤️‍👩🏻" ;

		public const string CoupleWithHeartWomanWomanMediumDarkSkinToneLightSkinToneMinimallyQualified = "👩🏾‍❤‍👩🏻" ;

		public const string CoupleWithHeartWomanWomanMediumDarkSkinToneMediumLightSkinToneFullyQualified =
			"👩🏾‍❤️‍👩🏼" ;

		public const string CoupleWithHeartWomanWomanMediumDarkSkinToneMediumLightSkinToneMinimallyQualified =
			"👩🏾‍❤‍👩🏼" ;

		public const string CoupleWithHeartWomanWomanMediumDarkSkinToneMediumSkinToneFullyQualified = "👩🏾‍❤️‍👩🏽" ;

		public const string CoupleWithHeartWomanWomanMediumDarkSkinToneMediumSkinToneMinimallyQualified =
			"👩🏾‍❤‍👩🏽" ;

		public const string CoupleWithHeartWomanWomanMediumDarkSkinToneFullyQualified = "👩🏾‍❤️‍👩🏾" ;

		public const string CoupleWithHeartWomanWomanMediumDarkSkinToneMinimallyQualified = "👩🏾‍❤‍👩🏾" ;

		public const string CoupleWithHeartWomanWomanMediumDarkSkinToneDarkSkinToneFullyQualified = "👩🏾‍❤️‍👩🏿" ;

		public const string CoupleWithHeartWomanWomanMediumDarkSkinToneDarkSkinToneMinimallyQualified = "👩🏾‍❤‍👩🏿" ;

		public const string CoupleWithHeartWomanWomanDarkSkinToneLightSkinToneFullyQualified = "👩🏿‍❤️‍👩🏻" ;

		public const string CoupleWithHeartWomanWomanDarkSkinToneLightSkinToneMinimallyQualified = "👩🏿‍❤‍👩🏻" ;

		public const string CoupleWithHeartWomanWomanDarkSkinToneMediumLightSkinToneFullyQualified = "👩🏿‍❤️‍👩🏼" ;

		public const string CoupleWithHeartWomanWomanDarkSkinToneMediumLightSkinToneMinimallyQualified = "👩🏿‍❤‍👩🏼" ;

		public const string CoupleWithHeartWomanWomanDarkSkinToneMediumSkinToneFullyQualified = "👩🏿‍❤️‍👩🏽" ;

		public const string CoupleWithHeartWomanWomanDarkSkinToneMediumSkinToneMinimallyQualified = "👩🏿‍❤‍👩🏽" ;

		public const string CoupleWithHeartWomanWomanDarkSkinToneMediumDarkSkinToneFullyQualified = "👩🏿‍❤️‍👩🏾" ;

		public const string CoupleWithHeartWomanWomanDarkSkinToneMediumDarkSkinToneMinimallyQualified = "👩🏿‍❤‍👩🏾" ;

		public const string CoupleWithHeartWomanWomanDarkSkinToneFullyQualified = "👩🏿‍❤️‍👩🏿" ;

		public const string CoupleWithHeartWomanWomanDarkSkinToneMinimallyQualified = "👩🏿‍❤‍👩🏿" ;

		public const string Family = "👪" ;

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

		public const string SpeakingHeadFullyQualified = "🗣️" ;

		public const string SpeakingHeadUnqualified = "🗣" ;

		public const string BustInSilhouette = "👤" ;

		public const string BustsInSilhouette = "👥" ;

		public const string PeopleHugging = "🫂" ;

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

		public const string Orangutan = "🦧" ;

		public const string DogFace = "🐶" ;

		public const string Dog = "🐕" ;

		public const string GuideDog = "🦮" ;

		public const string ServiceDog = "🐕‍🦺" ;

		public const string Poodle = "🐩" ;

		public const string Wolf = "🐺" ;

		public const string Fox = "🦊" ;

		public const string Raccoon = "🦝" ;

		public const string CatFace = "🐱" ;

		public const string Cat = "🐈" ;

		public const string BlackCat = "🐈‍⬛" ;

		public const string Lion = "🦁" ;

		public const string TigerFace = "🐯" ;

		public const string Tiger = "🐅" ;

		public const string Leopard = "🐆" ;

		public const string HorseFace = "🐴" ;

		public const string Moose = "🫎" ;

		public const string Donkey = "🫏" ;

		public const string Horse = "🐎" ;

		public const string Unicorn = "🦄" ;

		public const string Zebra = "🦓" ;

		public const string Deer = "🦌" ;

		public const string Bison = "🦬" ;

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

		public const string Mammoth = "🦣" ;

		public const string Rhinoceros = "🦏" ;

		public const string Hippopotamus = "🦛" ;

		public const string MouseFace = "🐭" ;

		public const string Mouse = "🐁" ;

		public const string Rat = "🐀" ;

		public const string Hamster = "🐹" ;

		public const string RabbitFace = "🐰" ;

		public const string Rabbit = "🐇" ;

		public const string ChipmunkFullyQualified = "🐿️" ;

		public const string ChipmunkUnqualified = "🐿" ;

		public const string Beaver = "🦫" ;

		public const string Hedgehog = "🦔" ;

		public const string Bat = "🦇" ;

		public const string Bear = "🐻" ;

		public const string PolarBearFullyQualified = "🐻‍❄️" ;

		public const string PolarBearMinimallyQualified = "🐻‍❄" ;

		public const string Koala = "🐨" ;

		public const string Panda = "🐼" ;

		public const string Sloth = "🦥" ;

		public const string Otter = "🦦" ;

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

		public const string DoveFullyQualified = "🕊️" ;

		public const string DoveUnqualified = "🕊" ;

		public const string Eagle = "🦅" ;

		public const string Duck = "🦆" ;

		public const string Swan = "🦢" ;

		public const string Owl = "🦉" ;

		public const string Dodo = "🦤" ;

		public const string Feather = "🪶" ;

		public const string Flamingo = "🦩" ;

		public const string Peacock = "🦚" ;

		public const string Parrot = "🦜" ;

		public const string Wing = "🪽" ;

		public const string BlackBird = "🐦‍⬛" ;

		public const string Goose = "🪿" ;

		public const string Frog = "🐸" ;

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

		public const string Seal = "🦭" ;

		public const string Fish = "🐟" ;

		public const string TropicalFish = "🐠" ;

		public const string Blowfish = "🐡" ;

		public const string Shark = "🦈" ;

		public const string Octopus = "🐙" ;

		public const string SpiralShell = "🐚" ;

		public const string Coral = "🪸" ;

		public const string Jellyfish = "🪼" ;

		public const string Snail = "🐌" ;

		public const string Butterfly = "🦋" ;

		public const string Bug = "🐛" ;

		public const string Ant = "🐜" ;

		public const string Honeybee = "🐝" ;

		public const string Beetle = "🪲" ;

		public const string LadyBeetle = "🐞" ;

		public const string Cricket = "🦗" ;

		public const string Cockroach = "🪳" ;

		public const string SpiderFullyQualified = "🕷️" ;

		public const string SpiderUnqualified = "🕷" ;

		public const string SpiderWebFullyQualified = "🕸️" ;

		public const string SpiderWebUnqualified = "🕸" ;

		public const string Scorpion = "🦂" ;

		public const string Mosquito = "🦟" ;

		public const string Fly = "🪰" ;

		public const string Worm = "🪱" ;

		public const string Microbe = "🦠" ;

		public const string Bouquet = "💐" ;

		public const string CherryBlossom = "🌸" ;

		public const string WhiteFlower = "💮" ;

		public const string Lotus = "🪷" ;

		public const string RosetteFullyQualified = "🏵️" ;

		public const string RosetteUnqualified = "🏵" ;

		public const string Rose = "🌹" ;

		public const string WiltedFlower = "🥀" ;

		public const string Hibiscus = "🌺" ;

		public const string Sunflower = "🌻" ;

		public const string Blossom = "🌼" ;

		public const string Tulip = "🌷" ;

		public const string Hyacinth = "🪻" ;

		public const string Seedling = "🌱" ;

		public const string PottedPlant = "🪴" ;

		public const string EvergreenTree = "🌲" ;

		public const string DeciduousTree = "🌳" ;

		public const string PalmTree = "🌴" ;

		public const string Cactus = "🌵" ;

		public const string SheafOfRice = "🌾" ;

		public const string Herb = "🌿" ;

		public const string ShamrockFullyQualified = "☘️" ;

		public const string ShamrockUnqualified = "☘" ;

		public const string FourLeafClover = "🍀" ;

		public const string MapleLeaf = "🍁" ;

		public const string FallenLeaf = "🍂" ;

		public const string LeafFlutteringInWind = "🍃" ;

		public const string EmptyNest = "🪹" ;

		public const string NestWithEggs = "🪺" ;

		public const string Mushroom = "🍄" ;

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

		public const string Blueberries = "🫐" ;

		public const string KiwiFruit = "🥝" ;

		public const string Tomato = "🍅" ;

		public const string Olive = "🫒" ;

		public const string Coconut = "🥥" ;

		public const string Avocado = "🥑" ;

		public const string Eggplant = "🍆" ;

		public const string Potato = "🥔" ;

		public const string Carrot = "🥕" ;

		public const string EarOfCorn = "🌽" ;

		public const string HotPepperFullyQualified = "🌶️" ;

		public const string HotPepperUnqualified = "🌶" ;

		public const string BellPepper = "🫑" ;

		public const string Cucumber = "🥒" ;

		public const string LeafyGreen = "🥬" ;

		public const string Broccoli = "🥦" ;

		public const string Garlic = "🧄" ;

		public const string Onion = "🧅" ;

		public const string Peanuts = "🥜" ;

		public const string Beans = "🫘" ;

		public const string Chestnut = "🌰" ;

		public const string GingerRoot = "🫚" ;

		public const string PeaPod = "🫛" ;

		public const string Bread = "🍞" ;

		public const string Croissant = "🥐" ;

		public const string BaguetteBread = "🥖" ;

		public const string Flatbread = "🫓" ;

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

		public const string Tamale = "🫔" ;

		public const string StuffedFlatbread = "🥙" ;

		public const string Falafel = "🧆" ;

		public const string Egg = "🥚" ;

		public const string Cooking = "🍳" ;

		public const string ShallowPanOfFood = "🥘" ;

		public const string PotOfFood = "🍲" ;

		public const string Fondue = "🫕" ;

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

		public const string Teapot = "🫖" ;

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

		public const string PouringLiquid = "🫗" ;

		public const string CupWithStraw = "🥤" ;

		public const string BubbleTea = "🧋" ;

		public const string BeverageBox = "🧃" ;

		public const string Mate = "🧉" ;

		public const string Ice = "🧊" ;

		public const string Chopsticks = "🥢" ;

		public const string ForkAndKnifeWithPlateFullyQualified = "🍽️" ;

		public const string ForkAndKnifeWithPlateUnqualified = "🍽" ;

		public const string ForkAndKnife = "🍴" ;

		public const string Spoon = "🥄" ;

		public const string KitchenKnife = "🔪" ;

		public const string Jar = "🫙" ;

		public const string Amphora = "🏺" ;

		public const string GlobeShowingEuropeAfrica = "🌍" ;

		public const string GlobeShowingAmericas = "🌎" ;

		public const string GlobeShowingAsiaAustralia = "🌏" ;

		public const string GlobeWithMeridians = "🌐" ;

		public const string WorldMapFullyQualified = "🗺️" ;

		public const string WorldMapUnqualified = "🗺" ;

		public const string MapOfJapan = "🗾" ;

		public const string Compass = "🧭" ;

		public const string SnowCappedMountainFullyQualified = "🏔️" ;

		public const string SnowCappedMountainUnqualified = "🏔" ;

		public const string MountainFullyQualified = "⛰️" ;

		public const string MountainUnqualified = "⛰" ;

		public const string Volcano = "🌋" ;

		public const string MountFuji = "🗻" ;

		public const string CampingFullyQualified = "🏕️" ;

		public const string CampingUnqualified = "🏕" ;

		public const string BeachWithUmbrellaFullyQualified = "🏖️" ;

		public const string BeachWithUmbrellaUnqualified = "🏖" ;

		public const string DesertFullyQualified = "🏜️" ;

		public const string DesertUnqualified = "🏜" ;

		public const string DesertIslandFullyQualified = "🏝️" ;

		public const string DesertIslandUnqualified = "🏝" ;

		public const string NationalParkFullyQualified = "🏞️" ;

		public const string NationalParkUnqualified = "🏞" ;

		public const string StadiumFullyQualified = "🏟️" ;

		public const string StadiumUnqualified = "🏟" ;

		public const string ClassicalBuildingFullyQualified = "🏛️" ;

		public const string ClassicalBuildingUnqualified = "🏛" ;

		public const string BuildingConstructionFullyQualified = "🏗️" ;

		public const string BuildingConstructionUnqualified = "🏗" ;

		public const string Brick = "🧱" ;

		public const string Rock = "🪨" ;

		public const string Wood = "🪵" ;

		public const string Hut = "🛖" ;

		public const string HousesFullyQualified = "🏘️" ;

		public const string HousesUnqualified = "🏘" ;

		public const string DerelictHouseFullyQualified = "🏚️" ;

		public const string DerelictHouseUnqualified = "🏚" ;

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

		public const string ShintoShrineFullyQualified = "⛩️" ;

		public const string ShintoShrineUnqualified = "⛩" ;

		public const string Kaaba = "🕋" ;

		public const string Fountain = "⛲" ;

		public const string Tent = "⛺" ;

		public const string Foggy = "🌁" ;

		public const string NightWithStars = "🌃" ;

		public const string CityscapeFullyQualified = "🏙️" ;

		public const string CityscapeUnqualified = "🏙" ;

		public const string SunriseOverMountains = "🌄" ;

		public const string Sunrise = "🌅" ;

		public const string CityscapeAtDusk = "🌆" ;

		public const string Sunset = "🌇" ;

		public const string BridgeAtNight = "🌉" ;

		public const string HotSpringsFullyQualified = "♨️" ;

		public const string HotSpringsUnqualified = "♨" ;

		public const string CarouselHorse = "🎠" ;

		public const string PlaygroundSlide = "🛝" ;

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

		public const string PickupTruck = "🛻" ;

		public const string DeliveryTruck = "🚚" ;

		public const string ArticulatedLorry = "🚛" ;

		public const string Tractor = "🚜" ;

		public const string RacingCarFullyQualified = "🏎️" ;

		public const string RacingCarUnqualified = "🏎" ;

		public const string MotorcycleFullyQualified = "🏍️" ;

		public const string MotorcycleUnqualified = "🏍" ;

		public const string MotorScooter = "🛵" ;

		public const string ManualWheelchair = "🦽" ;

		public const string MotorizedWheelchair = "🦼" ;

		public const string AutoRickshaw = "🛺" ;

		public const string Bicycle = "🚲" ;

		public const string KickScooter = "🛴" ;

		public const string Skateboard = "🛹" ;

		public const string RollerSkate = "🛼" ;

		public const string BusStop = "🚏" ;

		public const string MotorwayFullyQualified = "🛣️" ;

		public const string MotorwayUnqualified = "🛣" ;

		public const string RailwayTrackFullyQualified = "🛤️" ;

		public const string RailwayTrackUnqualified = "🛤" ;

		public const string OilDrumFullyQualified = "🛢️" ;

		public const string OilDrumUnqualified = "🛢" ;

		public const string FuelPump = "⛽" ;

		public const string Wheel = "🛞" ;

		public const string PoliceCarLight = "🚨" ;

		public const string HorizontalTrafficLight = "🚥" ;

		public const string VerticalTrafficLight = "🚦" ;

		public const string StopSign = "🛑" ;

		public const string Construction = "🚧" ;

		public const string Anchor = "⚓" ;

		public const string RingBuoy = "🛟" ;

		public const string Sailboat = "⛵" ;

		public const string Canoe = "🛶" ;

		public const string Speedboat = "🚤" ;

		public const string PassengerShipFullyQualified = "🛳️" ;

		public const string PassengerShipUnqualified = "🛳" ;

		public const string FerryFullyQualified = "⛴️" ;

		public const string FerryUnqualified = "⛴" ;

		public const string MotorBoatFullyQualified = "🛥️" ;

		public const string MotorBoatUnqualified = "🛥" ;

		public const string Ship = "🚢" ;

		public const string AirplaneFullyQualified = "✈️" ;

		public const string AirplaneUnqualified = "✈" ;

		public const string SmallAirplaneFullyQualified = "🛩️" ;

		public const string SmallAirplaneUnqualified = "🛩" ;

		public const string AirplaneDeparture = "🛫" ;

		public const string AirplaneArrival = "🛬" ;

		public const string Parachute = "🪂" ;

		public const string Seat = "💺" ;

		public const string Helicopter = "🚁" ;

		public const string SuspensionRailway = "🚟" ;

		public const string MountainCableway = "🚠" ;

		public const string AerialTramway = "🚡" ;

		public const string SatelliteFullyQualified = "🛰️" ;

		public const string SatelliteUnqualified = "🛰" ;

		public const string Rocket = "🚀" ;

		public const string FlyingSaucer = "🛸" ;

		public const string BellhopBellFullyQualified = "🛎️" ;

		public const string BellhopBellUnqualified = "🛎" ;

		public const string Luggage = "🧳" ;

		public const string HourglassDone = "⌛" ;

		public const string HourglassNotDone = "⏳" ;

		public const string Watch = "⌚" ;

		public const string AlarmClock = "⏰" ;

		public const string StopwatchFullyQualified = "⏱️" ;

		public const string StopwatchUnqualified = "⏱" ;

		public const string TimerClockFullyQualified = "⏲️" ;

		public const string TimerClockUnqualified = "⏲" ;

		public const string MantelpieceClockFullyQualified = "🕰️" ;

		public const string MantelpieceClockUnqualified = "🕰" ;

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

		public const string ThermometerFullyQualified = "🌡️" ;

		public const string ThermometerUnqualified = "🌡" ;

		public const string SunFullyQualified = "☀️" ;

		public const string SunUnqualified = "☀" ;

		public const string FullMoonFace = "🌝" ;

		public const string SunWithFace = "🌞" ;

		public const string RingedPlanet = "🪐" ;

		public const string Star = "⭐" ;

		public const string GlowingStar = "🌟" ;

		public const string ShootingStar = "🌠" ;

		public const string MilkyWay = "🌌" ;

		public const string CloudFullyQualified = "☁️" ;

		public const string CloudUnqualified = "☁" ;

		public const string SunBehindCloud = "⛅" ;

		public const string CloudWithLightningAndRainFullyQualified = "⛈️" ;

		public const string CloudWithLightningAndRainUnqualified = "⛈" ;

		public const string SunBehindSmallCloudFullyQualified = "🌤️" ;

		public const string SunBehindSmallCloudUnqualified = "🌤" ;

		public const string SunBehindLargeCloudFullyQualified = "🌥️" ;

		public const string SunBehindLargeCloudUnqualified = "🌥" ;

		public const string SunBehindRainCloudFullyQualified = "🌦️" ;

		public const string SunBehindRainCloudUnqualified = "🌦" ;

		public const string CloudWithRainFullyQualified = "🌧️" ;

		public const string CloudWithRainUnqualified = "🌧" ;

		public const string CloudWithSnowFullyQualified = "🌨️" ;

		public const string CloudWithSnowUnqualified = "🌨" ;

		public const string CloudWithLightningFullyQualified = "🌩️" ;

		public const string CloudWithLightningUnqualified = "🌩" ;

		public const string TornadoFullyQualified = "🌪️" ;

		public const string TornadoUnqualified = "🌪" ;

		public const string FogFullyQualified = "🌫️" ;

		public const string FogUnqualified = "🌫" ;

		public const string WindFaceFullyQualified = "🌬️" ;

		public const string WindFaceUnqualified = "🌬" ;

		public const string Cyclone = "🌀" ;

		public const string Rainbow = "🌈" ;

		public const string ClosedUmbrella = "🌂" ;

		public const string UmbrellaFullyQualified = "☂️" ;

		public const string UmbrellaUnqualified = "☂" ;

		public const string UmbrellaWithRainDrops = "☔" ;

		public const string UmbrellaOnGroundFullyQualified = "⛱️" ;

		public const string UmbrellaOnGroundUnqualified = "⛱" ;

		public const string HighVoltage = "⚡" ;

		public const string SnowflakeFullyQualified = "❄️" ;

		public const string SnowflakeUnqualified = "❄" ;

		public const string SnowmanFullyQualified = "☃️" ;

		public const string SnowmanUnqualified = "☃" ;

		public const string SnowmanWithoutSnow = "⛄" ;

		public const string CometFullyQualified = "☄️" ;

		public const string CometUnqualified = "☄" ;

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

		public const string ReminderRibbonFullyQualified = "🎗️" ;

		public const string ReminderRibbonUnqualified = "🎗" ;

		public const string AdmissionTicketsFullyQualified = "🎟️" ;

		public const string AdmissionTicketsUnqualified = "🎟" ;

		public const string Ticket = "🎫" ;

		public const string MilitaryMedalFullyQualified = "🎖️" ;

		public const string MilitaryMedalUnqualified = "🎖" ;

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

		public const string IceSkateFullyQualified = "⛸️" ;

		public const string IceSkateUnqualified = "⛸" ;

		public const string FishingPole = "🎣" ;

		public const string DivingMask = "🤿" ;

		public const string RunningShirt = "🎽" ;

		public const string Skis = "🎿" ;

		public const string Sled = "🛷" ;

		public const string CurlingStone = "🥌" ;

		public const string Bullseye = "🎯" ;

		public const string YoYo = "🪀" ;

		public const string Kite = "🪁" ;

		public const string WaterPistol = "🔫" ;

		public const string Pool8Ball = "🎱" ;

		public const string CrystalBall = "🔮" ;

		public const string MagicWand = "🪄" ;

		public const string VideoGame = "🎮" ;

		public const string JoystickFullyQualified = "🕹️" ;

		public const string JoystickUnqualified = "🕹" ;

		public const string SlotMachine = "🎰" ;

		public const string GameDie = "🎲" ;

		public const string PuzzlePiece = "🧩" ;

		public const string TeddyBear = "🧸" ;

		public const string Pinata = "🪅" ;

		public const string MirrorBall = "🪩" ;

		public const string NestingDolls = "🪆" ;

		public const string SpadeSuitFullyQualified = "♠️" ;

		public const string SpadeSuitUnqualified = "♠" ;

		public const string HeartSuitFullyQualified = "♥️" ;

		public const string HeartSuitUnqualified = "♥" ;

		public const string DiamondSuitFullyQualified = "♦️" ;

		public const string DiamondSuitUnqualified = "♦" ;

		public const string ClubSuitFullyQualified = "♣️" ;

		public const string ClubSuitUnqualified = "♣" ;

		public const string ChessPawnFullyQualified = "♟️" ;

		public const string ChessPawnUnqualified = "♟" ;

		public const string Joker = "🃏" ;

		public const string MahjongRedDragon = "🀄" ;

		public const string FlowerPlayingCards = "🎴" ;

		public const string PerformingArts = "🎭" ;

		public const string FramedPictureFullyQualified = "🖼️" ;

		public const string FramedPictureUnqualified = "🖼" ;

		public const string ArtistPalette = "🎨" ;

		public const string Thread = "🧵" ;

		public const string SewingNeedle = "🪡" ;

		public const string Yarn = "🧶" ;

		public const string Knot = "🪢" ;

		public const string Glasses = "👓" ;

		public const string SunglassesFullyQualified = "🕶️" ;

		public const string SunglassesUnqualified = "🕶" ;

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

		public const string OnePieceSwimsuit = "🩱" ;

		public const string Briefs = "🩲" ;

		public const string Shorts = "🩳" ;

		public const string Bikini = "👙" ;

		public const string WomansClothes = "👚" ;

		public const string FoldingHandFan = "🪭" ;

		public const string Purse = "👛" ;

		public const string Handbag = "👜" ;

		public const string ClutchBag = "👝" ;

		public const string ShoppingBagsFullyQualified = "🛍️" ;

		public const string ShoppingBagsUnqualified = "🛍" ;

		public const string Backpack = "🎒" ;

		public const string ThongSandal = "🩴" ;

		public const string MansShoe = "👞" ;

		public const string RunningShoe = "👟" ;

		public const string HikingBoot = "🥾" ;

		public const string FlatShoe = "🥿" ;

		public const string HighHeeledShoe = "👠" ;

		public const string WomansSandal = "👡" ;

		public const string BalletShoes = "🩰" ;

		public const string WomansBoot = "👢" ;

		public const string HairPick = "🪮" ;

		public const string Crown = "👑" ;

		public const string WomansHat = "👒" ;

		public const string TopHat = "🎩" ;

		public const string GraduationCap = "🎓" ;

		public const string BilledCap = "🧢" ;

		public const string MilitaryHelmet = "🪖" ;

		public const string RescueWorkersHelmetFullyQualified = "⛑️" ;

		public const string RescueWorkersHelmetUnqualified = "⛑" ;

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

		public const string StudioMicrophoneFullyQualified = "🎙️" ;

		public const string StudioMicrophoneUnqualified = "🎙" ;

		public const string LevelSliderFullyQualified = "🎚️" ;

		public const string LevelSliderUnqualified = "🎚" ;

		public const string ControlKnobsFullyQualified = "🎛️" ;

		public const string ControlKnobsUnqualified = "🎛" ;

		public const string Microphone = "🎤" ;

		public const string Headphone = "🎧" ;

		public const string Radio = "📻" ;

		public const string Saxophone = "🎷" ;

		public const string Accordion = "🪗" ;

		public const string Guitar = "🎸" ;

		public const string MusicalKeyboard = "🎹" ;

		public const string Trumpet = "🎺" ;

		public const string Violin = "🎻" ;

		public const string Banjo = "🪕" ;

		public const string Drum = "🥁" ;

		public const string LongDrum = "🪘" ;

		public const string Maracas = "🪇" ;

		public const string Flute = "🪈" ;

		public const string MobilePhone = "📱" ;

		public const string MobilePhoneWithArrow = "📲" ;

		public const string TelephoneFullyQualified = "☎️" ;

		public const string TelephoneUnqualified = "☎" ;

		public const string TelephoneReceiver = "📞" ;

		public const string Pager = "📟" ;

		public const string FaxMachine = "📠" ;

		public const string Battery = "🔋" ;

		public const string LowBattery = "🪫" ;

		public const string ElectricPlug = "🔌" ;

		public const string Laptop = "💻" ;

		public const string DesktopComputerFullyQualified = "🖥️" ;

		public const string DesktopComputerUnqualified = "🖥" ;

		public const string PrinterFullyQualified = "🖨️" ;

		public const string PrinterUnqualified = "🖨" ;

		public const string KeyboardFullyQualified = "⌨️" ;

		public const string KeyboardUnqualified = "⌨" ;

		public const string ComputerMouseFullyQualified = "🖱️" ;

		public const string ComputerMouseUnqualified = "🖱" ;

		public const string TrackballFullyQualified = "🖲️" ;

		public const string TrackballUnqualified = "🖲" ;

		public const string ComputerDisk = "💽" ;

		public const string FloppyDisk = "💾" ;

		public const string OpticalDisk = "💿" ;

		public const string Dvd = "📀" ;

		public const string Abacus = "🧮" ;

		public const string MovieCamera = "🎥" ;

		public const string FilmFramesFullyQualified = "🎞️" ;

		public const string FilmFramesUnqualified = "🎞" ;

		public const string FilmProjectorFullyQualified = "📽️" ;

		public const string FilmProjectorUnqualified = "📽" ;

		public const string ClapperBoard = "🎬" ;

		public const string Television = "📺" ;

		public const string Camera = "📷" ;

		public const string CameraWithFlash = "📸" ;

		public const string VideoCamera = "📹" ;

		public const string Videocassette = "📼" ;

		public const string MagnifyingGlassTiltedLeft = "🔍" ;

		public const string MagnifyingGlassTiltedRight = "🔎" ;

		public const string CandleFullyQualified = "🕯️" ;

		public const string CandleUnqualified = "🕯" ;

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

		public const string RolledUpNewspaperFullyQualified = "🗞️" ;

		public const string RolledUpNewspaperUnqualified = "🗞" ;

		public const string BookmarkTabs = "📑" ;

		public const string Bookmark = "🔖" ;

		public const string LabelFullyQualified = "🏷️" ;

		public const string LabelUnqualified = "🏷" ;

		public const string MoneyBag = "💰" ;

		public const string Coin = "🪙" ;

		public const string YenBanknote = "💴" ;

		public const string DollarBanknote = "💵" ;

		public const string EuroBanknote = "💶" ;

		public const string PoundBanknote = "💷" ;

		public const string MoneyWithWings = "💸" ;

		public const string CreditCard = "💳" ;

		public const string Receipt = "🧾" ;

		public const string ChartIncreasingWithYen = "💹" ;

		public const string EnvelopeFullyQualified = "✉️" ;

		public const string EnvelopeUnqualified = "✉" ;

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

		public const string BallotBoxWithBallotFullyQualified = "🗳️" ;

		public const string BallotBoxWithBallotUnqualified = "🗳" ;

		public const string PencilFullyQualified = "✏️" ;

		public const string PencilUnqualified = "✏" ;

		public const string BlackNibFullyQualified = "✒️" ;

		public const string BlackNibUnqualified = "✒" ;

		public const string FountainPenFullyQualified = "🖋️" ;

		public const string FountainPenUnqualified = "🖋" ;

		public const string PenFullyQualified = "🖊️" ;

		public const string PenUnqualified = "🖊" ;

		public const string PaintbrushFullyQualified = "🖌️" ;

		public const string PaintbrushUnqualified = "🖌" ;

		public const string CrayonFullyQualified = "🖍️" ;

		public const string CrayonUnqualified = "🖍" ;

		public const string Memo = "📝" ;

		public const string Briefcase = "💼" ;

		public const string FileFolder = "📁" ;

		public const string OpenFileFolder = "📂" ;

		public const string CardIndexDividersFullyQualified = "🗂️" ;

		public const string CardIndexDividersUnqualified = "🗂" ;

		public const string Calendar = "📅" ;

		public const string TearOffCalendar = "📆" ;

		public const string SpiralNotepadFullyQualified = "🗒️" ;

		public const string SpiralNotepadUnqualified = "🗒" ;

		public const string SpiralCalendarFullyQualified = "🗓️" ;

		public const string SpiralCalendarUnqualified = "🗓" ;

		public const string CardIndex = "📇" ;

		public const string ChartIncreasing = "📈" ;

		public const string ChartDecreasing = "📉" ;

		public const string BarChart = "📊" ;

		public const string Clipboard = "📋" ;

		public const string Pushpin = "📌" ;

		public const string RoundPushpin = "📍" ;

		public const string Paperclip = "📎" ;

		public const string LinkedPaperclipsFullyQualified = "🖇️" ;

		public const string LinkedPaperclipsUnqualified = "🖇" ;

		public const string StraightRuler = "📏" ;

		public const string TriangularRuler = "📐" ;

		public const string ScissorsFullyQualified = "✂️" ;

		public const string ScissorsUnqualified = "✂" ;

		public const string CardFileBoxFullyQualified = "🗃️" ;

		public const string CardFileBoxUnqualified = "🗃" ;

		public const string FileCabinetFullyQualified = "🗄️" ;

		public const string FileCabinetUnqualified = "🗄" ;

		public const string WastebasketFullyQualified = "🗑️" ;

		public const string WastebasketUnqualified = "🗑" ;

		public const string Locked = "🔒" ;

		public const string Unlocked = "🔓" ;

		public const string LockedWithPen = "🔏" ;

		public const string LockedWithKey = "🔐" ;

		public const string Key = "🔑" ;

		public const string OldKeyFullyQualified = "🗝️" ;

		public const string OldKeyUnqualified = "🗝" ;

		public const string Hammer = "🔨" ;

		public const string Axe = "🪓" ;

		public const string PickFullyQualified = "⛏️" ;

		public const string PickUnqualified = "⛏" ;

		public const string HammerAndPickFullyQualified = "⚒️" ;

		public const string HammerAndPickUnqualified = "⚒" ;

		public const string HammerAndWrenchFullyQualified = "🛠️" ;

		public const string HammerAndWrenchUnqualified = "🛠" ;

		public const string DaggerFullyQualified = "🗡️" ;

		public const string DaggerUnqualified = "🗡" ;

		public const string CrossedSwordsFullyQualified = "⚔️" ;

		public const string CrossedSwordsUnqualified = "⚔" ;

		public const string Bomb = "💣" ;

		public const string Boomerang = "🪃" ;

		public const string BowAndArrow = "🏹" ;

		public const string ShieldFullyQualified = "🛡️" ;

		public const string ShieldUnqualified = "🛡" ;

		public const string CarpentrySaw = "🪚" ;

		public const string Wrench = "🔧" ;

		public const string Screwdriver = "🪛" ;

		public const string NutAndBolt = "🔩" ;

		public const string GearFullyQualified = "⚙️" ;

		public const string GearUnqualified = "⚙" ;

		public const string ClampFullyQualified = "🗜️" ;

		public const string ClampUnqualified = "🗜" ;

		public const string BalanceScaleFullyQualified = "⚖️" ;

		public const string BalanceScaleUnqualified = "⚖" ;

		public const string WhiteCane = "🦯" ;

		public const string Link = "🔗" ;

		public const string ChainsFullyQualified = "⛓️" ;

		public const string ChainsUnqualified = "⛓" ;

		public const string Hook = "🪝" ;

		public const string Toolbox = "🧰" ;

		public const string Magnet = "🧲" ;

		public const string Ladder = "🪜" ;

		public const string AlembicFullyQualified = "⚗️" ;

		public const string AlembicUnqualified = "⚗" ;

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

		public const string Crutch = "🩼" ;

		public const string Stethoscope = "🩺" ;

		public const string XRay = "🩻" ;

		public const string Door = "🚪" ;

		public const string Elevator = "🛗" ;

		public const string Mirror = "🪞" ;

		public const string Window = "🪟" ;

		public const string BedFullyQualified = "🛏️" ;

		public const string BedUnqualified = "🛏" ;

		public const string CouchAndLampFullyQualified = "🛋️" ;

		public const string CouchAndLampUnqualified = "🛋" ;

		public const string Chair = "🪑" ;

		public const string Toilet = "🚽" ;

		public const string Plunger = "🪠" ;

		public const string Shower = "🚿" ;

		public const string Bathtub = "🛁" ;

		public const string MouseTrap = "🪤" ;

		public const string Razor = "🪒" ;

		public const string LotionBottle = "🧴" ;

		public const string SafetyPin = "🧷" ;

		public const string Broom = "🧹" ;

		public const string Basket = "🧺" ;

		public const string RollOfPaper = "🧻" ;

		public const string Bucket = "🪣" ;

		public const string Soap = "🧼" ;

		public const string Bubbles = "🫧" ;

		public const string Toothbrush = "🪥" ;

		public const string Sponge = "🧽" ;

		public const string FireExtinguisher = "🧯" ;

		public const string ShoppingCart = "🛒" ;

		public const string Cigarette = "🚬" ;

		public const string CoffinFullyQualified = "⚰️" ;

		public const string CoffinUnqualified = "⚰" ;

		public const string Headstone = "🪦" ;

		public const string FuneralUrnFullyQualified = "⚱️" ;

		public const string FuneralUrnUnqualified = "⚱" ;

		public const string NazarAmulet = "🧿" ;

		public const string Hamsa = "🪬" ;

		public const string Moai = "🗿" ;

		public const string Placard = "🪧" ;

		public const string IdentificationCard = "🪪" ;

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

		public const string WarningFullyQualified = "⚠️" ;

		public const string WarningUnqualified = "⚠" ;

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

		public const string RadioactiveFullyQualified = "☢️" ;

		public const string RadioactiveUnqualified = "☢" ;

		public const string BiohazardFullyQualified = "☣️" ;

		public const string BiohazardUnqualified = "☣" ;

		public const string UpArrowFullyQualified = "⬆️" ;

		public const string UpArrowUnqualified = "⬆" ;

		public const string UpRightArrowFullyQualified = "↗️" ;

		public const string UpRightArrowUnqualified = "↗" ;

		public const string RightArrowFullyQualified = "➡️" ;

		public const string RightArrowUnqualified = "➡" ;

		public const string DownRightArrowFullyQualified = "↘️" ;

		public const string DownRightArrowUnqualified = "↘" ;

		public const string DownArrowFullyQualified = "⬇️" ;

		public const string DownArrowUnqualified = "⬇" ;

		public const string DownLeftArrowFullyQualified = "↙️" ;

		public const string DownLeftArrowUnqualified = "↙" ;

		public const string LeftArrowFullyQualified = "⬅️" ;

		public const string LeftArrowUnqualified = "⬅" ;

		public const string UpLeftArrowFullyQualified = "↖️" ;

		public const string UpLeftArrowUnqualified = "↖" ;

		public const string UpDownArrowFullyQualified = "↕️" ;

		public const string UpDownArrowUnqualified = "↕" ;

		public const string LeftRightArrowFullyQualified = "↔️" ;

		public const string LeftRightArrowUnqualified = "↔" ;

		public const string RightArrowCurvingLeftFullyQualified = "↩️" ;

		public const string RightArrowCurvingLeftUnqualified = "↩" ;

		public const string LeftArrowCurvingRightFullyQualified = "↪️" ;

		public const string LeftArrowCurvingRightUnqualified = "↪" ;

		public const string RightArrowCurvingUpFullyQualified = "⤴️" ;

		public const string RightArrowCurvingUpUnqualified = "⤴" ;

		public const string RightArrowCurvingDownFullyQualified = "⤵️" ;

		public const string RightArrowCurvingDownUnqualified = "⤵" ;

		public const string ClockwiseVerticalArrows = "🔃" ;

		public const string CounterclockwiseArrowsButton = "🔄" ;

		public const string BackArrow = "🔙" ;

		public const string EndArrow = "🔚" ;

		public const string OnArrow = "🔛" ;

		public const string SoonArrow = "🔜" ;

		public const string TopArrow = "🔝" ;

		public const string PlaceOfWorship = "🛐" ;

		public const string AtomSymbolFullyQualified = "⚛️" ;

		public const string AtomSymbolUnqualified = "⚛" ;

		public const string OmFullyQualified = "🕉️" ;

		public const string OmUnqualified = "🕉" ;

		public const string StarOfDavidFullyQualified = "✡️" ;

		public const string StarOfDavidUnqualified = "✡" ;

		public const string WheelOfDharmaFullyQualified = "☸️" ;

		public const string WheelOfDharmaUnqualified = "☸" ;

		public const string YinYangFullyQualified = "☯️" ;

		public const string YinYangUnqualified = "☯" ;

		public const string LatinCrossFullyQualified = "✝️" ;

		public const string LatinCrossUnqualified = "✝" ;

		public const string OrthodoxCrossFullyQualified = "☦️" ;

		public const string OrthodoxCrossUnqualified = "☦" ;

		public const string StarAndCrescentFullyQualified = "☪️" ;

		public const string StarAndCrescentUnqualified = "☪" ;

		public const string PeaceSymbolFullyQualified = "☮️" ;

		public const string PeaceSymbolUnqualified = "☮" ;

		public const string Menorah = "🕎" ;

		public const string DottedSixPointedStar = "🔯" ;

		public const string Khanda = "🪯" ;

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

		public const string PlayButtonFullyQualified = "▶️" ;

		public const string PlayButtonUnqualified = "▶" ;

		public const string FastForwardButton = "⏩" ;

		public const string NextTrackButtonFullyQualified = "⏭️" ;

		public const string NextTrackButtonUnqualified = "⏭" ;

		public const string PlayOrPauseButtonFullyQualified = "⏯️" ;

		public const string PlayOrPauseButtonUnqualified = "⏯" ;

		public const string ReverseButtonFullyQualified = "◀️" ;

		public const string ReverseButtonUnqualified = "◀" ;

		public const string FastReverseButton = "⏪" ;

		public const string LastTrackButtonFullyQualified = "⏮️" ;

		public const string LastTrackButtonUnqualified = "⏮" ;

		public const string UpwardsButton = "🔼" ;

		public const string FastUpButton = "⏫" ;

		public const string DownwardsButton = "🔽" ;

		public const string FastDownButton = "⏬" ;

		public const string PauseButtonFullyQualified = "⏸️" ;

		public const string PauseButtonUnqualified = "⏸" ;

		public const string StopButtonFullyQualified = "⏹️" ;

		public const string StopButtonUnqualified = "⏹" ;

		public const string RecordButtonFullyQualified = "⏺️" ;

		public const string RecordButtonUnqualified = "⏺" ;

		public const string EjectButtonFullyQualified = "⏏️" ;

		public const string EjectButtonUnqualified = "⏏" ;

		public const string Cinema = "🎦" ;

		public const string DimButton = "🔅" ;

		public const string BrightButton = "🔆" ;

		public const string AntennaBars = "📶" ;

		public const string Wireless = "🛜" ;

		public const string VibrationMode = "📳" ;

		public const string MobilePhoneOff = "📴" ;

		public const string FemaleSignFullyQualified = "♀️" ;

		public const string FemaleSignUnqualified = "♀" ;

		public const string MaleSignFullyQualified = "♂️" ;

		public const string MaleSignUnqualified = "♂" ;

		public const string TransgenderSymbolFullyQualified = "⚧️" ;

		public const string TransgenderSymbolUnqualified = "⚧" ;

		public const string MultiplyFullyQualified = "✖️" ;

		public const string MultiplyUnqualified = "✖" ;

		public const string Plus = "➕" ;

		public const string Minus = "➖" ;

		public const string Divide = "➗" ;

		public const string HeavyEqualsSign = "🟰" ;

		public const string InfinityFullyQualified = "♾️" ;

		public const string InfinityUnqualified = "♾" ;

		public const string DoubleExclamationMarkFullyQualified = "‼️" ;

		public const string DoubleExclamationMarkUnqualified = "‼" ;

		public const string ExclamationQuestionMarkFullyQualified = "⁉️" ;

		public const string ExclamationQuestionMarkUnqualified = "⁉" ;

		public const string RedQuestionMark = "❓" ;

		public const string WhiteQuestionMark = "❔" ;

		public const string WhiteExclamationMark = "❕" ;

		public const string RedExclamationMark = "❗" ;

		public const string WavyDashFullyQualified = "〰️" ;

		public const string WavyDashUnqualified = "〰" ;

		public const string CurrencyExchange = "💱" ;

		public const string HeavyDollarSign = "💲" ;

		public const string MedicalSymbolFullyQualified = "⚕️" ;

		public const string MedicalSymbolUnqualified = "⚕" ;

		public const string RecyclingSymbolFullyQualified = "♻️" ;

		public const string RecyclingSymbolUnqualified = "♻" ;

		public const string FleurDeLisFullyQualified = "⚜️" ;

		public const string FleurDeLisUnqualified = "⚜" ;

		public const string TridentEmblem = "🔱" ;

		public const string NameBadge = "📛" ;

		public const string JapaneseSymbolForBeginner = "🔰" ;

		public const string HollowRedCircle = "⭕" ;

		public const string CheckMarkButton = "✅" ;

		public const string CheckBoxWithCheckFullyQualified = "☑️" ;

		public const string CheckBoxWithCheckUnqualified = "☑" ;

		public const string CheckMarkFullyQualified = "✔️" ;

		public const string CheckMarkUnqualified = "✔" ;

		public const string CrossMark = "❌" ;

		public const string CrossMarkButton = "❎" ;

		public const string CurlyLoop = "➰" ;

		public const string DoubleCurlyLoop = "➿" ;

		public const string PartAlternationMarkFullyQualified = "〽️" ;

		public const string PartAlternationMarkUnqualified = "〽" ;

		public const string EightSpokedAsteriskFullyQualified = "✳️" ;

		public const string EightSpokedAsteriskUnqualified = "✳" ;

		public const string EightPointedStarFullyQualified = "✴️" ;

		public const string EightPointedStarUnqualified = "✴" ;

		public const string SparkleFullyQualified = "❇️" ;

		public const string SparkleUnqualified = "❇" ;

		public const string CopyrightFullyQualified = "©️" ;

		public const string CopyrightUnqualified = "©" ;

		public const string RegisteredFullyQualified = "®️" ;

		public const string RegisteredUnqualified = "®" ;

		public const string TradeMarkFullyQualified = "™️" ;

		public const string TradeMarkUnqualified = "™" ;

		public const string KeycapFullyQualified = "#️⃣" ;

		public const string KeycapUnqualified = "#⃣" ;

		public const string KeycapFullyQualified2 = "*️⃣" ;

		public const string KeycapUnqualified2 = "*⃣" ;

		public const string Keycap0FullyQualified = "0️⃣" ;

		public const string Keycap0Unqualified = "0⃣" ;

		public const string Keycap1FullyQualified = "1️⃣" ;

		public const string Keycap1Unqualified = "1⃣" ;

		public const string Keycap2FullyQualified = "2️⃣" ;

		public const string Keycap2Unqualified = "2⃣" ;

		public const string Keycap3FullyQualified = "3️⃣" ;

		public const string Keycap3Unqualified = "3⃣" ;

		public const string Keycap4FullyQualified = "4️⃣" ;

		public const string Keycap4Unqualified = "4⃣" ;

		public const string Keycap5FullyQualified = "5️⃣" ;

		public const string Keycap5Unqualified = "5⃣" ;

		public const string Keycap6FullyQualified = "6️⃣" ;

		public const string Keycap6Unqualified = "6⃣" ;

		public const string Keycap7FullyQualified = "7️⃣" ;

		public const string Keycap7Unqualified = "7⃣" ;

		public const string Keycap8FullyQualified = "8️⃣" ;

		public const string Keycap8Unqualified = "8⃣" ;

		public const string Keycap9FullyQualified = "9️⃣" ;

		public const string Keycap9Unqualified = "9⃣" ;

		public const string Keycap10 = "🔟" ;

		public const string InputLatinUppercase = "🔠" ;

		public const string InputLatinLowercase = "🔡" ;

		public const string InputNumbers = "🔢" ;

		public const string InputSymbols = "🔣" ;

		public const string InputLatinLetters = "🔤" ;

		public const string AButtonBloodTypeFullyQualified = "🅰️" ;

		public const string AButtonBloodTypeUnqualified = "🅰" ;

		public const string AbButtonBloodType = "🆎" ;

		public const string BButtonBloodTypeFullyQualified = "🅱️" ;

		public const string BButtonBloodTypeUnqualified = "🅱" ;

		public const string ClButton = "🆑" ;

		public const string CoolButton = "🆒" ;

		public const string FreeButton = "🆓" ;

		public const string InformationFullyQualified = "ℹ️" ;

		public const string InformationUnqualified = "ℹ" ;

		public const string IdButton = "🆔" ;

		public const string CircledMFullyQualified = "Ⓜ️" ;

		public const string CircledMUnqualified = "Ⓜ" ;

		public const string NewButton = "🆕" ;

		public const string NgButton = "🆖" ;

		public const string OButtonBloodTypeFullyQualified = "🅾️" ;

		public const string OButtonBloodTypeUnqualified = "🅾" ;

		public const string OkButton = "🆗" ;

		public const string PButtonFullyQualified = "🅿️" ;

		public const string PButtonUnqualified = "🅿" ;

		public const string SosButton = "🆘" ;

		public const string UpButton = "🆙" ;

		public const string VsButton = "🆚" ;

		public const string JapaneseHereButton = "🈁" ;

		public const string JapaneseServiceChargeButtonFullyQualified = "🈂️" ;

		public const string JapaneseServiceChargeButtonUnqualified = "🈂" ;

		public const string JapaneseMonthlyAmountButtonFullyQualified = "🈷️" ;

		public const string JapaneseMonthlyAmountButtonUnqualified = "🈷" ;

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

		public const string JapaneseCongratulationsButtonFullyQualified = "㊗️" ;

		public const string JapaneseCongratulationsButtonUnqualified = "㊗" ;

		public const string JapaneseSecretButtonFullyQualified = "㊙️" ;

		public const string JapaneseSecretButtonUnqualified = "㊙" ;

		public const string JapaneseOpenForBusinessButton = "🈺" ;

		public const string JapaneseNoVacancyButton = "🈵" ;

		public const string RedCircle = "🔴" ;

		public const string OrangeCircle = "🟠" ;

		public const string YellowCircle = "🟡" ;

		public const string GreenCircle = "🟢" ;

		public const string BlueCircle = "🔵" ;

		public const string PurpleCircle = "🟣" ;

		public const string BrownCircle = "🟤" ;

		public const string BlackCircle = "⚫" ;

		public const string WhiteCircle = "⚪" ;

		public const string RedSquare = "🟥" ;

		public const string OrangeSquare = "🟧" ;

		public const string YellowSquare = "🟨" ;

		public const string GreenSquare = "🟩" ;

		public const string BlueSquare = "🟦" ;

		public const string PurpleSquare = "🟪" ;

		public const string BrownSquare = "🟫" ;

		public const string BlackLargeSquare = "⬛" ;

		public const string WhiteLargeSquare = "⬜" ;

		public const string BlackMediumSquareFullyQualified = "◼️" ;

		public const string BlackMediumSquareUnqualified = "◼" ;

		public const string WhiteMediumSquareFullyQualified = "◻️" ;

		public const string WhiteMediumSquareUnqualified = "◻" ;

		public const string BlackMediumSmallSquare = "◾" ;

		public const string WhiteMediumSmallSquare = "◽" ;

		public const string BlackSmallSquareFullyQualified = "▪️" ;

		public const string BlackSmallSquareUnqualified = "▪" ;

		public const string WhiteSmallSquareFullyQualified = "▫️" ;

		public const string WhiteSmallSquareUnqualified = "▫" ;

		public const string LargeOrangeDiamond = "🔶" ;

		public const string LargeBlueDiamond = "🔷" ;

		public const string SmallOrangeDiamond = "🔸" ;

		public const string SmallBlueDiamond = "🔹" ;

		public const string RedTrianglePointedUp = "🔺" ;

		public const string RedTrianglePointedDown = "🔻" ;

		public const string DiamondWithADot = "💠" ;

		public const string RadioButton = "🔘" ;

		public const string WhiteSquareButton = "🔳" ;

		public const string BlackSquareButton = "🔲" ;

		public const string ChequeredFlag = "🏁" ;

		public const string TriangularFlag = "🚩" ;

		public const string CrossedFlags = "🎌" ;

		public const string BlackFlag = "🏴" ;

		public const string WhiteFlagFullyQualified = "🏳️" ;

		public const string WhiteFlagUnqualified = "🏳" ;

		public const string RainbowFlagFullyQualified = "🏳️‍🌈" ;

		public const string RainbowFlagUnqualified = "🏳‍🌈" ;

		public const string TransgenderFlagFullyQualified = "🏳️‍⚧️" ;

		public const string TransgenderFlagUnqualified = "🏳‍⚧️" ;

		public const string TransgenderFlagMinimallyQualified = "🏳️‍⚧" ;

		public const string TransgenderFlagUnqualified2 = "🏳‍⚧" ;

		public const string PirateFlagFullyQualified = "🏴‍☠️" ;

		public const string PirateFlagMinimallyQualified = "🏴‍☠" ;

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

		public const string FlagNorthMacedonia = "🇲🇰" ;

		public const string FlagMali = "🇲🇱" ;

		public const string FlagMyanmarBurma = "🇲🇲" ;

		public const string FlagMongolia = "🇲🇳" ;

		public const string FlagMacaoSarChina = "🇲🇴" ;

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

		public const string FlagEswatini = "🇸🇿" ;

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
