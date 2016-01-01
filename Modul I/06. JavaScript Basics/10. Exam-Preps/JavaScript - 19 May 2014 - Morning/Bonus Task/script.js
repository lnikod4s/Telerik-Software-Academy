function s(a){return a[0]<=0?a[1]>0?0:2:a[1]<=0?3:1}

console.log(s([-1, -2]));
console.log(s([1, -2]));
console.log(s([-1, 2]));
console.log(s([1, 2]));