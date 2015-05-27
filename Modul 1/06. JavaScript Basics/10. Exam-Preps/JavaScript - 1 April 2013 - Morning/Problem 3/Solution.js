window.onload = function () {

    function Solve(inputArr) {

        var returnString = "",
            definedFunctions = {};
        for (var i = 0; i < inputArr.length; i++) {
            var newRE = new RegExp("\\)", "g");
            inputArr[i] = inputArr[i].replace(newRE, " ) ");
            newRE = new RegExp("\\(", "g");
            inputArr[i] = inputArr[i].replace(newRE, " ( ");
            //replace the called functions in the functions with their results
            for (var key in definedFunctions) {
                var re = new RegExp(" " + key + " ", "g");
                inputArr[i] = inputArr[i].replace(re, " " + definedFunctions[key] + " ");
                inputArr[i] = inputArr[i].replace(re, " " + definedFunctions[key] + " ");
            }
            if (i === inputArr.length - 1) {
                returnString = GetFunctionValue(inputArr[i].split('(')[1]);
            }
            //Check if the string line is a definition of a function
            if (inputArr[i].indexOf(" def ") !== -1) {
                //split the function by "(" sign
                var splittedFunction = inputArr[i].split('(');
                //the function is type "(%operation% [%attributes%] %sequence%")"
                if (splittedFunction.length === 2) {
                    definedFunctions[GetFunctionName(splittedFunction[1])] = GetFunctionValue(splittedFunction[1]);
                }
                    //the function is type "(%operation% [%attributes%] (%operation% [%attributes%] %sequence%"))"
                    //NOTE : there would be NO MORE than 1 nested (%operation% [%attributes%] %sequence%")
                else {
                    definedFunctions[GetFunctionName(splittedFunction[1])] = GetFunctionValue(splittedFunction[2]);
                }
                if (isNaN(definedFunctions[GetFunctionName(splittedFunction[1])])) {
                    return definedFunctions[GetFunctionName(splittedFunction[1])] + " At Line:" + (i + 1);
                }
            }
        }
        //console.log(definedFunctions);
        return returnString;
    }

    function GetFunctionName(functionString) {
        var splittedFunctionString = functionString.split(' ');
        for (var i = 0; i < splittedFunctionString.length; i++) {
            if (isNaN(splittedFunctionString[i]) &&
                splittedFunctionString[i] !== "def" &&
                splittedFunctionString[i].length > 0) {
                return splittedFunctionString[i];
            }
        }
        return false
    }

    function GetFunctionValue(functionString) {
        var newString = functionString.split(')');
        var splittedFunctionString = newString[0].split(' ');
        if (functionString.indexOf("+") === -1 &&
            functionString.indexOf("- ") === -1 &&
            functionString.indexOf("*") === -1 &&
            functionString.indexOf("/") === -1) {

            for (var i = 0; i < splittedFunctionString.length; i++) {
                if (!isNaN(splittedFunctionString[i]) && splittedFunctionString[i].length > 0) {
                    return parseInt(splittedFunctionString[i]);
                }
            }
        } else {
            var result = 0,
                sign,
                flagFirstNumber = false,
                number;
            if (functionString.indexOf('+') !== -1) {
                sign = '+';
                result = 0;
            } else if (functionString.indexOf('- ') !== -1) {
                sign = '-';
                result = 0;
            } else if (functionString.indexOf('*') !== -1) {
                sign = '*';
                result = 1;
            } else if (functionString.indexOf('/') !== -1) {
                sign = '/';
                result = 0;
            }
            for (var i = 0; i < splittedFunctionString.length; i++) {
                if (!isNaN(splittedFunctionString[i]) && splittedFunctionString[i].length > 0) {
                    number = parseInt(splittedFunctionString[i]);
                    if (sign === '+') {
                        result = result + number;
                    } else if (sign === '-') {
                        if (!flagFirstNumber) {
                            result = number;
                            flagFirstNumber = true;
                        } else {
                            result = result - number;
                        }
                    } else if (sign === '*') {
                        result *= number;
                    } else if (sign === '/') {
                        if (number === 0 && flagFirstNumber) {
                            return "Division by zero!";
                        }
                        result = (!flagFirstNumber) ? number : parseInt(result / number);
                        flagFirstNumber = true;
                    }
                }
            }
            return result;
        }

    }

    var zeroTestArr = ['(def func 10)',
                        '(def newFunc (+  func 2))',
                        '(def sumFunc (+ func func newFunc 0 0 0))',
                        '(* sumFunc 2)'];
    //64
    var zeroTestArr2 = ['(def func (+ 5 2))',
                    '(def func2 (/  func 5 2 1 0))',
                    '(def func3 (/ func 2))',
                    '(+ func3 func)'];
    //Division by zero! At Line:2
    var inputArr = ['(def     go6o    -7 )',
                    '(def pe6o (   /  -15 go6o))',
                    '(def asD (/ 2 0))',
                    '(def func2 asD  )',
                    '(           +        4          2      func2)'];
    //Division by zero! At Line:3
    var inputArr2 = ['(def     go6o    -7 )',
                    '(def asd (/ 0 5))',
                    '(def func2 asd  )',
                    '(           +        4          2      func2)'];
    //6
    var inputArr3 = ['(def     go6o    (+ -50 -2) )',
        '(           /        10      3 2)'];
    //-27
    var inputArr4 = ['(def     lube    5)',
                    '(def     Lube    6)',
                    '(def pe6o (+ lube Lube ))',
                    '(def joro pe6o)',
                    '(           *        pe6o        joro     )'];
    //121
    var inputArr5 = ['(def     lube    5)',
                    '(def toshko (+ lube 12))',
                    '(def pe6o (+ lube lube lube lube lube lube lube lube lube lube lube lube lube lube lube lube lube lube lube lube toshko))',
                    '(def joro pe6o)',
                    '(           +    2    joro    )'];
    //119
    var inputArr6 = ['(- 5 5)'];
    //0
    var inputArr7 = ['(/ 0)'];
    //0
    var inputArr8 = ['(+ 1999999999 1)'];
    //2000000000
    var inputArr13 = [
    "(def func0 0)                  ",
    "(def func1 (+ func0 1 ))       ",
    "(def func2 (+ func1 2 ))       ",
    "(def func3 (+ func2 3 ))       ",
    "(def func4 (+ func3 4 ))       ",
    "(def func5 (+ func4 5 ))       ",
    "(def func6 (+ func5 6 ))       ",
    "(def func7 (+ func6 7 ))       ",
    "(def func8 (+ func7 8 ))       ",
    "(def func9 (+ func8 9 ))       ",
    "(def func10 (+ func9 10 ))     ",
    "(def func11 (+ func10 11 ))    ",
    "(def func12 (+ func11 12 ))    ",
    "(def func13 (+ func12 13 ))    ",
    "(def func14 (+ func13 14 ))    ",
    "(def func15 (+ func14 15 ))    ",
    "(def func16 (+ func15 16 ))    ",
    "(def func17 (+ func16 17 ))    ",
    "(def func18 (+ func17 18 ))    ",
    "(def func19 (+ func18 19 ))    ",
    "(def func20 (+ func19 20 ))    ",
    "(def func21 (+ func20 21 ))    ",
    "(def func22 (+ func21 22 ))    ",
    "(def func23 (+ func22 23 ))    ",
    "(def func24 (+ func23 24 ))    ",
    "(def func25 (+ func24 25 ))    ",
    "(def func26 (+ func25 26 ))    ",
    "(def func27 (+ func26 27 ))    ",
    "(def func28 (+ func27 28 ))    ",
    "(def func29 (+ func28 29 ))    ",
    "(def func30 (+ func29 30 ))    ",
    "(def func31 (+ func30 31 ))    ",
    "(def func32 (+ func31 32 ))    ",
    "(def func33 (+ func32 33 ))    ",
    "(def func34 (+ func33 34 ))    ",
    "(def func35 (+ func34 35 ))    ",
    "(def func36 (+ func35 36 ))    ",
    "(def func37 (+ func36 37 ))    ",
    "(def func38 (+ func37 38 ))    ",
    "(def func39 (+ func38 39 ))    ",
    "(def func40 (+ func39 40 ))    ",
    "(def func41 (+ func40 41 ))    ",
    "(def func42 (+ func41 42 ))    ",
    "(def func43 (+ func42 43 ))    ",
    "(def func44 (+ func43 44 ))    ",
    "(def func45 (+ func44 45 ))    ",
    "(def func46 (+ func45 46 ))    ",
    "(def func47 (+ func46 47 ))    ",
    "(def func48 (+ func47 48 ))    ",
    "(def func49 (+ func48 49 ))    ",
    "(def func50 (+ func49 50 ))    ",
    "(def func51 (+ func50 51 ))    ",
    "(def func52 (+ func51 52 ))    ",
    "(def func53 (+ func52 53 ))    ",
    "(def func54 (+ func53 54 ))    ",
    "(def func55 (+ func54 55 ))    ",
    "(def func56 (+ func55 56 ))    ",
    "(def func57 (+ func56 57 ))    ",
    "(def func58 (+ func57 58 ))    ",
    "(def func59 (+ func58 59 ))    ",
    "(def func60 (+ func59 60 ))    ",
    "(def func61 (+ func60 61 ))    ",
    "(def func62 (+ func61 62 ))    ",
    "(def func63 (+ func62 63 ))    ",
    "(def func64 (+ func63 64 ))    ",
    "(def func65 (+ func64 65 ))    ",
    "(def func66 (+ func65 66 ))    ",
    "(def func67 (+ func66 67 ))    ",
    "(def func68 (+ func67 68 ))    ",
    "(def func69 (+ func68 69 ))    ",
    "(def func70 (+ func69 70 ))    ",
    "(def func71 (+ func70 71 ))    ",
    "(def func72 (+ func71 72 ))    ",
    "(def func73 (+ func72 73 ))    ",
    "(def func74 (+ func73 74 ))    ",
    "(def func75 (+ func74 75 ))    ",
    "(def func76 (+ func75 76 ))    ",
    "(def func77 (+ func76 77 ))    ",
    "(def func78 (+ func77 78 ))    ",
    "(def func79 (+ func78 79 ))    ",
    "(def func80 (+ func79 80 ))    ",
    "(def func81 (+ func80 81 ))    ",
    "(def func82 (+ func81 82 ))    ",
    "(def func83 (+ func82 83 ))    ",
    "(def func84 (+ func83 84 ))    ",
    "(def func85 (+ func84 85 ))    ",
    "(def func86 (+ func85 86 ))    ",
    "(def func87 (+ func86 87 ))    ",
    "(def func88 (+ func87 88 ))    ",
    "(def func89 (+ func88 89 ))    ",
    "(def func90 (+ func89 90 ))    ",
    "(def func91 (+ func90 91 ))    ",
    "(def func92 (+ func91 92 ))    ",
    "(def func93 (+ func92 93 ))    ",
    "(def func94 (+ func93 94 ))    ",
    "(def func95 (+ func94 95 ))    ",
    "(def func96 (+ func95 96 ))    ",
    "(def func97 (+ func96 97 ))    ",
    "(def func98 (+ func97 98 ))    ",
    "(def func99 (+ func98 99 ))    ",
    "(def func100 (+ func99 100 ))  ",
    "(def func101 (+ func100 101 )) ",
    "(def func102 (+ func101 102 )) ",
    "(def func103 (+ func102 103 )) ",
    "(def func104 (+ func103 104 )) ",
    "(def func105 (+ func104 105 )) ",
    "(def func106 (+ func105 106 )) ",
    "(def func107 (+ func106 107 )) ",
    "(def func108 (+ func107 108 )) ",
    "(def func109 (+ func108 109 )) ",
    "(def func110 (+ func109 110 )) ",
    "(def func111 (+ func110 111 )) ",
    "(def func112 (+ func111 112 )) ",
    "(def func113 (+ func112 113 )) ",
    "(def func114 (+ func113 114 )) ",
    "(def func115 (+ func114 115 )) ",
    "(def func116 (+ func115 116 )) ",
    "(def func117 (+ func116 117 )) ",
    "(def func118 (+ func117 118 )) ",
    "(def func119 (+ func118 119 )) ",
    "(def func120 (+ func119 120 )) ",
    "(def func121 (+ func120 121 )) ",
    "(def func122 (+ func121 122 )) ",
    "(def func123 (+ func122 123 )) ",
    "(def func124 (+ func123 124 )) ",
    "(def func125 (+ func124 125 )) ",
    "(def func126 (+ func125 126 )) ",
    "(def func127 (+ func126 127 )) ",
    "(def func128 (+ func127 128 )) ",
    "(def func129 (+ func128 129 )) ",
    "(def func130 (+ func129 130 )) ",
    "(def func131 (+ func130 131 )) ",
    "(def func132 (+ func131 132 )) ",
    "(def func133 (+ func132 133 )) ",
    "(def func134 (+ func133 134 )) ",
    "(def func135 (+ func134 135 )) ",
    "(def func136 (+ func135 136 )) ",
    "(def func137 (+ func136 137 )) ",
    "(def func138 (+ func137 138 )) ",
    "(def func139 (+ func138 139 )) ",
    "(def func140 (+ func139 140 )) ",
    "(def func141 (+ func140 141 )) ",
    "(def func142 (+ func141 142 )) ",
    "(def func143 (+ func142 143 )) ",
    "(def func144 (+ func143 144 )) ",
    "(def func145 (+ func144 145 )) ",
    "(def func146 (+ func145 146 )) ",
    "(def func147 (+ func146 147 )) ",
    "(def func148 (+ func147 148 )) ",
    "(def func149 (+ func148 149 )) ",
    "(def func150 (+ func149 150 )) ",
    "(def func151 (+ func150 151 )) ",
    "(def func152 (+ func151 152 )) ",
    "(def func153 (+ func152 153 )) ",
    "(def func154 (+ func153 154 )) ",
    "(def func155 (+ func154 155 )) ",
    "(def func156 (+ func155 156 )) ",
    "(def func157 (+ func156 157 )) ",
    "(def func158 (+ func157 158 )) ",
    "(def func159 (+ func158 159 )) ",
    "(def func160 (+ func159 160 )) ",
    "(def func161 (+ func160 161 )) ",
    "(def func162 (+ func161 162 )) ",
    "(def func163 (+ func162 163 )) ",
    "(def func164 (+ func163 164 )) ",
    "(def func165 (+ func164 165 )) ",
    "(def func166 (+ func165 166 )) ",
    "(def func167 (+ func166 167 )) ",
    "(def func168 (+ func167 168 )) ",
    "(def func169 (+ func168 169 )) ",
    "(def func170 (+ func169 170 )) ",
    "(def func171 (+ func170 171 )) ",
    "(def func172 (+ func171 172 )) ",
    "(def func173 (+ func172 173 )) ",
    "(def func174 (+ func173 174 )) ",
    "(def func175 (+ func174 175 )) ",
    "(def func176 (+ func175 176 )) ",
    "(def func177 (+ func176 177 )) ",
    "(def func178 (+ func177 178 )) ",
    "(def func179 (+ func178 179 )) ",
    "(def func180 (+ func179 180 )) ",
    "(def func181 (+ func180 181 )) ",
    "(def func182 (+ func181 182 )) ",
    "(def func183 (+ func182 183 )) ",
    "(def func184 (+ func183 184 )) ",
    "(def func185 (+ func184 185 )) ",
    "(def func186 (+ func185 186 )) ",
    "(def func187 (+ func186 187 )) ",
    "(def func188 (+ func187 188 )) ",
    "(def func189 (+ func188 189 )) ",
    "(def func190 (+ func189 190 )) ",
    "(def func191 (+ func190 191 )) ",
    "(def func192 (+ func191 192 )) ",
    "(def func193 (+ func192 193 )) ",
    "(def func194 (+ func193 194 )) ",
    "(def func195 (+ func194 195 )) ",
    "(def func196 (+ func195 196 )) ",
    "(def func197 (+ func196 197 )) ",
    "(def func198 (+ func197 198 )) ",
    "(def func199 (+ func198 199 )) ",
    "(def func200 (+ func199 200 )) ",
    "(def func201 (+ func200 201 )) ",
    "(def func202 (+ func201 202 )) ",
    "(def func203 (+ func202 203 )) ",
    "(def func204 (+ func203 204 )) ",
    "(def func205 (+ func204 205 )) ",
    "(def func206 (+ func205 206 )) ",
    "(def func207 (+ func206 207 )) ",
    "(def func208 (+ func207 208 )) ",
    "(def func209 (+ func208 209 )) ",
    "(def func210 (+ func209 210 )) ",
    "(def func211 (+ func210 211 )) ",
    "(def func212 (+ func211 212 )) ",
    "(def func213 (+ func212 213 )) ",
    "(def func214 (+ func213 214 )) ",
    "(def func215 (+ func214 215 )) ",
    "(def func216 (+ func215 216 )) ",
    "(def func217 (+ func216 217 )) ",
    "(def func218 (+ func217 218 )) ",
    "(def func219 (+ func218 219 )) ",
    "(def func220 (+ func219 220 )) ",
    "(def func221 (+ func220 221 )) ",
    "(def func222 (+ func221 222 )) ",
    "(def func223 (+ func222 223 )) ",
    "(def func224 (+ func223 224 )) ",
    "(def func225 (+ func224 225 )) ",
    "(def func226 (+ func225 226 )) ",
    "(def func227 (+ func226 227 )) ",
    "(def func228 (+ func227 228 )) ",
    "(def func229 (+ func228 229 )) ",
    "(def func230 (+ func229 230 )) ",
    "(def func231 (+ func230 231 )) ",
    "(def func232 (+ func231 232 )) ",
    "(def func233 (+ func232 233 )) ",
    "(def func234 (+ func233 234 )) ",
    "(def func235 (+ func234 235 )) ",
    "(def func236 (+ func235 236 )) ",
    "(def func237 (+ func236 237 )) ",
    "(def func238 (+ func237 238 )) ",
    "(def func239 (+ func238 239 )) ",
    "(def func240 (+ func239 240 )) ",
    "(def func241 (+ func240 241 )) ",
    "(def func242 (+ func241 242 )) ",
    "(def func243 (+ func242 243 )) ",
    "(def func244 (+ func243 244 )) ",
    "(def func245 (+ func244 245 )) ",
    "(def func246 (+ func245 246 )) ",
    "(def func247 (+ func246 247 )) ",
    "(def func248 (+ func247 248 )) ",
    "(def func249 (+ func248 249 )) ",
    "(def func250 (+ func249 250 )) ",
    "(def func251 (+ func250 251 )) ",
    "(def func252 (+ func251 252 )) ",
    "(def func253 (+ func252 253 )) ",
    "(def func254 (+ func253 254 )) ",
    "(def func255 (+ func254 255 )) ",
    "(def func256 (+ func255 256 )) ",
    "(def func257 (+ func256 257 )) ",
    "(def func258 (+ func257 258 )) ",
    "(def func259 (+ func258 259 )) ",
    "(def func260 (+ func259 260 )) ",
    "(def func261 (+ func260 261 )) ",
    "(def func262 (+ func261 262 )) ",
    "(def func263 (+ func262 263 )) ",
    "(def func264 (+ func263 264 )) ",
    "(def func265 (+ func264 265 )) ",
    "(def func266 (+ func265 266 )) ",
    "(def func267 (+ func266 267 )) ",
    "(def func268 (+ func267 268 )) ",
    "(def func269 (+ func268 269 )) ",
    "(def func270 (+ func269 270 )) ",
    "(def func271 (+ func270 271 )) ",
    "(def func272 (+ func271 272 )) ",
    "(def func273 (+ func272 273 )) ",
    "(def func274 (+ func273 274 )) ",
    "(def func275 (+ func274 275 )) ",
    "(def func276 (+ func275 276 )) ",
    "(def func277 (+ func276 277 )) ",
    "(def func278 (+ func277 278 )) ",
    "(def func279 (+ func278 279 )) ",
    "(def func280 (+ func279 280 )) ",
    "(def func281 (+ func280 281 )) ",
    "(def func282 (+ func281 282 )) ",
    "(def func283 (+ func282 283 )) ",
    "(def func284 (+ func283 284 )) ",
    "(def func285 (+ func284 285 )) ",
    "(def func286 (+ func285 286 )) ",
    "(def func287 (+ func286 287 )) ",
    "(def func288 (+ func287 288 )) ",
    "(def func289 (+ func288 289 )) ",
    "(def func290 (+ func289 290 )) ",
    "(def func291 (+ func290 291 )) ",
    "(def func292 (+ func291 292 )) ",
    "(def func293 (+ func292 293 )) ",
    "(def func294 (+ func293 294 )) ",
    "(def func295 (+ func294 295 )) ",
    "(def func296 (+ func295 296 )) ",
    "(def func297 (+ func296 297 )) ",
    "(def func298 (+ func297 298 )) ",
    "(def func299 (+ func298 299 )) ",
    "(def func300 (+ func299 300 )) ",
    "(def func301 (+ func300 301 )) ",
    "(def func302 (+ func301 302 )) ",
    "(def func303 (+ func302 303 )) ",
    "(def func304 (+ func303 304 )) ",
    "(def func305 (+ func304 305 )) ",
    "(def func306 (+ func305 306 )) ",
    "(def func307 (+ func306 307 )) ",
    "(def func308 (+ func307 308 )) ",
    "(def func309 (+ func308 309 )) ",
    "(def func310 (+ func309 310 )) ",
    "(def func311 (+ func310 311 )) ",
    "(def func312 (+ func311 312 )) ",
    "(def func313 (+ func312 313 )) ",
    "(def func314 (+ func313 314 )) ",
    "(def func315 (+ func314 315 )) ",
    "(def func316 (+ func315 316 )) ",
    "(def func317 (+ func316 317 )) ",
    "(def func318 (+ func317 318 )) ",
    "(def func319 (+ func318 319 )) ",
    "(def func320 (+ func319 320 )) ",
    "(def func321 (+ func320 321 )) ",
    "(def func322 (+ func321 322 )) ",
    "(def func323 (+ func322 323 )) ",
    "(def func324 (+ func323 324 )) ",
    "(def func325 (+ func324 325 )) ",
    "(def func326 (+ func325 326 )) ",
    "(def func327 (+ func326 327 )) ",
    "(def func328 (+ func327 328 )) ",
    "(def func329 (+ func328 329 )) ",
    "(def func330 (+ func329 330 )) ",
    "(def func331 (+ func330 331 )) ",
    "(def func332 (+ func331 332 )) ",
    "(def func333 (+ func332 333 )) ",
    "(def func334 (+ func333 334 )) ",
    "(def func335 (+ func334 335 )) ",
    "(def func336 (+ func335 336 )) ",
    "(def func337 (+ func336 337 )) ",
    "(def func338 (+ func337 338 )) ",
    "(def func339 (+ func338 339 )) ",
    "(def func340 (+ func339 340 )) ",
    "(def func341 (+ func340 341 )) ",
    "(def func342 (+ func341 342 )) ",
    "(def func343 (+ func342 343 )) ",
    "(def func344 (+ func343 344 )) ",
    "(def func345 (+ func344 345 )) ",
    "(def func346 (+ func345 346 )) ",
    "(def func347 (+ func346 347 )) ",
    "(def func348 (+ func347 348 )) ",
    "(def func349 (+ func348 349 )) ",
    "(def func350 (+ func349 350 )) ",
    "(def func351 (+ func350 351 )) ",
    "(def func352 (+ func351 352 )) ",
    "(def func353 (+ func352 353 )) ",
    "(def func354 (+ func353 354 )) ",
    "(def func355 (+ func354 355 )) ",
    "(def func356 (+ func355 356 )) ",
    "(def func357 (+ func356 357 )) ",
    "(def func358 (+ func357 358 )) ",
    "(def func359 (+ func358 359 )) ",
    "(def func360 (+ func359 360 )) ",
    "(def func361 (+ func360 361 )) ",
    "(def func362 (+ func361 362 )) ",
    "(def func363 (+ func362 363 )) ",
    "(def func364 (+ func363 364 )) ",
    "(def func365 (+ func364 365 )) ",
    "(def func366 (+ func365 366 )) ",
    "(def func367 (+ func366 367 )) ",
    "(def func368 (+ func367 368 )) ",
    "(def func369 (+ func368 369 )) ",
    "(def func370 (+ func369 370 )) ",
    "(def func371 (+ func370 371 )) ",
    "(def func372 (+ func371 372 )) ",
    "(def func373 (+ func372 373 )) ",
    "(+ func373 1)                  "];
    //181504
    var inputArr14 = [
    "(def func0 0)                                                                                                                                                   ",
    "(def func1 (+ 1 func0 ))                                                                                                                                        ",
    "(def func2 (+ 2 func1 func0 ))                                                                                                                                  ",
    "(def func3 (+ 3 func2 func1 func0 ))                                                                                                                            ",
    "(def func4 (+ 4 func3 func2 func1 func0 ))                                                                                                                      ",
    "(def func5 (+ 5 func4 func3 func2 func1 func0 ))                                                                                                                ",
    "(def func6 (+ 6 func5 func4 func3 func2 func1 func0 ))                                                                                                          ",
    "(def func7 (+ 7 func6 func5 func4 func3 func2 func1 func0 ))                                                                                                    ",
    "(def func8 (+ 8 func7 func6 func5 func4 func3 func2 func1 func0 ))                                                                                              ",
    "(def func9 (+ 9 func8 func7 func6 func5 func4 func3 func2 func1 func0 ))                                                                                        ",
    "(def func10 (+ 10 func9 func8 func7 func6 func5 func4 func3 func2 func1 func0 ))                                                                                ",
    "(def func11 (+ 11 func10 func9 func8 func7 func6 func5 func4 func3 func2 func1 func0 ))                                                                         ",
    "(def func12 (+ 12 func11 func10 func9 func8 func7 func6 func5 func4 func3 func2 func1 func0 ))                                                                  ",
    "(def func13 (+ 13 func12 func11 func10 func9 func8 func7 func6 func5 func4 func3 func2 func1 func0 ))                                                           ",
    "(def func14 (+ 14 func13 func12 func11 func10 func9 func8 func7 func6 func5 func4 func3 func2 func1 func0 ))                                                    ",
    "(def func15 (+ 15 func14 func13 func12 func11 func10 func9 func8 func7 func6 func5 func4 func3 func2 func1 func0 ))                                             ",
    "(def func16 (+ 16 func15 func14 func13 func12 func11 func10 func9 func8 func7 func6 func5 func4 func3 func2 func1 func0 ))                                      ",
    "(def func17 (+ 17 func16 func15 func14 func13 func12 func11 func10 func9 func8 func7 func6 func5 func4 func3 func2 func1 func0 ))                               ",
    "(def func18 (+ 18 func17 func16 func15 func14 func13 func12 func11 func10 func9 func8 func7 func6 func5 func4 func3 func2 func1 func0 ))                        ",
    "(def func19 (+ 19 func18 func17 func16 func15 func14 func13 func12 func11 func10 func9 func8 func7 func6 func5 func4 func3 func2 func1 func0 ))                 ",
    "(def func20 (+ 20 func19 func18 func17 func16 func15 func14 func13 func12 func11 func10 func9 func8 func7 func6 func5 func4 func3 func2 func1 func0 ))          ",
    "(+ func20 1)"
    ];
    //16777199
    var inputArr15 = [
    "(def func 0)                                                        ",
    "(def func0 (+ 1 func))                                              ",
    "(def func00 (+ 1 func0))                                            ",
    "(def func000 (+ 1 func00))                                          ",
    "(def func0000 (+ 1 func000))                                        ",
    "(def func00000 (+ 1 func0000))                                      ",
    "(def func000000 (+ 1 func00000))                                    ",
    "(def func0000000 (+ 1 func000000))                                  ",
    "(def func00000000 (+ 1 func0000000))                                ",
    "(def func000000000 (+ 1 func00000000))                              ",
    "(def func0000000000 (+ 1 func000000000))                            ",
    "(def func00000000000 (+ 1 func0000000000))                          ",
    "(def func000000000000 (+ 1 func00000000000))                        ",
    "(def func0000000000000 (+ 1 func000000000000))                      ",
    "(def func00000000000000 (+ 1 func0000000000000))                    ",
    "(def func000000000000000 (+ 1 func00000000000000))                  ",
    "(def func0000000000000000 (+ 1 func000000000000000))                ",
    "(def func00000000000000000 (+ 1 func0000000000000000))              ",
    "(def func000000000000000000 (+ 1 func00000000000000000))            ",
    "(def func0000000000000000000 (+ 1 func000000000000000000))          ",
    "(def func00000000000000000000 (+ 1 func0000000000000000000))        ",
    "(def func000000000000000000000 (+ 1 func00000000000000000000))      ",
    "(def func0000000000000000000000 (+ 1 func000000000000000000000))    ",
    "(def func00000000000000000000000 (+ 1 func0000000000000000000000))  ",
    "(def func000000000000000000000000 (+ 1 func00000000000000000000000))",
    "(- func000000000000000000000000 6000000)"];
    //-5999976
    console.log(Solve(inputArr14));
};