import { Role } from "./role.model";

export interface User {
    id: string;
    name: string;
    username: string;
    email: string;
    phoneNumber: string;
    role: Role;
    createdAt: Date;
    updatedAt: Date;
}