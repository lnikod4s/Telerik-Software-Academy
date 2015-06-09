function s(n){n = +n;r=0.5;for(i = 2;i <= n;i++){r*= i+n;r/=i}return r}

console.log(s([7]));