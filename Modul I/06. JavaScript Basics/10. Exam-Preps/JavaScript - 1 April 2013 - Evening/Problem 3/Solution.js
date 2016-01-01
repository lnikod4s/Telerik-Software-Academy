window.onload = function () {

    function Solve(inputArr) {

        var returnString = "",
            definedFunctions = {};
        for (var i = 0; i < inputArr.length; i++) {
            //replace the called functions in the functions with their results
            var firstRE = new RegExp(",", "g");
            inputArr[i] = inputArr[i].replace(firstRE, " , ");
            firstRE = new RegExp("\\[", "g");
            inputArr[i] = inputArr[i].replace(firstRE, "[ ");
            firstRE = new RegExp("\\]", "g");
            inputArr[i] = inputArr[i].replace(firstRE, " ]");
            for (var key in definedFunctions) {
                var re = new RegExp(" " + key + " ", "g");
                inputArr[i] = inputArr[i].replace(re, " " + definedFunctions[key] + " ");
                inputArr[i] = inputArr[i].replace(re, " " + definedFunctions[key] + " ");
            }

            var splittedFunction = inputArr[i].split('['),
             funcProps = GetFunctionProps(splittedFunction[0]);
            //Check if the string line is a definition of a function
            if (inputArr[i].indexOf("def ") !== -1) {
                //split the function by "[" sign
                definedFunctions[funcProps.funcName] = GetFunctionValue(funcProps.funcOperation, splittedFunction[1]);
                //console.log(definedFunctions[funcProps.funcName])
            }
            if (i === inputArr.length - 1) {
                returnString = GetFunctionValue(funcProps.funcOperation, splittedFunction[1]);
            }
        }
        //console.log(definedFunctions);
        return returnString;
    }

    function GetFunctionProps(functionString) {
        var splittedFunctionString = functionString.split(' '),
            returnObject = { funcName: "", funcOperation: "none" };
        for (var i = splittedFunctionString.length - 1; i >= 0 ; i--) {
            if (splittedFunctionString[i] === "sum" ||
                splittedFunctionString[i] === "avg" ||
                splittedFunctionString[i] === "min" ||
                splittedFunctionString[i] === "max") {
                returnObject.funcOperation = splittedFunctionString[i];
            }
            if (isNaN(splittedFunctionString[i]) &&
                splittedFunctionString[i] !== "def" &&
                splittedFunctionString[i] !== returnObject.funcOperation &&
                splittedFunctionString[i].length > 0) {
                returnObject.funcName = splittedFunctionString[i];
            }
        }
        //console.log(returnObject);
        return returnObject;
    }

    function GetFunctionValue(functionOperation, functionString) {
        var newString = functionString.split(']');
        if (functionOperation === "none") {
            return newString[0].trim();
        } else {
            var splittedFunctionString = newString[0].split(','),
                result = (functionOperation === 'min') ? Number.MAX_VALUE : 0,
                count = 0,
                number;
            for (var i = 0; i < splittedFunctionString.length; i++) {
                var numberString = splittedFunctionString[i].trim();
                if (!isNaN(numberString) && numberString.length > 0) {
                    number = parseInt(numberString);
                    count++;
                    if (functionOperation === 'sum' || functionOperation === 'avg') {
                        result = result + number;
                    } else if (functionOperation === 'max') {
                        if (number > Number.MIN_VALUE && number > result) {
                            result = number;
                        }
                    } else if (functionOperation === 'min') {
                        if (number < result) {
                            result = number;
                        }
                    }
                }
            }
            if (functionOperation === 'avg') {
                return parseInt(result / count);
            }
            return result;
        }

    }

    var zeroTestArr =  ['def func sum[5, 3, 7, 2, 6, 3]',
                        'def func2 [5, 3, 7, 2, 6, 3]',
                        'def func3 min[func2]',
                        'def func4 max[5, 3, 7, 2, 6, 3]',
                        'def func5 avg[5, 3, 7, 2, 6, 3]',
                        'def func6 sum[func2, func3, func4 ]',
                        'sum[func6, func4]'];
    //42
    var zeroTestArr1 = ['def func sum[1, 2, 3, -6]',
                        'def newList [func, 10, 1]',
                        'def newFunc sum[func, 100, newList]',
                        '[newFunc]'];
    //111
    var testArr1 = ['def definition[-100, -100, -100]',
                    'def definitionResult sum[definition]',
                    'def defTest sum[definitionResult, 6457457, 2345234, -234546]',
                    'avg[defTest, 1, 2, 3]'];
    //2141962
    var testArr2 =
    ["def test0[1]",
    "def test1 sum[1,test0]  ",
    "def test2 sum[1,test1]    ",
    "def test3 sum[1,test2]    ",
    "def test4 sum[1,test3]    ",
    "def test5 sum[1,test4]    ",
    "def test6 sum[1,test5]    ",
    "def test7 sum[1,test6]    ",
    "def test8 sum[1,test7]    ",
    "def test9 sum[1,test8]    ",
    "def test10 sum[1,test9]   ",
    "def test11 sum[1,test10]  ",
    "def test12 sum[1,test11]  ",
    "def test13 sum[1,test12]  ",
    "def test14 sum[1,test13]  ",
    "def test15 sum[1,test14]  ",
    "def test16 sum[1,test15]  ",
    "def test17 sum[1,test16]  ",
    "def test18 sum[1,test17]  ",
    "def test19 sum[1,test18]  ",
    "def test20 sum[1,test19]  ",
    "def test21 sum[1,test20]  ",
    "def test22 sum[1,test21]  ",
    "def test23 sum[1,test22]  ",
    "def test24 sum[1,test23]  ",
    "def test25 sum[1,test24]  ",
    "def test26 sum[1,test25]  ",
    "def test27 sum[1,test26]  ",
    "def test28 sum[1,test27]  ",
    "def test29 sum[1,test28]  ",
    "def test30 sum[1,test29]  ",
    "def test31 sum[1,test30]  ",
    "def test32 sum[1,test31]  ",
    "def test33 sum[1,test32]  ",
    "def test34 sum[1,test33]  ",
    "def test35 sum[1,test34]  ",
    "def test36 sum[1,test35]  ",
    "def test37 sum[1,test36]  ",
    "def test38 sum[1,test37]  ",
    "def test39 sum[1,test38]  ",
    "def test40 sum[1,test39]  ",
    "def test41 sum[1,test40]  ",
    "def test42 sum[1,test41]  ",
    "def test43 sum[1,test42]  ",
    "def test44 sum[1,test43]  ",
    "def test45 sum[1,test44]  ",
    "def test46 sum[1,test45]  ",
    "def test47 sum[1,test46]  ",
    "def test48 sum[1,test47]  ",
    "def test49 sum[1,test48]  ",
    "def test50 sum[1,test49]  ",
    "def test51 sum[1,test50]  ",
    "def test52 sum[1,test51]  ",
    "def test53 sum[1,test52]  ",
    "def test54 sum[1,test53]  ",
    "def test55 sum[1,test54]  ",
    "def test56 sum[1,test55]  ",
    "def test57 sum[1,test56]  ",
    "def test58 sum[1,test57]  ",
    "def test59 sum[1,test58]  ",
    "def test60 sum[1,test59]  ",
    "def test61 sum[1,test60]  ",
    "def test62 sum[1,test61]  ",
    "def test63 sum[1,test62]  ",
    "def test64 sum[1,test63]  ",
    "def test65 sum[1,test64]  ",
    "def test66 sum[1,test65]  ",
    "def test67 sum[1,test66]  ",
    "def test68 sum[1,test67]  ",
    "def test69 sum[1,test68]  ",
    "def test70 sum[1,test69]  ",
    "def test71 sum[1,test70]  ",
    "def test72 sum[1,test71]  ",
    "def test73 sum[1,test72]  ",
    "def test74 sum[1,test73]  ",
    "def test75 sum[1,test74]  ",
    "def test76 sum[1,test75]  ",
    "def test77 sum[1,test76]  ",
    "def test78 sum[1,test77]  ",
    "def test79 sum[1,test78]  ",
    "def test80 sum[1,test79]  ",
    "def test81 sum[1,test80]  ",
    "def test82 sum[1,test81]  ",
    "def test83 sum[1,test82]  ",
    "def test84 sum[1,test83]  ",
    "def test85 sum[1,test84]  ",
    "def test86 sum[1,test85]  ",
    "def test87 sum[1,test86]  ",
    "def test88 sum[1,test87]  ",
    "def test89 sum[1,test88]  ",
    "def test90 sum[1,test89]  ",
    "def test91 sum[1,test90]  ",
    "def test92 sum[1,test91]  ",
    "def test93 sum[1,test92]  ",
    "def test94 sum[1,test93]  ",
    "def test95 sum[1,test94]  ",
    "def test96 sum[1,test95]  ",
    "def test97 sum[1,test96]  ",
    "def test98 sum[1,test97]  ",
    "def test99 sum[1,test98]  ",
    "def test100 sum[1,test99] ",
    "def test101 sum[1,test100]",
    "def test102 sum[1,test101]",
    "def test103 sum[1,test102]",
    "def test104 sum[1,test103]",
    "def test105 sum[1,test104]",
    "def test106 sum[1,test105]",
    "def test107 sum[1,test106]",
    "def test108 sum[1,test107]",
    "def test109 sum[1,test108]",
    "def test110 sum[1,test109]",
    "def test111 sum[1,test110]",
    "def test112 sum[1,test111]",
    "def test113 sum[1,test112]",
    "def test114 sum[1,test113]",
    "def test115 sum[1,test114]",
    "def test116 sum[1,test115]",
    "def test117 sum[1,test116]",
    "def test118 sum[1,test117]",
    "def test119 sum[1,test118]",
    "def test120 sum[1,test119]",
    "def test121 sum[1,test120]",
    "def test122 sum[1,test121]",
    "def test123 sum[1,test122]",
    "def test124 sum[1,test123]",
    "def test125 sum[1,test124]",
    "def test126 sum[1,test125]",
    "def test127 sum[1,test126]",
    "def test128 sum[1,test127]",
    "def test129 sum[1,test128]",
    "def test130 sum[1,test129]",
    "def test131 sum[1,test130]",
    "def test132 sum[1,test131]",
    "def test133 sum[1,test132]",
    "def test134 sum[1,test133]",
    "def test135 sum[1,test134]",
    "def test136 sum[1,test135]",
    "def test137 sum[1,test136]",
    "def test138 sum[1,test137]",
    "def test139 sum[1,test138]",
    "def test140 sum[1,test139]",
    "def test141 sum[1,test140]",
    "def test142 sum[1,test141]",
    "def test143 sum[1,test142]",
    "def test144 sum[1,test143]",
    "def test145 sum[1,test144]",
    "def test146 sum[1,test145]",
    "def test147 sum[1,test146]",
    "def test148 sum[1,test147]",
    "def test149 sum[1,test148]",
    "def test150 sum[1,test149]",
    "def test151 sum[1,test150]",
    "def test152 sum[1,test151]",
    "def test153 sum[1,test152]",
    "def test154 sum[1,test153]",
    "def test155 sum[1,test154]",
    "def test156 sum[1,test155]",
    "def test157 sum[1,test156]",
    "def test158 sum[1,test157]",
    "def test159 sum[1,test158]",
    "def test160 sum[1,test159]",
    "def test161 sum[1,test160]",
    "def test162 sum[1,test161]",
    "def test163 sum[1,test162]",
    "def test164 sum[1,test163]",
    "def test165 sum[1,test164]",
    "def test166 sum[1,test165]",
    "def test167 sum[1,test166]",
    "def test168 sum[1,test167]",
    "def test169 sum[1,test168]",
    "def test170 sum[1,test169]",
    "def test171 sum[1,test170]",
    "def test172 sum[1,test171]",
    "def test173 sum[1,test172]",
    "def test174 sum[1,test173]",
    "def test175 sum[1,test174]",
    "def test176 sum[1,test175]",
    "def test177 sum[1,test176]",
    "def test178 sum[1,test177]",
    "def test179 sum[1,test178]",
    "def test180 sum[1,test179]",
    "def test181 sum[1,test180]",
    "def test182 sum[1,test181]",
    "def test183 sum[1,test182]",
    "def test184 sum[1,test183]",
    "def test185 sum[1,test184]",
    "def test186 sum[1,test185]",
    "def test187 sum[1,test186]",
    "def test188 sum[1,test187]",
    "def test189 sum[1,test188]",
    "def test190 sum[1,test189]",
    "def test191 sum[1,test190]",
    "def test192 sum[1,test191]",
    "def test193 sum[1,test192]",
    "def test194 sum[1,test193]",
    "def test195 sum[1,test194]",
    "def test196 sum[1,test195]",
    "def test197 sum[1,test196]",
    "def test198 sum[1,test197]",
    "def test199 sum[1,test198]",
    "def test200 sum[1,test199]",
    "def test201 sum[1,test200]",
    "def test202 sum[1,test201]",
    "def test203 sum[1,test202]",
    "def test204 sum[1,test203]",
    "def test205 sum[1,test204]",
    "def test206 sum[1,test205]",
    "def test207 sum[1,test206]",
    "def test208 sum[1,test207]",
    "def test209 sum[1,test208]",
    "def test210 sum[1,test209]",
    "def test211 sum[1,test210]",
    "def test212 sum[1,test211]",
    "def test213 sum[1,test212]",
    "def test214 sum[1,test213]",
    "def test215 sum[1,test214]",
    "def test216 sum[1,test215]",
    "def test217 sum[1,test216]",
    "def test218 sum[1,test217]",
    "def test219 sum[1,test218]",
    "def test220 sum[1,test219]",
    "def test221 sum[1,test220]",
    "def test222 sum[1,test221]",
    "def test223 sum[1,test222]",
    "def test224 sum[1,test223]",
    "def test225 sum[1,test224]",
    "def test226 sum[1,test225]",
    "def test227 sum[1,test226]",
    "def test228 sum[1,test227]",
    "def test229 sum[1,test228]",
    "def test230 sum[1,test229]",
    "def test231 sum[1,test230]",
    "def test232 sum[1,test231]",
    "def test233 sum[1,test232]",
    "def test234 sum[1,test233]",
    "def test235 sum[1,test234]",
    "def test236 sum[1,test235]",
    "def test237 sum[1,test236]",
    "def test238 sum[1,test237]",
    "def test239 sum[1,test238]",
    "def test240 sum[1,test239]",
    "def test241 sum[1,test240]",
    "def test242 sum[1,test241]",
    "def test243 sum[1,test242]",
    "def test244 sum[1,test243]",
    "def test245 sum[1,test244]",
    "def test246 sum[1,test245]",
    "def test247 sum[1,test246]",
    "def test248 sum[1,test247]",
    "def test249 sum[1,test248]",
    "def test250 sum[1,test249]",
    "def test251 sum[1,test250]",
    "def test252 sum[1,test251]",
    "def test253 sum[1,test252]",
    "def test254 sum[1,test253]",
    "def test255 sum[1,test254]",
    "def test256 sum[1,test255]",
    "def test257 sum[1,test256]",
    "def test258 sum[1,test257]",
    "def test259 sum[1,test258]",
    "def test260 sum[1,test259]",
    "def test261 sum[1,test260]",
    "def test262 sum[1,test261]",
    "def test263 sum[1,test262]",
    "def test264 sum[1,test263]",
    "def test265 sum[1,test264]",
    "def test266 sum[1,test265]",
    "def test267 sum[1,test266]",
    "def test268 sum[1,test267]",
    "def test269 sum[1,test268]",
    "def test270 sum[1,test269]",
    "def test271 sum[1,test270]",
    "def test272 sum[1,test271]",
    "def test273 sum[1,test272]",
    "def test274 sum[1,test273]",
    "def test275 sum[1,test274]",
    "def test276 sum[1,test275]",
    "def test277 sum[1,test276]",
    "def test278 sum[1,test277]",
    "def test279 sum[1,test278]",
    "def test280 sum[1,test279]",
    "def test281 sum[1,test280]",
    "def test282 sum[1,test281]",
    "def test283 sum[1,test282]",
    "def test284 sum[1,test283]",
    "def test285 sum[1,test284]",
    "def test286 sum[1,test285]",
    "def test287 sum[1,test286]",
    "def test288 sum[1,test287]",
    "def test289 sum[1,test288]",
    "def test290 sum[1,test289]",
    "def test291 sum[1,test290]",
    "def test292 sum[1,test291]",
    "def test293 sum[1,test292]",
    "def test294 sum[1,test293]",
    "def test295 sum[1,test294]",
    "def test296 sum[1,test295]",
    "def test297 sum[1,test296]",
    "def test298 sum[1,test297]",
    "def test299 sum[5345,test298]",
    "[test299]                 "];
    //5644
    var testArr3 = [" def newFunc     [      123,432    , 4]",
                    "def blaBLA sum[newFunc]",
                    "def BLAbla min[newFunc]",
                    "avg[BLAbla,blaBLA]"];
    //281
    testArr4 = ["sum[1999999999, 1]"];
    //2000000000
    testArr5 = ["    def newFunc     [      123,432    , 4]",
                    "def blaBLA sum[newFunc]",
                    "def BLAbla min[newFunc]",
                    "def BLAblA sum[newFunc,newFunc,newFunc,newFunc,newFunc]",
                    "def BLAbLA min[BLAblA]",
                    "avg[BLAbla,blaBLA,BLAbLA]"];
    //1119
    var testArr6 = ["def negFunc     [      -123,-432 ,-6474567    , 4]",
                    "def negsum sum[negFunc]",
                    "def negavg avg[negFunc]",
                    "min[                 negavg,              negsum          ]"];
    //-6475118
    var testArr7 = [
   " def test0[1]                                                                                                                                           ",
    "def test1 sum[1 ]                                                                                                                                      ",
    "def test2 sum[1 ,test1]                                                                                                                                ",
    "def test3 sum[1 ,test2,test1]                                                                                                                          ",
    "def test4 sum[1 ,test3,test2,test1]                                                                                                                    ",
    "def test5 sum[1 ,test4,test3,test2,test1]                                                                                                              ",
    "def test6 sum[1 ,test5,test4,test3,test2,test1]                                                                                                        ",
    "def test7 sum[1 ,test6,test5,test4,test3,test2,test1]                                                                                                  ",
    "def test8 sum[1 ,test7,test6,test5,test4,test3,test2,test1]                                                                                            ",
    "def test9 sum[1 ,test8,test7,test6,test5,test4,test3,test2,test1]                                                                                      ",
    "def test10 sum[1 ,test9,test8,test7,test6,test5,test4,test3,test2,test1]                                                                               ",
    "def test11 sum[1 ,test10,test9,test8,test7,test6,test5,test4,test3,test2,test1]                                                                        ",
    "def test12 sum[1 ,test11,test10,test9,test8,test7,test6,test5,test4,test3,test2,test1]                                                                 ",
    "def test13 sum[1 ,test12,test11,test10,test9,test8,test7,test6,test5,test4,test3,test2,test1]                                                          ",
    "def test14 sum[1 ,test13,test12,test11,test10,test9,test8,test7,test6,test5,test4,test3,test2,test1]                                                   ",
    "def test15 sum[1 ,test14,test13,test12,test11,test10,test9,test8,test7,test6,test5,test4,test3,test2,test1]                                            ",
    "def test16 sum[1 ,test15,test14,test13,test12,test11,test10,test9,test8,test7,test6,test5,test4,test3,test2,test1]                                     ",
    "def test17 sum[1 ,test16,test15,test14,test13,test12,test11,test10,test9,test8,test7,test6,test5,test4,test3,test2,test1]                              ",
    "def test18 sum[1 ,test17,test16,test15,test14,test13,test12,test11,test10,test9,test8,test7,test6,test5,test4,test3,test2,test1]                       ",
    "def test19 sum[1 ,test18,test17,test16,test15,test14,test13,test12,test11,test10,test9,test8,test7,test6,test5,test4,test3,test2,test1]                ",
    "def test20 sum[1 ,test19,test18,test17,test16,test15,test14,test13,test12,test11,test10,test9,test8,test7,test6,test5,test4,test3,test2,test1]         ",
    "def test21 sum[1 ,test20,test19,test18,test17,test16,test15,test14,test13,test12,test11,test10,test9,test8,test7,test6,test5,test4,test3,test2]        ",
    "def test22 sum[1 ,test21,test20,test19,test18,test17,test16,test15,test14,test13,test12,test11,test10,test9,test8,test7,test6,test5,test4,test3]       ",
    "def test23 sum[1 ,test22,test21,test20,test19,test18,test17,test16,test15,test14,test13,test12,test11,test10,test9,test8,test7,test6,test5,test4]      ",
    "def test24 sum[1 ,test23,test22,test21,test20,test19,test18,test17,test16,test15,test14,test13,test12,test11,test10,test9,test8,test7,test6,test5]     ",
    "def test25 sum[1 ,test24,test23,test22,test21,test20,test19,test18,test17,test16,test15,test14,test13,test12,test11,test10,test9,test8,test7,test6]    ",
    "def test26 sum[1 ,test25,test24,test23,test22,test21,test20,test19,test18,test17,test16,test15,test14,test13,test12,test11,test10,test9,test8,test7]   ",
    "def test27 sum[1 ,test26,test25,test24,test23,test22,test21,test20,test19,test18,test17,test16,test15,test14,test13,test12,test11,test10,test9,test8]  ",
    "def test28 sum[1 ,test27,test26,test25,test24,test23,test22,test21,test20,test19,test18,test17,test16,test15,test14,test13,test12,test11,test10,test9] ",
    " [test28]                                                                                                                                               "];
    //134216704
    var testArr8 = ["def hmfunc     [123, 654, 1234, 64]",
                    "def hm2 sum[hmfunc]",
                    "def hm22 min[hm2]",
                    "max[                 1,              hm22          ]"];
    //2075
    var testArr9 = ["def maxy max[100   ,600,6001,-100]",
                    "def combo [maxy, maxy,maxy,maxy, 5,6]",
                     "def summary sum[combo, maxy, -18000]",
                     "def pe6o avg[summary,5,maxy]",
                      "sum[1, pe6o]"];
    //6008
    var testArr10 = ["def maxy max[100]",
                     "def summary [0]",
                     "combo [maxy, maxy,maxy,maxy, 5,6]",
                     "summary sum[combo, maxy, -18000]",
                     "def pe6o avg[summary,maxy]",
                     "sum[7, pe6o]"];
    //57
	
	var testArr11 = ["def maxy max[100, 5000, 4,2,1]",
	"def summary1 [0]",
	"def summary11 avg[summary1,maxy]",
	"def summary111 avg[   summary11 ,  maxy]",
	"def summary1111 avg[summary111 , maxy]",
	"sum[75468, summary1111]"];
	//75468
	var testArr12 =["avg[1894998,2]"];
	//947500

	console.log(Solve(testArr11));
};