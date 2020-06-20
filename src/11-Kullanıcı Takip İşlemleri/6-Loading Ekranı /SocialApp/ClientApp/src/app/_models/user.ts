import {image} from './image';

export class User {
    id: number;
    username: string;
    name: string;
    age: number;
    gender: string;
    created: Date;
    lastActive: Date;
    city: string;
    country: string;
    introduction: string;
    hobbies: string;
    profileImageUrl: string;
    images: image[];
}