import { Component,OnInit } from '@angular/core';
import {DataserviceService} from './service/dataservice.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Group Data';
  dtOptions: DataTables.Settings = {};
  ExploreData:any;

  constructor(private _dataservice:DataserviceService,private toastr: ToastrService) { }

  ngOnInit(): void {

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      processing: true
    };

    this.GetGroup();
  }

  //Get Group
  GetGroup(){
    this.title = "Group Data";
    this._dataservice.GetGroup().subscribe((response: any) => {
      this.ExploreData = response.Data;
      console.log("success" , this.ExploreData);
    });
  }

  //Import Group Data
  PostGroup(){
    this._dataservice.PostGroup().subscribe((response: any) => {
      if(response.Success == true) {
        this.toastr.success('Group Data Imported Successfully!', 'Success');
        this.GetGroup();
      }
      else {
        this.toastr.error('Something went wrong!', 'Error');
      }
    });
  }

  //Get Package
  GetPackage(){
    this.title = "Package Data";
    this._dataservice.GetPackage().subscribe((response: any) => {
      this.ExploreData = response.Data;
      console.log("success" , this.ExploreData);
    });
  }

  //Import Package Data
  PostPackage(){
    this._dataservice.PostPackage().subscribe((response: any) => {
      if(response.Success == true) {
        this.toastr.success('Package Data Imported Successfully!', 'Success');
        this.GetPackage();
      }
      else {
        this.toastr.error('Something went wrong!', 'Error');
      }
    });
  }

  //Get Tag
  GetTag(){
    this.title = "Tag Data";
    this._dataservice.GetTag().subscribe((response: any) => {
      this.ExploreData = response.Data;
      console.log("success" , this.ExploreData);
    });
  }

  //Import Tag Data
  PostTag(){
    this._dataservice.PostTag().subscribe((response: any) => {
      if(response.Success == true) {
        this.toastr.success('Tag Data Imported Successfully!', 'Success');
        this.GetTag();
      }
      else {
        this.toastr.error('Something went wrong!', 'Error');
      }
    });
  }

}
