using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Linq ;
using System . Reflection ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Colors
{

	[PublicAPI]
	public static class KnownColor
	{

		public static ReadOnlyDictionary <string , HdrColor> Colors { get ; }

		static KnownColor ( )
		{
			Dictionary <string , HdrColor> colors =
				typeof ( KnownColor ) . GetFields ( BindingFlags . Static
													| BindingFlags . Public
													| BindingFlags . DeclaredOnly ) .
										ToDictionary ( fieldInfo => fieldInfo . Name ,
														fieldInfo => ( HdrColor ) fieldInfo . GetValue ( null ) ) ;

			Colors = new ReadOnlyDictionary <string , HdrColor> ( colors ) ;
		}

		public static readonly HdrColor ProcessYellow =
			new HdrColor ( 0.968627450980392 , 0.886274509803922 , 0.0784313725490196 ) ;

		public static readonly HdrColor Pms100 =
			new HdrColor ( 0.956862745098039 , 0.929411764705882 , 0.486274509803922 ) ;

		public static readonly HdrColor Pms101 =
			new HdrColor ( 0.956862745098039 , 0.929411764705882 , 0.27843137254902 ) ;

		public static readonly HdrColor Pms102 =
			new HdrColor ( 0.976470588235294 , 0.909803921568627 , 0.0784313725490196 ) ;

		public static readonly HdrColor PantoneYellow =
			new HdrColor ( 0.988235294117647 , 0.87843137254902 , 0.0862745098039216 ) ;

		public static readonly HdrColor Pms103 =
			new HdrColor ( 0.776470588235294 , 0.67843137254902 , 0.0588235294117647 ) ;

		public static readonly HdrColor Pms104 =
			new HdrColor ( 0.67843137254902 , 0.607843137254902 , 0.0470588235294118 ) ;

		public static readonly HdrColor Pms105 =
			new HdrColor ( 0.509803921568627 , 0.458823529411765 , 0.0588235294117647 ) ;

		public static readonly HdrColor Pms106 =
			new HdrColor ( 0.968627450980392 , 0.909803921568627 , 0.349019607843137 ) ;

		public static readonly HdrColor Pms107 =
			new HdrColor ( 0.976470588235294 , 0.898039215686275 , 0.149019607843137 ) ;

		public static readonly HdrColor Pms108 =
			new HdrColor ( 0.968627450980392 , 0.866666666666667 , 0.0862745098039216 ) ;

		public static readonly HdrColor Pms109 =
			new HdrColor ( 0.976470588235294 , 0.83921568627451 , 0.0862745098039216 ) ;

		public static readonly HdrColor Pms110 =
			new HdrColor ( 0.847058823529412 , 0.709803921568627 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms111 =
			new HdrColor ( 0.666666666666667 , 0.576470588235294 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms112 = new HdrColor ( 0.6 , 0.517647058823529 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms113 =
			new HdrColor ( 0.976470588235294 , 0.898039215686275 , 0.356862745098039 ) ;

		public static readonly HdrColor Pms114 =
			new HdrColor ( 0.976470588235294 , 0.886274509803922 , 0.298039215686275 ) ;

		public static readonly HdrColor Pms115 =
			new HdrColor ( 0.976470588235294 , 0.87843137254902 , 0.298039215686275 ) ;

		public static readonly HdrColor Pms116 =
			new HdrColor ( 0.988235294117647 , 0.819607843137255 , 0.0862745098039216 ) ;

		public static readonly HdrColor Pms117 =
			new HdrColor ( 0.776470588235294 , 0.627450980392157 , 0.0470588235294118 ) ;

		public static readonly HdrColor Pms118 =
			new HdrColor ( 0.666666666666667 , 0.556862745098039 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms119 =
			new HdrColor ( 0.537254901960784 , 0.466666666666667 , 0.0980392156862745 ) ;

		public static readonly HdrColor Pms120 =
			new HdrColor ( 0.976470588235294 , 0.886274509803922 , 0.498039215686275 ) ;

		public static readonly HdrColor Pms121 =
			new HdrColor ( 0.976470588235294 , 0.87843137254902 , 0.43921568627451 ) ;

		public static readonly HdrColor Pms122 =
			new HdrColor ( 0.988235294117647 , 0.847058823529412 , 0.337254901960784 ) ;

		public static readonly HdrColor Pms123 = new HdrColor ( 1 , 0.776470588235294 , 0.117647058823529 ) ;

		public static readonly HdrColor Pms124 =
			new HdrColor ( 0.87843137254902 , 0.666666666666667 , 0.0588235294117647 ) ;

		public static readonly HdrColor Pms125 =
			new HdrColor ( 0.709803921568627 , 0.549019607843137 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms1205 =
			new HdrColor ( 0.968627450980392 , 0.909803921568627 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms1215 =
			new HdrColor ( 0.976470588235294 , 0.87843137254902 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms1225 = new HdrColor ( 1 , 0.8 , 0.286274509803922 ) ;

		public static readonly HdrColor Pms1235 =
			new HdrColor ( 0.988235294117647 , 0.709803921568627 , 0.0784313725490196 ) ;

		public static readonly HdrColor Pms1245 =
			new HdrColor ( 0.749019607843137 , 0.568627450980392 , 0.0470588235294118 ) ;

		public static readonly HdrColor Pms1255 =
			new HdrColor ( 0.63921568627451 , 0.498039215686275 , 0.0784313725490196 ) ;

		public static readonly HdrColor Pms1265 =
			new HdrColor ( 0.486274509803922 , 0.388235294117647 , 0.0862745098039216 ) ;

		public static readonly HdrColor Pms127 =
			new HdrColor ( 0.956862745098039 , 0.886274509803922 , 0.529411764705882 ) ;

		public static readonly HdrColor Pms128 =
			new HdrColor ( 0.956862745098039 , 0.858823529411765 , 0.376470588235294 ) ;

		public static readonly HdrColor Pms129 =
			new HdrColor ( 0.949019607843137 , 0.819607843137255 , 0.23921568627451 ) ;

		public static readonly HdrColor Pms130 =
			new HdrColor ( 0.917647058823529 , 0.686274509803922 , 0.0588235294117647 ) ;

		public static readonly HdrColor Pms131 =
			new HdrColor ( 0.776470588235294 , 0.576470588235294 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms132 =
			new HdrColor ( 0.619607843137255 , 0.486274509803922 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms133 =
			new HdrColor ( 0.43921568627451 , 0.356862745098039 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms134 = new HdrColor ( 1 , 0.847058823529412 , 0.498039215686275 ) ;

		public static readonly HdrColor Pms135 =
			new HdrColor ( 0.988235294117647 , 0.788235294117647 , 0.388235294117647 ) ;

		public static readonly HdrColor Pms136 =
			new HdrColor ( 0.988235294117647 , 0.749019607843137 , 0.286274509803922 ) ;

		public static readonly HdrColor Pms137 =
			new HdrColor ( 0.988235294117647 , 0.63921568627451 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms138 =
			new HdrColor ( 0.847058823529412 , 0.549019607843137 , 0.00784313725490196 ) ;

		public static readonly HdrColor Pms139 =
			new HdrColor ( 0.686274509803922 , 0.458823529411765 , 0.0196078431372549 ) ;

		public static readonly HdrColor Pms140 =
			new HdrColor ( 0.47843137254902 , 0.356862745098039 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms1345 = new HdrColor ( 1 , 0.83921568627451 , 0.568627450980392 ) ;

		public static readonly HdrColor Pms1355 =
			new HdrColor ( 0.988235294117647 , 0.807843137254902 , 0.529411764705882 ) ;

		public static readonly HdrColor Pms1365 =
			new HdrColor ( 0.988235294117647 , 0.729411764705882 , 0.368627450980392 ) ;

		public static readonly HdrColor Pms1375 =
			new HdrColor ( 0.976470588235294 , 0.607843137254902 , 0.0470588235294118 ) ;

		public static readonly HdrColor Pms1385 = new HdrColor ( 0.8 , 0.47843137254902 , 0.00784313725490196 ) ;

		public static readonly HdrColor Pms1395 = new HdrColor ( 0.6 , 0.376470588235294 , 0.0274509803921569 ) ;

		public static readonly HdrColor Pms1405 =
			new HdrColor ( 0.419607843137255 , 0.27843137254902 , 0.0784313725490196 ) ;

		public static readonly HdrColor Pms141 =
			new HdrColor ( 0.949019607843137 , 0.807843137254902 , 0.407843137254902 ) ;

		public static readonly HdrColor Pms142 =
			new HdrColor ( 0.949019607843137 , 0.749019607843137 , 0.286274509803922 ) ;

		public static readonly HdrColor Pms143 =
			new HdrColor ( 0.937254901960784 , 0.698039215686274 , 0.176470588235294 ) ;

		public static readonly HdrColor Pms144 =
			new HdrColor ( 0.886274509803922 , 0.549019607843137 , 0.0196078431372549 ) ;

		public static readonly HdrColor Pms145 =
			new HdrColor ( 0.776470588235294 , 0.498039215686275 , 0.0274509803921569 ) ;

		public static readonly HdrColor Pms146 =
			new HdrColor ( 0.619607843137255 , 0.419607843137255 , 0.0196078431372549 ) ;

		public static readonly HdrColor Pms147 =
			new HdrColor ( 0.447058823529412 , 0.368627450980392 , 0.149019607843137 ) ;

		public static readonly HdrColor Pms148 = new HdrColor ( 1 , 0.83921568627451 , 0.607843137254902 ) ;

		public static readonly HdrColor Pms149 = new HdrColor ( 0.988235294117647 , 0.8 , 0.576470588235294 ) ;

		public static readonly HdrColor Pms150 =
			new HdrColor ( 0.988235294117647 , 0.67843137254902 , 0.337254901960784 ) ;

		public static readonly HdrColor Pms151 = new HdrColor ( 0.968627450980392 , 0.498039215686275 , 0 ) ;

		public static readonly HdrColor Pms152 = new HdrColor ( 0.866666666666667 , 0.458823529411765 , 0 ) ;

		public static readonly HdrColor Pms153 =
			new HdrColor ( 0.737254901960784 , 0.427450980392157 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms154 = new HdrColor ( 0.6 , 0.349019607843137 , 0.0196078431372549 ) ;

		public static readonly HdrColor Pms1485 = new HdrColor ( 1 , 0.717647058823529 , 0.466666666666667 ) ;

		public static readonly HdrColor Pms1495 = new HdrColor ( 1 , 0.6 , 0.247058823529412 ) ;

		public static readonly HdrColor Pms1505 = new HdrColor ( 0.956862745098039 , 0.486274509803922 , 0 ) ;

		public static readonly HdrColor Orange021 = new HdrColor ( 0.937254901960784 , 0.419607843137255 , 0 ) ;

		public static readonly HdrColor Pms1525 = new HdrColor ( 0.709803921568627 , 0.329411764705882 , 0 ) ;

		public static readonly HdrColor Pms1535 = new HdrColor ( 0.549019607843137 , 0.266666666666667 , 0 ) ;

		public static readonly HdrColor Pms1545 =
			new HdrColor ( 0.298039215686275 , 0.156862745098039 , 0.0588235294117647 ) ;

		public static readonly HdrColor Pms155 =
			new HdrColor ( 0.956862745098039 , 0.858823529411765 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms156 =
			new HdrColor ( 0.949019607843137 , 0.776470588235294 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms157 =
			new HdrColor ( 0.929411764705882 , 0.627450980392157 , 0.309803921568627 ) ;

		public static readonly HdrColor Pms158 =
			new HdrColor ( 0.909803921568627 , 0.458823529411765 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms159 =
			new HdrColor ( 0.776470588235294 , 0.376470588235294 , 0.0196078431372549 ) ;

		public static readonly HdrColor Pms160 =
			new HdrColor ( 0.619607843137255 , 0.329411764705882 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms161 =
			new HdrColor ( 0.388235294117647 , 0.227450980392157 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms1555 =
			new HdrColor ( 0.976470588235294 , 0.749019607843137 , 0.619607843137255 ) ;

		public static readonly HdrColor Pms1565 =
			new HdrColor ( 0.988235294117647 , 0.647058823529412 , 0.466666666666667 ) ;

		public static readonly HdrColor Pms1575 =
			new HdrColor ( 0.988235294117647 , 0.529411764705882 , 0.266666666666667 ) ;

		public static readonly HdrColor Pms1585 =
			new HdrColor ( 0.976470588235294 , 0.419607843137255 , 0.0274509803921569 ) ;

		public static readonly HdrColor Pms1595 =
			new HdrColor ( 0.819607843137255 , 0.356862745098039 , 0.0196078431372549 ) ;

		public static readonly HdrColor Pms1605 =
			new HdrColor ( 0.627450980392157 , 0.309803921568627 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms1615 =
			new HdrColor ( 0.517647058823529 , 0.247058823529412 , 0.0588235294117647 ) ;

		public static readonly HdrColor Pms162 =
			new HdrColor ( 0.976470588235294 , 0.776470588235294 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms163 =
			new HdrColor ( 0.988235294117647 , 0.619607843137255 , 0.43921568627451 ) ;

		public static readonly HdrColor Pms164 =
			new HdrColor ( 0.988235294117647 , 0.498039215686275 , 0.247058823529412 ) ;

		public static readonly HdrColor Pms165 =
			new HdrColor ( 0.976470588235294 , 0.388235294117647 , 0.00784313725490196 ) ;

		public static readonly HdrColor Pms166 = new HdrColor ( 0.866666666666667 , 0.349019607843137 , 0 ) ;

		public static readonly HdrColor Pms167 =
			new HdrColor ( 0.737254901960784 , 0.309803921568627 , 0.0274509803921569 ) ;

		public static readonly HdrColor Pms168 =
			new HdrColor ( 0.427450980392157 , 0.188235294117647 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms1625 =
			new HdrColor ( 0.976470588235294 , 0.647058823529412 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms1635 =
			new HdrColor ( 0.976470588235294 , 0.556862745098039 , 0.427450980392157 ) ;

		public static readonly HdrColor Pms1645 =
			new HdrColor ( 0.976470588235294 , 0.447058823529412 , 0.258823529411765 ) ;

		public static readonly HdrColor Pms1655 =
			new HdrColor ( 0.976470588235294 , 0.337254901960784 , 0.00784313725490196 ) ;

		public static readonly HdrColor Pms1665 =
			new HdrColor ( 0.976470588235294 , 0.337254901960784 , 0.00784313725490196 ) ;

		public static readonly HdrColor Pms1675 =
			new HdrColor ( 0.647058823529412 , 0.247058823529412 , 0.0588235294117647 ) ;

		public static readonly HdrColor Pms1685 =
			new HdrColor ( 0.517647058823529 , 0.207843137254902 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms169 =
			new HdrColor ( 0.976470588235294 , 0.729411764705882 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms170 =
			new HdrColor ( 0.976470588235294 , 0.537254901960784 , 0.447058823529412 ) ;

		public static readonly HdrColor Pms171 =
			new HdrColor ( 0.976470588235294 , 0.376470588235294 , 0.227450980392157 ) ;

		public static readonly HdrColor Pms172 =
			new HdrColor ( 0.968627450980392 , 0.286274509803922 , 0.00784313725490196 ) ;

		public static readonly HdrColor Pms173 =
			new HdrColor ( 0.819607843137255 , 0.266666666666667 , 0.0784313725490196 ) ;

		public static readonly HdrColor Pms174 = new HdrColor ( 0.576470588235294 , 0.2 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms175 = new HdrColor ( 0.427450980392157 , 0.2 , 0.129411764705882 ) ;

		public static readonly HdrColor Pms176 =
			new HdrColor ( 0.976470588235294 , 0.686274509803922 , 0.67843137254902 ) ;

		public static readonly HdrColor Pms177 =
			new HdrColor ( 0.976470588235294 , 0.509803921568627 , 0.498039215686275 ) ;

		public static readonly HdrColor Pms178 =
			new HdrColor ( 0.976470588235294 , 0.368627450980392 , 0.349019607843137 ) ;

		public static readonly HdrColor WarmRed =
			new HdrColor ( 0.976470588235294 , 0.247058823529412 , 0.149019607843137 ) ;

		public static readonly HdrColor Pms179 =
			new HdrColor ( 0.886274509803922 , 0.23921568627451 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms180 =
			new HdrColor ( 0.756862745098039 , 0.219607843137255 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms181 =
			new HdrColor ( 0.486274509803922 , 0.176470588235294 , 0.137254901960784 ) ;

		public static readonly HdrColor Pms1765 =
			new HdrColor ( 0.976470588235294 , 0.619607843137255 , 0.63921568627451 ) ;

		public static readonly HdrColor Pms1775 =
			new HdrColor ( 0.976470588235294 , 0.517647058823529 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms1785 =
			new HdrColor ( 0.988235294117647 , 0.309803921568627 , 0.349019607843137 ) ;

		public static readonly HdrColor Pms1788 =
			new HdrColor ( 0.937254901960784 , 0.168627450980392 , 0.176470588235294 ) ;

		public static readonly HdrColor Pms1795 =
			new HdrColor ( 0.83921568627451 , 0.156862745098039 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms1805 =
			new HdrColor ( 0.686274509803922 , 0.149019607843137 , 0.149019607843137 ) ;

		public static readonly HdrColor Pms1815 =
			new HdrColor ( 0.486274509803922 , 0.129411764705882 , 0.117647058823529 ) ;

		public static readonly HdrColor Pms1767 =
			new HdrColor ( 0.976470588235294 , 0.698039215686274 , 0.717647058823529 ) ;

		public static readonly HdrColor Pms1777 = new HdrColor ( 0.988235294117647 , 0.4 , 0.458823529411765 ) ;

		public static readonly HdrColor Pms1787 =
			new HdrColor ( 0.956862745098039 , 0.247058823529412 , 0.309803921568627 ) ;

		public static readonly HdrColor Red032 =
			new HdrColor ( 0.937254901960784 , 0.168627450980392 , 0.176470588235294 ) ;

		public static readonly HdrColor Pms1797 = new HdrColor ( 0.8 , 0.176470588235294 , 0.188235294117647 ) ;

		public static readonly HdrColor Pms1807 = new HdrColor ( 0.627450980392157 , 0.188235294117647 , 0.2 ) ;

		public static readonly HdrColor Pms1817 =
			new HdrColor ( 0.356862745098039 , 0.176470588235294 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms182 =
			new HdrColor ( 0.976470588235294 , 0.749019607843137 , 0.756862745098039 ) ;

		public static readonly HdrColor Pms183 = new HdrColor ( 0.988235294117647 , 0.549019607843137 , 0.6 ) ;

		public static readonly HdrColor Pms184 =
			new HdrColor ( 0.988235294117647 , 0.368627450980392 , 0.447058823529412 ) ;

		public static readonly HdrColor Pms185 =
			new HdrColor ( 0.909803921568627 , 0.0666666666666667 , 0.176470588235294 ) ;

		public static readonly HdrColor Pms186 =
			new HdrColor ( 0.807843137254902 , 0.0666666666666667 , 0.149019607843137 ) ;

		public static readonly HdrColor Pms187 =
			new HdrColor ( 0.686274509803922 , 0.117647058823529 , 0.176470588235294 ) ;

		public static readonly HdrColor Pms188 =
			new HdrColor ( 0.486274509803922 , 0.129411764705882 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms189 = new HdrColor ( 1 , 0.63921568627451 , 0.698039215686274 ) ;

		public static readonly HdrColor Pms190 =
			new HdrColor ( 0.988235294117647 , 0.458823529411765 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms191 =
			new HdrColor ( 0.956862745098039 , 0.27843137254902 , 0.419607843137255 ) ;

		public static readonly HdrColor Pms192 =
			new HdrColor ( 0.898039215686275 , 0.0196078431372549 , 0.227450980392157 ) ;

		public static readonly HdrColor Pms193 =
			new HdrColor ( 0.749019607843137 , 0.0392156862745098 , 0.188235294117647 ) ;

		public static readonly HdrColor Pms194 = new HdrColor ( 0.6 , 0.129411764705882 , 0.207843137254902 ) ;

		public static readonly HdrColor Pms195 =
			new HdrColor ( 0.466666666666667 , 0.176470588235294 , 0.207843137254902 ) ;

		public static readonly HdrColor Pms1895 =
			new HdrColor ( 0.988235294117647 , 0.749019607843137 , 0.788235294117647 ) ;

		public static readonly HdrColor Pms1905 =
			new HdrColor ( 0.988235294117647 , 0.607843137254902 , 0.698039215686274 ) ;

		public static readonly HdrColor Pms1915 =
			new HdrColor ( 0.956862745098039 , 0.329411764705882 , 0.486274509803922 ) ;

		public static readonly HdrColor Pms1925 =
			new HdrColor ( 0.87843137254902 , 0.0274509803921569 , 0.27843137254902 ) ;

		public static readonly HdrColor Pms1935 =
			new HdrColor ( 0.756862745098039 , 0.0196078431372549 , 0.219607843137255 ) ;

		public static readonly HdrColor Pms1945 =
			new HdrColor ( 0.658823529411765 , 0.0470588235294118 , 0.207843137254902 ) ;

		public static readonly HdrColor Pms1955 =
			new HdrColor ( 0.576470588235294 , 0.0862745098039216 , 0.219607843137255 ) ;

		public static readonly HdrColor Pms196 =
			new HdrColor ( 0.956862745098039 , 0.788235294117647 , 0.788235294117647 ) ;

		public static readonly HdrColor Pms197 = new HdrColor ( 0.937254901960784 , 0.6 , 0.63921568627451 ) ;

		public static readonly HdrColor Pms198 =
			new HdrColor ( 0.898039215686275 , 0.337254901960784 , 0.427450980392157 ) ;

		public static readonly HdrColor Pms199 =
			new HdrColor ( 0.847058823529412 , 0.109803921568627 , 0.247058823529412 ) ;

		public static readonly HdrColor Pms200 =
			new HdrColor ( 0.768627450980392 , 0.117647058823529 , 0.227450980392157 ) ;

		public static readonly HdrColor Pms201 =
			new HdrColor ( 0.63921568627451 , 0.149019607843137 , 0.219607843137255 ) ;

		public static readonly HdrColor Pms202 = new HdrColor ( 0.549019607843137 , 0.149019607843137 , 0.2 ) ;

		public static readonly HdrColor Pms203 =
			new HdrColor ( 0.949019607843137 , 0.686274509803922 , 0.756862745098039 ) ;

		public static readonly HdrColor Pms204 =
			new HdrColor ( 0.929411764705882 , 0.47843137254902 , 0.619607843137255 ) ;

		public static readonly HdrColor Pms205 =
			new HdrColor ( 0.898039215686275 , 0.298039215686275 , 0.486274509803922 ) ;

		public static readonly HdrColor Pms206 =
			new HdrColor ( 0.827450980392157 , 0.0196078431372549 , 0.27843137254902 ) ;

		public static readonly HdrColor Pms207 = new HdrColor ( 0.686274509803922 , 0 , 0.23921568627451 ) ;

		public static readonly HdrColor Pms208 =
			new HdrColor ( 0.556862745098039 , 0.137254901960784 , 0.266666666666667 ) ;

		public static readonly HdrColor Pms209 =
			new HdrColor ( 0.458823529411765 , 0.149019607843137 , 0.23921568627451 ) ;

		public static readonly HdrColor Pms210 = new HdrColor ( 1 , 0.627450980392157 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms211 = new HdrColor ( 1 , 0.466666666666667 , 0.658823529411765 ) ;

		public static readonly HdrColor Pms212 =
			new HdrColor ( 0.976470588235294 , 0.309803921568627 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms213 =
			new HdrColor ( 0.917647058823529 , 0.0588235294117647 , 0.419607843137255 ) ;

		public static readonly HdrColor Pms214 = new HdrColor ( 0.8 , 0.00784313725490196 , 0.337254901960784 ) ;

		public static readonly HdrColor Pms215 =
			new HdrColor ( 0.647058823529412 , 0.0196078431372549 , 0.266666666666667 ) ;

		public static readonly HdrColor Pms216 =
			new HdrColor ( 0.486274509803922 , 0.117647058823529 , 0.247058823529412 ) ;

		public static readonly HdrColor Pms217 =
			new HdrColor ( 0.956862745098039 , 0.749019607843137 , 0.819607843137255 ) ;

		public static readonly HdrColor Pms218 =
			new HdrColor ( 0.929411764705882 , 0.447058823529412 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms219 =
			new HdrColor ( 0.886274509803922 , 0.156862745098039 , 0.509803921568627 ) ;

		public static readonly HdrColor RubineRed = new HdrColor ( 0.819607843137255 , 0 , 0.337254901960784 ) ;

		public static readonly HdrColor Pms220 = new HdrColor ( 0.666666666666667 , 0 , 0.309803921568627 ) ;

		public static readonly HdrColor Pms221 = new HdrColor ( 0.576470588235294 , 0 , 0.258823529411765 ) ;

		public static readonly HdrColor Pms222 =
			new HdrColor ( 0.43921568627451 , 0.0980392156862745 , 0.23921568627451 ) ;

		public static readonly HdrColor Pms223 =
			new HdrColor ( 0.976470588235294 , 0.576470588235294 , 0.768627450980392 ) ;

		public static readonly HdrColor Pms224 =
			new HdrColor ( 0.956862745098039 , 0.419607843137255 , 0.686274509803922 ) ;

		public static readonly HdrColor Pms225 =
			new HdrColor ( 0.929411764705882 , 0.156862745098039 , 0.576470588235294 ) ;

		public static readonly HdrColor Pms226 =
			new HdrColor ( 0.83921568627451 , 0.00784313725490196 , 0.43921568627451 ) ;

		public static readonly HdrColor Pms227 = new HdrColor ( 0.67843137254902 , 0 , 0.356862745098039 ) ;

		public static readonly HdrColor Pms228 = new HdrColor ( 0.549019607843137 , 0 , 0.298039215686275 ) ;

		public static readonly HdrColor Pms229 =
			new HdrColor ( 0.427450980392157 , 0.129411764705882 , 0.247058823529412 ) ;

		public static readonly HdrColor Pms230 = new HdrColor ( 1 , 0.627450980392157 , 0.8 ) ;

		public static readonly HdrColor Pms231 =
			new HdrColor ( 0.988235294117647 , 0.43921568627451 , 0.729411764705882 ) ;

		public static readonly HdrColor Pms232 =
			new HdrColor ( 0.956862745098039 , 0.247058823529412 , 0.647058823529412 ) ;

		public static readonly HdrColor RhodamineRed = new HdrColor ( 0.929411764705882 , 0 , 0.568627450980392 ) ;

		public static readonly HdrColor Pms233 = new HdrColor ( 0.807843137254902 , 0 , 0.486274509803922 ) ;

		public static readonly HdrColor Pms234 = new HdrColor ( 0.666666666666667 , 0 , 0.4 ) ;

		public static readonly HdrColor Pms235 =
			new HdrColor ( 0.556862745098039 , 0.0196078431372549 , 0.329411764705882 ) ;

		public static readonly HdrColor Pms236 =
			new HdrColor ( 0.976470588235294 , 0.686274509803922 , 0.827450980392157 ) ;

		public static readonly HdrColor Pms237 =
			new HdrColor ( 0.956862745098039 , 0.517647058823529 , 0.768627450980392 ) ;

		public static readonly HdrColor Pms238 =
			new HdrColor ( 0.929411764705882 , 0.309803921568627 , 0.686274509803922 ) ;

		public static readonly HdrColor Pms239 =
			new HdrColor ( 0.87843137254902 , 0.129411764705882 , 0.619607843137255 ) ;

		public static readonly HdrColor Pms240 =
			new HdrColor ( 0.768627450980392 , 0.0588235294117647 , 0.537254901960784 ) ;

		public static readonly HdrColor Pms241 = new HdrColor ( 0.67843137254902 , 0 , 0.458823529411765 ) ;

		public static readonly HdrColor Pms242 =
			new HdrColor ( 0.486274509803922 , 0.109803921568627 , 0.317647058823529 ) ;

		public static readonly HdrColor Pms2365 =
			new HdrColor ( 0.968627450980392 , 0.768627450980392 , 0.847058823529412 ) ;

		public static readonly HdrColor Pms2375 =
			new HdrColor ( 0.917647058823529 , 0.419607843137255 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms2385 =
			new HdrColor ( 0.858823529411765 , 0.156862745098039 , 0.647058823529412 ) ;

		public static readonly HdrColor Pms2395 = new HdrColor ( 0.768627450980392 , 0 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms2405 = new HdrColor ( 0.658823529411765 , 0 , 0.47843137254902 ) ;

		public static readonly HdrColor Pms2415 = new HdrColor ( 0.607843137254902 , 0 , 0.43921568627451 ) ;

		public static readonly HdrColor Pms2425 = new HdrColor ( 0.529411764705882 , 0 , 0.356862745098039 ) ;

		public static readonly HdrColor Pms243 =
			new HdrColor ( 0.949019607843137 , 0.729411764705882 , 0.847058823529412 ) ;

		public static readonly HdrColor Pms244 =
			new HdrColor ( 0.929411764705882 , 0.627450980392157 , 0.827450980392157 ) ;

		public static readonly HdrColor Pms245 =
			new HdrColor ( 0.909803921568627 , 0.498039215686275 , 0.788235294117647 ) ;

		public static readonly HdrColor Pms246 = new HdrColor ( 0.8 , 0 , 0.627450980392157 ) ;

		public static readonly HdrColor Pms247 = new HdrColor ( 0.717647058823529 , 0 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms248 =
			new HdrColor ( 0.63921568627451 , 0.0196078431372549 , 0.498039215686275 ) ;

		public static readonly HdrColor Pms249 =
			new HdrColor ( 0.498039215686275 , 0.156862745098039 , 0.376470588235294 ) ;

		public static readonly HdrColor Pms250 =
			new HdrColor ( 0.929411764705882 , 0.768627450980392 , 0.866666666666667 ) ;

		public static readonly HdrColor Pms251 =
			new HdrColor ( 0.886274509803922 , 0.619607843137255 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms252 =
			new HdrColor ( 0.827450980392157 , 0.419607843137255 , 0.776470588235294 ) ;

		public static readonly HdrColor Purple =
			new HdrColor ( 0.749019607843137 , 0.188235294117647 , 0.709803921568627 ) ;

		public static readonly HdrColor Pms253 =
			new HdrColor ( 0.686274509803922 , 0.137254901960784 , 0.647058823529412 ) ;

		public static readonly HdrColor Pms254 =
			new HdrColor ( 0.627450980392157 , 0.176470588235294 , 0.588235294117647 ) ;

		public static readonly HdrColor Pms255 =
			new HdrColor ( 0.466666666666667 , 0.176470588235294 , 0.419607843137255 ) ;

		public static readonly HdrColor Pms256 =
			new HdrColor ( 0.898039215686275 , 0.768627450980392 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms257 =
			new HdrColor ( 0.827450980392157 , 0.647058823529412 , 0.788235294117647 ) ;

		public static readonly HdrColor Pms258 =
			new HdrColor ( 0.607843137254902 , 0.309803921568627 , 0.588235294117647 ) ;

		public static readonly HdrColor Pms259 =
			new HdrColor ( 0.447058823529412 , 0.0862745098039216 , 0.419607843137255 ) ;

		public static readonly HdrColor Pms260 =
			new HdrColor ( 0.407843137254902 , 0.117647058823529 , 0.356862745098039 ) ;

		public static readonly HdrColor Pms261 =
			new HdrColor ( 0.368627450980392 , 0.129411764705882 , 0.329411764705882 ) ;

		public static readonly HdrColor Pms262 =
			new HdrColor ( 0.329411764705882 , 0.137254901960784 , 0.266666666666667 ) ;

		public static readonly HdrColor Pms2562 =
			new HdrColor ( 0.847058823529412 , 0.658823529411765 , 0.847058823529412 ) ;

		public static readonly HdrColor Pms2572 =
			new HdrColor ( 0.776470588235294 , 0.529411764705882 , 0.819607843137255 ) ;

		public static readonly HdrColor Pms2582 =
			new HdrColor ( 0.666666666666667 , 0.27843137254902 , 0.729411764705882 ) ;

		public static readonly HdrColor Pms2592 =
			new HdrColor ( 0.576470588235294 , 0.0588235294117647 , 0.647058823529412 ) ;

		public static readonly HdrColor Pms2602 =
			new HdrColor ( 0.509803921568627 , 0.0470588235294118 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms2612 =
			new HdrColor ( 0.43921568627451 , 0.117647058823529 , 0.447058823529412 ) ;

		public static readonly HdrColor Pms2622 =
			new HdrColor ( 0.376470588235294 , 0.176470588235294 , 0.349019607843137 ) ;

		public static readonly HdrColor Pms2563 = new HdrColor ( 0.819607843137255 , 0.627450980392157 , 0.8 ) ;

		public static readonly HdrColor Pms2573 =
			new HdrColor ( 0.729411764705882 , 0.486274509803922 , 0.737254901960784 ) ;

		public static readonly HdrColor Pms2583 =
			new HdrColor ( 0.619607843137255 , 0.309803921568627 , 0.647058823529412 ) ;

		public static readonly HdrColor Pms2593 =
			new HdrColor ( 0.529411764705882 , 0.168627450980392 , 0.576470588235294 ) ;

		public static readonly HdrColor Pms2603 =
			new HdrColor ( 0.43921568627451 , 0.0784313725490196 , 0.47843137254902 ) ;

		public static readonly HdrColor Pms2613 = new HdrColor ( 0.4 , 0.0666666666666667 , 0.427450980392157 ) ;

		public static readonly HdrColor Pms2623 =
			new HdrColor ( 0.356862745098039 , 0.0980392156862745 , 0.368627450980392 ) ;

		public static readonly HdrColor Pms2567 = new HdrColor ( 0.749019607843137 , 0.576470588235294 , 0.8 ) ;

		public static readonly HdrColor Pms2577 =
			new HdrColor ( 0.666666666666667 , 0.447058823529412 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms2587 =
			new HdrColor ( 0.556862745098039 , 0.27843137254902 , 0.67843137254902 ) ;

		public static readonly HdrColor Pms2597 = new HdrColor ( 0.4 , 0 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms2607 =
			new HdrColor ( 0.356862745098039 , 0.00784313725490196 , 0.47843137254902 ) ;

		public static readonly HdrColor Pms2617 =
			new HdrColor ( 0.337254901960784 , 0.0470588235294118 , 0.43921568627451 ) ;

		public static readonly HdrColor Pms2627 =
			new HdrColor ( 0.298039215686275 , 0.0784313725490196 , 0.368627450980392 ) ;

		public static readonly HdrColor Pms263 =
			new HdrColor ( 0.87843137254902 , 0.807843137254902 , 0.87843137254902 ) ;

		public static readonly HdrColor Pms264 =
			new HdrColor ( 0.776470588235294 , 0.666666666666667 , 0.858823529411765 ) ;

		public static readonly HdrColor Pms265 =
			new HdrColor ( 0.588235294117647 , 0.388235294117647 , 0.768627450980392 ) ;

		public static readonly HdrColor Pms266 =
			new HdrColor ( 0.427450980392157 , 0.156862745098039 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms267 =
			new HdrColor ( 0.349019607843137 , 0.0666666666666667 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms268 =
			new HdrColor ( 0.309803921568627 , 0.129411764705882 , 0.43921568627451 ) ;

		public static readonly HdrColor Pms269 =
			new HdrColor ( 0.266666666666667 , 0.137254901960784 , 0.349019607843137 ) ;

		public static readonly HdrColor Pms2635 =
			new HdrColor ( 0.788235294117647 , 0.67843137254902 , 0.847058823529412 ) ;

		public static readonly HdrColor Pms2645 =
			new HdrColor ( 0.709803921568627 , 0.568627450980392 , 0.819607843137255 ) ;

		public static readonly HdrColor Pms2655 =
			new HdrColor ( 0.607843137254902 , 0.427450980392157 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms2665 =
			new HdrColor ( 0.537254901960784 , 0.309803921568627 , 0.749019607843137 ) ;

		public static readonly HdrColor Violet = new HdrColor ( 0.4 , 0.0274509803921569 , 0.647058823529412 ) ;

		public static readonly HdrColor Pms2685 = new HdrColor ( 0.337254901960784 , 0 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms2695 =
			new HdrColor ( 0.266666666666667 , 0.137254901960784 , 0.368627450980392 ) ;

		public static readonly HdrColor Pms270 =
			new HdrColor ( 0.729411764705882 , 0.686274509803922 , 0.827450980392157 ) ;

		public static readonly HdrColor Pms271 =
			new HdrColor ( 0.619607843137255 , 0.568627450980392 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms272 =
			new HdrColor ( 0.537254901960784 , 0.466666666666667 , 0.729411764705882 ) ;

		public static readonly HdrColor Pms273 =
			new HdrColor ( 0.219607843137255 , 0.0980392156862745 , 0.47843137254902 ) ;

		public static readonly HdrColor Pms274 = new HdrColor ( 0.168627450980392 , 0.0666666666666667 , 0.4 ) ;

		public static readonly HdrColor Pms275 =
			new HdrColor ( 0.149019607843137 , 0.0588235294117647 , 0.329411764705882 ) ;

		public static readonly HdrColor Pms276 =
			new HdrColor ( 0.168627450980392 , 0.129411764705882 , 0.27843137254902 ) ;

		public static readonly HdrColor Pms2705 =
			new HdrColor ( 0.67843137254902 , 0.619607843137255 , 0.827450980392157 ) ;

		public static readonly HdrColor Pms2715 = new HdrColor ( 0.576470588235294 , 0.47843137254902 , 0.8 ) ;

		public static readonly HdrColor Pms2725 =
			new HdrColor ( 0.447058823529412 , 0.317647058823529 , 0.737254901960784 ) ;

		public static readonly HdrColor Pms2735 = new HdrColor ( 0.309803921568627 , 0 , 0.576470588235294 ) ;

		public static readonly HdrColor Pms2745 = new HdrColor ( 0.247058823529412 , 0 , 0.466666666666667 ) ;

		public static readonly HdrColor Pms2755 = new HdrColor ( 0.207843137254902 , 0 , 0.427450980392157 ) ;

		public static readonly HdrColor Pms2765 =
			new HdrColor ( 0.168627450980392 , 0.0470588235294118 , 0.337254901960784 ) ;

		public static readonly HdrColor Pms2706 =
			new HdrColor ( 0.819607843137255 , 0.807843137254902 , 0.866666666666667 ) ;

		public static readonly HdrColor Pms2716 =
			new HdrColor ( 0.647058823529412 , 0.627450980392157 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms2726 = new HdrColor ( 0.4 , 0.337254901960784 , 0.737254901960784 ) ;

		public static readonly HdrColor Pms2736 =
			new HdrColor ( 0.286274509803922 , 0.188235294117647 , 0.67843137254902 ) ;

		public static readonly HdrColor Pms2746 =
			new HdrColor ( 0.247058823529412 , 0.156862745098039 , 0.576470588235294 ) ;

		public static readonly HdrColor Pms2756 = new HdrColor ( 0.2 , 0.156862745098039 , 0.458823529411765 ) ;

		public static readonly HdrColor Pms2766 =
			new HdrColor ( 0.168627450980392 , 0.149019607843137 , 0.356862745098039 ) ;

		public static readonly HdrColor Pms2707 =
			new HdrColor ( 0.749019607843137 , 0.819607843137255 , 0.898039215686275 ) ;

		public static readonly HdrColor Pms2717 =
			new HdrColor ( 0.647058823529412 , 0.729411764705882 , 0.87843137254902 ) ;

		public static readonly HdrColor Pms2727 =
			new HdrColor ( 0.368627450980392 , 0.407843137254902 , 0.768627450980392 ) ;

		public static readonly HdrColor Blue072 = new HdrColor ( 0.219607843137255 , 0 , 0.588235294117647 ) ;

		public static readonly HdrColor Pms2747 =
			new HdrColor ( 0.109803921568627 , 0.0784313725490196 , 0.419607843137255 ) ;

		public static readonly HdrColor Pms2757 =
			new HdrColor ( 0.0784313725490196 , 0.0862745098039216 , 0.329411764705882 ) ;

		public static readonly HdrColor Pms2767 =
			new HdrColor ( 0.0784313725490196 , 0.129411764705882 , 0.23921568627451 ) ;

		public static readonly HdrColor Pms2708 =
			new HdrColor ( 0.686274509803922 , 0.737254901960784 , 0.858823529411765 ) ;

		public static readonly HdrColor Pms2718 = new HdrColor ( 0.356862745098039 , 0.466666666666667 , 0.8 ) ;

		public static readonly HdrColor Pms2728 =
			new HdrColor ( 0.188235294117647 , 0.266666666666667 , 0.709803921568627 ) ;

		public static readonly HdrColor Pms2738 = new HdrColor ( 0.176470588235294 , 0 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms2748 =
			new HdrColor ( 0.117647058823529 , 0.109803921568627 , 0.466666666666667 ) ;

		public static readonly HdrColor Pms2758 =
			new HdrColor ( 0.0980392156862745 , 0.129411764705882 , 0.407843137254902 ) ;

		public static readonly HdrColor Pms2768 =
			new HdrColor ( 0.0666666666666667 , 0.129411764705882 , 0.317647058823529 ) ;

		public static readonly HdrColor Pms277 =
			new HdrColor ( 0.709803921568627 , 0.819607843137255 , 0.909803921568627 ) ;

		public static readonly HdrColor Pms278 = new HdrColor ( 0.6 , 0.729411764705882 , 0.866666666666667 ) ;

		public static readonly HdrColor Pms279 = new HdrColor ( 0.4 , 0.537254901960784 , 0.8 ) ;

		public static readonly HdrColor ReflexBlue =
			new HdrColor ( 0.0470588235294118 , 0.109803921568627 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms280 = new HdrColor ( 0 , 0.168627450980392 , 0.498039215686275 ) ;

		public static readonly HdrColor Pms281 = new HdrColor ( 0 , 0.156862745098039 , 0.407843137254902 ) ;

		public static readonly HdrColor Pms282 = new HdrColor ( 0 , 0.149019607843137 , 0.329411764705882 ) ;

		public static readonly HdrColor Pms283 =
			new HdrColor ( 0.607843137254902 , 0.768627450980392 , 0.886274509803922 ) ;

		public static readonly HdrColor Pms284 =
			new HdrColor ( 0.458823529411765 , 0.666666666666667 , 0.858823529411765 ) ;

		public static readonly HdrColor Pms285 =
			new HdrColor ( 0.227450980392157 , 0.458823529411765 , 0.768627450980392 ) ;

		public static readonly HdrColor Pms286 = new HdrColor ( 0 , 0.219607843137255 , 0.658823529411765 ) ;

		public static readonly HdrColor Pms287 = new HdrColor ( 0 , 0.219607843137255 , 0.576470588235294 ) ;

		public static readonly HdrColor Pms288 = new HdrColor ( 0 , 0.2 , 0.498039215686275 ) ;

		public static readonly HdrColor Pms289 = new HdrColor ( 0 , 0.149019607843137 , 0.286274509803922 ) ;

		public static readonly HdrColor Pms290 =
			new HdrColor ( 0.768627450980392 , 0.847058823529412 , 0.886274509803922 ) ;

		public static readonly HdrColor Pms291 =
			new HdrColor ( 0.658823529411765 , 0.807843137254902 , 0.886274509803922 ) ;

		public static readonly HdrColor Pms292 =
			new HdrColor ( 0.458823529411765 , 0.698039215686274 , 0.866666666666667 ) ;

		public static readonly HdrColor Pms293 = new HdrColor ( 0 , 0.317647058823529 , 0.729411764705882 ) ;

		public static readonly HdrColor Pms294 = new HdrColor ( 0 , 0.247058823529412 , 0.529411764705882 ) ;

		public static readonly HdrColor Pms295 = new HdrColor ( 0 , 0.219607843137255 , 0.419607843137255 ) ;

		public static readonly HdrColor Pms296 = new HdrColor ( 0 , 0.176470588235294 , 0.27843137254902 ) ;

		public static readonly HdrColor Pms2905 =
			new HdrColor ( 0.576470588235294 , 0.776470588235294 , 0.87843137254902 ) ;

		public static readonly HdrColor Pms2915 =
			new HdrColor ( 0.376470588235294 , 0.686274509803922 , 0.866666666666667 ) ;

		public static readonly HdrColor Pms2925 = new HdrColor ( 0 , 0.556862745098039 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms2935 = new HdrColor ( 0 , 0.356862745098039 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms2945 = new HdrColor ( 0 , 0.329411764705882 , 0.627450980392157 ) ;

		public static readonly HdrColor Pms2955 = new HdrColor ( 0 , 0.23921568627451 , 0.419607843137255 ) ;

		public static readonly HdrColor Pms2965 = new HdrColor ( 0 , 0.2 , 0.298039215686275 ) ;

		public static readonly HdrColor Pms297 =
			new HdrColor ( 0.509803921568627 , 0.776470588235294 , 0.886274509803922 ) ;

		public static readonly HdrColor Pms298 =
			new HdrColor ( 0.317647058823529 , 0.709803921568627 , 0.87843137254902 ) ;

		public static readonly HdrColor Pms299 = new HdrColor ( 0 , 0.63921568627451 , 0.866666666666667 ) ;

		public static readonly HdrColor Pms300 = new HdrColor ( 0 , 0.447058823529412 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms301 = new HdrColor ( 0 , 0.356862745098039 , 0.6 ) ;

		public static readonly HdrColor Pms302 = new HdrColor ( 0 , 0.309803921568627 , 0.427450980392157 ) ;

		public static readonly HdrColor Pms303 = new HdrColor ( 0 , 0.247058823529412 , 0.329411764705882 ) ;

		public static readonly HdrColor Pms2975 =
			new HdrColor ( 0.729411764705882 , 0.87843137254902 , 0.886274509803922 ) ;

		public static readonly HdrColor Pms2985 =
			new HdrColor ( 0.317647058823529 , 0.749019607843137 , 0.886274509803922 ) ;

		public static readonly HdrColor Pms2995 = new HdrColor ( 0 , 0.647058823529412 , 0.858823529411765 ) ;

		public static readonly HdrColor Pms3005 = new HdrColor ( 0 , 0.517647058823529 , 0.788235294117647 ) ;

		public static readonly HdrColor Pms3015 = new HdrColor ( 0 , 0.43921568627451 , 0.619607843137255 ) ;

		public static readonly HdrColor Pms3025 = new HdrColor ( 0 , 0.329411764705882 , 0.419607843137255 ) ;

		public static readonly HdrColor Pms3035 = new HdrColor ( 0 , 0.266666666666667 , 0.329411764705882 ) ;

		public static readonly HdrColor Pms304 =
			new HdrColor ( 0.647058823529412 , 0.866666666666667 , 0.886274509803922 ) ;

		public static readonly HdrColor Pms305 =
			new HdrColor ( 0.43921568627451 , 0.807843137254902 , 0.886274509803922 ) ;

		public static readonly HdrColor Pms306 = new HdrColor ( 0 , 0.737254901960784 , 0.886274509803922 ) ;

		public static readonly HdrColor ProcessBlue = new HdrColor ( 0 , 0.568627450980392 , 0.788235294117647 ) ;

		public static readonly HdrColor Pms307 = new HdrColor ( 0 , 0.47843137254902 , 0.647058823529412 ) ;

		public static readonly HdrColor Pms308 = new HdrColor ( 0 , 0.376470588235294 , 0.486274509803922 ) ;

		public static readonly HdrColor Pms309 = new HdrColor ( 0 , 0.247058823529412 , 0.286274509803922 ) ;

		public static readonly HdrColor Pms310 =
			new HdrColor ( 0.447058823529412 , 0.819607843137255 , 0.866666666666667 ) ;

		public static readonly HdrColor Pms311 =
			new HdrColor ( 0.156862745098039 , 0.768627450980392 , 0.847058823529412 ) ;

		public static readonly HdrColor Pms312 = new HdrColor ( 0 , 0.67843137254902 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms313 = new HdrColor ( 0 , 0.6 , 0.709803921568627 ) ;

		public static readonly HdrColor Pms314 = new HdrColor ( 0 , 0.509803921568627 , 0.607843137254902 ) ;

		public static readonly HdrColor Pms315 = new HdrColor ( 0 , 0.419607843137255 , 0.466666666666667 ) ;

		public static readonly HdrColor Pms316 = new HdrColor ( 0 , 0.286274509803922 , 0.309803921568627 ) ;

		public static readonly HdrColor Pms3105 =
			new HdrColor ( 0.498039215686275 , 0.83921568627451 , 0.858823529411765 ) ;

		public static readonly HdrColor Pms3115 =
			new HdrColor ( 0.176470588235294 , 0.776470588235294 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms3125 = new HdrColor ( 0 , 0.717647058823529 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms3135 = new HdrColor ( 0 , 0.607843137254902 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms3145 = new HdrColor ( 0 , 0.517647058823529 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms3155 = new HdrColor ( 0 , 0.427450980392157 , 0.458823529411765 ) ;

		public static readonly HdrColor Pms3165 = new HdrColor ( 0 , 0.337254901960784 , 0.356862745098039 ) ;

		public static readonly HdrColor Pms317 =
			new HdrColor ( 0.788235294117647 , 0.909803921568627 , 0.866666666666667 ) ;

		public static readonly HdrColor Pms318 =
			new HdrColor ( 0.576470588235294 , 0.866666666666667 , 0.858823529411765 ) ;

		public static readonly HdrColor Pms319 =
			new HdrColor ( 0.298039215686275 , 0.807843137254902 , 0.819607843137255 ) ;

		public static readonly HdrColor Pms320 = new HdrColor ( 0 , 0.619607843137255 , 0.627450980392157 ) ;

		public static readonly HdrColor Pms321 = new HdrColor ( 0 , 0.529411764705882 , 0.537254901960784 ) ;

		public static readonly HdrColor Pms322 = new HdrColor ( 0 , 0.447058823529412 , 0.447058823529412 ) ;

		public static readonly HdrColor Pms323 = new HdrColor ( 0 , 0.4 , 0.388235294117647 ) ;

		public static readonly HdrColor Pms324 =
			new HdrColor ( 0.666666666666667 , 0.866666666666667 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms325 =
			new HdrColor ( 0.337254901960784 , 0.788235294117647 , 0.756862745098039 ) ;

		public static readonly HdrColor Pms326 = new HdrColor ( 0 , 0.698039215686274 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms327 = new HdrColor ( 0 , 0.549019607843137 , 0.509803921568627 ) ;

		public static readonly HdrColor Pms328 = new HdrColor ( 0 , 0.466666666666667 , 0.43921568627451 ) ;

		public static readonly HdrColor Pms329 = new HdrColor ( 0 , 0.427450980392157 , 0.4 ) ;

		public static readonly HdrColor Pms330 = new HdrColor ( 0 , 0.349019607843137 , 0.317647058823529 ) ;

		public static readonly HdrColor Pms3242 =
			new HdrColor ( 0.529411764705882 , 0.866666666666667 , 0.819607843137255 ) ;

		public static readonly HdrColor Pms3252 =
			new HdrColor ( 0.337254901960784 , 0.83921568627451 , 0.788235294117647 ) ;

		public static readonly HdrColor Pms3262 = new HdrColor ( 0 , 0.756862745098039 , 0.709803921568627 ) ;

		public static readonly HdrColor Pms3272 = new HdrColor ( 0 , 0.666666666666667 , 0.619607843137255 ) ;

		public static readonly HdrColor Pms3282 = new HdrColor ( 0 , 0.549019607843137 , 0.509803921568627 ) ;

		public static readonly HdrColor Pms3292 = new HdrColor ( 0 , 0.376470588235294 , 0.337254901960784 ) ;

		public static readonly HdrColor Pms3302 = new HdrColor ( 0 , 0.286274509803922 , 0.247058823529412 ) ;

		public static readonly HdrColor Pms3245 =
			new HdrColor ( 0.549019607843137 , 0.87843137254902 , 0.819607843137255 ) ;

		public static readonly HdrColor Pms3255 =
			new HdrColor ( 0.27843137254902 , 0.83921568627451 , 0.756862745098039 ) ;

		public static readonly HdrColor Pms3265 = new HdrColor ( 0 , 0.776470588235294 , 0.698039215686274 ) ;

		public static readonly HdrColor Pms3275 = new HdrColor ( 0 , 0.698039215686274 , 0.627450980392157 ) ;

		public static readonly HdrColor Pms3285 = new HdrColor ( 0 , 0.6 , 0.529411764705882 ) ;

		public static readonly HdrColor Pms3295 = new HdrColor ( 0 , 0.509803921568627 , 0.447058823529412 ) ;

		public static readonly HdrColor Pms3305 = new HdrColor ( 0 , 0.309803921568627 , 0.258823529411765 ) ;

		public static readonly HdrColor Pms3248 =
			new HdrColor ( 0.47843137254902 , 0.827450980392157 , 0.756862745098039 ) ;

		public static readonly HdrColor Pms3258 =
			new HdrColor ( 0.207843137254902 , 0.768627450980392 , 0.686274509803922 ) ;

		public static readonly HdrColor Pms3268 = new HdrColor ( 0 , 0.686274509803922 , 0.6 ) ;

		public static readonly HdrColor Pms3278 = new HdrColor ( 0 , 0.607843137254902 , 0.517647058823529 ) ;

		public static readonly HdrColor Pms3288 = new HdrColor ( 0 , 0.509803921568627 , 0.43921568627451 ) ;

		public static readonly HdrColor Pms3298 = new HdrColor ( 0 , 0.419607843137255 , 0.356862745098039 ) ;

		public static readonly HdrColor Pms3308 = new HdrColor ( 0 , 0.266666666666667 , 0.219607843137255 ) ;

		public static readonly HdrColor Pms331 =
			new HdrColor ( 0.729411764705882 , 0.917647058823529 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms332 =
			new HdrColor ( 0.627450980392157 , 0.898039215686275 , 0.807843137254902 ) ;

		public static readonly HdrColor Pms333 =
			new HdrColor ( 0.368627450980392 , 0.866666666666667 , 0.756862745098039 ) ;

		public static readonly HdrColor Green = new HdrColor ( 0 , 0.686274509803922 , 0.576470588235294 ) ;

		public static readonly HdrColor Pms334 = new HdrColor ( 0 , 0.6 , 0.486274509803922 ) ;

		public static readonly HdrColor Pms335 = new HdrColor ( 0 , 0.486274509803922 , 0.4 ) ;

		public static readonly HdrColor Pms336 = new HdrColor ( 0 , 0.407843137254902 , 0.329411764705882 ) ;

		public static readonly HdrColor Pms337 =
			new HdrColor ( 0.607843137254902 , 0.858823529411765 , 0.756862745098039 ) ;

		public static readonly HdrColor Pms338 =
			new HdrColor ( 0.47843137254902 , 0.819607843137255 , 0.709803921568627 ) ;

		public static readonly HdrColor Pms339 = new HdrColor ( 0 , 0.698039215686274 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms340 = new HdrColor ( 0 , 0.6 , 0.466666666666667 ) ;

		public static readonly HdrColor Pms341 = new HdrColor ( 0 , 0.47843137254902 , 0.368627450980392 ) ;

		public static readonly HdrColor Pms342 = new HdrColor ( 0 , 0.419607843137255 , 0.329411764705882 ) ;

		public static readonly HdrColor Pms343 = new HdrColor ( 0 , 0.337254901960784 , 0.247058823529412 ) ;

		public static readonly HdrColor Pms3375 =
			new HdrColor ( 0.556862745098039 , 0.886274509803922 , 0.737254901960784 ) ;

		public static readonly HdrColor Pms3385 =
			new HdrColor ( 0.329411764705882 , 0.847058823529412 , 0.658823529411765 ) ;

		public static readonly HdrColor Pms3395 = new HdrColor ( 0 , 0.788235294117647 , 0.576470588235294 ) ;

		public static readonly HdrColor Pms3405 = new HdrColor ( 0 , 0.698039215686274 , 0.47843137254902 ) ;

		public static readonly HdrColor Pms3415 = new HdrColor ( 0 , 0.486274509803922 , 0.349019607843137 ) ;

		public static readonly HdrColor Pms3425 = new HdrColor ( 0 , 0.407843137254902 , 0.27843137254902 ) ;

		public static readonly HdrColor Pms3435 =
			new HdrColor ( 0.00784313725490196 , 0.286274509803922 , 0.188235294117647 ) ;

		public static readonly HdrColor Pms344 =
			new HdrColor ( 0.709803921568627 , 0.886274509803922 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms345 =
			new HdrColor ( 0.588235294117647 , 0.847058823529412 , 0.686274509803922 ) ;

		public static readonly HdrColor Pms346 =
			new HdrColor ( 0.43921568627451 , 0.807843137254902 , 0.607843137254902 ) ;

		public static readonly HdrColor Pms347 = new HdrColor ( 0 , 0.619607843137255 , 0.376470588235294 ) ;

		public static readonly HdrColor Pms348 = new HdrColor ( 0 , 0.529411764705882 , 0.317647058823529 ) ;

		public static readonly HdrColor Pms349 = new HdrColor ( 0 , 0.419607843137255 , 0.247058823529412 ) ;

		public static readonly HdrColor Pms350 = new HdrColor ( 0.137254901960784 , 0.309803921568627 , 0.2 ) ;

		public static readonly HdrColor Pms351 =
			new HdrColor ( 0.709803921568627 , 0.909803921568627 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms352 = new HdrColor ( 0.6 , 0.898039215686275 , 0.698039215686274 ) ;

		public static readonly HdrColor Pms353 =
			new HdrColor ( 0.517647058823529 , 0.886274509803922 , 0.658823529411765 ) ;

		public static readonly HdrColor Pms354 = new HdrColor ( 0 , 0.717647058823529 , 0.376470588235294 ) ;

		public static readonly HdrColor Pms355 = new HdrColor ( 0 , 0.619607843137255 , 0.286274509803922 ) ;

		public static readonly HdrColor Pms356 = new HdrColor ( 0 , 0.47843137254902 , 0.23921568627451 ) ;

		public static readonly HdrColor Pms357 = new HdrColor ( 0.129411764705882 , 0.356862745098039 , 0.2 ) ;

		public static readonly HdrColor Pms358 =
			new HdrColor ( 0.666666666666667 , 0.866666666666667 , 0.588235294117647 ) ;

		public static readonly HdrColor Pms359 =
			new HdrColor ( 0.627450980392157 , 0.858823529411765 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms360 =
			new HdrColor ( 0.376470588235294 , 0.776470588235294 , 0.349019607843137 ) ;

		public static readonly HdrColor Pms361 =
			new HdrColor ( 0.117647058823529 , 0.709803921568627 , 0.227450980392157 ) ;

		public static readonly HdrColor Pms362 = new HdrColor ( 0.2 , 0.619607843137255 , 0.207843137254902 ) ;

		public static readonly HdrColor Pms363 = new HdrColor ( 0.23921568627451 , 0.556862745098039 , 0.2 ) ;

		public static readonly HdrColor Pms364 =
			new HdrColor ( 0.227450980392157 , 0.466666666666667 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms365 =
			new HdrColor ( 0.827450980392157 , 0.909803921568627 , 0.63921568627451 ) ;

		public static readonly HdrColor Pms366 =
			new HdrColor ( 0.768627450980392 , 0.898039215686275 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms367 =
			new HdrColor ( 0.666666666666667 , 0.866666666666667 , 0.427450980392157 ) ;

		public static readonly HdrColor Pms368 =
			new HdrColor ( 0.356862745098039 , 0.749019607843137 , 0.129411764705882 ) ;

		public static readonly HdrColor Pms369 =
			new HdrColor ( 0.337254901960784 , 0.666666666666667 , 0.109803921568627 ) ;

		public static readonly HdrColor Pms370 =
			new HdrColor ( 0.337254901960784 , 0.556862745098039 , 0.0784313725490196 ) ;

		public static readonly HdrColor Pms371 =
			new HdrColor ( 0.337254901960784 , 0.419607843137255 , 0.129411764705882 ) ;

		public static readonly HdrColor Pms372 =
			new HdrColor ( 0.847058823529412 , 0.929411764705882 , 0.588235294117647 ) ;

		public static readonly HdrColor Pms373 =
			new HdrColor ( 0.807843137254902 , 0.917647058823529 , 0.509803921568627 ) ;

		public static readonly HdrColor Pms374 =
			new HdrColor ( 0.729411764705882 , 0.909803921568627 , 0.376470588235294 ) ;

		public static readonly HdrColor Pms375 = new HdrColor ( 0.549019607843137 , 0.83921568627451 , 0 ) ;

		public static readonly HdrColor Pms376 = new HdrColor ( 0.498039215686275 , 0.729411764705882 , 0 ) ;

		public static readonly HdrColor Pms377 =
			new HdrColor ( 0.43921568627451 , 0.576470588235294 , 0.00784313725490196 ) ;

		public static readonly HdrColor Pms378 =
			new HdrColor ( 0.337254901960784 , 0.388235294117647 , 0.0784313725490196 ) ;

		public static readonly HdrColor Pms379 =
			new HdrColor ( 0.87843137254902 , 0.917647058823529 , 0.407843137254902 ) ;

		public static readonly HdrColor Pms380 =
			new HdrColor ( 0.83921568627451 , 0.898039215686275 , 0.258823529411765 ) ;

		public static readonly HdrColor Pms381 = new HdrColor ( 0.8 , 0.886274509803922 , 0.149019607843137 ) ;

		public static readonly HdrColor Pms382 =
			new HdrColor ( 0.729411764705882 , 0.847058823529412 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms383 =
			new HdrColor ( 0.63921568627451 , 0.686274509803922 , 0.0274509803921569 ) ;

		public static readonly HdrColor Pms384 = new HdrColor ( 0.576470588235294 , 0.6 , 0.0196078431372549 ) ;

		public static readonly HdrColor Pms385 =
			new HdrColor ( 0.43921568627451 , 0.43921568627451 , 0.0784313725490196 ) ;

		public static readonly HdrColor Pms386 =
			new HdrColor ( 0.909803921568627 , 0.929411764705882 , 0.376470588235294 ) ;

		public static readonly HdrColor Pms387 =
			new HdrColor ( 0.87843137254902 , 0.929411764705882 , 0.266666666666667 ) ;

		public static readonly HdrColor Pms388 =
			new HdrColor ( 0.83921568627451 , 0.909803921568627 , 0.0588235294117647 ) ;

		public static readonly HdrColor Pms389 =
			new HdrColor ( 0.807843137254902 , 0.87843137254902 , 0.0274509803921569 ) ;

		public static readonly HdrColor Pms390 =
			new HdrColor ( 0.729411764705882 , 0.768627450980392 , 0.0196078431372549 ) ;

		public static readonly HdrColor Pms391 =
			new HdrColor ( 0.619607843137255 , 0.619607843137255 , 0.0274509803921569 ) ;

		public static readonly HdrColor Pms392 =
			new HdrColor ( 0.517647058823529 , 0.509803921568627 , 0.0196078431372549 ) ;

		public static readonly HdrColor Pms393 =
			new HdrColor ( 0.949019607843137 , 0.937254901960784 , 0.529411764705882 ) ;

		public static readonly HdrColor Pms394 =
			new HdrColor ( 0.917647058823529 , 0.929411764705882 , 0.207843137254902 ) ;

		public static readonly HdrColor Pms395 =
			new HdrColor ( 0.898039215686275 , 0.909803921568627 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms396 =
			new HdrColor ( 0.87843137254902 , 0.886274509803922 , 0.0470588235294118 ) ;

		public static readonly HdrColor Pms397 =
			new HdrColor ( 0.756862745098039 , 0.749019607843137 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms398 =
			new HdrColor ( 0.686274509803922 , 0.658823529411765 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms399 = new HdrColor ( 0.6 , 0.556862745098039 , 0.0274509803921569 ) ;

		public static readonly HdrColor Pms3935 =
			new HdrColor ( 0.949019607843137 , 0.929411764705882 , 0.427450980392157 ) ;

		public static readonly HdrColor Pms3945 =
			new HdrColor ( 0.937254901960784 , 0.917647058823529 , 0.0274509803921569 ) ;

		public static readonly HdrColor Pms3955 =
			new HdrColor ( 0.929411764705882 , 0.886274509803922 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms3965 =
			new HdrColor ( 0.909803921568627 , 0.866666666666667 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms3975 =
			new HdrColor ( 0.709803921568627 , 0.658823529411765 , 0.0470588235294118 ) ;

		public static readonly HdrColor Pms3985 = new HdrColor ( 0.6 , 0.549019607843137 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms3995 =
			new HdrColor ( 0.427450980392157 , 0.376470588235294 , 0.00784313725490196 ) ;

		public static readonly HdrColor Pms400 =
			new HdrColor ( 0.819607843137255 , 0.776470588235294 , 0.709803921568627 ) ;

		public static readonly HdrColor Pms401 =
			new HdrColor ( 0.756862745098039 , 0.709803921568627 , 0.647058823529412 ) ;

		public static readonly HdrColor Pms402 =
			new HdrColor ( 0.686274509803922 , 0.647058823529412 , 0.576470588235294 ) ;

		public static readonly HdrColor Pms403 = new HdrColor ( 0.6 , 0.549019607843137 , 0.486274509803922 ) ;

		public static readonly HdrColor Pms404 = new HdrColor ( 0.509803921568627 , 0.458823529411765 , 0.4 ) ;

		public static readonly HdrColor Pms405 =
			new HdrColor ( 0.419607843137255 , 0.368627450980392 , 0.309803921568627 ) ;

		public static readonly HdrColor Black = new HdrColor ( 0.23921568627451 , 0.2 , 0.168627450980392 ) ;

		public static readonly HdrColor Pms406 =
			new HdrColor ( 0.807843137254902 , 0.756862745098039 , 0.709803921568627 ) ;

		public static readonly HdrColor Pms407 =
			new HdrColor ( 0.729411764705882 , 0.666666666666667 , 0.619607843137255 ) ;

		public static readonly HdrColor Pms408 = new HdrColor ( 0.658823529411765 , 0.6 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms409 = new HdrColor ( 0.6 , 0.537254901960784 , 0.486274509803922 ) ;

		public static readonly HdrColor Pms410 =
			new HdrColor ( 0.486274509803922 , 0.427450980392157 , 0.388235294117647 ) ;

		public static readonly HdrColor Pms411 = new HdrColor ( 0.4 , 0.349019607843137 , 0.298039215686275 ) ;

		public static readonly HdrColor Pms412 =
			new HdrColor ( 0.23921568627451 , 0.188235294117647 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms413 =
			new HdrColor ( 0.776470588235294 , 0.756862745098039 , 0.698039215686274 ) ;

		public static readonly HdrColor Pms414 =
			new HdrColor ( 0.709803921568627 , 0.686274509803922 , 0.627450980392157 ) ;

		public static readonly HdrColor Pms415 =
			new HdrColor ( 0.63921568627451 , 0.619607843137255 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms416 =
			new HdrColor ( 0.556862745098039 , 0.549019607843137 , 0.47843137254902 ) ;

		public static readonly HdrColor Pms417 =
			new HdrColor ( 0.466666666666667 , 0.447058823529412 , 0.388235294117647 ) ;

		public static readonly HdrColor Pms418 =
			new HdrColor ( 0.376470588235294 , 0.368627450980392 , 0.309803921568627 ) ;

		public static readonly HdrColor Pms419 =
			new HdrColor ( 0.156862745098039 , 0.156862745098039 , 0.129411764705882 ) ;

		public static readonly HdrColor Pms420 = new HdrColor ( 0.819607843137255 , 0.8 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms421 =
			new HdrColor ( 0.749019607843137 , 0.729411764705882 , 0.686274509803922 ) ;

		public static readonly HdrColor Pms422 =
			new HdrColor ( 0.686274509803922 , 0.666666666666667 , 0.63921568627451 ) ;

		public static readonly HdrColor Pms423 =
			new HdrColor ( 0.588235294117647 , 0.576470588235294 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms424 =
			new HdrColor ( 0.509803921568627 , 0.498039215686275 , 0.466666666666667 ) ;

		public static readonly HdrColor Pms425 =
			new HdrColor ( 0.376470588235294 , 0.376470588235294 , 0.356862745098039 ) ;

		public static readonly HdrColor Pms426 =
			new HdrColor ( 0.168627450980392 , 0.168627450980392 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms427 =
			new HdrColor ( 0.866666666666667 , 0.858823529411765 , 0.819607843137255 ) ;

		public static readonly HdrColor Pms428 =
			new HdrColor ( 0.819607843137255 , 0.807843137254902 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms429 =
			new HdrColor ( 0.67843137254902 , 0.686274509803922 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms430 =
			new HdrColor ( 0.568627450980392 , 0.588235294117647 , 0.576470588235294 ) ;

		public static readonly HdrColor Pms431 = new HdrColor ( 0.4 , 0.427450980392157 , 0.43921568627451 ) ;

		public static readonly HdrColor Pms432 =
			new HdrColor ( 0.266666666666667 , 0.309803921568627 , 0.317647058823529 ) ;

		public static readonly HdrColor Pms433 =
			new HdrColor ( 0.188235294117647 , 0.219607843137255 , 0.227450980392157 ) ;

		public static readonly HdrColor Pms434 =
			new HdrColor ( 0.87843137254902 , 0.819607843137255 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms435 =
			new HdrColor ( 0.827450980392157 , 0.749019607843137 , 0.717647058823529 ) ;

		public static readonly HdrColor Pms436 =
			new HdrColor ( 0.737254901960784 , 0.647058823529412 , 0.619607843137255 ) ;

		public static readonly HdrColor Pms437 =
			new HdrColor ( 0.549019607843137 , 0.43921568627451 , 0.419607843137255 ) ;

		public static readonly HdrColor Pms438 =
			new HdrColor ( 0.349019607843137 , 0.247058823529412 , 0.23921568627451 ) ;

		public static readonly HdrColor Pms439 = new HdrColor ( 0.286274509803922 , 0.207843137254902 , 0.2 ) ;

		public static readonly HdrColor Pms440 =
			new HdrColor ( 0.247058823529412 , 0.188235294117647 , 0.168627450980392 ) ;

		public static readonly HdrColor Pms441 =
			new HdrColor ( 0.819607843137255 , 0.819607843137255 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms442 =
			new HdrColor ( 0.729411764705882 , 0.749019607843137 , 0.717647058823529 ) ;

		public static readonly HdrColor Pms443 =
			new HdrColor ( 0.63921568627451 , 0.658823529411765 , 0.63921568627451 ) ;

		public static readonly HdrColor Pms444 =
			new HdrColor ( 0.537254901960784 , 0.556862745098039 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms445 =
			new HdrColor ( 0.337254901960784 , 0.349019607843137 , 0.349019607843137 ) ;

		public static readonly HdrColor Pms446 =
			new HdrColor ( 0.286274509803922 , 0.298039215686275 , 0.286274509803922 ) ;

		public static readonly HdrColor Pms447 =
			new HdrColor ( 0.247058823529412 , 0.247058823529412 , 0.219607843137255 ) ;

		public static readonly HdrColor WarmGray1 = new HdrColor ( 0.898039215686275 , 0.858823529411765 , 0.8 ) ;

		public static readonly HdrColor WarmGray2 =
			new HdrColor ( 0.866666666666667 , 0.819607843137255 , 0.756862745098039 ) ;

		public static readonly HdrColor WarmGray3 = new HdrColor ( 0.8 , 0.756862745098039 , 0.698039215686274 ) ;

		public static readonly HdrColor WarmGray4 =
			new HdrColor ( 0.756862745098039 , 0.709803921568627 , 0.647058823529412 ) ;

		public static readonly HdrColor WarmGray5 = new HdrColor ( 0.709803921568627 , 0.658823529411765 , 0.6 ) ;

		public static readonly HdrColor WarmGray6 =
			new HdrColor ( 0.686274509803922 , 0.63921568627451 , 0.576470588235294 ) ;

		public static readonly HdrColor WarmGray7 =
			new HdrColor ( 0.63921568627451 , 0.588235294117647 , 0.529411764705882 ) ;

		public static readonly HdrColor WarmGray8 =
			new HdrColor ( 0.588235294117647 , 0.537254901960784 , 0.47843137254902 ) ;

		public static readonly HdrColor WarmGray9 =
			new HdrColor ( 0.549019607843137 , 0.498039215686275 , 0.43921568627451 ) ;

		public static readonly HdrColor WarmGray10 =
			new HdrColor ( 0.509803921568627 , 0.447058823529412 , 0.388235294117647 ) ;

		public static readonly HdrColor WarmGray11 =
			new HdrColor ( 0.427450980392157 , 0.368627450980392 , 0.317647058823529 ) ;

		public static readonly HdrColor CoolGray1 =
			new HdrColor ( 0.909803921568627 , 0.886274509803922 , 0.83921568627451 ) ;

		public static readonly HdrColor CoolGray2 =
			new HdrColor ( 0.866666666666667 , 0.847058823529412 , 0.807843137254902 ) ;

		public static readonly HdrColor CoolGray3 =
			new HdrColor ( 0.827450980392157 , 0.807843137254902 , 0.768627450980392 ) ;

		public static readonly HdrColor CoolGray4 =
			new HdrColor ( 0.768627450980392 , 0.756862745098039 , 0.729411764705882 ) ;

		public static readonly HdrColor CoolGray5 =
			new HdrColor ( 0.729411764705882 , 0.717647058823529 , 0.686274509803922 ) ;

		public static readonly HdrColor CoolGray6 =
			new HdrColor ( 0.709803921568627 , 0.698039215686274 , 0.666666666666667 ) ;

		public static readonly HdrColor CoolGray7 =
			new HdrColor ( 0.647058823529412 , 0.63921568627451 , 0.619607843137255 ) ;

		public static readonly HdrColor CoolGray8 = new HdrColor ( 0.607843137254902 , 0.6 , 0.576470588235294 ) ;

		public static readonly HdrColor CoolGray9 =
			new HdrColor ( 0.549019607843137 , 0.537254901960784 , 0.517647058823529 ) ;

		public static readonly HdrColor CoolGray10 =
			new HdrColor ( 0.466666666666667 , 0.466666666666667 , 0.447058823529412 ) ;

		public static readonly HdrColor CoolGray11 = new HdrColor ( 0.407843137254902 , 0.4 , 0.388235294117647 ) ;

		public static readonly HdrColor Pms448 =
			new HdrColor ( 0.329411764705882 , 0.27843137254902 , 0.176470588235294 ) ;

		public static readonly HdrColor Pms449 =
			new HdrColor ( 0.329411764705882 , 0.27843137254902 , 0.149019607843137 ) ;

		public static readonly HdrColor Pms450 =
			new HdrColor ( 0.376470588235294 , 0.329411764705882 , 0.168627450980392 ) ;

		public static readonly HdrColor Pms451 =
			new HdrColor ( 0.67843137254902 , 0.627450980392157 , 0.47843137254902 ) ;

		public static readonly HdrColor Pms452 =
			new HdrColor ( 0.768627450980392 , 0.717647058823529 , 0.588235294117647 ) ;

		public static readonly HdrColor Pms453 = new HdrColor ( 0.83921568627451 , 0.8 , 0.686274509803922 ) ;

		public static readonly HdrColor Pms454 =
			new HdrColor ( 0.886274509803922 , 0.847058823529412 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms4485 =
			new HdrColor ( 0.376470588235294 , 0.298039215686275 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms4495 =
			new HdrColor ( 0.529411764705882 , 0.458823529411765 , 0.188235294117647 ) ;

		public static readonly HdrColor Pms4505 =
			new HdrColor ( 0.627450980392157 , 0.568627450980392 , 0.317647058823529 ) ;

		public static readonly HdrColor Pms4515 =
			new HdrColor ( 0.737254901960784 , 0.67843137254902 , 0.458823529411765 ) ;

		public static readonly HdrColor Pms4525 = new HdrColor ( 0.8 , 0.749019607843137 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms4535 =
			new HdrColor ( 0.858823529411765 , 0.807843137254902 , 0.647058823529412 ) ;

		public static readonly HdrColor Pms4545 =
			new HdrColor ( 0.898039215686275 , 0.858823529411765 , 0.729411764705882 ) ;

		public static readonly HdrColor Pms455 = new HdrColor ( 0.4 , 0.337254901960784 , 0.0784313725490196 ) ;

		public static readonly HdrColor Pms456 = new HdrColor ( 0.6 , 0.529411764705882 , 0.0784313725490196 ) ;

		public static readonly HdrColor Pms457 =
			new HdrColor ( 0.709803921568627 , 0.607843137254902 , 0.0470588235294118 ) ;

		public static readonly HdrColor Pms458 = new HdrColor ( 0.866666666666667 , 0.8 , 0.419607843137255 ) ;

		public static readonly HdrColor Pms459 =
			new HdrColor ( 0.886274509803922 , 0.83921568627451 , 0.486274509803922 ) ;

		public static readonly HdrColor Pms460 =
			new HdrColor ( 0.917647058823529 , 0.866666666666667 , 0.588235294117647 ) ;

		public static readonly HdrColor Pms461 =
			new HdrColor ( 0.929411764705882 , 0.898039215686275 , 0.67843137254902 ) ;

		public static readonly HdrColor Pms462 =
			new HdrColor ( 0.356862745098039 , 0.27843137254902 , 0.137254901960784 ) ;

		public static readonly HdrColor Pms463 =
			new HdrColor ( 0.458823529411765 , 0.329411764705882 , 0.149019607843137 ) ;

		public static readonly HdrColor Pms464 =
			new HdrColor ( 0.529411764705882 , 0.376470588235294 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms465 =
			new HdrColor ( 0.756862745098039 , 0.658823529411765 , 0.458823529411765 ) ;

		public static readonly HdrColor Pms466 =
			new HdrColor ( 0.819607843137255 , 0.749019607843137 , 0.568627450980392 ) ;

		public static readonly HdrColor Pms467 = new HdrColor ( 0.866666666666667 , 0.8 , 0.647058823529412 ) ;

		public static readonly HdrColor Pms468 =
			new HdrColor ( 0.886274509803922 , 0.83921568627451 , 0.709803921568627 ) ;

		public static readonly HdrColor Pms4625 =
			new HdrColor ( 0.27843137254902 , 0.137254901960784 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms4635 = new HdrColor ( 0.549019607843137 , 0.349019607843137 , 0.2 ) ;

		public static readonly HdrColor Pms4645 =
			new HdrColor ( 0.698039215686274 , 0.509803921568627 , 0.376470588235294 ) ;

		public static readonly HdrColor Pms4655 = new HdrColor ( 0.768627450980392 , 0.6 , 0.466666666666667 ) ;

		public static readonly HdrColor Pms4665 =
			new HdrColor ( 0.847058823529412 , 0.709803921568627 , 0.588235294117647 ) ;

		public static readonly HdrColor Pms4675 =
			new HdrColor ( 0.898039215686275 , 0.776470588235294 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms4685 =
			new HdrColor ( 0.929411764705882 , 0.827450980392157 , 0.737254901960784 ) ;

		public static readonly HdrColor Pms469 = new HdrColor ( 0.376470588235294 , 0.2 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms4695 =
			new HdrColor ( 0.317647058823529 , 0.149019607843137 , 0.109803921568627 ) ;

		public static readonly HdrColor Pms4705 =
			new HdrColor ( 0.486274509803922 , 0.317647058823529 , 0.23921568627451 ) ;

		public static readonly HdrColor Pms4715 = new HdrColor ( 0.6 , 0.43921568627451 , 0.356862745098039 ) ;

		public static readonly HdrColor Pms4725 =
			new HdrColor ( 0.709803921568627 , 0.568627450980392 , 0.486274509803922 ) ;

		public static readonly HdrColor Pms4735 = new HdrColor ( 0.8 , 0.686274509803922 , 0.607843137254902 ) ;

		public static readonly HdrColor Pms4745 =
			new HdrColor ( 0.847058823529412 , 0.749019607843137 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms4755 = new HdrColor ( 0.886274509803922 , 0.8 , 0.729411764705882 ) ;

		public static readonly HdrColor Pms476 =
			new HdrColor ( 0.349019607843137 , 0.23921568627451 , 0.168627450980392 ) ;

		public static readonly HdrColor Pms477 =
			new HdrColor ( 0.388235294117647 , 0.219607843137255 , 0.149019607843137 ) ;

		public static readonly HdrColor Pms478 =
			new HdrColor ( 0.47843137254902 , 0.247058823529412 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms479 =
			new HdrColor ( 0.686274509803922 , 0.537254901960784 , 0.43921568627451 ) ;

		public static readonly HdrColor Pms480 =
			new HdrColor ( 0.827450980392157 , 0.717647058823529 , 0.63921568627451 ) ;

		public static readonly HdrColor Pms481 = new HdrColor ( 0.87843137254902 , 0.8 , 0.729411764705882 ) ;

		public static readonly HdrColor Pms482 =
			new HdrColor ( 0.898039215686275 , 0.827450980392157 , 0.756862745098039 ) ;

		public static readonly HdrColor Pms483 =
			new HdrColor ( 0.419607843137255 , 0.188235294117647 , 0.129411764705882 ) ;

		public static readonly HdrColor Pms484 =
			new HdrColor ( 0.607843137254902 , 0.188235294117647 , 0.109803921568627 ) ;

		public static readonly HdrColor Pms485 =
			new HdrColor ( 0.847058823529412 , 0.117647058823529 , 0.0196078431372549 ) ;

		public static readonly HdrColor Pms486 =
			new HdrColor ( 0.929411764705882 , 0.619607843137255 , 0.517647058823529 ) ;

		public static readonly HdrColor Pms487 =
			new HdrColor ( 0.937254901960784 , 0.709803921568627 , 0.627450980392157 ) ;

		public static readonly HdrColor Pms488 =
			new HdrColor ( 0.949019607843137 , 0.768627450980392 , 0.686274509803922 ) ;

		public static readonly HdrColor Pms489 =
			new HdrColor ( 0.949019607843137 , 0.819607843137255 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms490 =
			new HdrColor ( 0.356862745098039 , 0.149019607843137 , 0.149019607843137 ) ;

		public static readonly HdrColor Pms491 =
			new HdrColor ( 0.458823529411765 , 0.156862745098039 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms492 = new HdrColor ( 0.568627450980392 , 0.2 , 0.219607843137255 ) ;

		public static readonly HdrColor Pms493 =
			new HdrColor ( 0.858823529411765 , 0.509803921568627 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms494 =
			new HdrColor ( 0.949019607843137 , 0.67843137254902 , 0.698039215686274 ) ;

		public static readonly HdrColor Pms495 =
			new HdrColor ( 0.956862745098039 , 0.737254901960784 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms496 =
			new HdrColor ( 0.968627450980392 , 0.788235294117647 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms497 =
			new HdrColor ( 0.317647058823529 , 0.156862745098039 , 0.149019607843137 ) ;

		public static readonly HdrColor Pms498 = new HdrColor ( 0.427450980392157 , 0.2 , 0.168627450980392 ) ;

		public static readonly HdrColor Pms499 =
			new HdrColor ( 0.47843137254902 , 0.219607843137255 , 0.176470588235294 ) ;

		public static readonly HdrColor Pms500 =
			new HdrColor ( 0.807843137254902 , 0.537254901960784 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms501 =
			new HdrColor ( 0.917647058823529 , 0.698039215686274 , 0.698039215686274 ) ;

		public static readonly HdrColor Pms502 =
			new HdrColor ( 0.949019607843137 , 0.776470588235294 , 0.768627450980392 ) ;

		public static readonly HdrColor Pms503 = new HdrColor ( 0.956862745098039 , 0.819607843137255 , 0.8 ) ;

		public static readonly HdrColor Pms4975 =
			new HdrColor ( 0.266666666666667 , 0.117647058823529 , 0.109803921568627 ) ;

		public static readonly HdrColor Pms4985 =
			new HdrColor ( 0.517647058823529 , 0.286274509803922 , 0.286274509803922 ) ;

		public static readonly HdrColor Pms4995 =
			new HdrColor ( 0.647058823529412 , 0.419607843137255 , 0.427450980392157 ) ;

		public static readonly HdrColor Pms5005 =
			new HdrColor ( 0.737254901960784 , 0.529411764705882 , 0.529411764705882 ) ;

		public static readonly HdrColor Pms5015 =
			new HdrColor ( 0.847058823529412 , 0.67843137254902 , 0.658823529411765 ) ;

		public static readonly HdrColor Pms5025 =
			new HdrColor ( 0.886274509803922 , 0.737254901960784 , 0.717647058823529 ) ;

		public static readonly HdrColor Pms5035 =
			new HdrColor ( 0.929411764705882 , 0.807843137254902 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms504 =
			new HdrColor ( 0.317647058823529 , 0.117647058823529 , 0.149019607843137 ) ;

		public static readonly HdrColor Pms505 = new HdrColor ( 0.4 , 0.117647058823529 , 0.168627450980392 ) ;

		public static readonly HdrColor Pms506 =
			new HdrColor ( 0.47843137254902 , 0.149019607843137 , 0.219607843137255 ) ;

		public static readonly HdrColor Pms507 =
			new HdrColor ( 0.847058823529412 , 0.537254901960784 , 0.607843137254902 ) ;

		public static readonly HdrColor Pms508 =
			new HdrColor ( 0.909803921568627 , 0.647058823529412 , 0.686274509803922 ) ;

		public static readonly HdrColor Pms509 =
			new HdrColor ( 0.949019607843137 , 0.729411764705882 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms510 =
			new HdrColor ( 0.956862745098039 , 0.776470588235294 , 0.788235294117647 ) ;

		public static readonly HdrColor Pms511 =
			new HdrColor ( 0.376470588235294 , 0.129411764705882 , 0.266666666666667 ) ;

		public static readonly HdrColor Pms512 =
			new HdrColor ( 0.517647058823529 , 0.129411764705882 , 0.419607843137255 ) ;

		public static readonly HdrColor Pms513 =
			new HdrColor ( 0.619607843137255 , 0.137254901960784 , 0.529411764705882 ) ;

		public static readonly HdrColor Pms514 =
			new HdrColor ( 0.847058823529412 , 0.517647058823529 , 0.737254901960784 ) ;

		public static readonly HdrColor Pms515 =
			new HdrColor ( 0.909803921568627 , 0.63921568627451 , 0.788235294117647 ) ;

		public static readonly HdrColor Pms516 =
			new HdrColor ( 0.949019607843137 , 0.729411764705882 , 0.827450980392157 ) ;

		public static readonly HdrColor Pms517 = new HdrColor ( 0.956862745098039 , 0.8 , 0.847058823529412 ) ;

		public static readonly HdrColor Pms5115 =
			new HdrColor ( 0.309803921568627 , 0.129411764705882 , 0.227450980392157 ) ;

		public static readonly HdrColor Pms5125 =
			new HdrColor ( 0.458823529411765 , 0.27843137254902 , 0.376470588235294 ) ;

		public static readonly HdrColor Pms5135 =
			new HdrColor ( 0.576470588235294 , 0.419607843137255 , 0.498039215686275 ) ;

		public static readonly HdrColor Pms5145 = new HdrColor ( 0.67843137254902 , 0.529411764705882 , 0.6 ) ;

		public static readonly HdrColor Pms5155 = new HdrColor ( 0.8 , 0.686274509803922 , 0.717647058823529 ) ;

		public static readonly HdrColor Pms5165 = new HdrColor ( 0.87843137254902 , 0.788235294117647 , 0.8 ) ;

		public static readonly HdrColor Pms5175 =
			new HdrColor ( 0.909803921568627 , 0.83921568627451 , 0.819607843137255 ) ;

		public static readonly HdrColor Pms518 =
			new HdrColor ( 0.317647058823529 , 0.176470588235294 , 0.266666666666667 ) ;

		public static readonly HdrColor Pms519 =
			new HdrColor ( 0.388235294117647 , 0.188235294117647 , 0.368627450980392 ) ;

		public static readonly HdrColor Pms520 =
			new HdrColor ( 0.43921568627451 , 0.207843137254902 , 0.447058823529412 ) ;

		public static readonly HdrColor Pms521 =
			new HdrColor ( 0.709803921568627 , 0.549019607843137 , 0.698039215686274 ) ;

		public static readonly HdrColor Pms522 =
			new HdrColor ( 0.776470588235294 , 0.63921568627451 , 0.756862745098039 ) ;

		public static readonly HdrColor Pms523 = new HdrColor ( 0.827450980392157 , 0.717647058823529 , 0.8 ) ;

		public static readonly HdrColor Pms524 = new HdrColor ( 0.886274509803922 , 0.8 , 0.827450980392157 ) ;

		public static readonly HdrColor Pms5185 =
			new HdrColor ( 0.27843137254902 , 0.156862745098039 , 0.207843137254902 ) ;

		public static readonly HdrColor Pms5195 = new HdrColor ( 0.349019607843137 , 0.2 , 0.266666666666667 ) ;

		public static readonly HdrColor Pms5205 =
			new HdrColor ( 0.556862745098039 , 0.407843137254902 , 0.466666666666667 ) ;

		public static readonly HdrColor Pms5215 =
			new HdrColor ( 0.709803921568627 , 0.576470588235294 , 0.607843137254902 ) ;

		public static readonly HdrColor Pms5225 = new HdrColor ( 0.8 , 0.67843137254902 , 0.686274509803922 ) ;

		public static readonly HdrColor Pms5235 =
			new HdrColor ( 0.866666666666667 , 0.776470588235294 , 0.768627450980392 ) ;

		public static readonly HdrColor Pms5245 = new HdrColor ( 0.898039215686275 , 0.827450980392157 , 0.8 ) ;

		public static readonly HdrColor Pms525 =
			new HdrColor ( 0.317647058823529 , 0.149019607843137 , 0.329411764705882 ) ;

		public static readonly HdrColor Pms526 =
			new HdrColor ( 0.407843137254902 , 0.129411764705882 , 0.47843137254902 ) ;

		public static readonly HdrColor Pms527 = new HdrColor ( 0.47843137254902 , 0.117647058823529 , 0.6 ) ;

		public static readonly HdrColor Pms528 =
			new HdrColor ( 0.686274509803922 , 0.447058823529412 , 0.756862745098039 ) ;

		public static readonly HdrColor Pms529 =
			new HdrColor ( 0.807843137254902 , 0.63921568627451 , 0.827450980392157 ) ;

		public static readonly HdrColor Pms530 =
			new HdrColor ( 0.83921568627451 , 0.686274509803922 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms531 =
			new HdrColor ( 0.898039215686275 , 0.776470588235294 , 0.858823529411765 ) ;

		public static readonly HdrColor Pms5255 =
			new HdrColor ( 0.207843137254902 , 0.149019607843137 , 0.309803921568627 ) ;

		public static readonly HdrColor Pms5265 =
			new HdrColor ( 0.286274509803922 , 0.23921568627451 , 0.388235294117647 ) ;

		public static readonly HdrColor Pms5275 =
			new HdrColor ( 0.376470588235294 , 0.337254901960784 , 0.466666666666667 ) ;

		public static readonly HdrColor Pms5285 = new HdrColor ( 0.549019607843137 , 0.509803921568627 , 0.6 ) ;

		public static readonly HdrColor Pms5295 =
			new HdrColor ( 0.698039215686274 , 0.658823529411765 , 0.709803921568627 ) ;

		public static readonly HdrColor Pms5305 = new HdrColor ( 0.8 , 0.756862745098039 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms5315 =
			new HdrColor ( 0.858823529411765 , 0.827450980392157 , 0.827450980392157 ) ;

		public static readonly HdrColor Pms532 =
			new HdrColor ( 0.207843137254902 , 0.219607843137255 , 0.258823529411765 ) ;

		public static readonly HdrColor Pms533 =
			new HdrColor ( 0.207843137254902 , 0.247058823529412 , 0.356862745098039 ) ;

		public static readonly HdrColor Pms534 =
			new HdrColor ( 0.227450980392157 , 0.286274509803922 , 0.447058823529412 ) ;

		public static readonly HdrColor Pms535 =
			new HdrColor ( 0.607843137254902 , 0.63921568627451 , 0.717647058823529 ) ;

		public static readonly HdrColor Pms536 =
			new HdrColor ( 0.67843137254902 , 0.698039215686274 , 0.756862745098039 ) ;

		public static readonly HdrColor Pms537 =
			new HdrColor ( 0.768627450980392 , 0.776470588235294 , 0.807843137254902 ) ;

		public static readonly HdrColor Pms538 =
			new HdrColor ( 0.83921568627451 , 0.827450980392157 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms539 = new HdrColor ( 0 , 0.188235294117647 , 0.286274509803922 ) ;

		public static readonly HdrColor Pms540 = new HdrColor ( 0 , 0.2 , 0.356862745098039 ) ;

		public static readonly HdrColor Pms541 = new HdrColor ( 0 , 0.247058823529412 , 0.466666666666667 ) ;

		public static readonly HdrColor Pms542 = new HdrColor ( 0.4 , 0.576470588235294 , 0.737254901960784 ) ;

		public static readonly HdrColor Pms543 =
			new HdrColor ( 0.576470588235294 , 0.717647058823529 , 0.819607843137255 ) ;

		public static readonly HdrColor Pms544 = new HdrColor ( 0.717647058823529 , 0.8 , 0.858823529411765 ) ;

		public static readonly HdrColor Pms545 =
			new HdrColor ( 0.768627450980392 , 0.827450980392157 , 0.866666666666667 ) ;

		public static readonly HdrColor Pms5395 =
			new HdrColor ( 0.00784313725490196 , 0.156862745098039 , 0.227450980392157 ) ;

		public static readonly HdrColor Pms5405 =
			new HdrColor ( 0.247058823529412 , 0.376470588235294 , 0.458823529411765 ) ;

		public static readonly HdrColor Pms5415 =
			new HdrColor ( 0.376470588235294 , 0.486274509803922 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms5425 = new HdrColor ( 0.517647058823529 , 0.6 , 0.647058823529412 ) ;

		public static readonly HdrColor Pms5435 =
			new HdrColor ( 0.686274509803922 , 0.737254901960784 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms5445 = new HdrColor ( 0.768627450980392 , 0.8 , 0.8 ) ;

		public static readonly HdrColor Pms5455 =
			new HdrColor ( 0.83921568627451 , 0.847058823529412 , 0.827450980392157 ) ;

		public static readonly HdrColor Pms546 =
			new HdrColor ( 0.0470588235294118 , 0.219607843137255 , 0.266666666666667 ) ;

		public static readonly HdrColor Pms547 = new HdrColor ( 0 , 0.247058823529412 , 0.329411764705882 ) ;

		public static readonly HdrColor Pms548 = new HdrColor ( 0 , 0.266666666666667 , 0.349019607843137 ) ;

		public static readonly HdrColor Pms549 = new HdrColor ( 0.368627450980392 , 0.6 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms550 =
			new HdrColor ( 0.529411764705882 , 0.686274509803922 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms551 =
			new HdrColor ( 0.63921568627451 , 0.756862745098039 , 0.788235294117647 ) ;

		public static readonly HdrColor Pms552 =
			new HdrColor ( 0.768627450980392 , 0.83921568627451 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms5463 = new HdrColor ( 0 , 0.207843137254902 , 0.227450980392157 ) ;

		public static readonly HdrColor Pms5473 =
			new HdrColor ( 0.149019607843137 , 0.407843137254902 , 0.427450980392157 ) ;

		public static readonly HdrColor Pms5483 =
			new HdrColor ( 0.376470588235294 , 0.568627450980392 , 0.568627450980392 ) ;

		public static readonly HdrColor Pms5493 =
			new HdrColor ( 0.549019607843137 , 0.686274509803922 , 0.67843137254902 ) ;

		public static readonly HdrColor Pms5503 =
			new HdrColor ( 0.666666666666667 , 0.768627450980392 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms5513 =
			new HdrColor ( 0.807843137254902 , 0.847058823529412 , 0.819607843137255 ) ;

		public static readonly HdrColor Pms5523 =
			new HdrColor ( 0.83921568627451 , 0.866666666666667 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms5467 = new HdrColor ( 0.0980392156862745 , 0.219607843137255 , 0.2 ) ;

		public static readonly HdrColor Pms5477 =
			new HdrColor ( 0.227450980392157 , 0.337254901960784 , 0.309803921568627 ) ;

		public static readonly HdrColor Pms5487 = new HdrColor ( 0.4 , 0.486274509803922 , 0.447058823529412 ) ;

		public static readonly HdrColor Pms5497 = new HdrColor ( 0.568627450980392 , 0.63921568627451 , 0.6 ) ;

		public static readonly HdrColor Pms5507 =
			new HdrColor ( 0.686274509803922 , 0.729411764705882 , 0.698039215686274 ) ;

		public static readonly HdrColor Pms5517 =
			new HdrColor ( 0.788235294117647 , 0.807843137254902 , 0.768627450980392 ) ;

		public static readonly HdrColor Pms5527 =
			new HdrColor ( 0.807843137254902 , 0.819607843137255 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms553 =
			new HdrColor ( 0.137254901960784 , 0.266666666666667 , 0.207843137254902 ) ;

		public static readonly HdrColor Pms554 =
			new HdrColor ( 0.0980392156862745 , 0.368627450980392 , 0.27843137254902 ) ;

		public static readonly HdrColor Pms555 =
			new HdrColor ( 0.0274509803921569 , 0.427450980392157 , 0.329411764705882 ) ;

		public static readonly HdrColor Pms556 =
			new HdrColor ( 0.47843137254902 , 0.658823529411765 , 0.568627450980392 ) ;

		public static readonly HdrColor Pms557 =
			new HdrColor ( 0.63921568627451 , 0.756862745098039 , 0.67843137254902 ) ;

		public static readonly HdrColor Pms558 =
			new HdrColor ( 0.717647058823529 , 0.807843137254902 , 0.737254901960784 ) ;

		public static readonly HdrColor Pms559 =
			new HdrColor ( 0.776470588235294 , 0.83921568627451 , 0.768627450980392 ) ;

		public static readonly HdrColor Pms5535 =
			new HdrColor ( 0.129411764705882 , 0.23921568627451 , 0.188235294117647 ) ;

		public static readonly HdrColor Pms5545 =
			new HdrColor ( 0.309803921568627 , 0.427450980392157 , 0.368627450980392 ) ;

		public static readonly HdrColor Pms5555 =
			new HdrColor ( 0.466666666666667 , 0.568627450980392 , 0.509803921568627 ) ;

		public static readonly HdrColor Pms5565 = new HdrColor ( 0.588235294117647 , 0.666666666666667 , 0.6 ) ;

		public static readonly HdrColor Pms5575 =
			new HdrColor ( 0.686274509803922 , 0.749019607843137 , 0.67843137254902 ) ;

		public static readonly HdrColor Pms5585 =
			new HdrColor ( 0.768627450980392 , 0.807843137254902 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms5595 = new HdrColor ( 0.847058823529412 , 0.858823529411765 , 0.8 ) ;

		public static readonly HdrColor Pms560 =
			new HdrColor ( 0.168627450980392 , 0.298039215686275 , 0.247058823529412 ) ;

		public static readonly HdrColor Pms561 = new HdrColor ( 0.149019607843137 , 0.4 , 0.349019607843137 ) ;

		public static readonly HdrColor Pms562 =
			new HdrColor ( 0.117647058823529 , 0.47843137254902 , 0.427450980392157 ) ;

		public static readonly HdrColor Pms563 =
			new HdrColor ( 0.498039215686275 , 0.737254901960784 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms564 =
			new HdrColor ( 0.627450980392157 , 0.807843137254902 , 0.737254901960784 ) ;

		public static readonly HdrColor Pms565 = new HdrColor ( 0.737254901960784 , 0.858823529411765 , 0.8 ) ;

		public static readonly HdrColor Pms566 =
			new HdrColor ( 0.819607843137255 , 0.886274509803922 , 0.827450980392157 ) ;

		public static readonly HdrColor Pms5605 =
			new HdrColor ( 0.137254901960784 , 0.227450980392157 , 0.176470588235294 ) ;

		public static readonly HdrColor Pms5615 =
			new HdrColor ( 0.329411764705882 , 0.407843137254902 , 0.337254901960784 ) ;

		public static readonly HdrColor Pms5625 =
			new HdrColor ( 0.447058823529412 , 0.517647058823529 , 0.43921568627451 ) ;

		public static readonly HdrColor Pms5635 = new HdrColor ( 0.619607843137255 , 0.666666666666667 , 0.6 ) ;

		public static readonly HdrColor Pms5645 =
			new HdrColor ( 0.737254901960784 , 0.756862745098039 , 0.698039215686274 ) ;

		public static readonly HdrColor Pms5655 = new HdrColor ( 0.776470588235294 , 0.8 , 0.729411764705882 ) ;

		public static readonly HdrColor Pms568 =
			new HdrColor ( 0.83921568627451 , 0.83921568627451 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms569 =
			new HdrColor ( 0.0196078431372549 , 0.43921568627451 , 0.368627450980392 ) ;

		public static readonly HdrColor Pms570 = new HdrColor ( 0 , 0.529411764705882 , 0.447058823529412 ) ;

		public static readonly HdrColor Pms571 =
			new HdrColor ( 0.498039215686275 , 0.776470588235294 , 0.698039215686274 ) ;

		public static readonly HdrColor Pms572 =
			new HdrColor ( 0.666666666666667 , 0.858823529411765 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms573 =
			new HdrColor ( 0.737254901960784 , 0.886274509803922 , 0.807843137254902 ) ;

		public static readonly HdrColor Pms574 = new HdrColor ( 0.8 , 0.898039215686275 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms575 =
			new HdrColor ( 0.286274509803922 , 0.349019607843137 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms576 =
			new HdrColor ( 0.329411764705882 , 0.466666666666667 , 0.188235294117647 ) ;

		public static readonly HdrColor Pms577 =
			new HdrColor ( 0.376470588235294 , 0.556862745098039 , 0.227450980392157 ) ;

		public static readonly HdrColor Pms578 = new HdrColor ( 0.709803921568627 , 0.8 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms579 =
			new HdrColor ( 0.776470588235294 , 0.83921568627451 , 0.627450980392157 ) ;

		public static readonly HdrColor Pms580 =
			new HdrColor ( 0.788235294117647 , 0.83921568627451 , 0.63921568627451 ) ;

		public static readonly HdrColor Pms5743 =
			new HdrColor ( 0.847058823529412 , 0.866666666666667 , 0.709803921568627 ) ;

		public static readonly HdrColor Pms5753 =
			new HdrColor ( 0.247058823529412 , 0.286274509803922 , 0.149019607843137 ) ;

		public static readonly HdrColor Pms5763 = new HdrColor ( 0.368627450980392 , 0.4 , 0.227450980392157 ) ;

		public static readonly HdrColor Pms5773 =
			new HdrColor ( 0.466666666666667 , 0.486274509803922 , 0.309803921568627 ) ;

		public static readonly HdrColor Pms5783 =
			new HdrColor ( 0.607843137254902 , 0.619607843137255 , 0.447058823529412 ) ;

		public static readonly HdrColor Pms5793 =
			new HdrColor ( 0.709803921568627 , 0.709803921568627 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms803 = new HdrColor ( 1 , 0.929411764705882 , 0.219607843137255 ) ;

		public static readonly HdrColor Pms5747 =
			new HdrColor ( 0.847058823529412 , 0.83921568627451 , 0.717647058823529 ) ;

		public static readonly HdrColor Pms5757 =
			new HdrColor ( 0.258823529411765 , 0.27843137254902 , 0.0862745098039216 ) ;

		public static readonly HdrColor Pms5767 =
			new HdrColor ( 0.419607843137255 , 0.43921568627451 , 0.168627450980392 ) ;

		public static readonly HdrColor Pms5777 =
			new HdrColor ( 0.549019607843137 , 0.568627450980392 , 0.309803921568627 ) ;

		public static readonly HdrColor Pms5787 =
			new HdrColor ( 0.666666666666667 , 0.67843137254902 , 0.458823529411765 ) ;

		public static readonly HdrColor Pms5797 = new HdrColor ( 0.776470588235294 , 0.776470588235294 , 0.6 ) ;

		public static readonly HdrColor Pms5807 =
			new HdrColor ( 0.827450980392157 , 0.819607843137255 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms581 =
			new HdrColor ( 0.87843137254902 , 0.866666666666667 , 0.737254901960784 ) ;

		public static readonly HdrColor Pms582 =
			new HdrColor ( 0.376470588235294 , 0.368627450980392 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms583 =
			new HdrColor ( 0.529411764705882 , 0.537254901960784 , 0.0196078431372549 ) ;

		public static readonly HdrColor Pms584 =
			new HdrColor ( 0.666666666666667 , 0.729411764705882 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms585 =
			new HdrColor ( 0.858823529411765 , 0.87843137254902 , 0.419607843137255 ) ;

		public static readonly HdrColor Pms586 =
			new HdrColor ( 0.886274509803922 , 0.898039215686275 , 0.517647058823529 ) ;

		public static readonly HdrColor Pms587 =
			new HdrColor ( 0.909803921568627 , 0.909803921568627 , 0.607843137254902 ) ;

		public static readonly HdrColor Pms5815 =
			new HdrColor ( 0.286274509803922 , 0.266666666666667 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms5825 =
			new HdrColor ( 0.458823529411765 , 0.43921568627451 , 0.168627450980392 ) ;

		public static readonly HdrColor Pms5835 = new HdrColor ( 0.619607843137255 , 0.6 , 0.349019607843137 ) ;

		public static readonly HdrColor Pms5845 =
			new HdrColor ( 0.698039215686274 , 0.666666666666667 , 0.43921568627451 ) ;

		public static readonly HdrColor Pms5855 = new HdrColor ( 0.8 , 0.776470588235294 , 0.576470588235294 ) ;

		public static readonly HdrColor Pms5865 =
			new HdrColor ( 0.83921568627451 , 0.807843137254902 , 0.63921568627451 ) ;

		public static readonly HdrColor Pms5875 =
			new HdrColor ( 0.87843137254902 , 0.858823529411765 , 0.709803921568627 ) ;

		public static readonly HdrColor Pms600 =
			new HdrColor ( 0.956862745098039 , 0.929411764705882 , 0.686274509803922 ) ;

		public static readonly HdrColor Pms601 =
			new HdrColor ( 0.949019607843137 , 0.929411764705882 , 0.619607843137255 ) ;

		public static readonly HdrColor Pms602 =
			new HdrColor ( 0.949019607843137 , 0.917647058823529 , 0.529411764705882 ) ;

		public static readonly HdrColor Pms603 =
			new HdrColor ( 0.929411764705882 , 0.909803921568627 , 0.356862745098039 ) ;

		public static readonly HdrColor Pms604 =
			new HdrColor ( 0.909803921568627 , 0.866666666666667 , 0.129411764705882 ) ;

		public static readonly HdrColor Pms605 =
			new HdrColor ( 0.866666666666667 , 0.807843137254902 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms606 =
			new HdrColor ( 0.827450980392157 , 0.749019607843137 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms607 =
			new HdrColor ( 0.949019607843137 , 0.917647058823529 , 0.737254901960784 ) ;

		public static readonly HdrColor Pms608 =
			new HdrColor ( 0.937254901960784 , 0.909803921568627 , 0.67843137254902 ) ;

		public static readonly HdrColor Pms609 =
			new HdrColor ( 0.917647058823529 , 0.898039215686275 , 0.588235294117647 ) ;

		public static readonly HdrColor Pms610 =
			new HdrColor ( 0.886274509803922 , 0.858823529411765 , 0.447058823529412 ) ;

		public static readonly HdrColor Pms611 =
			new HdrColor ( 0.83921568627451 , 0.807843137254902 , 0.286274509803922 ) ;

		public static readonly HdrColor Pms612 = new HdrColor ( 0.768627450980392 , 0.729411764705882 , 0 ) ;

		public static readonly HdrColor Pms613 =
			new HdrColor ( 0.686274509803922 , 0.627450980392157 , 0.0470588235294118 ) ;

		public static readonly HdrColor Pms614 =
			new HdrColor ( 0.917647058823529 , 0.886274509803922 , 0.717647058823529 ) ;

		public static readonly HdrColor Pms615 =
			new HdrColor ( 0.886274509803922 , 0.858823529411765 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms616 =
			new HdrColor ( 0.866666666666667 , 0.83921568627451 , 0.607843137254902 ) ;

		public static readonly HdrColor Pms617 = new HdrColor ( 0.8 , 0.768627450980392 , 0.486274509803922 ) ;

		public static readonly HdrColor Pms618 =
			new HdrColor ( 0.709803921568627 , 0.666666666666667 , 0.349019607843137 ) ;

		public static readonly HdrColor Pms619 =
			new HdrColor ( 0.588235294117647 , 0.549019607843137 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms620 =
			new HdrColor ( 0.517647058823529 , 0.466666666666667 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms621 =
			new HdrColor ( 0.847058823529412 , 0.866666666666667 , 0.807843137254902 ) ;

		public static readonly HdrColor Pms622 =
			new HdrColor ( 0.756862745098039 , 0.819607843137255 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms623 =
			new HdrColor ( 0.647058823529412 , 0.749019607843137 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms624 =
			new HdrColor ( 0.498039215686275 , 0.627450980392157 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms625 =
			new HdrColor ( 0.356862745098039 , 0.529411764705882 , 0.447058823529412 ) ;

		public static readonly HdrColor Pms626 =
			new HdrColor ( 0.129411764705882 , 0.329411764705882 , 0.247058823529412 ) ;

		public static readonly HdrColor Pms627 =
			new HdrColor ( 0.0470588235294118 , 0.188235294117647 , 0.149019607843137 ) ;

		public static readonly HdrColor Pms628 = new HdrColor ( 0.8 , 0.886274509803922 , 0.866666666666667 ) ;

		public static readonly HdrColor Pms629 =
			new HdrColor ( 0.698039215686274 , 0.847058823529412 , 0.847058823529412 ) ;

		public static readonly HdrColor Pms630 = new HdrColor ( 0.549019607843137 , 0.8 , 0.827450980392157 ) ;

		public static readonly HdrColor Pms631 =
			new HdrColor ( 0.329411764705882 , 0.717647058823529 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms632 = new HdrColor ( 0 , 0.627450980392157 , 0.729411764705882 ) ;

		public static readonly HdrColor Pms633 = new HdrColor ( 0 , 0.498039215686275 , 0.6 ) ;

		public static readonly HdrColor Pms634 = new HdrColor ( 0 , 0.4 , 0.498039215686275 ) ;

		public static readonly HdrColor Pms635 =
			new HdrColor ( 0.729411764705882 , 0.87843137254902 , 0.87843137254902 ) ;

		public static readonly HdrColor Pms636 = new HdrColor ( 0.6 , 0.83921568627451 , 0.866666666666667 ) ;

		public static readonly HdrColor Pms637 =
			new HdrColor ( 0.419607843137255 , 0.788235294117647 , 0.858823529411765 ) ;

		public static readonly HdrColor Pms638 = new HdrColor ( 0 , 0.709803921568627 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms639 = new HdrColor ( 0 , 0.627450980392157 , 0.768627450980392 ) ;

		public static readonly HdrColor Pms640 = new HdrColor ( 0 , 0.549019607843137 , 0.698039215686274 ) ;

		public static readonly HdrColor Pms641 = new HdrColor ( 0 , 0.47843137254902 , 0.647058823529412 ) ;

		public static readonly HdrColor Pms642 =
			new HdrColor ( 0.819607843137255 , 0.847058823529412 , 0.847058823529412 ) ;

		public static readonly HdrColor Pms643 =
			new HdrColor ( 0.776470588235294 , 0.819607843137255 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms644 =
			new HdrColor ( 0.607843137254902 , 0.686274509803922 , 0.768627450980392 ) ;

		public static readonly HdrColor Pms645 =
			new HdrColor ( 0.466666666666667 , 0.588235294117647 , 0.698039215686274 ) ;

		public static readonly HdrColor Pms646 =
			new HdrColor ( 0.368627450980392 , 0.509803921568627 , 0.63921568627451 ) ;

		public static readonly HdrColor Pms647 =
			new HdrColor ( 0.149019607843137 , 0.329411764705882 , 0.486274509803922 ) ;

		public static readonly HdrColor Pms648 = new HdrColor ( 0 , 0.188235294117647 , 0.368627450980392 ) ;

		public static readonly HdrColor Pms649 =
			new HdrColor ( 0.83921568627451 , 0.83921568627451 , 0.847058823529412 ) ;

		public static readonly HdrColor Pms650 =
			new HdrColor ( 0.749019607843137 , 0.776470588235294 , 0.819607843137255 ) ;

		public static readonly HdrColor Pms651 =
			new HdrColor ( 0.607843137254902 , 0.666666666666667 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms652 =
			new HdrColor ( 0.427450980392157 , 0.529411764705882 , 0.658823529411765 ) ;

		public static readonly HdrColor Pms653 = new HdrColor ( 0.2 , 0.337254901960784 , 0.529411764705882 ) ;

		public static readonly HdrColor Pms654 =
			new HdrColor ( 0.0588235294117647 , 0.168627450980392 , 0.356862745098039 ) ;

		public static readonly HdrColor Pms655 =
			new HdrColor ( 0.0470588235294118 , 0.109803921568627 , 0.27843137254902 ) ;

		public static readonly HdrColor Pms656 =
			new HdrColor ( 0.83921568627451 , 0.858823529411765 , 0.87843137254902 ) ;

		public static readonly HdrColor Pms657 =
			new HdrColor ( 0.756862745098039 , 0.788235294117647 , 0.866666666666667 ) ;

		public static readonly HdrColor Pms658 =
			new HdrColor ( 0.647058823529412 , 0.686274509803922 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms659 =
			new HdrColor ( 0.498039215686275 , 0.549019607843137 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms660 =
			new HdrColor ( 0.349019607843137 , 0.376470588235294 , 0.658823529411765 ) ;

		public static readonly HdrColor Pms661 = new HdrColor ( 0.176470588235294 , 0.2 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms662 =
			new HdrColor ( 0.0470588235294118 , 0.0980392156862745 , 0.458823529411765 ) ;

		public static readonly HdrColor Pms663 =
			new HdrColor ( 0.886274509803922 , 0.827450980392157 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms664 = new HdrColor ( 0.847058823529412 , 0.8 , 0.819607843137255 ) ;

		public static readonly HdrColor Pms665 =
			new HdrColor ( 0.776470588235294 , 0.709803921568627 , 0.768627450980392 ) ;

		public static readonly HdrColor Pms666 =
			new HdrColor ( 0.658823529411765 , 0.576470588235294 , 0.67843137254902 ) ;

		public static readonly HdrColor Pms667 = new HdrColor ( 0.498039215686275 , 0.4 , 0.537254901960784 ) ;

		public static readonly HdrColor Pms668 = new HdrColor ( 0.4 , 0.286274509803922 , 0.458823529411765 ) ;

		public static readonly HdrColor Pms669 =
			new HdrColor ( 0.27843137254902 , 0.168627450980392 , 0.349019607843137 ) ;

		public static readonly HdrColor Pms670 =
			new HdrColor ( 0.949019607843137 , 0.83921568627451 , 0.847058823529412 ) ;

		public static readonly HdrColor Pms671 =
			new HdrColor ( 0.937254901960784 , 0.776470588235294 , 0.827450980392157 ) ;

		public static readonly HdrColor Pms672 =
			new HdrColor ( 0.917647058823529 , 0.666666666666667 , 0.768627450980392 ) ;

		public static readonly HdrColor Pms673 =
			new HdrColor ( 0.87843137254902 , 0.549019607843137 , 0.698039215686274 ) ;

		public static readonly HdrColor Pms674 =
			new HdrColor ( 0.827450980392157 , 0.419607843137255 , 0.619607843137255 ) ;

		public static readonly HdrColor Pms675 =
			new HdrColor ( 0.737254901960784 , 0.219607843137255 , 0.466666666666667 ) ;

		public static readonly HdrColor Pms676 = new HdrColor ( 0.627450980392157 , 0 , 0.329411764705882 ) ;

		public static readonly HdrColor Pms677 =
			new HdrColor ( 0.929411764705882 , 0.83921568627451 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms678 = new HdrColor ( 0.917647058823529 , 0.8 , 0.807843137254902 ) ;

		public static readonly HdrColor Pms679 =
			new HdrColor ( 0.898039215686275 , 0.749019607843137 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms680 =
			new HdrColor ( 0.827450980392157 , 0.619607843137255 , 0.686274509803922 ) ;

		public static readonly HdrColor Pms681 =
			new HdrColor ( 0.717647058823529 , 0.447058823529412 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms682 =
			new HdrColor ( 0.627450980392157 , 0.317647058823529 , 0.458823529411765 ) ;

		public static readonly HdrColor Pms683 =
			new HdrColor ( 0.498039215686275 , 0.156862745098039 , 0.309803921568627 ) ;

		public static readonly HdrColor Pms684 = new HdrColor ( 0.937254901960784 , 0.8 , 0.807843137254902 ) ;

		public static readonly HdrColor Pms685 =
			new HdrColor ( 0.917647058823529 , 0.749019607843137 , 0.768627450980392 ) ;

		public static readonly HdrColor Pms686 =
			new HdrColor ( 0.87843137254902 , 0.666666666666667 , 0.729411764705882 ) ;

		public static readonly HdrColor Pms687 =
			new HdrColor ( 0.788235294117647 , 0.537254901960784 , 0.619607843137255 ) ;

		public static readonly HdrColor Pms688 = new HdrColor ( 0.698039215686274 , 0.4 , 0.517647058823529 ) ;

		public static readonly HdrColor Pms689 = new HdrColor ( 0.576470588235294 , 0.258823529411765 , 0.4 ) ;

		public static readonly HdrColor Pms690 =
			new HdrColor ( 0.43921568627451 , 0.137254901960784 , 0.258823529411765 ) ;

		public static readonly HdrColor Pms691 =
			new HdrColor ( 0.937254901960784 , 0.819607843137255 , 0.788235294117647 ) ;

		public static readonly HdrColor Pms692 =
			new HdrColor ( 0.909803921568627 , 0.749019607843137 , 0.729411764705882 ) ;

		public static readonly HdrColor Pms693 =
			new HdrColor ( 0.858823529411765 , 0.658823529411765 , 0.647058823529412 ) ;

		public static readonly HdrColor Pms694 =
			new HdrColor ( 0.788235294117647 , 0.549019607843137 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms695 =
			new HdrColor ( 0.698039215686274 , 0.419607843137255 , 0.43921568627451 ) ;

		public static readonly HdrColor Pms696 =
			new HdrColor ( 0.556862745098039 , 0.27843137254902 , 0.286274509803922 ) ;

		public static readonly HdrColor Pms697 =
			new HdrColor ( 0.498039215686275 , 0.219607843137255 , 0.227450980392157 ) ;

		public static readonly HdrColor Pms698 = new HdrColor ( 0.968627450980392 , 0.819607843137255 , 0.8 ) ;

		public static readonly HdrColor Pms699 =
			new HdrColor ( 0.968627450980392 , 0.749019607843137 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms700 =
			new HdrColor ( 0.949019607843137 , 0.647058823529412 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms701 =
			new HdrColor ( 0.909803921568627 , 0.529411764705882 , 0.556862745098039 ) ;

		public static readonly HdrColor Pms702 =
			new HdrColor ( 0.83921568627451 , 0.376470588235294 , 0.427450980392157 ) ;

		public static readonly HdrColor Pms703 =
			new HdrColor ( 0.717647058823529 , 0.219607843137255 , 0.266666666666667 ) ;

		public static readonly HdrColor Pms704 =
			new HdrColor ( 0.619607843137255 , 0.156862745098039 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms705 =
			new HdrColor ( 0.976470588235294 , 0.866666666666667 , 0.83921568627451 ) ;

		public static readonly HdrColor Pms706 =
			new HdrColor ( 0.988235294117647 , 0.788235294117647 , 0.776470588235294 ) ;

		public static readonly HdrColor Pms707 =
			new HdrColor ( 0.988235294117647 , 0.67843137254902 , 0.686274509803922 ) ;

		public static readonly HdrColor Pms708 = new HdrColor ( 0.976470588235294 , 0.556862745098039 , 0.6 ) ;

		public static readonly HdrColor Pms709 =
			new HdrColor ( 0.949019607843137 , 0.407843137254902 , 0.466666666666667 ) ;

		public static readonly HdrColor Pms710 =
			new HdrColor ( 0.87843137254902 , 0.258823529411765 , 0.317647058823529 ) ;

		public static readonly HdrColor Pms711 = new HdrColor ( 0.819607843137255 , 0.176470588235294 , 0.2 ) ;

		public static readonly HdrColor Pms712 = new HdrColor ( 1 , 0.827450980392157 , 0.666666666666667 ) ;

		public static readonly HdrColor Pms713 =
			new HdrColor ( 0.976470588235294 , 0.788235294117647 , 0.63921568627451 ) ;

		public static readonly HdrColor Pms714 =
			new HdrColor ( 0.976470588235294 , 0.729411764705882 , 0.509803921568627 ) ;

		public static readonly HdrColor Pms715 =
			new HdrColor ( 0.988235294117647 , 0.619607843137255 , 0.286274509803922 ) ;

		public static readonly HdrColor Pms716 =
			new HdrColor ( 0.949019607843137 , 0.517647058823529 , 0.0666666666666667 ) ;

		public static readonly HdrColor Pms717 = new HdrColor ( 0.827450980392157 , 0.427450980392157 , 0 ) ;

		public static readonly HdrColor Pms718 = new HdrColor ( 0.749019607843137 , 0.356862745098039 , 0 ) ;

		public static readonly HdrColor Pms719 =
			new HdrColor ( 0.956862745098039 , 0.819607843137255 , 0.686274509803922 ) ;

		public static readonly HdrColor Pms720 =
			new HdrColor ( 0.937254901960784 , 0.768627450980392 , 0.619607843137255 ) ;

		public static readonly HdrColor Pms721 =
			new HdrColor ( 0.909803921568627 , 0.698039215686274 , 0.509803921568627 ) ;

		public static readonly HdrColor Pms722 =
			new HdrColor ( 0.819607843137255 , 0.556862745098039 , 0.329411764705882 ) ;

		public static readonly HdrColor Pms723 =
			new HdrColor ( 0.729411764705882 , 0.458823529411765 , 0.188235294117647 ) ;

		public static readonly HdrColor Pms724 =
			new HdrColor ( 0.556862745098039 , 0.286274509803922 , 0.0196078431372549 ) ;

		public static readonly HdrColor Pms725 =
			new HdrColor ( 0.458823529411765 , 0.219607843137255 , 0.00784313725490196 ) ;

		public static readonly HdrColor Pms726 =
			new HdrColor ( 0.929411764705882 , 0.827450980392157 , 0.709803921568627 ) ;

		public static readonly HdrColor Pms727 =
			new HdrColor ( 0.886274509803922 , 0.749019607843137 , 0.607843137254902 ) ;

		public static readonly HdrColor Pms728 =
			new HdrColor ( 0.827450980392157 , 0.658823529411765 , 0.486274509803922 ) ;

		public static readonly HdrColor Pms729 =
			new HdrColor ( 0.756862745098039 , 0.556862745098039 , 0.376470588235294 ) ;

		public static readonly HdrColor Pms730 =
			new HdrColor ( 0.666666666666667 , 0.458823529411765 , 0.247058823529412 ) ;

		public static readonly HdrColor Pms731 =
			new HdrColor ( 0.447058823529412 , 0.247058823529412 , 0.0392156862745098 ) ;

		public static readonly HdrColor Pms732 = new HdrColor ( 0.376470588235294 , 0.2 , 0.0392156862745098 ) ;

		public static readonly HdrColor Yellow2X =
			new HdrColor ( 0.988235294117647 , 0.886274509803922 , 0.0862745098039216 ) ;

		public static readonly HdrColor Pms1162X =
			new HdrColor ( 0.968627450980392 , 0.709803921568627 , 0.0470588235294118 ) ;

		public static readonly HdrColor Pms1302X = new HdrColor ( 0.886274509803922 , 0.568627450980392 , 0 ) ;

		public static readonly HdrColor Pms1652X = new HdrColor ( 0.917647058823529 , 0.309803921568627 , 0 ) ;

		public static readonly HdrColor WarmRed2X = new HdrColor ( 0.87843137254902 , 0.227450980392157 , 0 ) ;

		public static readonly HdrColor Pms17882X = new HdrColor ( 0.83921568627451 , 0.129411764705882 , 0 ) ;

		public static readonly HdrColor Pms18522X = new HdrColor ( 0.819607843137255 , 0.0862745098039216 , 0 ) ;

		public static readonly HdrColor Pms4852X = new HdrColor ( 0.8 , 0.0470588235294118 , 0 ) ;

		public static readonly HdrColor RubineRed2X = new HdrColor ( 0.776470588235294 , 0 , 0.23921568627451 ) ;

		public static readonly HdrColor RhodamineRed2X =
			new HdrColor ( 0.819607843137255 , 0.0196078431372549 , 0.447058823529412 ) ;

		public static readonly HdrColor Pms2392X =
			new HdrColor ( 0.768627450980392 , 0.0196078431372549 , 0.486274509803922 ) ;

		public static readonly HdrColor Purple2X = new HdrColor ( 0.666666666666667 , 0 , 0.588235294117647 ) ;

		public static readonly HdrColor Pms25922X = new HdrColor ( 0.447058823529412 , 0 , 0.509803921568627 ) ;

		public static readonly HdrColor Violet2X = new HdrColor ( 0.349019607843137 , 0 , 0.556862745098039 ) ;

		public static readonly HdrColor ReflexBlue2X = new HdrColor ( 0.109803921568627 , 0 , 0.47843137254902 ) ;

		public static readonly HdrColor ProcessBlue2X = new HdrColor ( 0 , 0.466666666666667 , 0.749019607843137 ) ;

		public static readonly HdrColor Pms2992X = new HdrColor ( 0 , 0.498039215686275 , 0.8 ) ;

		public static readonly HdrColor Pms3062X = new HdrColor ( 0 , 0.63921568627451 , 0.819607843137255 ) ;

		public static readonly HdrColor Pms3202X = new HdrColor ( 0 , 0.498039215686275 , 0.509803921568627 ) ;

		public static readonly HdrColor Pms3272X = new HdrColor ( 0 , 0.537254901960784 , 0.466666666666667 ) ;

		public static readonly HdrColor Green2X = new HdrColor ( 0 , 0.588235294117647 , 0.466666666666667 ) ;

		public static readonly HdrColor Pms3542X = new HdrColor ( 0 , 0.6 , 0.266666666666667 ) ;

		public static readonly HdrColor Pms3682X = new HdrColor ( 0 , 0.619607843137255 , 0.0588235294117647 ) ;

		public static readonly HdrColor Pms3752X = new HdrColor ( 0.329411764705882 , 0.737254901960784 , 0 ) ;

		public static readonly HdrColor Pms3822X = new HdrColor ( 0.619607843137255 , 0.768627450980392 , 0 ) ;

		public static readonly HdrColor Pms4712X =
			new HdrColor ( 0.63921568627451 , 0.266666666666667 , 0.00784313725490196 ) ;

		public static readonly HdrColor Pms4642X =
			new HdrColor ( 0.43921568627451 , 0.258823529411765 , 0.0784313725490196 ) ;

		public static readonly HdrColor Pms4332X =
			new HdrColor ( 0.0392156862745098 , 0.0470588235294118 , 0.0666666666666667 ) ;

		public static readonly HdrColor Black2 = new HdrColor ( 0.227450980392157 , 0.2 , 0.129411764705882 ) ;

		public static readonly HdrColor Black3 =
			new HdrColor ( 0.156862745098039 , 0.176470588235294 , 0.149019607843137 ) ;

		public static readonly HdrColor Black4 =
			new HdrColor ( 0.23921568627451 , 0.188235294117647 , 0.137254901960784 ) ;

		public static readonly HdrColor Black5 =
			new HdrColor ( 0.258823529411765 , 0.176470588235294 , 0.176470588235294 ) ;

		public static readonly HdrColor Black6 =
			new HdrColor ( 0.109803921568627 , 0.149019607843137 , 0.188235294117647 ) ;

		public static readonly HdrColor Black7 =
			new HdrColor ( 0.266666666666667 , 0.23921568627451 , 0.219607843137255 ) ;

		public static readonly HdrColor Black22X =
			new HdrColor ( 0.0666666666666667 , 0.0666666666666667 , 0.0666666666666667 ) ;

		public static readonly HdrColor Black32X =
			new HdrColor ( 0.0666666666666667 , 0.0666666666666667 , 0.0784313725490196 ) ;

		public static readonly HdrColor Black42X =
			new HdrColor ( 0.0588235294117647 , 0.0588235294117647 , 0.0588235294117647 ) ;

		public static readonly HdrColor Black52X =
			new HdrColor ( 0.0666666666666667 , 0.0470588235294118 , 0.0588235294117647 ) ;

		public static readonly HdrColor Black62X =
			new HdrColor ( 0.0274509803921569 , 0.0470588235294118 , 0.0588235294117647 ) ;

		public static readonly HdrColor Black72X = new HdrColor ( 0.2 , 0.188235294117647 , 0.168627450980392 ) ;

		public static readonly HdrColor Pms801 = new HdrColor ( 0 , 0.666666666666667 , 0.8 ) ;

		public static readonly HdrColor Pms802 =
			new HdrColor ( 0.376470588235294 , 0.866666666666667 , 0.286274509803922 ) ;

		public static readonly HdrColor Pms804 = new HdrColor ( 1 , 0.576470588235294 , 0.219607843137255 ) ;

		public static readonly HdrColor Pms805 =
			new HdrColor ( 0.976470588235294 , 0.349019607843137 , 0.317647058823529 ) ;

		public static readonly HdrColor Pms806 = new HdrColor ( 1 , 0 , 0.576470588235294 ) ;

		public static readonly HdrColor Pms807 = new HdrColor ( 0.83921568627451 , 0 , 0.619607843137255 ) ;

		public static readonly HdrColor Pms8012X = new HdrColor ( 0 , 0.537254901960784 , 0.686274509803922 ) ;

		public static readonly HdrColor Pms8022X =
			new HdrColor ( 0.109803921568627 , 0.807843137254902 , 0.156862745098039 ) ;

		public static readonly HdrColor Pms8032X = new HdrColor ( 1 , 0.847058823529412 , 0.0862745098039216 ) ;

		public static readonly HdrColor Pms8042X = new HdrColor ( 1 , 0.498039215686275 , 0.117647058823529 ) ;

		public static readonly HdrColor Pms8052X =
			new HdrColor ( 0.976470588235294 , 0.227450980392157 , 0.168627450980392 ) ;

		public static readonly HdrColor Pms8062X =
			new HdrColor ( 0.968627450980392 , 0.00784313725490196 , 0.486274509803922 ) ;

		public static readonly HdrColor Pms8072X = new HdrColor ( 0.749019607843137 , 0 , 0.549019607843137 ) ;

		public static readonly HdrColor Pms808 = new HdrColor ( 0 , 0.709803921568627 , 0.607843137254902 ) ;

		public static readonly HdrColor Pms809 =
			new HdrColor ( 0.866666666666667 , 0.87843137254902 , 0.0588235294117647 ) ;

		public static readonly HdrColor Pms810 = new HdrColor ( 1 , 0.8 , 0.117647058823529 ) ;

		public static readonly HdrColor Pms811 = new HdrColor ( 1 , 0.447058823529412 , 0.27843137254902 ) ;

		public static readonly HdrColor Pms812 = new HdrColor ( 0.988235294117647 , 0.137254901960784 , 0.4 ) ;

		public static readonly HdrColor Pms813 = new HdrColor ( 0.898039215686275 , 0 , 0.6 ) ;

		public static readonly HdrColor Pms814 =
			new HdrColor ( 0.549019607843137 , 0.376470588235294 , 0.756862745098039 ) ;

		public static readonly HdrColor Pms8082X = new HdrColor ( 0 , 0.627450980392157 , 0.529411764705882 ) ;

		public static readonly HdrColor Pms8092X =
			new HdrColor ( 0.83921568627451 , 0.83921568627451 , 0.0470588235294118 ) ;

		public static readonly HdrColor Pms8102X = new HdrColor ( 1 , 0.737254901960784 , 0.129411764705882 ) ;

		public static readonly HdrColor Pms8112X = new HdrColor ( 1 , 0.329411764705882 , 0.0862745098039216 ) ;

		public static readonly HdrColor Pms8122X =
			new HdrColor ( 0.988235294117647 , 0.0274509803921569 , 0.309803921568627 ) ;

		public static readonly HdrColor Pms8132X = new HdrColor ( 0.819607843137255 , 0 , 0.517647058823529 ) ;

		public static readonly HdrColor Pms8142X =
			new HdrColor ( 0.43921568627451 , 0.247058823529412 , 0.686274509803922 ) ;

	}

}
