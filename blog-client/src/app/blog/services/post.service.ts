import { Injectable } from '@angular/core';
import { BaseService } from '../../shared/base.service';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { PostParameters } from '../models/post-parameters';
import { PostAdd } from '../models/post-add';
import { Post } from '../models/post';
import { Observable } from 'rxjs';
import { Operation } from 'fast-json-patch';

@Injectable({
  providedIn: 'root'
})
export class PostService extends BaseService {

  constructor(private http: HttpClient) {
    super();
   }

  getPagedPosts(postParameter?:any | PostParameters){
    return this.http.get(`${this.apiUrlBase}/posts`,{
      headers: new HttpHeaders({
        'Accept':'application/vnd.awind.hateoas+json'
      }),
      observe:'response',
      params:postParameter
    })
  }

  getPostById(id:number | string): Observable<Post>{
    return this.http.get<Post>(`${this.apiUrlBase}/posts/${id}`);
  }

  addPost(post: PostAdd){
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':'application/vnd.awind.create+json',
        'Accept':'application/vnd.awind.hateoas+json'
      })
    };
    return this.http.post<Post>(`${this.apiUrlBase}/posts`, post, httpOptions);
  }

  partiallyUpdatePost(id: number | string, patchDocument: Operation[]): Observable<any> {
    return this.http.patch(`${this.apiUrlBase}/posts/${id}`, patchDocument,
      {
        headers: { 'Content-Type': 'application/json-patch+json' }
      });
  }
}
