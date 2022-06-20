

export default function getAge(dateString) {
    var today = new Date();
    var birthDate = new Date(dateString);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}

 export function timeOnly(date) {
     var d = new Date(date);
     const h = d.getHours(); // => 9
     const m = d.getMinutes(); // =>  30
     const s = d.getSeconds(); // => 51
     return `${h}:${m}:${s} `
}

 export  function dateOnly(date) {
     var d = new Date(date);
     d.getHours(); // => 9
     d.getMinutes(); // =>  30
     d.getSeconds(); // => 51
}

export function dateWordFormat(date) {
   return new Date(date).toDateString()
}