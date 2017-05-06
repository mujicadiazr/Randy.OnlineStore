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
var CategoryComponent = (function () {
    function CategoryComponent() {
        this.CategoryID = '1';
        this.CategoryName = 'Beverages';
    }
    CategoryComponent = __decorate([
        core_1.Component({
            selector: "category",
            templateUrl: "\n      <h1><strong>ID:</strong> {{CategoryID}}</h1><h1> <strong>Category:</strong> {{CategoryName}}</h1>\n      <p><strong>Description:</strong> {{Description}}</p>\n      <p><strong>Picture:</strong> {{Picture}}</p>      \n    ",
        }), 
        __metadata('design:paramtypes', [])
    ], CategoryComponent);
    return CategoryComponent;
}());
exports.CategoryComponent = CategoryComponent;
;
//# sourceMappingURL=app.category.component.js.map