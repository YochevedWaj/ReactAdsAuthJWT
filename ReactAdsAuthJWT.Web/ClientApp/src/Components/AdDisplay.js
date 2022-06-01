import React from 'react';
import format from 'date-fns/format';

const AdDisplay = ({ ad: { date, number, description }, onDeleteClick, canDelete, userName }) => {
    return (
        <div className="jumbotron">
            {userName && <h5>Listed by {userName}</h5>}
            <h5>Listed on {format(new Date(date), 'EEEE LLLL do, R')}</h5>
            <h5>Phone Number: {number}</h5>
            <h3>Details:</h3>
            <p>{description}</p>
            {canDelete && <button onClick={onDeleteClick} className="btn btn-danger">Delete</button>}
        </div>
    )
}
export default AdDisplay;