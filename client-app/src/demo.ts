export interface ICar{
    color: string,
    model: string,
    topspeed?: number
}

const car1: ICar = {
    color: 'blue',
    model: 'honda'
}

const car2: ICar = {
    color: 'red',
    model: 'baleno',
    topspeed: 220
}

export const cars = [car1,car2];