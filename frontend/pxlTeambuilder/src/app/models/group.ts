import { User } from './user';

export class Group{
    
    private id : string;
    private name : string;
    private projectId : string;
    private teammembers : User[]


    constructor(){}

    public get Id(){
        return this.id;
    }

    public get Name(){
        return this.name;
    }

    public get ProjectId(){
        return this.projectId;
    }

    public get TeamMembers(){
        return this.teammembers;
    }

    public set Id(id : string){
        this.id = id;
    }

    public set Name(name : string){
        this.name = name;
    }

    public set ProjectId(projectId : string){
        this.projectId = projectId;
    }

    public set TeamMembers(teammembers : User[]){
        this.teammembers = teammembers;
    }
}