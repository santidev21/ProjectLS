import { PetTypes } from "./PetTypes";

export interface selectCustom{
    title?: string,
    defaultValue?: string,
    stringOptions?: any[],
    currentValue?: string;
    disabled?: boolean;
}