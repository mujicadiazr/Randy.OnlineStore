"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var category_service_1 = require("../services/category.service");
var CategoryComponent = (function () {
    function CategoryComponent(categoryService) {
        this.categoryService = categoryService;
        this.categoryID = '1';
        this.categoryName = 'Beverages';
        this.description = 'Soft drinks, coffees, teas, beers, and ales';
        this.picture = {
            hexcode: '0x151C2F00020000000D000E0014002100FFFFFFFF4269746D617020496D616765005061696E742E5069637475726500010500000200000007000000504272757368000000000000000000A0290000424D98290000000000005600000028000000AC00000078000000010004000000000000000000880B0000880B000008000000'
        };
        this.comments = ['I love Lager beer', 'My grandma like teas'];
        this.categoryService.getCategories().subscribe(function (categories) {
            console.log(categories);
        });
    }
    CategoryComponent.prototype.toggleDescription = function () {
        if (this.showDescription) {
            this.showDescription = false;
        }
        else {
            this.showDescription = true;
        }
    };
    CategoryComponent.prototype.addComment = function (comment) {
        this.comments.push(comment);
    };
    CategoryComponent.prototype.deleteComment = function (i) {
        this.comments.splice(i, 1);
    };
    CategoryComponent.prototype.getSrc = function (str) {
        return 'data:image/gif;base64,' + this.hexToBase64(this.picture.hexcode);
    };
    CategoryComponent.prototype.hexToBase64 = function (hexstring) {
        return btoa(hexstring.match(/\w{2}/g).map(function (a) {
            return String.fromCharCode(parseInt(a, 16));
        }).join(""));
    };
    CategoryComponent = __decorate([
        core_1.Component({
            selector: "category",
            template: "\n      <h1>{{categoryName}}</h1>\n      <p><strong>ID:</strong> {{categoryID}}</p>\n      <button class=\"btn btn-primary\" (click)=\"toggleDescription()\">{{showDescription ? \"Hide discription\" : \"Show description\"}}</button>\n      <div *ngIf=\"showDescription\">\n            <p><strong>Description:</strong> {{description}}</p>\n      </div>\n      <h3>Comments</h3>\n      <ul>\n         <li *ngFor=\"let comment of comments; let i = index\">\n            {{comment}}<button (click)=\"deleteComment(i)\">X</button>\n         </li>  \n      </ul>\n      <form (submit)=\"addComment(comment.value)\" >\n        <label>Add comment: </label>\n        <input type=\"text\" #comment />\n        <input type=\"submit\" value=\"Add\" class=\"btn btn-primary\">      \n      </form>\n  \n      <hr/>\n      <h3>Edit Category</h3>\n      <form>  \n        <label>Category name: </label>\n        <input type=\"text\" name=\"categoryName\" [(ngModel)]=\"categoryName\" />\n        <br/>  \n        <label>Description: </label>\n        <input type=\"text\" name=\"description\" [(ngModel)]=\"description\" />\n        <br/>\n      </form>             \n    ",
            providers: [category_service_1.CategoryService]
        }), 
        __metadata('design:paramtypes', [category_service_1.CategoryService])
    ], CategoryComponent);
    return CategoryComponent;
}());
exports.CategoryComponent = CategoryComponent;
//# sourceMappingURL=category.component.js.map