import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Component } from 'react';

interface INote {
    id: number;
    noteContent: string;
    isCompleted: boolean;
}

export class Note extends Component<any, INote> {
    constructor(props: INote) {
        super(props);
        this.state = { id: props.id, noteContent: props.noteContent, isCompleted: props.isCompleted };
        this.taskComplete = this.taskComplete.bind(this);
    };
    
    public render() {
        const colour = this.state.isCompleted ? '#02BA85' : '#AA9';
        return (<div className="note fade-in">
            <span style={{ paddingTop: '27px' }}
                aria-hidden="true">
                <i style={{ color: colour }} onClick={this.taskComplete} className="closebtn fas fa-check-circle"></i>
            </span>
            <p style={{ paddingTop: '20px' }}
                className="noteContent">
                {this.props.noteContent}
            </p>
        </div>);
    }

    taskComplete(e: any) {
        //console.log(e, this.state, this.props);
        var node = document.querySelector(".noteButton");

        if (this.state.isCompleted) {
            e.target.style.color = '#02BA85';
        }
        else {
            e.target.style.color = '#AA9';
        }
        this.props.handleCompleted(this.state.id);
        this.setState({
            isCompleted: !this.state.isCompleted
        })
        
    }
    
}