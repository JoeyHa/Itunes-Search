import React, { Fragment } from 'react'
import { Media } from 'reactstrap'


export default ({ Topitem }) => (
    <Fragment>
      <Media className="my-3">
        <Media body>
          <Media heading>
          </Media>
          <h2>"{Topitem.SearchValue}"</h2>
        </Media>
      </Media>
    </Fragment>
  )
  