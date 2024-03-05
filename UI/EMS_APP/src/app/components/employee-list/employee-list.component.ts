import { Component, OnInit } from '@angular/core';
import { EmployeeApiService } from './employee-api.service';
import {
  IDeleteEmployee_Response,
  IEmployeeList,
  IEmployeeList_Response,
} from 'src/app/Interfaces/Employee_Models';
import { ToastrService } from 'ngx-toastr';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddEditEmployeeComponent } from '../add-edit-employee/add-edit-employee.component';
import { debounceTime, map } from 'rxjs';
import { ISortParams } from 'src/app/Interfaces/shared_Models';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss'],
})
export class EmployeeListComponent implements OnInit {
  public employeeList: IEmployeeList[] = [];
  public orderBy: string = 'Name';
  public sortDir: string = 'asc';
  public searchKeyword: string = '';
  constructor(
    private employeApiService: EmployeeApiService,
    private toastr: ToastrService,
    private ngbModal: NgbModal
  ) {
    this.getEmployeeList();
  }

  ngOnInit(): void {}

  /**
   * This function will be called to get all the employe list to show in the table
   */
  private getEmployeeList() {
    let requestPayload: ISortParams = {
      OrderBy: this.orderBy,
      SearchKeyword: this.searchKeyword,
      SortDir: this.sortDir,
    };
    this.employeApiService
      .GetEmployeeList(requestPayload)
      .pipe(
        map((res: IEmployeeList_Response) => {
          res.employees.forEach((emp) => {
            emp.createdDate = new Date(emp.createdDate).toLocaleString();
            if (emp.updatedDate) {
              emp.updatedDate = new Date(emp.updatedDate).toLocaleString();
            }
          });
          return res;
        })
      )
      .subscribe((res: IEmployeeList_Response) => {
        this.employeeList = res.employees;
        if (res.isSuccess) {
        } else if (res.isError) {
          this.toastr.error(res.message);
        } else if (res.isInformation) {
          this.toastr.info(res.message);
        }
      });
  }

  /**
   * This function will be called upon add employee button clcik
   */
  public onAddEmployeeClick() {
    let AddEditModel = this.ngbModal.open(AddEditEmployeeComponent);
    AddEditModel.result.then((res) => {
      this.getEmployeeList();
    });
  }

  /**
   * This function will be called to open AddEditEmployeeComponent in order to update record
   */
  public onUpdateRecord(id: number) {
    let AddEditModel = this.ngbModal.open(AddEditEmployeeComponent);
    AddEditModel.componentInstance.isFromUpdate = true;
    AddEditModel.componentInstance.employeeId = id;

    AddEditModel.result.then((res) => {
      this.getEmployeeList();
    });
  }

  /**
   * This function will be called to delete employee
   */
  public onDeleteButtonClick(id: number) {
    if (
      confirm(
        'This action can not be undone. are you sure you want to delete this record?'
      )
    ) {
      this.employeApiService
        .DeleteEmployee(id)
        .subscribe((res: IDeleteEmployee_Response) => {
          if (res.isSuccess) {
            this.toastr.success(res.message);
            this.getEmployeeList();
          } else if (res.isInformation) {
            this.toastr.info(res.message);
          } else if (res.isError) {
            this.toastr.error(res.message);
          } else if (res.isWarning) {
            this.toastr.warning(res.message);
          }
        });
    }
  }

  public onSorting(orderBy: string) {
    if (this.orderBy == orderBy && this.sortDir == 'asc') {
      this.sortDir = 'desc';
    } else {
      this.sortDir = 'asc';
    }
    this.orderBy = orderBy;
    this.getEmployeeList();
  }


  /**
   * This function will be called on search icon click
   */
  public onSearchClick(){
    this.getEmployeeList();
  }
}
