/* Options:
Date: 2024-08-15 00:46:10
Version: 8.30
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://localhost:5001

//AddServiceStackTypes: True
//AddDocAnnotations: True
//AddDescriptionAsComments: True
//IncludeTypes: 
//ExcludeTypes: 
//DefaultImports: 
*/

"use strict";
export class SortedRequest {
    /** @param {{find?:string,sortBy?:string,sortDesc?:boolean}} [init] */
    constructor(init) { Object.assign(this, init) }
    /**
     * @type {string}
     * @description Search by text in results: default is (empty) */
    find;
    /**
     * @type {string}
     * @description Sort results by property values: default is (empty) */
    sortBy;
    /**
     * @type {boolean}
     * @description Sort results descending: default is (true) */
    sortDesc;
}
export class PagedRequest extends SortedRequest {
    /** @param {{limit?:number,page?:number,find?:string,sortBy?:string,sortDesc?:boolean}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
    /**
     * @type {number}
     * @description Items per page */
    limit;
    /**
     * @type {number}
     * @description Page number: default is (10) */
    page;
}
export class Idd {
    /** @param {{root?:string,suffixes?:string[]}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    root;
    /** @type {string[]} */
    suffixes;
}
export class Maps {
    /** @param {{googleMaps?:string,openStreetMaps?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    googleMaps;
    /** @type {string} */
    openStreetMaps;
}
export class Car {
    /** @param {{signs?:string[],side?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string[]} */
    signs;
    /** @type {string} */
    side;
}
export class Flags {
    /** @param {{png?:string,svg?:string,alt?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    png;
    /** @type {string} */
    svg;
    /** @type {string} */
    alt;
}
export class CoatOfArms {
    /** @param {{png?:string,svg?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    png;
    /** @type {string} */
    svg;
}
export class CapitalInfo {
    /** @param {{latlng?:number[]}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number[]} */
    latlng;
}
export class Country {
    /** @param {{name?:string,tld?:string[],cca2?:string,ccn3?:number,cca3?:string,independent?:boolean,status?:string,unMember?:boolean,currencies?:{ [index: string]: Object; },idd?:Idd,capital?:string[],altSpellings?:string[],region?:string,languages?:{ [index: string]: Object; },translations?:{ [index: string]: Object; },latlng?:number[],landlocked?:boolean,area?:number,demonyms?:{ [index: string]: Object; },flag?:string,maps?:Maps,population?:number,car?:Car,timezones?:string[],continents?:string[],flags?:Flags,coatOfArms?:CoatOfArms,startOfWeek?:string,capitalInfo?:CapitalInfo}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    name;
    /** @type {string[]} */
    tld;
    /** @type {string} */
    cca2;
    /** @type {?number} */
    ccn3;
    /** @type {string} */
    cca3;
    /** @type {?boolean} */
    independent;
    /** @type {string} */
    status;
    /** @type {boolean} */
    unMember;
    /** @type {{ [index: string]: Object; }} */
    currencies;
    /** @type {Idd} */
    idd;
    /** @type {string[]} */
    capital;
    /** @type {string[]} */
    altSpellings;
    /** @type {string} */
    region;
    /** @type {?{ [index: string]: Object; }} */
    languages;
    /** @type {{ [index: string]: Object; }} */
    translations;
    /** @type {number[]} */
    latlng;
    /** @type {boolean} */
    landlocked;
    /** @type {number} */
    area;
    /** @type {{ [index: string]: Object; }} */
    demonyms;
    /** @type {string} */
    flag;
    /** @type {Maps} */
    maps;
    /** @type {number} */
    population;
    /** @type {Car} */
    car;
    /** @type {string[]} */
    timezones;
    /** @type {string[]} */
    continents;
    /** @type {Flags} */
    flags;
    /** @type {CoatOfArms} */
    coatOfArms;
    /** @type {string} */
    startOfWeek;
    /** @type {CapitalInfo} */
    capitalInfo;
}
export class LanguageResponseItem {
    /** @param {{language?:string,items?:Country[]}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    language;
    /** @type {Country[]} */
    items;
}
export class RegionResponseItem {
    /** @param {{region?:string,items?:Country[]}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    region;
    /** @type {Country[]} */
    items;
}
export class CountriesResponse {
    /** @param {{items?:Country[],itemCount?:number,page?:number,pageCount?:number,total?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {Country[]} */
    items;
    /** @type {number} */
    itemCount;
    /** @type {number} */
    page;
    /** @type {number} */
    pageCount;
    /** @type {number} */
    total;
}
export class LanguagesResponse {
    /** @param {{items?:LanguageResponseItem[],itemCount?:number,page?:number,pageCount?:number,total?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {LanguageResponseItem[]} */
    items;
    /** @type {number} */
    itemCount;
    /** @type {number} */
    page;
    /** @type {number} */
    pageCount;
    /** @type {number} */
    total;
}
export class RegionsResponse {
    /** @param {{items?:RegionResponseItem[],itemCount?:number,page?:number,pageCount?:number,total?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {RegionResponseItem[]} */
    items;
    /** @type {number} */
    itemCount;
    /** @type {number} */
    page;
    /** @type {number} */
    pageCount;
    /** @type {number} */
    total;
}
export class Countries extends PagedRequest {
    /** @param {{code?:string,limit?:number,page?:number,find?:string,sortBy?:string,sortDesc?:boolean}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
    /** @type {string} */
    code;
    getTypeName() { return 'Countries' }
    getMethod() { return 'GET' }
    createResponse() { return new CountriesResponse() }
}
export class Languages extends PagedRequest {
    /** @param {{id?:string,limit?:number,page?:number,find?:string,sortBy?:string,sortDesc?:boolean}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
    /** @type {string} */
    id;
    getTypeName() { return 'Languages' }
    getMethod() { return 'GET' }
    createResponse() { return new LanguagesResponse() }
}
export class Regions extends PagedRequest {
    /** @param {{id?:string,limit?:number,page?:number,find?:string,sortBy?:string,sortDesc?:boolean}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
    /** @type {string} */
    id;
    getTypeName() { return 'Regions' }
    getMethod() { return 'GET' }
    createResponse() { return new RegionsResponse() }
}
