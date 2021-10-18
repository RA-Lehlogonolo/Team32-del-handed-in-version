"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __spreadArrays = (this && this.__spreadArrays) || function () {
    for (var s = 0, i = 0, il = arguments.length; i < il; i++) s += arguments[i].length;
    for (var r = Array(s), k = 0, i = 0; i < il; i++)
        for (var a = arguments[i], j = 0, jl = a.length; j < jl; j++, k++)
            r[k] = a[j];
    return r;
};
exports.__esModule = true;
exports.AnnouncementsComponent = void 0;
var core_1 = require("@angular/core");
var http_1 = require("@angular/common/http");
var forms_1 = require("@angular/forms");
var AnnouncementsComponent = /** @class */ (function () {
    function AnnouncementsComponent(fb, _nzNotificationService, _authService, _announcementService, _userServiceManagementService) {
        this.fb = fb;
        this._nzNotificationService = _nzNotificationService;
        this._authService = _authService;
        this._announcementService = _announcementService;
        this._userServiceManagementService = _userServiceManagementService;
        this.tableDataReady = false;
        this.listOfData = [];
        this.listOfDisplayData = [];
        this.listOfAnnouncementTypes = [];
        //Search Operations
        this.searchValue = '';
        this.visible = false;
        this.getUserDetails();
        this.getAllRecords();
    }
    AnnouncementsComponent.prototype.reset = function () {
        this.searchValue = '';
        this.search();
    };
    AnnouncementsComponent.prototype.search = function () {
        var _this = this;
        this.visible = false;
        this.listOfDisplayData = this.listOfData.filter(function (item) { return item.announcementtype.indexOf(_this.searchValue) !== -1; });
    };
    AnnouncementsComponent.prototype.ngOnInit = function () {
        this.buildAddForm();
        this.buildUpdateFormWithEmptyFields();
    };
    //Add Operations
    AnnouncementsComponent.prototype.onShowAddModal = function () {
        this.isAddModalVisible = true;
    };
    AnnouncementsComponent.prototype.onCancelAdd = function () {
        this.isAddModalVisible = false;
    };
    AnnouncementsComponent.prototype.buildAddForm = function () {
        this.addForm = this.fb.group({
            Description: ['', [forms_1.Validators.required]],
            AnnouncementTypeId: ['', [forms_1.Validators.required]],
            ResidenceId: ['', [forms_1.Validators.required]],
            Date: ['', [forms_1.Validators.required]]
        });
    };
    AnnouncementsComponent.prototype.onAddSubmit = function () {
        var _this = this;
        if (this.addForm.valid) {
            this._announcementService.addAnnouncement(this.addForm.value, this.loggedInUser.UserName)
                .subscribe(function (event) {
                if (event.type === http_1.HttpEventType.Sent) {
                    _this.tableDataReady = false;
                }
                if (event.type === http_1.HttpEventType.Response) {
                    _this.getAllRecords();
                    _this.onCancelAdd();
                    _this.tableDataReady = true;
                    _this._nzNotificationService.success("Add Success", "New Announcement Added");
                }
            }, function (error) {
                _this.tableDataReady = true;
                _this._nzNotificationService.error('Add Announcement Error', error.error.message);
            });
        }
    };
    //Update Operations
    AnnouncementsComponent.prototype.onShowUpdateModal = function (element) {
        this.buildUpdateForm(element);
        this.isUpdateModalVisisble = true;
    };
    AnnouncementsComponent.prototype.onCancelUpdate = function () {
        this.isUpdateModalVisisble = false;
    };
    AnnouncementsComponent.prototype.buildUpdateFormWithEmptyFields = function () {
        this.updateForm = this.fb.group({
            /* Name: ['', [Validators.required]],*/
            Description: ['', [forms_1.Validators.required]],
            Id: ['']
        });
    };
    AnnouncementsComponent.prototype.buildUpdateForm = function (role) {
        this.updateForm = this.fb.group({
            /* Name: [role.name, [Validators.required]],*/
            Id: [role.id]
        });
    };
    AnnouncementsComponent.prototype.onUpdateSubmit = function () {
        var _this = this;
        if (this.updateForm.valid) {
            var updateId = this.updateForm.get('Id').value;
            this._announcementService.updateAnnouncement(this.updateForm.value, this.loggedInUser.UserName, updateId)
                .subscribe(function (event) {
                if (event.type === http_1.HttpEventType.Sent) {
                    _this.tableDataReady = false;
                }
                if (event.type === http_1.HttpEventType.Response) {
                    _this.getAllRecords();
                    _this.onCancelUpdate();
                    _this.tableDataReady = true;
                    _this._nzNotificationService.success("Update Success", "Announcement Updated");
                }
            }, function (error) {
                _this.tableDataReady = true;
                _this._nzNotificationService.error('Update Announcement Error', error.error.message);
            });
        }
    };
    //Delete Oprations
    AnnouncementsComponent.prototype.onShowDeleteModal = function (item) {
        this.isDeleteModalVisible = true;
        this.itemToDelete = item;
    };
    AnnouncementsComponent.prototype.onDeleteSubmit = function () {
        var _this = this;
        this.isDeleteModalVisible = false;
        if (this.itemToDelete != null) {
            this._announcementService.deleteAnnouncement(this.loggedInUser.UserName, this.itemToDelete.id)
                .subscribe(function (event) {
                if (event.type === http_1.HttpEventType.Sent) {
                    _this.tableDataReady = false;
                }
                if (event.type === http_1.HttpEventType.Response) {
                    _this.getAllRecords();
                    _this._nzNotificationService.success('Delete Sucess', "Delete Record");
                    _this.tableDataReady = true;
                }
            }, function (error) {
                _this.tableDataReady = true;
                _this._nzNotificationService.error('Delete Error', error.error.message);
            });
        }
    };
    AnnouncementsComponent.prototype.onCalcenDelete = function () {
        this.isDeleteModalVisible = false;
    };
    //Get & Helper Operations
    AnnouncementsComponent.prototype.getAllRecords = function () {
        var _this = this;
        this._announcementService.getAllAnnouncements()
            .subscribe(function (event) {
            if (event.type === http_1.HttpEventType.Sent) {
                _this.tableDataReady = false;
            }
            if (event.type === http_1.HttpEventType.Response) {
                _this.getAllLookupsFromServer();
                _this.listOfData = event.body;
                _this.listOfDisplayData = __spreadArrays(_this.listOfData);
                _this.tableDataReady = true;
            }
        }, function (error) {
            _this.tableDataReady = true;
            _this._nzNotificationService.error('Get Records Error', error.error.message);
        });
    };
    AnnouncementsComponent.prototype.getUserDetails = function () {
        this.loggedInUser = this._authService.currentUser;
    };
    AnnouncementsComponent.prototype.getAllAnnouncementTypes = function () {
        var _this = this;
        this._announcementService.getAllAnnouncementTypes()
            .subscribe(function (event) {
            if (event.type === http_1.HttpEventType.Sent) {
                _this.tableDataReady = false;
            }
            if (event.type === http_1.HttpEventType.Response) {
                _this.listOfAnnouncementTypes = event.body;
                _this.tableDataReady = true;
            }
        }, function (error) {
            _this.tableDataReady = true;
            _this._nzNotificationService.error('Get Announcement Type Error', error.error.message);
        });
    };
    AnnouncementsComponent.prototype.getAllLookupsFromServer = function () {
        this.getAllAnnouncementTypes();
    };
    AnnouncementsComponent = __decorate([
        core_1.Component({
            selector: 'app-announcements',
            templateUrl: './announcements.component.html',
            styleUrls: ['./announcements.component.css']
        })
    ], AnnouncementsComponent);
    return AnnouncementsComponent;
}());
exports.AnnouncementsComponent = AnnouncementsComponent;
