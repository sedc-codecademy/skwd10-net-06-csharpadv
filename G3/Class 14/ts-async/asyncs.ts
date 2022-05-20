const delay = (ms: number) => new Promise(resolve => setTimeout(resolve, ms));

async function count() {
    for (let index = 0; index < 10; index++) {
        console.log(index);
        await delay(1000);
    }
}

count();

// console.log(0); 
// setTimeout(() => {
//     console.log(1);
//     setTimeout(() => {
//         setTimeout(() => {
//             console.log(3);
//         }, 1000);
//         console.log(2);
//     }, 1000);
// }, 1000);


