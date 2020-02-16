import React, { Fragment } from 'react'
import { Media } from 'reactstrap'
import { Link } from 'react-router-dom'

export default ({ item }) => (
  <Fragment>
    <Media className="my-3">
      <Media left className="mr-3">
        <Media object src={item.artworkUrl100} alt={item.trackName} />
      </Media>
      <Media body>
        <Media heading>
          <Link to={`/tracks/${item.trackId}`}>{item.trackName}</Link>
        </Media>
        {item.artistName}
      </Media>
    </Media>
  </Fragment>
)
