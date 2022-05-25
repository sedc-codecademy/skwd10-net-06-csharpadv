const delay = (ms: number) => new Promise(resolve => setTimeout(resolve, ms));

const nums = [1, 2, 3, 4, 5, 6];

const main = async () => {
    for (const num of nums) {
        await delay(1000);
        console.log(num);
    }
};

main();