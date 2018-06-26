import * as React from 'react';
import { Component, Props } from 'react';
import { RouteComponentProps } from 'react-router';

interface INoteForm {
    newNoteContent: string;
}

export class NoteForm extends Component<any, INoteForm> {

    constructor(props: any) {
        super(props);
        this.state = { newNoteContent: "" };
        this.handleInput = this.handleInput.bind(this);
        this.writeNote = this.writeNote.bind(this);
    }

    public render() {
        return (
            <div className="formWrapper">
                <input id="ip" className="noteInput"
                    type="text"
                    onChange={this.handleInput}
                    value={this.props.newNoteContent}
                    placeholder="Your task for today?" />
                <button className="noteButton"
                    type="button"
                    onClick={this.writeNote}>
                    Add Note
                </button>
            </div>
        );
    }

    handleInput(e: any) {
        //console.log(e);
        this.setState({
            newNoteContent: e.target.value,
        })
    }

    writeNote() {
        //console.log(this.state.newNoteContent);
        this.props.addNote(this.state.newNoteContent);
        this.setState({
            newNoteContent: "",
        })
    }
}

