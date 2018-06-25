import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Component } from 'react';
import { Note } from './Note';
import { NoteForm } from './NoteForm';

interface IToDoList {
    notes: any[];
}

interface INoteItem {
    id: number;
    noteContent: string;
    isCompleted: boolean;
}

export class ToDoList extends Component<RouteComponentProps<{}>, IToDoList> {
    constructor(props: any) {
        super(props);
        this.state = {
            notes: []
        }
        fetch('api/getnotes')
            .then(response => response.json() as Promise<INoteItem[]>)
            .then(data => {
                //console.log(data);
                this.setState({ notes: data });
            });
        this.addNote = this.addNote.bind(this);
        this.handleCompleted = this.handleCompleted.bind(this);
    };

    addNote(note: INoteItem) {
        const prevNotes = this.state.notes;
        prevNotes.push({ noteID: this.state.notes.length + 1, noteContent: note });
        this.setState({
            notes: prevNotes
        })
        fetch('api/getnotes', {
            method: 'POST',
            headers: {
                'Accept': 'application/json, text/plain',
                'Content-type': 'application/json'
            },
            body: JSON.stringify({ noteID: prevNotes.length, noteContent: note, isCompleted: false })
        })
            .then((res) => res.json)
            .then((data) => console.log(data));
    }

    handleCompleted(id: number) {
        const prevNotes = this.state.notes;
        for (let i in prevNotes) {
            if (prevNotes[i].id === id) {
                prevNotes[i].isCompleted = !(prevNotes[i].isCompleted);
                break;
            }
        }
        this.setState({
            notes: prevNotes
        })
        fetch('api/getnotes/' + id, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json, text/plain',
                'Content-type': 'application/json'
            },

        })
            .then((res) => res.json)
            .then((data) => console.log(data));
    }

    //this.state.notes.push(note);

    public render() {
        return (
            <div className="wrapper">
                <div className="header">
                    <div className="heading">ToDoList</div>
                </div>
                <div className="notesForm" style={{ textAlign: 'center' }}>
                    <NoteForm addNote={this.addNote} />
                </div>
                <div className="notesBody">
                    {
                        this.state.notes.map((note) => {
                            return (
                                <Note id={note.id}
                                    noteContent={note.noteContent}
                                    isCompleted={note.isCompleted}
                                    handleCompleted={this.handleCompleted}
                                    key={note.noteID} />
                            );
                        })
                    }
                </div>
            </div>

        );
    }
}